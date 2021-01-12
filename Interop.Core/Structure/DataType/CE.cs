using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// CE - Coded Element.
    /// </summary>
    [Serializable]
    public class CE : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public CE(string description, int maxLength, bool required) : base(description, maxLength, required, 6)
        {
            this[1] = new ST("Identifier", 20, false);
            this[2] = new ST("Text", 199, false);
            this[3] = new ID("Name Of Coding System", 20, false);
            this[4] = new ST("Alternate Identifier", 20, false);
            this[5] = new ST("Alternate Text", 199, false);
            this[6] = new ID("Name Of Alternate Coding System", 20, false);
        }

        /// <summary>
        /// CE.1 - Identifier.
        /// </summary>
        public ST Identifier
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[1] as ST;
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
        /// CE.2 - Text.
        /// </summary>
        public ST Text
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[2] as ST;
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
        /// CE.3 - Name Of Coding System.
        /// </summary>
        public ID NameOfCodingSystem
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[3] as ID;
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

        /// <summary>
        /// CE.4 - Alternate Identifier.
        /// </summary>
        public ST AlternateIdentifier
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[4] as ST;
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
                    this[4] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// CE.5 - Alternate Text.
        /// </summary>
        public ST AlternateText
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[5] as ST;
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
                    this[5] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// CE.6 - Name Of Alternate Coding System.
        /// </summary>
        public ID NameOfAlternateCodingSystem
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[6] as ID;
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
                    this[6] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }
    }
}