using Interop.Core.Base.Model;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// ID - Coded values for HL7 tables.
    /// </summary>
    [Serializable]
    public class ID : AbstractTypePrimitive
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>
        public ID(string description, int maxLength, bool required) : base(description, maxLength, required) { }
    }
}