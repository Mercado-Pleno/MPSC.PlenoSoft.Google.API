using MPSC.PlenoSoft.Google.API.Maps;
using System.Linq;

namespace MPSC.PlenoSoft.Google.API.Console
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			System.Console.Write("Enter With Your API Key Here: ");
			var apiKey = System.Console.ReadLine();
			var googleMapsService = new GoogleMapsService(apiKey);

			var distanceMatrix = googleMapsService.GetDistanceMatrix(
				origins: "Niterói - RJ",
				destinations: "Rio de Janeiro - RJ"
			);

			System.Console.WriteLine();
			System.Console.WriteLine(distanceMatrix.Origin_Addresses.FirstOrDefault());
			System.Console.WriteLine(distanceMatrix.Destination_Addresses.FirstOrDefault());
			System.Console.WriteLine(distanceMatrix.Distance.Text);
			System.Console.WriteLine(distanceMatrix.Distance.Value + " metros");
			System.Console.WriteLine(distanceMatrix.Duration.Text);
			System.Console.WriteLine(distanceMatrix.Duration.Value + " segundos");

			System.Console.Write("Pressione Enter pra finalizar ...");
			System.Console.ReadLine();
		}
	}
}