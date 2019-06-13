using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Core.Maps.DTO
{
	[Serializable]
	public class Row
	{
		public IEnumerable<Element> Elements { get; set; } = new List<Element>();

		public Element FirstElement { get { return Elements?.FirstOrDefault() ?? new Element(); } }
	}
}