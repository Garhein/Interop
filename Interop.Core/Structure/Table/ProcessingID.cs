using System.Collections.Generic;

namespace Interop.Core.Structure.Table
{
    /// <summary>
    /// 0103 - Processing ID.
    /// </summary>
    public struct ProcessingID
    {
        public const string DEBUGGING   = "D";
        public const string PRODUCTION  = "P";
        public const string TRAINING    = "T";

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
                    { ProcessingID.DEBUGGING, "Debugging" },
                    { ProcessingID.PRODUCTION, "Production" },
                    { ProcessingID.TRAINING, "Training" }
                };
            }
        }
    }
}