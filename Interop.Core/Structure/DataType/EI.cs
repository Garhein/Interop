using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// EI - Entity Identifier.
    /// </summary>
    [Serializable]
    public class EI : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public EI(string description, int maxLength, bool required) : base(description, maxLength, required, 4)
        {
            this[1] = new ST("Entity Identifier", 199, false);
            this[2] = new IS("Namespace Id", 20, false);
            this[3] = new ST("Universal Id", 199, false);
            this[4] = new ID("Universal Id Type", 6, false);
        }

        /// <summary>
        /// EI.1 - Entity Identifier.
        /// </summary>
        public ST EntityIdentifier
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
        /// EI.2 - Namespace Id.
        /// </summary>
        public IS NamespaceId
        {
            get
            {
                IS ret = null;

                try
                {
                    ret = this[2] as IS;
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
        /// EI.3 - Universal Id.
        /// </summary>
        public ST UniversalId
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[3] as ST;
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
        /// EI.4 - Universal Id Type.
        /// </summary>
        public ID UniversalIdType
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[4] as ID;
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
    }
}