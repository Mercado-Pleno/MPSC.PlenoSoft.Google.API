using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Maps.DTO
{
	[Serializable]
	public class DistanceMatrix
	{
		public IEnumerable<String> Origin_Addresses { get; set; } = new List<String>();
		public IEnumerable<String> Destination_Addresses { get; set; } = new List<String>();
		public IEnumerable<Row> Rows { get; set; } = new List<Row>();
		public String Status { get; set; } = "Error";

		public Record Distance => Rows?.FirstOrDefault()?.Elements?.FirstOrDefault()?.Distance ?? new Record();
		public Record Duration => Rows?.FirstOrDefault()?.Elements?.FirstOrDefault()?.Duration ?? new Record();
	}
}