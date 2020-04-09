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
