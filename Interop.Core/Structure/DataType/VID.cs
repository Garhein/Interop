using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// VID - Version Identifier.
    /// </summary>
    [Serializable]
    public class VID : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public VID(string description, int maxLength, bool required) : base(description, maxLength, required, 3)
        {
            this[1] = new ID("Version Id", 5, false);
            this[2] = new CE("Internationalization Code", 483, false);
            this[3] = new CE("International Version Id", 483, false);
        }

        /// <summary>
        /// VID.1 - Version Id.
        /// </summary>
        public ID VersionId
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
        /// VID.2 - Internationalization Code.
        /// </summary>
        public CE InternationalizationCode
        {
            get
            {
                CE ret = null;

                try
                {
                    ret = this[2] as CE;
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

        /// <summary>
        /// VID.3 - International Version Id.
        /// </summary>
        public CE InternationalVersionId
        {
            get
            {
                CE ret = null;

                try
                {
                    ret = this[3] as CE;
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
                    this[3] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }
    }
}