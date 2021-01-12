using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0003 - Event type.
    /// </summary>
    public struct EventType
    {
        public const string A28 = "A28";

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
                    { EventType.A28, "ADT/ACK - Add person information" }
                };
            }
        }
    }
}