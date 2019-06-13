using MPSC.PlenoSoft.Google.API.Maps.DTO;
using MPSC.PlenoSoft.Google.API.Utils;
using Newtonsoft.Json;
using System;

namespace MPSC.PlenoSoft.Google.API.Maps
{
	public class GoogleMapsService
	{
		private const String apiUrlPattern = "https://maps.googleapis.com/maps/api/distancematrix/json?key={apiKey}&origins={origins}&destinations={destinations}&mode={mode}&language={language}{aditionalParameters}";
		private static String mode = "driving";
		private static String language = "pt-BR";
		private static String aditionalParameters = "";
		private readonly String _apiKey;

		public GoogleMapsService(String apiKey) { _apiKey = apiKey; }

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
				.Replace("{mode}", mode)
				.Replace("{language}", language)
				.Replace("{aditionalParameters}", aditionalParameters)
			;
			return new Uri(apiUrl);
		}
	}
}