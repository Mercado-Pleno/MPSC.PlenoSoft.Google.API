using System;

namespace MPSC.PlenoSoft.Google.API.Maps.DTO
{
	[Serializable]
	public class Record
	{
		public String Text { get; set; } = "Error";
		public Decimal? Value { get; set; } = null;
	}
}