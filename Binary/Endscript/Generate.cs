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



using System;
using FastColoredTextBoxNS;



namespace Binary.Endscript
{
	public static class Generate
	{
		private static bool NeedsNewLine(FastColoredTextBox box)
		{
			if (string.IsNullOrEmpty(box.Text) || box.Text.EndsWith(Environment.NewLine))
				return false;
			else
				return true;
		}

		public static void WriteCommand(eCommands command, FastColoredTextBox box, params string[] paths)
		{
			string str = command.ToString();
			bool needs_newline = NeedsNewLine(box);

			foreach (var path in paths)
				str += " " + path;
			box.Text += needs_newline ? Environment.NewLine : string.Empty;
			box.Text += str + Environment.NewLine;
			Core.WriteEndscriptLine(str);
		}

		public static void WriteCommand(string line, FastColoredTextBox box)
		{
			box.Text += NeedsNewLine(box) ? Environment.NewLine : string.Empty;
			box.Text += line + Environment.NewLine;
			Core.WriteEndscriptLine(line);
		}
	}
}