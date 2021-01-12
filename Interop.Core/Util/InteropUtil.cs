using System;

namespace Interop.Core.Util
{
    /// <summary>
    /// Fonctions utilitaires.
    /// </summary>
    public static class InteropUtil
    {
        /// <summary>
        /// Indique si le segment définit les caractères d'encodage.
        /// </summary>
        /// <param name="segmentName">Nom du segment.</param>
        /// <returns></returns>
        public static bool IsSegmentDefDelimiters(string segmentName)
        {
            return segmentName.Equals("MSH") || segmentName.Equals("FHS") || segmentName.Equals("BHS");
        }

        /// <summary>        
        /// Construit la numérotation d'un champ.
        /// </summary>
        /// <param name="segmentName">Nom du segment.</param>
        /// <param name="numField">Numéro du champ.</param>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <param name="numSubComponent">Numéro du sous-composant.</param>
        /// <returns></returns>
        public static string ConstructFieldNumber(string segmentName, int numField, int? numRepetition = null, int? numSubComponent = null)
        {
            if (string.IsNullOrWhiteSpace(segmentName))
            {
                throw new ArgumentNullException(nameof(segmentName));
            }

            if (numField <= 0)
            {
                throw new ArgumentException($"Numéro de champ non valide.");
            }

            string retVal = $"{segmentName}-{numField}";

            if (numRepetition.HasValue && numRepetition.Value > 0)
            {
                retVal += $".{numRepetition.Value}";

                if (numSubComponent.HasValue && numSubComponent.Value > 0)
                {
                    retVal += $"/{numSubComponent}";
                }
            }

            return retVal;
        }
    
        /// <summary>
        /// Retrait des séparateurs inutiles.
        /// </summary>
        /// <param name="strToSanitize">Données à nettoyer.</param>
        /// <param name="delimiter">Séparateur à traiter.</param>
        /// <returns></returns>
        public static string RemoveExtraDelimiters(string strToSanitize, char delimiter)
        {
            char[] chars = strToSanitize.ToCharArray();

            // Recherche depuis la fin du 1er caractère qui ne correspond pas au séparateur
            int length = chars.Length - 1;
            bool found = false;

            while (length >= 0 && !found)
            {
                if (chars[length] != delimiter)
                {
                    found = true;
                }
                else
                {
                    length--;
                }
            }

            string ret = string.Empty;

            if (found)
            {
                ret = new string(chars, 0, length + 1);
            }

            return ret;
        }
    }
}