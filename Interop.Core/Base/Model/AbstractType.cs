using Interop.Core.Util;

namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Représente un type de données.
    /// </summary>
    public abstract class AbstractType : IType
    {
        private string  _description;
        private int     _maxLength;
        private bool    _required;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>
        public AbstractType(string description, int maxLength, bool required)
        {
            this._description   = description;
            this._maxLength     = maxLength;
            this._required      = required;
        }

        /// <summary>
        /// Description de la donnée.
        /// </summary>
        public string Description
        {
            get
            {
                return this._description;
            }
        }

        /// <summary>
        /// Longueur maximale autorisée.
        /// </summary>
        public int MaxLength
        {
            get
            {
                return this._maxLength > 0 ? this._maxLength : int.MaxValue;
            }
        }

        /// <summary>
        /// Indique si la donnée est obligatoire.
        /// </summary>
        public bool IsRequired
        {
            get
            {
                return this._required;
            }
        }

        #region Implémentations

        /// <summary>
        /// Récupère le nom du type de données.
        /// </summary>
        public string TypeName 
        {
            get
            {
                return TypeUtil.GetTypeName(this);
            }
        }

        #endregion
    }
}