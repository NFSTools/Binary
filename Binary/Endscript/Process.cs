using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using GlobalLib.Utils;



namespace Binary.Endscript
{
	public static class Linear
	{
		public static string LaunchProcess(string filename)
		{
			try
			{
				var lines = File.ReadAllLines(filename);
				if (lines == null) return null;
				var launches = new List<Launch>();

				const string startregion = "#region launch";
				const string endregion = "#endregion";
				bool in_launch_format = false;
				int last_index = -1;

				foreach (var line in lines)
				{
					if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
						continue;
					else if (line == endregion)
					{
						in_launch_format = false;
						continue;
					}
					else if (!in_launch_format && line == startregion)
					{
						last_index = launches.Count;
						in_launch_format = true;
						launches.Add(new Launch());
						continue;
					}
					else if (in_launch_format)
					{
						if (!line.Contains("="))
							throw new Exception($"Unable to process line {line} in script {filename}.");
						var tokens = Utils.CleanUp.SplitScriptString(line);
						if (!Enum.TryParse(tokens.Item1, out ScriptArgs arg))
							throw new Exception($"Unrecognized keyword {tokens.Item1} in script {filename}.");
						ScriptDict.KeywordFunctions[arg].Invoke(tokens.Item2, launches[last_index]);
					}
					else
					{
						throw new Exception($"Unable to process line {line} in script {filename}.");
					}
				}

				foreach (var launch in launches)
				{
					switch (launch.ChooseDir)
					{
						case eChooseDirMethod.OpenFileDialog:
							var ofd = new OpenFileDialog()
							{
								Filter = Path.GetExtension(launch.ProcessName),
								CheckFileExists = true,
								CheckPathExists = true,
								Multiselect = false,
								Title = launch.Description,
							};
							ofd.FileOk += new CancelEventHandler((object sender, CancelEventArgs e) =>
							{
								if (Path.GetFileName(ofd.FileName) != launch.ProcessName)
									e.Cancel = true;
							});

							if (ofd.ShowDialog() == DialogResult.OK)
							{
								launch.ProcessName = ofd.FileName;
								goto default;
							}
							throw new Exception($"User interrupted execution of process {launch.ProcessName}.");

						case eChooseDirMethod.OpenFolderDialog:
							var fbd = new FolderBrowserDialog()
							{
								RootFolder = Environment.SpecialFolder.MyComputer,
								Description = launch.Description,
								ShowNewFolderButton = false,
							};
							if (fbd.ShowDialog() == DialogResult.OK)
							{
								string path = Path.Combine(fbd.SelectedPath, launch.ProcessName);
								if (!File.Exists(path))
								{
									MessageBox.Show($"File {launch.ProcessName} does not exist in the chosen directory",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
									goto case eChooseDirMethod.OpenFolderDialog;
								}
								else
								{
									launch.ProcessName = path;
									goto default;
								}
							}
							throw new Exception($"User interrupted execution of process {launch.ProcessName}.");

						case eChooseDirMethod.UserEnterFilePath:
							var fileform = new Interact.Input(launch.Description);
							if (fileform.ShowDialog() == DialogResult.OK)
							{
								if (!File.Exists(fileform.CollectionName))
								{
									MessageBox.Show($"File named {fileform.CollectionName} does not exist.",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
									goto case eChooseDirMethod.UserEnterFilePath;
								}
								else if (Path.GetFileName(fileform.CollectionName) != launch.ProcessName)
								{
									MessageBox.Show($"File chosen is not a file named {launch.ProcessName}.",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
									goto case eChooseDirMethod.UserEnterFilePath;
								}
								else
								{
									launch.ProcessName = fileform.CollectionName;
									goto default;
								}
							}
							throw new Exception($"User interrupted execution of process {launch.ProcessName}.");

						case eChooseDirMethod.UserEnterFolderPath:
							var folderform = new Interact.Input(launch.Description);
							if (folderform.ShowDialog() == DialogResult.OK)
							{
								string path = Path.Combine(folderform.CollectionName, launch.ProcessName);
								if (!File.Exists(path))
								{
									MessageBox.Show($"File named {folderform.CollectionName} does not exist.",
										"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
									goto case eChooseDirMethod.UserEnterFilePath;
								}
								else
								{
									launch.ProcessName = path;
									goto default;
								}
							}
							throw new Exception($"User interrupted execution of process {launch.ProcessName}.");

						default:
							var args = string.Empty;
							foreach (var arg in launch.StrCommandArgs)
								args += arg + " ";
							using (var process = new Process())
							{
								Log.EnableLog = true;
								process.StartInfo.FileName = launch.ProcessName;
								process.StartInfo.Arguments = args;
								process.StartInfo.UseShellExecute = false;
								process.StartInfo.WorkingDirectory = Path.GetDirectoryName(launch.ProcessName);
								process.StartInfo.RedirectStandardOutput = true;
								process.Start();
								Log.Write(process.StandardOutput.ReadToEnd());
								process.WaitForExit();
								Log.EnableLog = false;
								break;
							}
					}
				}

				Utils.CleanUp.GCCollect();
				return null;
			}
			catch (Exception e)
			{
				while (e.InnerException != null) e = e.InnerException;
				return e.Message;
			}
		}
	}
}
