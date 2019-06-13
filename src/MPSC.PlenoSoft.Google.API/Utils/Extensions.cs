using System;
using System.IO;
using System.Net;

namespace MPSC.PlenoSoft.Google.API.Utils
{
	public static class Extensions
	{
		public static String GetContent(this Uri uri)
		{
			var webRequest = WebRequest.Create(uri);
			using (var webResponse = webRequest.GetResponse())
			{
				try
				{
					return ReadAllString(webResponse.GetResponseStream());
				}
				finally
				{
					webResponse.Close();
				}
			}
		}

		public static String ReadAllString(this Stream stream)
		{
			using (var streamReader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true))
			{
				try
				{
					return streamReader.ReadToEnd();
				}
				finally
				{
					streamReader.Close();
				}
			}
		}
	}
}