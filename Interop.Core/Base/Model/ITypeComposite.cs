namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Définition des comportements communs aux types de données composites.
    /// </summary>
    public interface ITypeComposite
    {
        /// <summary>
        /// Récupère les composants du type de données.
        /// </summary>
        IType[] Components { get; }

        /// <summary>
        /// Affecte et récupère un composant précis du type de données.
        /// Les composants sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="index">Index du composant.</param>
        /// <returns>Composant de type <see cref="IType"/>.</returns>
        IType this[int index] { get; set; }
    }
}