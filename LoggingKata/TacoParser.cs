using System;
using System.Collections;
using System.Collections.Generic;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        public TacoParser()
        {

        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) { return null; }

            var cells = line.Split(',');

            if (cells.Length < 2)
            {
                Console.WriteLine("Something went wrong");
                return null; // Log that and return null
            }

            double lon;
            double lat;

            try
            {
                lon = double.Parse(cells[0]);
                lat = double.Parse(cells[1]);
            }
            catch (Exception e)
            {
                Logger.Error("Failed to parse lat and long", e);
                return null;
            }

            //return value;
            var tacoBell = new TacoBell
            {
                Name = cells.Length > 2 ? cells[2] : null,
                Location = new Point { Latitude = lat, Longitude = lon }
            };

            return tacoBell;
        }
    }
}























                                