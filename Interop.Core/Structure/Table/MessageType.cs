using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0076 - Message type.
    /// </summary>
    public struct MessageType
    {
        public const string ADT = "ADT";

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
                    { MessageType.ADT, "ADT message" }
                };
            }
        }
    }
}