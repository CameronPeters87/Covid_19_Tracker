using System.Threading.Tasks;

namespace CovidTracker.Extensions
{
    public static class Helper
    {
        public static async Task<string> FormatIntToString(int integerValue)
        {
            return integerValue.ToString("N0");
        }
    }
}