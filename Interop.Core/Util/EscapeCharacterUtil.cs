using Interop.Core.Base.Parser;
using System.Text;

namespace Interop.Core.Util
{
    /// <summary>
    /// Fonctions d'échappement des caractères.
    /// </summary>
    public static class EscapeCharacterUtil
    {
        private const string CSTS_ESCAPE_FIELD          = @"\F\";
        private const string CSTS_ESCAPE_COMPONENT      = @"\S\";
        private const string CSTS_ESCAPE_REPETITION     = @"\R\";
        private const string CSTS_ESCAPE_CHAR           = @"\E\";
        private const string CSTS_ESCAPE_SUBCOMPONENT   = @"\T\";

        /// <summary>
        /// Échappement des caractères réservés.
        /// </summary>
        /// <param name="data">Données à échapper.</param>
        /// <param name="encChars">Caractères d'encodage utilisés.</param>
        /// <returns></returns>
        public static string Escape(string data, EncodingCharacters encChars)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return string.Empty;
            }

            char[] dataAsChar = data.ToCharArray();
            StringBuilder ret = new StringBuilder();

            for (int i = 0; i < dataAsChar.Length; i++)
            {
                if (dataAsChar[i].Equals(encChars.FieldSeparator))
                {
                    ret.Append(EscapeCharacterUtil.CSTS_ESCAPE_FIELD);
                }
                else if (dataAsChar[i].Equals(encChars.ComponentSeparator))
                {
                    ret.Append(EscapeCharacterUtil.CSTS_ESCAPE_COMPONENT);
                }
                else if (dataAsChar[i].Equals(encChars.RepetitionSeparator))
                {
                    ret.Append(EscapeCharacterUtil.CSTS_ESCAPE_REPETITION);
                }
                else if (dataAsChar[i].Equals(encChars.EscapeCharacter))
                {
                    ret.Append(EscapeCharacterUtil.CSTS_ESCAPE_CHAR);
                }
                else if (dataAsChar[i].Equals(encChars.SubComponentSeparator))
                {
                    ret.Append(EscapeCharacterUtil.CSTS_ESCAPE_SUBCOMPONENT);
                }
                else
                {
                    ret.Append(dataAsChar[i]);
                }
            }

            if (ret.Length > 0)
            {
                return ret.ToString().Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Échappement des caractères réservés.
        /// </summary>
        /// <param name="data">Données à échapper.</param>
        /// <param name="encChars">Caractères d'encodage utilisés.</param>
        /// <returns></returns>
        public static string Unescape(string data, EncodingCharacters encChars)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return string.Empty;
            }

            data = data.Replace(EscapeCharacterUtil.CSTS_ESCAPE_FIELD, encChars.FieldSeparator.ToString());
            data = data.Replace(EscapeCharacterUtil.CSTS_ESCAPE_COMPONENT, encChars.ComponentSeparator.ToString());
            data = data.Replace(EscapeCharacterUtil.CSTS_ESCAPE_REPETITION, encChars.RepetitionSeparator.ToString());
            data = data.Replace(EscapeCharacterUtil.CSTS_ESCAPE_CHAR, encChars.EscapeCharacter.ToString());
            data = data.Replace(EscapeCharacterUtil.CSTS_ESCAPE_SUBCOMPONENT, encChars.SubComponentSeparator.ToString());

            return data;
        }
    }
}