using Interop.Core.Base.Parser;
using Interop.Core.Structure.Segment;

namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Définition des comportements communs aux messages.
    /// </summary>
    public interface IMessage
    {       
        /// <summary>
        /// Récupère les caractères d'encodage utilisés par le message.
        /// </summary>
        EncodingCharacters EncodingCharacters { get; }

        /// <summary>
        /// Récupère les informations de la personne à l'origine de l'événement.
        /// </summary>
        object EventOperator { get; }

        /// <summary>
        /// Segment MSH.
        /// </summary>
        MSH MSH { get; }

        /// <summary>
        /// Segment EVN.
        /// </summary>
        EVN EVN { get; }

        /// <summary>
        /// Récupère le nombre de groupements de segments.
        /// </summary>
        int CountStructure { get; }

        /// <summary>
        /// Récupère une répétition d'un groupement de segments.
        /// Les groupements sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="name">Nom du groupement.</param>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        ISegment GetSegment(string name, int numRepetition);

        // TODO: MessageItem GetStructure(string name);
        /// <summary>
        /// Récupère un groupement de segments.
        /// </summary>
        /// <param name="name">Nom du groupement.</param>
        /// <returns></returns>
        /// MessageItem GetStructure(string name);
        
        /// <summary>
        /// Récupère un groupement de segments.
        /// Les groupements sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="numGroupement">Numéro du groupement.</param>
        /// <returns></returns>
        MessageItem GetStructure(int numGroupement);
    }
}