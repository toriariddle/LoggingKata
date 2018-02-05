using System;
using System.Linq;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var file = Path.Combine(Environment.CurrentDirectory, "Taco_Bell-US-AL-Alabama.csv");
            var lines = File.ReadAllLines(file);

            switch (lines.Length)
            {
                case 0:
                    Logger.Error("Nothing to read from file.");
                    return;
                case 1:
                    Logger.Warn("Only 1 line read from file.");
                    return;
            }

            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToList();

            ITrackable locA = null;
            ITrackable locB = null;
            var distance = 0.0;

            foreach (var a in locations)
            {
                var origin = new Coordinate { Latitude = a.Location.Latitude, Longitude = a.Location.Longitude };

                foreach (var b in locations)
                {
                    var destination = new Coordinate { Latitude = b.Location.Latitude, Longitude = b.Location.Longitude };

                    var dist = GeoCalculator.GetDistance(origin, destination);

                    if (dist <= distance)
                    {
                        continue;
                    }

                    distance = dist;
                    locA = a;
                    locB = b;
                }

                Console.WriteLine($"The two tacobells furthest from each other are {locA?.Name} and {locB?.Name} with {distance} miles apart.");
                Console.WriteLine();
                Console.ReadKey();
            }
        }
    }
}
