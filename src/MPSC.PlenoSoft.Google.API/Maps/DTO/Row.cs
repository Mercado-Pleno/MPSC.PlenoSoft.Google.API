using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Maps.DTO
{
	[Serializable]
	public class Row
	{
		public IEnumerable<Element> Elements { get; set; } = new List<Element>();

		public Element FirstElement => Elements?.FirstOrDefault() ?? new Element();
	}
}