using Interop.Core.Base.Model;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// ST - String Data.
    /// </summary>
    [Serializable]
    public class ST : AbstractTypePrimitive
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>
        public ST(string description, int maxLength, bool required) : base(description, maxLength, required) { }
    }
}