using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Utils;



namespace Binary.Endscript
{
    public static partial class Core
    {
		#region End File Management

		private static string EndFileDir { get; set; }

        public static void CreateEndscriptFile(string filename)
        {
            EndFileDir = filename;
            try
            {
                bool NewFileMake = !File.Exists(EndFileDir);
                FileStream ModStream;
                StreamWriter ModFile;

                if (Properties.Settings.Default.EnableStaticEnd || NewFileMake)
                {
                    ModStream = File.Open(EndFileDir, FileMode.Create);
                    ModFile = new StreamWriter(ModStream);

                    ModFile.WriteLine("// Binary Endscript File");
                    ModFile.WriteLine("// File created on: " + DateTime.Now.ToString());
                    ModFile.WriteLine("// ------------------------------------------------------------------------------");

                    ModFile.Close();
                    ModFile.Dispose();
                    ModStream.Dispose();
                }
                else
                {
                    ModStream = File.Open(EndFileDir, FileMode.Append, FileAccess.Write);
                    ModFile = new StreamWriter(ModStream);

                    ModFile.WriteLine("");
                    ModFile.WriteLine("");
                    ModFile.WriteLine("");
                    ModFile.WriteLine("// ------------------------------------------------------------------------------");
                    ModFile.WriteLine("// File continued on: " + DateTime.Now.ToString());
                    ModFile.WriteLine("// ------------------------------------------------------------------------------");

                    ModFile.Close();
                    ModFile.Dispose();
                    ModStream.Dispose();
                }
            }
            catch (Exception) { }
        }

        public static void WriteEndscriptLine(string line)
        {
            if (!File.Exists(EndFileDir))
                Properties.Settings.Default.EnableEndscriptLog = false;
            if (Properties.Settings.Default.EnableEndscriptLog)
            {
                try
                {
                    FileStream ModStream;
                    StreamWriter ModWriter;

                    ModStream = File.Open(EndFileDir, FileMode.Append, FileAccess.Write);
                    ModWriter = new StreamWriter(ModStream);
                    ModWriter.WriteLine(line);
                    ModWriter.Close();
                    ModWriter.Dispose();
                    ModStream.Dispose();
                }
                catch (Exception)
                {
                    Properties.Settings.Default.EnableEndscriptLog = false;
                }
            }
        }

		#endregion

		#region Endscript Loading

		private static IEnumerable<EndLine> LoadEndscriptFile(string dir, string filename, string thisfile = null, int index = 0)
        {
            string filepath = Path.Combine(dir, filename);
            if (!File.Exists(filepath) || Path.GetExtension(filepath) != ".end")
                throw new FileNotFoundException($"Unable to find endscript {filepath}; " +
                    $"Endscript {thisfile}, line {index}");

            var lines = File.ReadAllLines(filepath);
            for (int loop = 0; loop < lines.Length; ++loop)
            {
                string line = lines[loop];
                if (string.IsNullOrWhiteSpace(line)) continue;
                else if (line.StartsWith("//")) continue;
                else if (line.StartsWith(Commands.attach.ToString()))
                {
                    int a1 = line.LastIndexOf(' ') + 1;
                    var subfile = line.Substring(a1, line.Length - a1);
                    var attachedlines = LoadEndscriptFile(Path.GetDirectoryName(filepath), subfile, filepath, loop);
                    foreach (var attachedline in attachedlines)
                        yield return attachedline;
                }
                else
                {
                    var endline = new EndLine()
                    {
                        Index = loop + 1,
                        Text = line,
                        Filename = filepath,
                    };
                    yield return endline;
                }
            }
        }

