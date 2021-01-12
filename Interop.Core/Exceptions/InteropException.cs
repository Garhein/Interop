using System;

namespace Interop.Core.Exceptions
{
    /// <summary>
    /// Classe de base des exceptions levées/interceptées.
    /// </summary>
    [Serializable]
    public class InteropException : Exception
    {
        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public InteropException() { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        public InteropException(string message) : base(message) { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        /// <param name="inner">Exception interne.</param>
        public InteropException(string message, Exception inner) : base(message, inner) { }
    }
}