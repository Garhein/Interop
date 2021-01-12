using System;

namespace Interop.Core.Exceptions
{
    /// <summary>
    /// Exceptions levées/interceptées au niveau de la gestion des segments.
    /// </summary>
    [Serializable]
    public class SegmentException : Exception
    {
        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public SegmentException() { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        public SegmentException(string message) : base(message) { }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="message">Message de l'exception.</param>
        /// <param name="inner">Exception interne.</param>
        public SegmentException(string message, Exception inner) : base(message, inner) { }
    }
}