using System;

namespace Interop.Core.Exceptions
{
    /// <summary>
    /// Exceptions levées/interceptées au niveau de l'encodage d'un message.
    /// </summary>
    [Serializable]
    public class EncodingException : Exception
    {
        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public EncodingException() { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        public EncodingException(string message) : base(message) { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        /// <param name="inner">Exception interne.</param>
        public EncodingException(string message, Exception inner) : base(message, inner) { }
    }
}