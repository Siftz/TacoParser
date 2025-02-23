namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array's Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log error message and return null
                logger.LogError("Invalid data. More than 2 elements are required.");
                return null; 
            }

            // TODO: Grab the latitude from your array at index 0
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            if (!double.TryParse(cells[0], out double latitude))
            {
                logger.LogError($"Invalid latitude value: {cells[0]}");
                return null;
            }
            
            // TODO: Grab the longitude from your array at index 1
            // You're going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            if (!double.TryParse(cells[1], out double longitude))
            {
                logger.LogError($"Invalid longitude value: {cells[1]}");
                return null;
            }
            
            // TODO: Grab the name from your array at index 2
            var name = cells[2];

            // TODO: Create a TacoBell class
            // that conforms to ITrackable
            
            // <Created TacoBell Class> // 
            
            // TODO: Create an instance of the Point Struct
            // TODO: Set the values of the point correctly (Latitude and Longitude) 
            var location = new Point
            {
                Latitude = latitude,
                Longitude = longitude
            };

            // TODO: Create an instance of the TacoBell class
            // TODO: Set the values of the class correctly (Name and Location)
            var tacoBell = new TacoBell
            {
                Name = name,
                Location = location
            };

            // TODO: Then, return the instance of your TacoBell class,
            // since it conforms to ITrackable
            return tacoBell;

            return null;
        }
    }
}
