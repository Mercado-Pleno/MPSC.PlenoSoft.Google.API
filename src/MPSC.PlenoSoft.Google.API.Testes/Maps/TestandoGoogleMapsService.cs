using Microsoft.VisualStudio.TestTools.UnitTesting;
using MPSC.PlenoSoft.Google.API.Maps;
using System;

namespace MPSC.PlenoSoft.Google.API.Testes.Maps
{
	[TestClass]
	public class TestandoGoogleMapsService
	{
		private const String cApiKey = "Enter With Your API Key Here";

		[TestMethod]
		public void QuandoSolicitaADistanciaEntreNiteroiERioDeJaneiro_DeveRetornarComSucesso()
		{
			var googleMapsService = new GoogleMapsService(apiKey: cApiKey);

			var distanceMatrix = googleMapsService.GetDistanceMatrix(
				origins: "Niterói rj",
				destinations: "Rio de Janeiro rj"
			);

			Assert.IsNotNull(distanceMatrix);
			Assert.IsNotNull(distanceMatrix.Distance);
			Assert.IsNotNull(distanceMatrix.Duration);

			Console.WriteLine(distanceMatrix.Distance.Text);
			Console.WriteLine(distanceMatrix.Distance.Value);
			Console.WriteLine(distanceMatrix.Duration.Text);
			Console.WriteLine(distanceMatrix.Duration.Value);
		}
	}
}