using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0354 - Message structure.
    /// </summary>
    public struct MessageStructure
    {
        public const string ADT_A05 = "ADT_A05";

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
                    { MessageStructure.ADT_A05, "A05, A14, A28, A31" }
                };
            }
        }
    }
}