using System;
using log4net;

namespace LoggingKata
{
    public class TacoParser
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) { return null; }

            var cells = line.Split(',');

            if (cells.Length < 2)
            {
                Logger.Warn("Missing a lat or lon");
                return null;
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

            var tacoBell = new TacoBell
            {
                Name = cells.Length > 2 ? cells[2] : null,
                Location = new Point { Latitude = lat, Longitude = lon }
            };

            return tacoBell;
        }
    }
}
