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
