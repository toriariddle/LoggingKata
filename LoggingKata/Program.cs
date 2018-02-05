using System;
using System.Linq;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
           // Logger.Info("Log initialized");

            var file = Path.Combine(Environment.CurrentDirectory, "Taco_Bell-US-AL-Alabama.csv");

            var lines = File.ReadAllLines(file);

             if (lines.Length == 0)
            {
                Logger.Error("Nothing to read from file.");
                return;
            }
        
              if (lines.Length == 1)
            {
                Logger.Warn("Only 1 line read from file.");
                return;
            }

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToList();


            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable locA = null;
            ITrackable locB = null;
            var distance = 0.0;

            foreach (var a in locations)
            {
                var origin = new Coordinate {Latitude = a.Location.Latitude, Longitude = a.Location.Longitude};

                foreach (var b in locations)
                {
                    var destination = new Coordinate {Latitude = b.Location.Latitude, Longitude = b.Location.Longitude};

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
