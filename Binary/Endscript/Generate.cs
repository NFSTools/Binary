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

		public static void WriteCommand(Commands command, FastColoredTextBox box, params string[] paths)
		{
			string str = command.ToString();
			bool needs_newline = NeedsNewLine(box);

			foreach (var path in paths)
				str += " " + path;
			box.Text += needs_newline ? Environment.NewLine : string.Empty;
			box.Text += str + Environment.NewLine;
			Core.WriteEndscriptLine(str);
		}
	}
}