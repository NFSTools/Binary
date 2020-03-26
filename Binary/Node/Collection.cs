using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalLib.Reflection.Abstract;

namespace Binary.Node
{
	public class Collection
	{
		Dictionary<uint, CollectionAttrib> AttributeMap { get; set; }
		public string FullPath { get; set; }

		public int Count { get => AttributeMap.Count; }

		public Collection()
		{
			this.AttributeMap = new Dictionary<uint, CollectionAttrib>();
		}

		public CollectionAttrib GetAttrbute(string path)
		{
			return this.AttributeMap.TryGetValue(Mark.Hash(path), out var collection) ? collection : null;
		}


	}
}
