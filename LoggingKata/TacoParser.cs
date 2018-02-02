using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using log4net;
using log4net.Util;

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
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                Console.WriteLine("something went wrong");
                return null;  // Log that and return null
            }

            var longitude = Double.Parse(cells[0]); // grab the long from your array at index 0 // Your going to need to parse your string as a `double`
            var latitude = Double.Parse(cells[1]); // grab the lat from your array at index 1 // Your going to need to parse your string as a `double`
            var name = cells[2]; // grab the name from your array at index 2                 // which is similar to parse a string as an `int`



            // that conforms to ITrackable



            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            //DO not fail if one record parsing fails, return null
            //TODO Implement

            return null;
        }
    }
}

