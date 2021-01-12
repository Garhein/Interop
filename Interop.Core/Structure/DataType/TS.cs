using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// TS - Time Stamp.
    /// </summary>
    [Serializable]
    public class TS : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public TS(string description, int maxLength, bool required) : base(description, maxLength, required, 2)
        {
            this[1] = new DTM("Time", 24, true);
            this[2] = new ID("Degree Of Precision", 1, false);
        }

        /// <summary>
        /// TS.1 - Time.
        /// </summary>
        public DTM Time
        {
            get
            {
                DTM ret = null;

                try
                {
                    ret = this[1] as DTM;
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
        /// TS.2 - Degree Of Precision.
        /// </summary>
        public ID DegreeOfPrecision
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