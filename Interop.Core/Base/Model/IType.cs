namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Définition des comportements communs aux types de données.
    /// </summary>
    public interface IType
    {
        /// <summary>
        /// Récupère le nom du type de données.
        /// </summary>
        string TypeName { get; }
    }
}