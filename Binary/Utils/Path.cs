using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary.Utils
{
	public static class Path
	{
		public static string[] SplitPath(string path)
		{
			return path.Split(new char[] { ' ', '\\', '/', '|' }, StringSplitOptions.RemoveEmptyEntries);
		}

		public static string CombinePath(char splitter, params string[] path)
		{
			string result = string.Empty;
			foreach (var str in path)
				result += str + splitter.ToString();
			return result.Substring(0, result.Length - 1);
		}
	}
}
