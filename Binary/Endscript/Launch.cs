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
	}
}
