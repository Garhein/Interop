using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using Interop.Core.Structure.Message;
using Interop.Core.Structure.Table;
using Interop.Core.Util;
using System;
using System.Linq;

namespace Interop.Core.Base.Parser
{
    /// <summary>
    /// Conteneur de gestion de l'encodage de messages.
    /// </summary>
    public class EncoderContainer
    {
        public const string CSTS_DEFAULT_EXTENSION_HL7          = "hl7";
        public const string CSTS_DEFAULT_EXTENSION_VALIDATION   = "ok";

        private EncodingOptions _options;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="options">Options applicables à l'ensemble des messages.</param>
        public EncoderContainer(EncodingOptions options)
        {
            this._options = options;
        }

        /// <summary>
        /// Création d'un message vierge.
        /// </summary>
        /// <param name="eventType">Code de l'événement (A28, A01, ...).</param>
        /// <param name="eventOperator">Informations de la personne à l'origine de l'événement.</param>
        /// <returns></returns>
        public AbstractMessage CreateMessage(string eventType, object eventOperator)
        {
            AbstractMessage msgHL7 = null;

            if (string.IsNullOrWhiteSpace(eventType))
            {
                throw new ArgumentNullException(nameof(eventType));
            }

            if (!EventType.Description.ContainsKey(eventType))
            {
                throw new EncodingException($"L'événement '{eventType}' n'est pas implémenté par '{TypeUtil.GetTypeName(this)}'.");
            }

            switch (eventType)
            {
                case EventType.A28:
                    {
                        msgHL7 = new ADT_A28(this._options.EncodingChars, eventOperator);
                        break;
                    }
                default:
                    {
                        throw new EncodingException($"L'événement '{eventType}' n'est pas implémenté par '{TypeUtil.GetTypeName(this)}'.");                        
                    }
            }

            return msgHL7;
        }
    
        /// <summary>
        /// Encodage d'un message.
        /// </summary>
        /// <param name="message">Message à encoder.</param>
        /// <param name="createFiles">Indique si les fichiers doivent être créés.</param>
        /// <returns></returns>
        public string Encode(IMessage message, bool createFiles = true)
        {
            if (createFiles && (this._options.ExportPaths == null || !this._options.ExportPaths.Any()))
            {
                throw new EncodingException("Aucun chemin d'export n'a été renseigné.");
            }

            string dtEvent = DateTimeUtil.DateSecondeToString();

            #region Champs variables - MSH

            // MSH-1
            message.MSH.FieldSeparator.Value = this._options.EncodingChars.FieldSeparator.ToString();

            // MSH-2
            message.MSH.EncodingCharacters.Value = this._options.EncodingChars.ToString();

            // MSH-7
            message.MSH.DateTimeOfMessage.Time.Value = dtEvent;

            // MSH-10
            if (this._options.MsgControlIdInMilliseconds)
            {
                message.MSH.MessageControlId.Value = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            }
            else
            {
                message.MSH.MessageControlId.Value = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            }

            // MSH-11
#if DEBUG
            message.MSH.ProcessingId.ProcessingId.Value = ProcessingID.DEBUGGING;
#else
            message.MSH.ProcessingId.ProcessingId.Value = ProcessingID.PRODUCTION;
#endif

            // MSH-12
            message.MSH.VersionId.VersionId.Value                           = this._options.Version;
            message.MSH.VersionId.InternationalizationCode.Identifier.Value = this._options.CountryCode;
            message.MSH.VersionId.InternationalizationCode.Text.Value       = CountryCode.Description[this._options.CountryCode];
            message.MSH.VersionId.InternationalVersionId.Identifier.Value   = this._options.Version;

            // MSH-17
            message.MSH.CountryCode.Value = this._options.CountryCode;

            #endregion

            #region Champs variables - EVN

            // EVN-2
            message.EVN.RecordedDateTime.Time.Value = dtEvent;

            // TODO: initialize EVN-5
            if (message.EventOperator != null)
            {

            }

            #endregion

            #region Encodage, création des fichiers et retour

            string encodingText = PipeParser.Encode(message);

            if (createFiles)
            {
                foreach (string path in this._options.ExportPaths)
                {
                    // TODO: pouvoir choisir de préfixer/suffixer avec le type d'événement (A28, A01, ...)
                    string fileName     = DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
                    bool errCreateFile  = false;

                    try
                    {                        
                        FileUtil.CreateFile(fileName, this._options.FileExtension, encodingText, path);
                    }
                    catch
                    {
                        errCreateFile = true;
                        throw;
                    }
                    finally
                    {
                        if (!errCreateFile && this._options.CreateValidationFile)
                        {                            
                            FileUtil.CreateFile(fileName, this._options.ValidationFileExtension, encodingText, path);
                        }
                    }
                }
            }

            return encodingText;

            #endregion
        }
    }
}