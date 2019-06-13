using System;
using System.Collections.Generic;

namespace MPSC.PlenoSoft.Google.API.Maps.DTO
{
	[Serializable]
	public class Row
	{
		public IEnumerable<Element> Elements { get; set; } = new List<Element>();
	}
}