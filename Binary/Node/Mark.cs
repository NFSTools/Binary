using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary.Node
{
	public static class Mark
	{
		public static uint Hash(string value)
		{
			int num = value.Length % 4;
			uint result = 0;

			switch (num)
			{
				case 1:
					for (int a = 0; a < value.Length; ++a)
						result += (uint)((byte)value[a] * 73 + ((num % 2 == 0) ? 102 : 125));
					return result;

				case 2:
					for (int a = 0; a < value.Length; a += 2)
						result += (uint)((byte)value[a] * (byte)value[a + 1] * 47 + ((byte)value[a] << 1));
					return result;

				case 3:
					for (int a = 0; a < value.Length; ++a)
						result += (uint)((byte)value[a] * 17 + ((num % 2 == 0) ? 37 : ((byte)value[a] << 2)));
					return result;

				default:
					for (int a = 0; a < value.Length; a += 2)
						result += (uint)(((byte)value[a] << 2) * ((byte)value[a + 1] * ((byte)value[a] >> 1)));
					return result;
			}
		}
	}
}
