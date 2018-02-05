using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;
using System.Device.Location;

namespace LoggingKata
{
    internal class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Logger.Info("Log initialized");
            var file = Path.Combine(Environment.CurrentDirectory, "Taco_Bell-US-AL-Alabama.csv"); // Grab the path from Environment.CurrentDirectory + the name of your file

            // Log and error if you get 0 lines and a warning if you get 1 line
            // Now, here's the new code

            var lines = File.ReadAllLines(file); // use File.ReadAllLines(path) to grab all the lines from your csv file
            var parser = new TacoParser(); // Create a new instance of your TacoParser class

            var locations = lines.Select(line => parser.Parse(line)); // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(line => parser.Parse(line));

            ITrackable loc1 = null; // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable loc2 = null;

            double dist = 0; //Create a `double` variable to store the distance
            {

                foreach (var location in locations)
                {
                    Console.WriteLine("location: " + location.Name);
                }



                //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
                //HINT:  You'll need two nested forloops


                // Include the Geolocation toolbox, so you can compare locations


                foreach (var locA in locations)                  // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                {
                    var origin = new Coordinate
                    {
                        Latitude = locA.Location.Latitude,
                        Longitude = locA.Location.Longitude
                    };

                }

                foreach (var locB in locations)  // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)             
                {
                    var distance = new Coordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude
                    };

                }
             
                   {
                            Coordinate = locA; // Create a new Coordinate with your locA's lat and long
                            locB = locB; // Create a new Coordinate with your locB's lat and long
                        }

                        // Now, compare the two using `GeoCalculator.GetDistance(origin, destination)`, which returns a double
                        // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
                        if (outcome > distance)
                // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
            }
                }
            }