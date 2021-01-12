using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0104 - Version ID.
    /// </summary>
    public struct VersionID
    {
        public const string V2_0    = "2.0";
        public const string V2_0D   = "2.0D";
        public const string V2_1    = "2.1";
        public const string V2_2    = "2.2";
        public const string V2_3    = "2.3";
        public const string V2_3_1  = "2.3.1";
        public const string V2_4    = "2.4";
        public const string V2_5    = "2.5";
        public const string V2_5_1  = "2.5.1";

        /// <summary>
        /// Dictionnaire des codes associés à leur description.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> Description
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { VersionID.V2_0, "Release 2.0" },
                    { VersionID.V2_0D, "Demo 2.0" },
                    { VersionID.V2_1, "Release 2.1" },
                    { VersionID.V2_2, "Release 2.2" },
                    { VersionID.V2_3, "Release 2.3" },
                    { VersionID.V2_3_1, "Release 2.3.1" },
                    { VersionID.V2_4, "Release 2.4" },
                    { VersionID.V2_5, "Release 2.5" },
                    { VersionID.V2_5_1, "Release 2.5.1" }
                };
            }
        }
    }
}