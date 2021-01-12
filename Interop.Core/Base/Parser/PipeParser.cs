using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using Interop.Core.Util;
using System.Text;

namespace Interop.Core.Base.Parser
{
    public static class PipeParser
    {
        private const char SEG_DELIMITER = '\r';

        #region Encode

        /// <summary>
        /// Encode un message.
        /// </summary>
        /// <param name="message">Message à encoder.</param>
        /// <returns></returns>
        public static string Encode(IMessage message)
        {
            StringBuilder retMessage = new StringBuilder();

            for (int i = 0; i < message.CountStructure; i++)
            {
                int pos          = i + 1;
                MessageItem item = message.GetStructure(pos);

                if (item.Repetitions.Count > 0)
                {
                    foreach (ISegment segment in item.Repetitions)
                    {
                        string segString = PipeParser.Encode(segment, message.EncodingCharacters);
                        if (!string.IsNullOrWhiteSpace(segString) && segString.Length >= 4)
                        {
                            retMessage.Append(segString);
                            retMessage.Append(PipeParser.SEG_DELIMITER);
                        }
                    }
                }
            }

            return retMessage.ToString();
        }

        /// <summary>
        /// Encode un segment.
        /// </summary>
        /// <param name="segment">Segment à encoder.</param>
        /// <param name="encChars">Caractères d'encodage utilisés.</param>
        /// <returns></returns>
        public static string Encode(ISegment segment, EncodingCharacters encChars)
        {
            StringBuilder retSegment = new StringBuilder();

            // Code du segment et premier séparateur de champ
            retSegment.Append(segment.SegmentName);
            retSegment.Append(encChars.FieldSeparator);

            // Si segment MSH : position de départ sur MSH-2 car MSH-1 correspond au séparateur de champ
            int startPos = InteropUtil.IsSegmentDefDelimiters(segment.SegmentName) ? 2 : 1;

            // Parcours des champs
            for (int i = startPos; i <= segment.Fields.Count; i++)
            {
                try
                {
                    // Parcours des répétitions
                    IType[] repetitions = segment.GetField(i);

                    for (int j = 0; j < repetitions.Length; j++)
                    {
                        string repValue = PipeParser.Encode(repetitions[j], encChars);

                        // Si MSH-2 : il faut annuler l'échappement des caractères réservés
                        if (InteropUtil.IsSegmentDefDelimiters(segment.SegmentName) && i == 2)
                        {
                            repValue = EscapeCharacterUtil.Unescape(repValue, encChars);
                        }

                        retSegment.Append(repValue);

                        if (j < repetitions.Length - 1)
                        {
                            retSegment.Append(encChars.RepetitionSeparator);
                        }
                    }
                }
                catch
                {
                    throw;
                }                
                
                retSegment.Append(encChars.FieldSeparator);                
            }

            return InteropUtil.RemoveExtraDelimiters(retSegment.ToString(), encChars.FieldSeparator);
        }

        /// <summary>
        /// Encode du type de données.
        /// </summary>
        /// <param name="type">Type de données à encoder.</param>
        /// <param name="encChars">Caractères d'encodage utilisés.</param>
        /// <param name="subComponent">Indique si l'on encode un sous-composant.</param>
        /// <returns></returns>
        public static string Encode(IType type, EncodingCharacters encChars, bool subComponent = false)
        {
            StringBuilder retType = new StringBuilder();

            if (type is ITypePrimitive)
            {
                ITypePrimitive primitive = type as ITypePrimitive;
                if (primitive == null)
                {
                    throw new EncodingException("Une erreur s'est produite à la conversion de 'IType' vers 'ITypePrimitive'.");
                }
                else
                {
                    retType.Append(PipeParser.Encode(primitive, encChars));
                }
            }
            else
            {
                ITypeComposite composite = type as ITypeComposite;
                if (composite == null)
                {
                    throw new EncodingException("Une erreur s'est produite à la conversion de 'IType' vers 'ITypeComposite'.");
                }
                else
                {
                    StringBuilder retComp = new StringBuilder();
                    char compDelimiter    = subComponent ? encChars.SubComponentSeparator : encChars.ComponentSeparator;

                    for (int i = 0; i < composite.Components.Length; i++)
                    {
                        retComp.Append(PipeParser.Encode(composite.Components[i], encChars, true));
                        if (i < composite.Components.Length - 1)
                        {
                            retComp.Append(compDelimiter);
                        }
                    }

                    retType.Append(InteropUtil.RemoveExtraDelimiters(retComp.ToString(), compDelimiter));
                }
            }

            return retType.ToString();
        }

        /// <summary>
        /// Encode un type de données primitif.
        /// </summary>
        /// <param name="primitive">Type de données à encoder.</param>
        /// <param name="encChars">Caractères d'encodage utilisés.</param>
        /// <returns></returns>
        public static string Encode(ITypePrimitive primitive, EncodingCharacters encChars)
        {
            return EscapeCharacterUtil.Escape(primitive.Value, encChars);
        }

        #endregion
    }
}