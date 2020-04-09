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



namespace Binary.Endscript
{
	public class Launch
	{
		public string ProcessName { get; set; }
		public string Description { get; set; }
		public eChooseDirMethod ChooseDir { get; set; }
		public int NumCommandArgs { get; set; }
		public List<string> StrCommandArgs { get; set; }
		public string ScriptFilename { get; set; }
		public string ThisEndDirectory { get; set; }

		public Launch(string thisenddir)
		{
			this.ThisEndDirectory = thisenddir;
			this.ChooseDir = eChooseDirMethod.None;
			this.NumCommandArgs = -1;
			this.StrCommandArgs = new List<string>();
		}
	}
}
