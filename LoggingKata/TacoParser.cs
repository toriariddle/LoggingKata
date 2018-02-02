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
            var cells = line.Split(',');
            var longitude = Double.Parse(cells[0]);
            var latitude = Double.Parse(cells[1]);
            var name = cells[2];

            if (cells.Length < 3)
            {
                Console.WriteLine("Something went wrong");
                return null; // Log that and return null
            }

            Console.WriteLine("test");
            Console.ReadLine();

            //return value;
            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = new Point(latitude, longitude)
            };

            return tacoBell;
        }
    }
}

