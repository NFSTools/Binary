/********************************************************************************
 * MIT License
 * 
 * Copyright (c) 2020 MaxHwoy & NFS Tools
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE. 
********************************************************************************/



using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binary.Properties;
using GlobalLib.Utils;
using GlobalLib.Utils.EA;
using GlobalLib.Reflection.Enum;
using GlobalLib.Reflection.Abstract;
using GlobalLib.Support.Shared.Class;
using GlobalLib.Support.Shared.Parts.FNGParts;



namespace Binary.Endscript
{
    public static partial class Core
    {
        #region Constants

        private const string absolute = "absolute";
        private const string relative = "relative";
        private const string file = "file";
        private const string folder = "folder";
        private const string FNGroups = "FNGroups";
        private const string TPKBlocks = "TPKBlocks";
        private const string STRBlocks = "STRBlocks";
        private static Stopwatch watch = new Stopwatch();

        #endregion

        #region End File Management

        private static string GlobalDir { get; set; } = string.Empty;

        private static string EndFileDir { get; set; } = string.Empty;

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

		private static IEnumerable<EndLine> LoadEndscriptFile(string dir, string filename,
            string thisfile = null, int index = 0)
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
                else if (line.StartsWith(eCommands.attach.ToString()))
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

        public static bool ProcessEndscript(string dir, string filepath, BasicBase db,
            out string label, out string text)
        {
            label = null;
            text = string.Empty;
            GlobalDir = dir;
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
                string filedir = Path.GetDirectoryName(filepath);

                watch.Reset();
                watch.Start();
                foreach (var endline in EndLines)
                {
                    endline.Error = ExecuteEndscriptLine(endline.Text, db, filedir);
                    if (endline.Error != null) ErrorEndLines.Add(endline);
                }
                watch.Stop();

                if (ErrorEndLines.Count > 0)
                {
                    var errorwindow = new Interact.ErrorView(ErrorEndLines);
                    errorwindow.ShowDialog();

                }

                var build = new StringBuilder(EndLines.Count * 100);
                foreach (var endline in EndLines)
                    build.Append(endline.Text + Environment.NewLine);

                text = build.ToString();
                label = $"Processed {total_line_count} lines of script in {watch.ElapsedMilliseconds}ms";
                GlobalDir = string.Empty;
                return true;
            }
            else
            {
                GlobalDir = string.Empty;
                return false;
            }
        }

        #endregion

        #region Processing

        public static string ExecuteEndscriptLine(string line, BasicBase db, string filedir = "")
        {
            string error = "Incorrect amount of passed script parameters.";
            var words = DisperseLine(line, new char[] { ' ', '\t', '\n'});
            if (!Enum.TryParse(words[0], out eCommands command))
                return $"Unrecognized command {words[0]}; unable to process.";

            int len = words.Length;

            switch (command)
            {
                case eCommands.update:
                    if (len == 5) return ExecuteUpdateCollection(db, words[1], words[2],
                        words[3], words[4]);
                    else if (len == 6) return ExecuteUpdateTPKSTR(db, words[1], words[2],
                        words[3], words[4], words[5]);
                    else if (len == 7) return ExecuteUpdateSubNode(db, words[1], words[2],
                        words[3], words[4], words[5], words[6]);
                    else goto default;

                case eCommands.add:
                    if (len == 3) return ExecuteAddCollection(db, words[1], words[2]);
                    else if (len == 4) return ExecuteAddTexture(db, words[1], words[2], 
                        Path.Combine(filedir, words[3]));
                    else if (len == 6) return ExecuteAddString(db, words[1], words[2],
                        words[3], words[4], words[5]);
                    else goto default;

                case eCommands.delete:
                    if (len == 3) return ExecuteDeleteCollection(db, words[1], words[2]);
                    else if (len == 4) return ExecuteDeleteTPKSTR(db, words[1], words[2], words[3]);
                    else goto default;

                case eCommands.copy:
                    if (len == 4) return ExecuteCopyCollection(db, words[1], words[2], words[3]);
                    else if (len == 5) return ExecuteCopyTexture(db, words[1], words[2],
                        words[3], words[4]);
                    else goto default;

                case eCommands.@static:
                    if (!Settings.Default.EnableStaticEnd)
                        return "Static command execution is not enabled. Unable to process.";
                    if (len == 4) return ExecuteStaticCollection(db, words[1], words[2], words[3]);
                    else goto default;

                case eCommands.replace:
                    if (len == 5) return ExecuteReplaceTexture(db, words[1], words[2],
                        words[3], Path.Combine(filedir, words[4]));
                    else goto default;

                case eCommands.import:
                    if (len == 3) return ExecuteImportCollection(db, words[1], 
                        Path.Combine(filedir, words[2]));
                    else goto default;

                case eCommands.move:
                    if (string.IsNullOrWhiteSpace(GlobalDir))
                        return "This command can be executed only through endscript.";
                    if (len == 5) return ExecuteMoveCommand(words[1], words[2], filedir,
                        words[3], words[4]);
                    else goto default;

                case eCommands.erase:
                    if (string.IsNullOrWhiteSpace(GlobalDir))
                        return "This command can be executed only through endscript.";
                    if (len == 4) return ExecuteEraseCommand(words[1], words[2], filedir, words[3]);
                    else goto default;

                case eCommands.create:
                    if (string.IsNullOrWhiteSpace(GlobalDir))
                        return "This command can be executed only through endscript.";
                    if (len == 4) return ExecuteCreateCommand(words[1], words[2], filedir, words[3]);
                    else goto default;

                case eCommands.attach:
                    return "This command can be executed only through endscript.";

                case eCommands.execute:
                    if (string.IsNullOrWhiteSpace(GlobalDir))
                        return "This command can be executed only through endscript.";
                    if (len == 2)
                    {
                        watch.Stop();
                        error = Linear.LaunchProcess(Path.Combine(filedir, words[1]), filedir);
                        watch.Start();
                        return error;
                    }
                    else goto default;

                case eCommands.@switch:
                    if (len == 3) return ExecuteSwitchSetting(words[1], words[2]);
                    else goto default;

                default:
                    return error;
            }
        }

