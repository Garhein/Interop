using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// PT - Processing Type.
    /// </summary>
    [Serializable]
    public class PT : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public PT(string description, int maxLength, bool required) : base(description, maxLength, required, 2)
        {
            this[1] = new ID("Processing Id", 1, false);
            this[2] = new ID("Processing Mode", 1, false);
        }

        /// <summary>
        /// PT.1 - Processing Id.
        /// </summary>
        public ID ProcessingId
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[1] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[1] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// PT.2 - Processing Mode.
        /// </summary>
        public ID ProcessingMode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[2] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[2] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }
    }
}