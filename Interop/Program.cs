using Interop.Core.Base.Model;
using Interop.Core.Base.Parser;
using Interop.Core.Structure.Table;
using System;
using System.Collections.Generic;

namespace Interop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Message *****");

            EncodingOptions options = new EncodingOptions(
                "FRA",
                VersionID.V2_5_1,
                new List<string>()
                {
                    "C:\\Users\\Xavier\\Documents\\Sources\\NET\\HL7\\REP1",
                    "C:\\Users\\Xavier\\Documents\\Sources\\NET\\HL7\\REP2",
                    "C:\\Users\\Xavier\\Documents\\Sources\\NET\\HL7\\REP3"
                },
                new EncodingCharacters());

            EncoderContainer encoder = new EncoderContainer(options);
            AbstractMessage msgA28   = encoder.CreateMessage("A28", null);
            string retEncode         = encoder.Encode(msgA28, true);

            Console.WriteLine($"Encode = {retEncode}");
            Console.WriteLine($"Full   = {msgA28.GetType().FullName}");
        }
    }
}
