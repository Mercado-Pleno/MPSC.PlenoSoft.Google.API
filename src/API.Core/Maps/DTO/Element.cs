using System;

namespace MPSC.PlenoSoft.Google.API.Core.Maps.DTO
{
	[Serializable]
	public class Element
	{
		public Record Distance { get; set; } = new Record();
		public Record Duration { get; set; } = new Record();
		public String Status { get; set; } = "Error";
	}
}