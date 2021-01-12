using Interop.Core.Base.Model;
using Interop.Core.Base.Parser;
using Interop.Core.Structure.Table;

namespace Interop.Core.Structure.Message
{
    public class ADT_A28 : AbstractMessage
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="encChars">Caractères d'encodage utilisés par le message.</param>
        /// <param name="eventOperator">Informations de la personne à l'origine de l'événement.</param>
        public ADT_A28(EncodingCharacters encChars, object eventOperator)
                      : base(encChars, eventOperator, MessageType.ADT, EventType.A28, MessageStructure.ADT_A05) { }
    }
}