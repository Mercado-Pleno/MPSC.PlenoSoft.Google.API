using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MPSC.PlenoSoft.Google.API.Core.Utils
{
	public static class Extensions
	{
		public static void Merge(this IDictionary<String, String> dictionary, IEnumerable<KeyValuePair<String, String>> newDictionary)
		{
			if (newDictionary != null)
			{
				foreach (var kvp in newDictionary)
				{
					if (!dictionary.ContainsKey(kvp.Key))
						dictionary.Add(kvp.Key, kvp.Value);
				}
			}
		}

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