using System.Collections.Generic;



namespace Binary.Utils
{
	public static class Filenames
	{
		public static List<(string, string)> Carbon { get; set; } = new List<(string, string)>()
		{
			(@"\GLOBAL\GlobalA.bun", @"\GLOBAL\GlobalA.bun.bacc"),
			(@"\GLOBAL\GlobalB.lzc", @"\GLOBAL\GlobalB.lzc.bacc"),
			(@"\LANGUAGES\English_Global.bin", @"\LANGUAGES\English_Global.bin.bacc"),
			(@"\LANGUAGES\Labels_Global.bin", @"\LANGUAGES\Labels_Global.bin.bacc"),
		};

		public static List<(string, string)> MostWanted { get; set; } = new List<(string, string)>()
		{
			(@"\GLOBAL\GlobalA.bun", @"\GLOBAL\GlobalA.bun.bacc"),
			(@"\GLOBAL\GlobalB.lzc", @"\GLOBAL\GlobalB.lzc.bacc"),
			(@"\LANGUAGES\English.bin", @"\LANGUAGES\English.bin.bacc"),
			(@"\LANGUAGES\Labels.bin", @"\LANGUAGES\Labels.bin.bacc"),
		};

		public static List<(string, string)> Underground2 { get; set; } = new List<(string, string)>()
		{
			(@"\GLOBAL\GlobalA.bun", @"\GLOBAL\GlobalA.bun.bacc"),
			(@"\GLOBAL\GlobalB.lzc", @"\GLOBAL\GlobalB.lzc.bacc"),
			(@"\LANGUAGES\English.bin", @"\LANGUAGES\English.bin.bacc"),
			(@"\LANGUAGES\Labels.bin", @"\LANGUAGES\Labels.bin.bacc"),
		};
	}
}
