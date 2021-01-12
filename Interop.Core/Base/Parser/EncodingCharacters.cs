using System;
using System.Text;

namespace Interop.Core.Base.Parser
{
    /// <summary>
    /// Représente les caractères d'encodage d'un message.
    /// </summary>
    [Serializable]
    public class EncodingCharacters
    {
        public const char DEF_FIELD_SEP         = '|';
        public const char DEF_COMPONENT_SEP     = '^';
        public const char DEF_REPETITION_SEP    = '~';
        public const char DEF_ESCAPE_CHAR       = '\\';
        public const char DEF_SUB_COMPONENT_SEP = '&';

        private char    _fieldSeparator;
        private char[]  _encodingCharacters;

        /// <summary>
        /// Constructeur vide initialisant les caractères d'encodage à leur valeur par défaut.
        /// </summary>
        public EncodingCharacters()
        {
            this._fieldSeparator        = EncodingCharacters.DEF_FIELD_SEP;

            this._encodingCharacters    = new char[4];
            this._encodingCharacters[0] = EncodingCharacters.DEF_COMPONENT_SEP;
            this._encodingCharacters[1] = EncodingCharacters.DEF_REPETITION_SEP;
            this._encodingCharacters[2] = EncodingCharacters.DEF_ESCAPE_CHAR;
            this._encodingCharacters[3] = EncodingCharacters.DEF_SUB_COMPONENT_SEP;
        }

        /// <summary>
        /// Constructeur.
        /// Si les valeurs sont incorrectes les caractères d'encodage sont initialisés à leur valeur par défaut.
        /// </summary>
        /// <param name="fieldSeparator">Séparateur de champ.</param>
        /// <param name="encodingCharacters">Caractères d'encodage.</param>
        public EncodingCharacters(char fieldSeparator, string encodingCharacters)
        {
            if (char.IsWhiteSpace(fieldSeparator))
            {
                this._fieldSeparator = EncodingCharacters.DEF_FIELD_SEP;
            }
            else
            {
                this._fieldSeparator = fieldSeparator;
            }

            if (string.IsNullOrWhiteSpace(encodingCharacters) || encodingCharacters.Length < 4)
            {
                this._encodingCharacters = new char[4];
                this._encodingCharacters[0] = EncodingCharacters.DEF_COMPONENT_SEP;
                this._encodingCharacters[1] = EncodingCharacters.DEF_REPETITION_SEP;
                this._encodingCharacters[2] = EncodingCharacters.DEF_ESCAPE_CHAR;
                this._encodingCharacters[3] = EncodingCharacters.DEF_SUB_COMPONENT_SEP;
            }
            else
            {
                this._encodingCharacters = encodingCharacters.ToCharArray(0, 4);
            }
        }
    
        /// <summary>
        /// Affecte et récupère le séparateur de champ.
        /// </summary>
        public char FieldSeparator
        {
            get
            {
                return this._fieldSeparator;
            }
            set
            {
                this._fieldSeparator = value;
            }
        }

        /// <summary>
        /// Affecte et récupère le séparateur de composant.
        /// </summary>
        public char ComponentSeparator
        {
            get
            {
                return this._encodingCharacters[0];
            }
            set
            {
                this._encodingCharacters[0] = value;
            }
        }

        /// <summary>
        /// Affecte et récupère le séparateur de répétition.
        /// </summary>
        public char RepetitionSeparator
        {
            get
            {
                return this._encodingCharacters[1];
            }
            set
            {
                this._encodingCharacters[1] = value;
            }
        }

        /// <summary>
        /// Affecte et récupère le caractère d'échappement.
        /// </summary>
        public char EscapeCharacter
        {
            get
            {
                return this._encodingCharacters[2];
            }
            set
            {
                this._encodingCharacters[2] = value;
            }
        }

        /// <summary>
        /// Affecte et récupère le séparateur de sous-composant.
        /// </summary>
        public char SubComponentSeparator
        {
            get
            {
                return this._encodingCharacters[3];
            }
            set
            {
                this._encodingCharacters[3] = value;
            }
        }

        /// <summary>
        /// Construction des caractères d'encodage, séparateur de champ exclu.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            foreach (char encodingChar in this._encodingCharacters)
            {
                ret.Append(encodingChar);
            }

            return ret.ToString();
        }
    }
}