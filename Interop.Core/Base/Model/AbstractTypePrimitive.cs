namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Représente un type de données primitif, c'est-à-dire composé d'une seule valeur.
    /// </summary>
    public abstract class AbstractTypePrimitive : AbstractType, ITypePrimitive
    {
        private string _value;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>
        public AbstractTypePrimitive(string description, int maxLength, bool required) : base(description, maxLength, required) { }

        #region Implémentations

        /// <summary>
        /// Affecte et récupère la valeur du type de données.
        /// </summary>
        public string Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }

        #endregion
    }
}