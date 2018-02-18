namespace Edusharp.Troelsen.Unit4
{
    public class DatabaseReader
    {
        public int? numerricValue = null;
        public bool? boolValue = true;

        public int? GetIntFromDatabase()
        {
            return numerricValue;
        }

        public bool? GetBollFromDatabase()
        {
            return boolValue;
        }
    }
}