        public static bool RefreshFullTree(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;
            var words = DisperseLine(line, ' ', '\t', '\n', '\r', '\0');
            Enum.TryParse(words[0], out eCommands command);
            var parent = words[1];
            switch (command)
            {
                case eCommands.update:
                case eCommands.@static:
                    if (line.Contains("CollectionName"))
                        return true;
                    return false;

                default:
                    return true;
            }
        }

        public static string[] DisperseLine(string line, params char[] delim)
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
            if (root == FNGroups) return ExecuteUpdateFNG(db, node, field, value);
            string error = null;
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (collection.SetValue(field, value, ref error)) return null;
            else return error;
        }

        private static string ExecuteUpdateFNG(BasicBase db, string node, string field, string value)
        {
            if (!db.TryGetCollection(node, FNGroups, out var collection))
                return $"Collection {node} does not exist in root {FNGroups}.";
            if (!(collection is FNGroup fng))
                return $"Collection {node} is not a {FNGroups} collection.";

            if (!SAT.CanBeColor(value))
                return $"Value {value} is not an 8-digit hexadecimal color-type.";

            var color = new FEngColor(null);
            color.Alpha = SAT.GetAlpha(value);
            color.Red = SAT.GetRed(value);
            color.Green = SAT.GetGreen(value);
            color.Blue = SAT.GetBlue(value);

            if (field.StartsWith("ReplaceSame"))
            {
                if (field.StartsWith("ReplaceSameNoAlpha[") && field.EndsWith("]"))
                {
                    if (FormatX.GetInt32(field, "ReplaceSameNoAlpha[{X}]", out int index))
                        fng.TrySetSame(index, color, true);
                    else
                        return $"Unable to get color index from field named {field}.";
                }
                else if (field.StartsWith("ReplaceSameWithAlpha[") && field.EndsWith("]"))
                {
                    if (FormatX.GetInt32(field, "ReplaceSameWithAlpha[{X}]", out int index))
                        fng.TrySetSame(index, color, false);
                    else
                        return $"Unable to get color index from field named {field}.";
                }
                else
                    return $"Incorrect passed parameter named {field}.";
            }
            else if (field == "ReplaceAllNoAlpha")
                fng.TrySetAll(color, true);
            else if (field == "ReplaceAllWithAlpha")
                fng.TrySetAll(color, false);
            else
            {
                int index = SAT.GetIndex(field);
                if (index >= fng.InfoLength || index == -1)
                    return $"Field named {field} does not exist.";
                fng.TrySetOne(index, color);
            }
            return null;
        }

        private static string ExecuteUpdateTPKSTR(BasicBase db, string root, string node,
            string hash, string field, string value)
        {
            switch (root)
            {
                case TPKBlocks:
                    if (!db.TryGetCollection(node, root, out var inter))
                        return $"Collection {node} cannot be found in root {root}.";
                    if (!(inter is TPKBlock tpk))
                        return $"Collection {node} is not a {STRBlocks} collection.";
                    var texture = tpk.FindTexture(ConvertX.ToUInt32(hash), eKeyType.BINKEY);
                    if (texture == null) return $"Texture with key {hash} does not exist in {node}";
                    string error = null;
                    texture.SetValue(field, value, ref error);
                    return error;

                case STRBlocks:
                    if (!db.TryGetCollection(node, root, out var collection))
                        return $"Collection {node} cannot be found in root {root}.";
                    if (!(collection is STRBlock str))
                        return $"Collection {node} is not a {STRBlocks} collection.";
                    var record = str.GetRecord(hash);
                    if (record == null) return $"StringRecord with key {hash} does not exist.";
                    if (!record.TrySetValue(field, value))
                        return $"Unable to set value {value} in field {field} specified.";
                    else return null;

                default:
                    return $"Invalid root passed named {root}.";
            }
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
            else if (Settings.Default.EnableSuppressABCI) return null;
            else return error;
        }

        private static string ExecuteAddTexture(BasicBase db, string root, string node, string path)
        {
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (!(collection is TPKBlock tpk))
                return $"Collection {node} is not a {root} collection.";
            if (!File.Exists(path))
                return $"File named {path} does not exist.";
            if (tpk.TryAddTexture(Path.GetFileNameWithoutExtension(path), path, out var error))
                return null;
            else if (Settings.Default.EnableSuppressABCI)
                return null;
            else
                return error;
        }

        private static string ExecuteAddString(BasicBase db, string root, string node,
            string key, string label, string text)
        {
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (!(collection is STRBlock str))
                return $"Collection {node} is not a {STRBlocks} collection.";
            if (str.TryAddRecord(key, label, text, out var error)) return null;
            else if (Settings.Default.EnableSuppressABCI) return null;
            else return error;
        }

        #endregion

        #region Delete Command

        private static string ExecuteDeleteCollection(BasicBase db, string root, string node)
        {
            if (db.TryRemoveCollection(node, root, out var error)) return null;
            else if (Settings.Default.EnableSuppressABCI) return null;
            else return error;
        }

        private static string ExecuteDeleteTPKSTR(BasicBase db, string root, string node, string hash)
        {
            switch (root)
            {
                case TPKBlocks:
                    if (!db.TryGetCollection(node, root, out var inter))
                        return $"Collection {node} cannot be found in root {root}.";
                    if (!(inter is TPKBlock tpk))
                        return $"Collection {node} is not a {STRBlocks} collection.";
                    if (tpk.TryRemoveTexture(ConvertX.ToUInt32(hash), eKeyType.BINKEY, out var error))
                        return null;
                    else if (Settings.Default.EnableSuppressABCI)
                        return null;
                    else
                        return error;

                case STRBlocks:
                    if (!db.TryGetCollection(node, root, out var collection))
                        return $"Collection {node} cannot be found in root {root}.";
                    if (!(collection is STRBlock str))
                        return $"Collection {node} is not a {STRBlocks} collection.";
                    if (str.TryRemoveRecord(hash, out var fail)) return null;
                    else if (Settings.Default.EnableSuppressABCI) return null;
                    else return fail;

                default:
                    return $"Invalid root passed named {root}.";
            }
        }

        #endregion

        #region Copy Command

        private static string ExecuteCopyCollection(BasicBase db, string root,
            string copyfrom, string newname)
        {
            if (db.TryCloneCollection(newname, copyfrom, root, out var error)) return null;
            else if (Settings.Default.EnableSuppressABCI) return null;
            else return error;
        }

        private static string ExecuteCopyTexture(BasicBase db, string root, string node,
            string hash, string cname)
        {
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (!(collection is TPKBlock tpk))
                return $"Collection {node} is not a {STRBlocks} collection.";
            if (tpk.TryCloneTexture(cname, ConvertX.ToUInt32(hash), eKeyType.BINKEY, out var error))
                return null;
            else if (Settings.Default.EnableSuppressABCI)
                return null;
            else
                return error;
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

		#region Replace Command

        private static string ExecuteReplaceTexture(BasicBase db, string root, string node,
            string hash, string path)
        {
            if (!db.TryGetCollection(node, root, out var collection))
                return $"Collection {node} cannot be found in root {root}.";
            if (!(collection is TPKBlock tpk))
                return $"Collection {node} is not a {STRBlocks} collection.";
            if (!File.Exists(path))
                return $"File named {path} does not exist.";
            if (tpk.TryReplaceTexture(ConvertX.ToUInt32(hash), eKeyType.BINKEY, path, out var error))
                return null;
            else
                return error;
        }

		#endregion

		#region Import Command

        private static string ExecuteImportCollection(BasicBase db, string root, string path)
        {
            if (root == "Collision")
            {
                if (db.TryAddCollision(Path.GetFileNameWithoutExtension(path), path, out var error))
                    return null;
                else
                    return error;
            }
            else
            {
                if (db.TryImportCollection(root, path, out var error)) return null;
                else if (Settings.Default.EnableSuppressABCI) return null;
                else return error;
            }
        }

		#endregion

		#region Move Command

		private static string ExecuteMoveCommand(string method, string type,
            string dir, string thispath, string destpath)
        {
            try
            {
                if (method == absolute)
                {
                    string thisfile = Path.Combine(GlobalDir, thispath);
                    string destfile = Path.Combine(GlobalDir, destpath);
                    if (type == folder) Directory.Move(thisfile, destfile);
                    else if (type == file) File.Copy(thisfile, destfile, true);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                else if (method == relative)
                {
                    string thisfile = Path.Combine(dir, thispath);
                    string destfile = Path.Combine(GlobalDir, destpath);
                    if (type == folder) Directory.Move(thisfile, destfile);
                    else if (type == file) File.Copy(thisfile, destfile, true);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                else return $"Unrecognized command named {method}.";
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                return e.Message;
            }
        }

		#endregion

		#region Erase Command

        private static string ExecuteEraseCommand(string method, string type, string dir, string destpath)
        {
            try
            {
                if (method == absolute)
                {
                    string destfile = Path.Combine(GlobalDir, destpath);
                    if (type == folder && Directory.Exists(destfile)) Directory.Delete(destfile, true);
                    else if (type == file && File.Exists(destfile)) File.Delete(destfile);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                else if (method == relative)
                {
                    string destfile = Path.Combine(dir, destpath);
                    if (type == folder && Directory.Exists(destfile)) Directory.Delete(destfile, true);
                    else if (type == file && File.Exists(destfile)) File.Delete(destfile);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                else return $"Invalid path type specifier named {method}.";
            }
            catch (Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                return e.Message;
            }
        }

        #endregion

        #region Create Command

        private static string ExecuteCreateCommand(string method, string type, string dir, string destpath)
        {
            if (method == "absolute")
            {
                string destfile = Path.Combine(GlobalDir, destpath);
                try
                {
                    if (type == folder) Directory.CreateDirectory(destfile);
                    else if (type == file) File.Create(destfile);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                catch (Exception e)
                {
                    while (e.InnerException != null) e = e.InnerException;
                    return e.Message;
                }
            }
            else if (method == "relative")
            {
                string destfile = Path.Combine(dir, destpath);
                try
                {
                    if (type == folder) Directory.CreateDirectory(destfile);
                    else if (type == file) File.Create(destfile);
                    else return $"Invalid attribute specifier named {type}.";
                    return null;
                }
                catch (Exception e)
                {
                    while (e.InnerException != null) e = e.InnerException;
                    return e.Message;
                }
            }
            else return $"Invalid path type specifier named {method}.";
        }

		#endregion

		#region Switch Command

        private static string ExecuteSwitchSetting(string setting, string option)
        {
            var set = setting.Replace(' ', '_');
            if (!Enum.TryParse(set, out eSettingType type))
                return $"Setting named \"{setting}\" does not exist.";
            if (type == eSettingType.Set_Modder_Name) goto LABEL_NAME;
            if (!Enum.TryParse(option, out eBoolean turn))
                return $"Invalid option type named {option}.";
            bool is_on = turn == eBoolean.True ? true : false;
            switch (type)
            {
                case eSettingType.Enable_Auto_Backup_Save:
                    Settings.Default.EnableAutobackup = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Compress_Files_When_Saving:
                    Settings.Default.EnableCompression = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Save_End_Commands:
                    Settings.Default.EnableEndscriptLog = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Enable_Static_Commands:
                    Settings.Default.EnableStaticEnd = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Start_In_Maximized_Mode:
                    Settings.Default.EnableMaximized = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Enable_Modder_Watermarks:
                    Settings.Default.EnableWatermarks = is_on;
                    Settings.Default.Save();
                    return null;
                case eSettingType.Suppress_ADCI_Errors:
                    Settings.Default.EnableSuppressABCI = is_on;
                    Settings.Default.Save();
                    return null;
                default:
                    return $"Setting named \"{setting}\" does not exist.";
            }

        LABEL_NAME:
            if (option.Length > 15) return $"Modder Name should not exceed 15 characters.";
            Settings.Default.BinaryUsername = option;
            Settings.Default.Save();
            return null;
        }

		#endregion
	}
}