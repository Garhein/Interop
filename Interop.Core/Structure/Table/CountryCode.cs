using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0399 - Country code.
    /// </summary>
    public struct CountryCode
    {
        public const string FRANCE = "FRA";

        /// <summary>
        /// Dictionnaire des codes associées à leur description.
        /// </summary>
        public static Dictionary<string, string> Description
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { CountryCode.FRANCE, "France" }
                };
            }
        }
    }
}