namespace Binary.Utils
{
	public static class CleanUp
	{
		public static void GCCollect()
		{
			for (int a1 = 0; a1 < System.GC.MaxGeneration; ++a1)
				System.GC.Collect(a1, System.GCCollectionMode.Forced);
		}

		public static (string, string) SplitScriptString(string line)
		{
			if (line.Contains("//"))
				line = line.Substring(0, line.IndexOf("//"));
			var keyword = line.Substring(0, line.IndexOf('='));
			var value = line.Substring(line.IndexOf('=') + 1);
			keyword = GlobalLib.Utils.ScriptX.CleanString(keyword, true);
			value = GlobalLib.Utils.ScriptX.CleanString(value, true);
			return (keyword, value);
		}
	}
}
