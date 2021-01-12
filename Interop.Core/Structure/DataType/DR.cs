using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// DR - Date/Time Range.
    /// </summary>
    [Serializable]
    public class DR : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public DR(string description, int maxLength, bool required) : base(description, maxLength, required, 2)
        {
            this[1] = new TS("Range Start Date/Time", 25, false);
            this[2] = new TS("Range End Date/Time", 25, false);
        }

        /// <summary>
        /// DR.1 - Range Start Date/Time.
        /// </summary>
        public TS RangeStartDateTime
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this[1] as TS;
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
        /// DR.2 - Range End Date/Time.
        /// </summary>
        public TS RangeEndDateTime
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this[2] as TS;
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
                catch (DataTypeException ex)
                {
                    throw new Exception("Une erreur inattendue est a été détectée.", ex);
                }
            }
        }
    }
}