        private static bool ProceedSafeLoading(string filepath, out List<EndLine> lines)
        {
            lines = null;
            try
            {
                // Considering path is valid
                lines = LoadEndscriptFile(Path.GetDirectoryName(filepath), Path.GetFileName(filepath)).ToList();
                return true;
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ProcessEndscript(string filepath, BasicBase db, out string label)
        {
            label = null;
            if (!ProceedSafeLoading(filepath, out var EndLines)) return false;

            var MenuEndLines = new List<string>();
            int begin = -1;
            int end = -1;

            for (int loop = 0; loop < EndLines.Count; ++loop)
            {
                // If encountered <menu> tag, begin accumulating EndMenu lines
                if (EndLines[loop].Text == "<menu>") { begin = loop; continue; }
                // If encountered </menu> tag, stop accumulating EndMenu lines
                else if (EndLines[loop].Text == "</menu>") { end = loop; continue; }
                // If accumulating, append and continue
                else if (begin != -1 && end == -1) { MenuEndLines.Add(EndLines[loop].Text); }
                else EndLines[loop].Text = ScriptX.CleanString(EndLines[loop].Text, true);
            }

            if (begin != -1 && end != -1)
                EndLines.RemoveRange(begin, end - begin + 1);

            int total_line_count = EndLines.Count;
            var ErrorEndLines = new List<EndLine>();

            var window = new Interact.EndMenu(MenuEndLines.ToArray(), Path.GetDirectoryName(filepath));
            if (window.ShowDialog() == DialogResult.OK)
            {
                var watch = new System.Diagnostics.Stopwatch();
                watch.Start();

                foreach (var endline in EndLines)
                {
                    endline.Error = ExecuteEndscriptLine(endline.Text, db);
                    if (endline.Error != null) ErrorEndLines.Add(endline);
                }



                watch.Stop();
                label = $"Processed {total_line_count} lines of script in {watch.ElapsedMilliseconds}ms";
                return true;
            }
            else return false;
        }

		#endregion

		#region Processing

		public static string ExecuteEndscriptLine(string line, BasicBase db)
        {
            string error = "Incorrect amount of passed script parameters.";
            var words = DisperseLine(line, new char[] { ' ', '\t', '\n'});
            if (!Enum.TryParse(words[0], out Commands command))
                return $"Unrecognized command {words[0]}; unable to process.";

            int len = words.Length;

            switch (command)
            {
                case Commands.update:
                    if (len == 5) return ExecuteUpdateCollection(db, words[1], words[2],
                        words[3], words[4]);
                    else if (len == 7) return ExecuteUpdateSubNode(db, words[1], words[2],
                        words[3], words[4], words[5], words[6]);
                    else goto default;

                case Commands.add:
                    if (len == 3) return ExecuteAddCollection(db, words[1], words[2]);
                    else goto default;

                case Commands.delete:
                    if (len == 3) return ExecuteDeleteCollection(db, words[1], words[2]);
                    else goto default;

                case Commands.copy:
                    if (len == 4) return ExecuteCopyCollection(db, words[1], words[2], words[3]);
                    else goto default;

                case Commands.@static:
                    if (!Properties.Settings.Default.EnableStaticEnd)
                        return "Static command execution is not enabled. Unable to process.";
                    if (len == 4) return ExecuteStaticCollection(db, words[1], words[2], words[3]);
                    else goto default;

                default:
                    return error;
            }
        }

        public static bool RefreshFullTree(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;
            char[] delim = new char[] { ' ', '\t', '\0' };
            var words = line.Split(delim, StringSplitOptions.RemoveEmptyEntries);
            Enum.TryParse(words[0], out Commands command);
            var parent = words[1];
            switch (command)
            {
                case Commands.update:
                    if (line.Contains("CollectionName"))
                        return true;
                    return false;

                default:
                    return true;
            }
        }

        private static string[] DisperseLine(string line, params char[] delim)
        {
            var result = new List<string>();
            string str = null;
            bool inquote = false;
            line += '\0'.ToString();

            foreach (var val in line)
            {
                if (val == '\0') result.Add(str);
                else if (val == '"') inquote = !inquote;
                else if (!inquote && delim.Contains(val))
                {
                    if (!string.IsNullOrEmpty(str))
                        result.Add(str);
                    str = null;
                    continue;
                }
                else str += val.ToString();
            }
            return result.ToArray();
        }

		#endregion

		#region Update Command

		private static string ExecuteUpdateCollection(BasicBase db, string root, string node,
            string field, string value)
        {
            string error = null;
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (collection.SetValue(field, value, ref error)) return null;
            else return error;
        }

        private static string ExecuteUpdateSubNode(BasicBase db, string root, string node,
            string subroute, string subnode, string field, string value)
        {
            string error = null;
            var collection = db.GetPrimitive(root, node, subroute, subnode);
            if (collection == null)
                return $"SubNode {subnode} does not exist in collection {node} in root {root}.";
            if (collection.SetValue(field, value, ref error)) return null;
            else return error;
        }

		#endregion

		#region Add Command

        private static string ExecuteAddCollection(BasicBase db, string root, string node)
        {
            if (db.TryAddCollection(node, root, out var error)) return null;
            else return error;
        }

		#endregion

		#region Delete Command

        private static string ExecuteDeleteCollection(BasicBase db, string root, string node)
        {
            if (db.TryRemoveCollection(node, root, out var error)) return null;
            else return error;
        }

		#endregion

		#region Copy Command

        private static string ExecuteCopyCollection(BasicBase db, string root,
            string copyfrom, string newname)
        {
            if (db.TryCloneCollection(newname, copyfrom, root, out var error)) return null;
            else return error;
        }

		#endregion

		#region Static Command

        private static string ExecuteStaticCollection(BasicBase db, string root,
            string field, string value)
        {
            if (db.TrySetStaticValue(root, field, value, out var error)) return null;
            else return error;
        }

		#endregion
	}
}