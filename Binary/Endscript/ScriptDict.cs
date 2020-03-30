using System;
using System.Collections.Generic;



namespace Binary.Endscript
{
	public static class ScriptDict
	{
		public static Dictionary<ScriptArgs, Func<string, Launch, bool>> KeywordFunctions { get; set; } =
			new Dictionary<ScriptArgs, Func<string, Launch, bool>>()
		{
			{
				ScriptArgs.Process,
				(string str, Launch lan) =>
				{
					if (!string.IsNullOrEmpty(lan.ProcessName))
					{
						lan.ProcessName = str;
						return true;
					}
					else return false;
				}
			},

			{
				ScriptArgs.ChooseDirMethod,
				(string str, Launch lan) =>
				{
					if (Enum.TryParse(str, out eChooseDirMethod method))
					{
						lan.ChooseDir = method;
						return true;
					}
					else return false;
				}
			},

			{
				ScriptArgs.Description,
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
				ScriptArgs.NumCommandArgs,
				(string str, Launch lan) =>
				{
					if (!int.TryParse(str, out var num) || num < 0)
						return false;
					lan.NumCommandArgs = num;
					return true;
				}
			},

			{
				ScriptArgs.StrCommandArgs,
				(string str, Launch lan) =>
				{
					if (lan.StrCommandArgs.Count >= lan.NumCommandArgs) return false;
					else
					{
						lan.StrCommandArgs.Add(str);
						return true;
					}
				}
			},
		};
	}
}
