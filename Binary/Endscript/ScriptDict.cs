using System;
using System.IO;
using System.Collections.Generic;



namespace Binary.Endscript
{
	public static class ScriptDict
	{
		public static Dictionary<eScriptArgs, Func<string, Launch, bool>> KeywordFunctions { get; set; } =
			new Dictionary<eScriptArgs, Func<string, Launch, bool>>()
		{
			{
				eScriptArgs.Process,
				(string str, Launch lan) =>
				{
					if (string.IsNullOrEmpty(lan.ProcessName))
					{
						lan.ProcessName = str;
						return true;
					}
					else return false;
				}
			},

			{
				eScriptArgs.ChooseMethod,
				(string str, Launch lan) =>
				{
					if (lan.ChooseDir != eChooseDirMethod.None) return false;
					if (Enum.TryParse(str, out eChooseDirMethod method))
					{
						lan.ChooseDir = method;
						return true;
					}
					else return false;
				}
			},

			{
				eScriptArgs.Description,
				(string str, Launch lan) =>
				{
					if (string.IsNullOrEmpty(lan.Description))
						lan.Description = str;
					else if (!lan.Description.EndsWith(" "))
						lan.Description += " " + str;
					else
						lan.Description += str;
					return true;
				}
			},

			{
				eScriptArgs.NumCommandArgs,
				(string str, Launch lan) =>
				{
					if (lan.NumCommandArgs > -1) return false;
					if (!int.TryParse(str, out var num) || num < 0)
						return false;
					lan.NumCommandArgs = num;
					return true;
				}
			},

			{
				eScriptArgs.StrCommandArgs,
				(string str, Launch lan) =>
				{
					if (lan.StrCommandArgs.Count >= lan.NumCommandArgs) return false;
					else if (str.Contains(eScriptArgs.ScriptFilename.ToString()))
						lan.StrCommandArgs.Add(str.Replace(eScriptArgs.ScriptFilename.ToString(),
							lan.ScriptFilename));
					else
						lan.StrCommandArgs.Add(str);
					return true;
				}
			},

			{
				eScriptArgs.ScriptFilename,
				(string str, Launch lan) =>
				{
					if (string.IsNullOrEmpty(lan.ScriptFilename))
					{
						lan.ScriptFilename = Path.Combine(lan.ThisEndDirectory, str);
						return true;
					}
					else return false;
				}
			}
		};
	}
}
