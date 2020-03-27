using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;



namespace Binary.Endscript
{
    public static partial class Core
    {
        private static string EndFileDir { get; set; }
        private static List<Error> ErrorsOccured = new List<Error>();
        private static string scriptdir;

        private static void AddErrorType(string error, string line, int index)
        {
            var addon = new Error()
            {
                Command = line,
                Type = error,
                LineNumber = index
            };
            ErrorsOccured.Add(addon);
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

        public static void CreateEndscriptFile(string filename)
        {
            EndFileDir = filename;
            try
            {
                bool NewFileMake = !File.Exists(EndFileDir);
                FileStream ModStream;
                StreamWriter ModFile;

                if (Properties.Settings.Default.EnableNewEndscripts || NewFileMake)
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
    }
}