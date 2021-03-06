﻿/********************************************************************************
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
using System.ComponentModel;
using System.Collections.Generic;
using GlobalLib.Utils;



namespace Binary.Endscript
{
	public static class Linear
	{
		public static string LaunchProcess(string filename, string origdir)
		{
			try
			{
				var lines = File.ReadAllLines(filename);
				if (lines == null) return null;
				var launches = new List<Launch>();

				const string startregion = "#region launch";
				const string endregion = "#endregion";
				const string YAMLDatabase = "YAMLDatabase.exe";
				bool in_launch_format = false;
				int last_index = -1;

				foreach (var line in lines)
				{
					if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//"))
						continue;
					else if (in_launch_format && line == endregion)
					{
						in_launch_format = false;
						continue;
					}
					else if (!in_launch_format && line == startregion)
					{
						last_index = launches.Count;
						in_launch_format = true;
						launches.Add(new Launch(origdir));
						continue;
					}
					else if (in_launch_format)
					{
						if (!line.Contains("="))
							throw new Exception($"Unable to process line {line} in script {filename}.");
						var tokens = Utils.CleanUp.SplitScriptString(line);
						if (!Enum.TryParse(tokens.Item1, out eScriptArgs arg))
							throw new Exception($"Unrecognized keyword {tokens.Item1} in script {filename}.");
						if (!ScriptDict.KeywordFunctions[arg].Invoke(tokens.Item2, launches[last_index]))
							throw new Exception($"Unable to process keyword {arg} in script {filename}.");
					}
					else
					{
						throw new Exception($"Unable to process line {line} in script {filename}.");
					}
				}

				if (in_launch_format)
					throw new Exception($"Keyword {endregion} was not found in script {filename}.");


				bool is_yaml_linked = File.Exists(Properties.Settings.Default.YAMLDirectory);
				string prev_launch = string.Empty;
				foreach (var launch in launches)
				{
					switch (launch.ChooseDir)
					{
						case eChooseDirMethod.None:
							throw new Exception($"Unable to find file named {launch.ProcessName}.");

						case eChooseDirMethod.OpenFileDialog:
							if (launch.ProcessName == YAMLDatabase && is_yaml_linked)
							{
								launch.ProcessName = Properties.Settings.Default.YAMLDirectory;
								goto default;
							}
							var ofd = new OpenFileDialog()
							{
								Filter = $"{Path.GetFileNameWithoutExtension(launch.ProcessName)} | " +
										 $"*{Path.GetExtension(launch.ProcessName)}",
								CheckFileExists = true,
								CheckPathExists = true,
								Multiselect = false,
								Title = launch.Description,
							};
							ofd.FileOk += new CancelEventHandler((object sender, CancelEventArgs e) =>
							{
								if (Path.GetFileName(ofd.FileName) != launch.ProcessName)
								{
									MessageBox.Show($"File chosen is not {launch.ProcessName}.", "Error",
										MessageBoxButtons.OK, MessageBoxIcon.Error);
									e.Cancel = true;
								}
							});

							if (ofd.ShowDialog() == DialogResult.OK)
							{
								launch.ProcessName = ofd.FileName;
								goto default;
							}
							throw new Exception($"User interrupted execution of process {launch.ProcessName}.");

						case eChooseDirMethod.OpenFolderDialog:
							if (launch.ProcessName == YAMLDatabase && is_yaml_linked)
							{
								launch.ProcessName = Properties.Settings.Default.YAMLDirectory;
								goto default;
							}
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
							if (launch.ProcessName == YAMLDatabase && is_yaml_linked)
							{
								launch.ProcessName = Properties.Settings.Default.YAMLDirectory;
								goto default;
							}
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
							if (launch.ProcessName == YAMLDatabase && is_yaml_linked)
							{
								launch.ProcessName = Properties.Settings.Default.YAMLDirectory;
								goto default;
							}
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

						case eChooseDirMethod.FromPreviousLaunch:
							if (string.IsNullOrEmpty(prev_launch))
								throw new Exception($"Unable to use file path from previous launch in script {filename}.");
							launch.ProcessName = prev_launch;
							goto default;

						default:
							prev_launch = launch.ProcessName;
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
