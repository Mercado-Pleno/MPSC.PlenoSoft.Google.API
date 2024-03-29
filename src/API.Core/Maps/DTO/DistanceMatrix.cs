﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Core.Maps.DTO
{
	[Serializable]
	public class DistanceMatrix
	{
		public IEnumerable<String> Origin_Addresses { get; set; } = new List<String>();
		public IEnumerable<String> Destination_Addresses { get; set; } = new List<String>();
		public IEnumerable<Row> Rows { get; set; } = new List<Row>();
		public String Status { get; set; } = "Error";


		public Row FirstRow { get { return Rows?.FirstOrDefault() ?? new Row(); } }
		public Record Distance { get { return FirstRow.FirstElement.Distance ?? new Record(); } }
		public Record Duration { get { return FirstRow.FirstElement.Duration ?? new Record(); } }
	}
}