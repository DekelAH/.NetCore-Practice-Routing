using Microsoft.Extensions.Primitives;

namespace CountriesAppRoutingPractice.Data
{
    public static class CountriesData
    {
        #region Fields

        private static readonly Dictionary<int, StringValues> _countriesData = new()
        {
            { 1, "United States" },
            { 2, "Canda" },
            { 3, "United Kingdom" },
            { 4, "India" },
            { 5, "Japan" },

        };

        #endregion

        #region Properties

        public static Dictionary<int, StringValues> GetCountriesData => _countriesData;

        #endregion
    }
}
