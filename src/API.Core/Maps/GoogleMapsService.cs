using MPSC.PlenoSoft.Google.API.Core.Maps.DTO;
using MPSC.PlenoSoft.Google.API.Core.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Core.Maps
{
	/// <summary>
	/// https://developers.google.com/maps/documentation/distance-matrix/start
	/// </summary>
	public class GoogleMapsService
	{
		private const String apiUrlPattern = "https://maps.googleapis.com/maps/api/distancematrix/json?key={apiKey}&origins={origins}&destinations={destinations}";
		private readonly Dictionary<String, String> _parameters;
		private readonly String _apiKey;

		public GoogleMapsService(String apiKey, String travelMode = "driving", String language = "pt-BR", IEnumerable<KeyValuePair<String, String>> parameters = null)
		{
			_apiKey = apiKey;
			_parameters = new Dictionary<String, String> { { "mode", travelMode }, { "language", language } };
			_parameters.Merge(parameters);
		}

		public DistanceMatrix GetDistanceMatrix(String origins, String destinations, String alternativeApiKey = null)
		{
			var jsonString = GetDistanceMatrixFromApi(origins, destinations, alternativeApiKey ?? _apiKey);
			var distanceMatrix = JsonConvert.DeserializeObject<DistanceMatrix>(jsonString);
			return distanceMatrix ?? new DistanceMatrix();
		}

		private String GetDistanceMatrixFromApi(String origins, String destinations, String apiKey)
		{
			var apiUri = GetApiUri(origins, destinations, apiKey);
			return apiUri.GetContent();
		}

		private Uri GetApiUri(String origins, String destinations, String apiKey)
		{
			var apiUrl = apiUrlPattern
				.Replace("{apiKey}", apiKey)
				.Replace("{origins}", origins)
				.Replace("{destinations}", destinations)
			;
			return new Uri(apiUrl + Parameters);
		}

		private String Parameters { get { return "&" + String.Join("&", _parameters.Select(d => $"{d.Key}={d.Value}")); } }
	}
}