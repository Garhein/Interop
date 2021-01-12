using Interop.Core.Exceptions;
using Interop.Core.Structure.Table;
using Interop.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interop.Core.Base.Parser
{
    /// <summary>
    /// Représente les options d'encodage d'un message.
    /// </summary>
    [Serializable]
    public class EncodingOptions
    {
        private EncodingCharacters  _encChars;
        private bool                _msgControlIdInMilliseconds;
        private string              _version;
        private string              _countryCode;
        private List<string>        _exportPaths;
        private bool                _createValidationFile;
        private string              _fileExtension;
        private string              _validationFileExtension;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="countryCode">Code pays exporté sur les champs <see cref="MSH.VersionId"/> (MSH-12) et <see cref="MSH.CountryCode/> (MSH-17).</param>
        /// <param name="version">Version de la norme exportée sur le champ <see cref="MSH.VersionId"/> (MSH-12).</param>
        /// <param name="exportPaths">Chemins d'export des fichiers.</param>
        /// <param name="encChars">Caractères d'encodage à utiliser.</param>
        /// <param name="fileExtension">Extension des fichiers générés.</param>
        /// <param name="validationFileExtension">Extension des fichiers de validation.</param>
        /// <param name="msgControlIdInMilliseconds">Indique si le champ <see cref="MSH.MessageControlId"/> (MSH-10) est généré en millisecondes.</param>
        /// <param name="createValidationFile">Indique si un fichier de validation doit être créé pour chaque fichier généré.</param>
        public EncodingOptions(string countryCode,
                               string version,                               
                               List<string> exportPaths,
                               EncodingCharacters encChars = null,
                               string fileExtension = null,
                               string validationFileExtension = null,
                               bool msgControlIdInMilliseconds = true,
                               bool createValidationFile = true)
        {
            if (string.IsNullOrWhiteSpace(countryCode))
            {
                throw new EncodingException($"Le code pays à exporter sur les champs {InteropUtil.ConstructFieldNumber("MSH", 12)} et {InteropUtil.ConstructFieldNumber("MSH", 17)} n'a pas été renseignée.");
            }

            if (!Structure.Table.CountryCode.Description.ContainsKey(countryCode))
            {
                throw new EncodingException($"Le code pays à exporter sur les champs {InteropUtil.ConstructFieldNumber("MSH", 12)} et {InteropUtil.ConstructFieldNumber("MSH", 17)} n'est pas valide.");
            }

            if (string.IsNullOrWhiteSpace(version))
            {
                throw new EncodingException($"La version de la norme à exporter sur le champ {InteropUtil.ConstructFieldNumber("MSH", 12)} n'a pas été renseignée.");
            }

            if (!VersionID.Description.ContainsKey(version))
            {
                throw new EncodingException($"La version de la norme à exporter sur le champ {InteropUtil.ConstructFieldNumber("MSH", 12)} n'est pas valide.");
            }

            if (exportPaths == null || !exportPaths.Any())
            {
                throw new EncodingException("Aucun chemin d'export n'a été renseigné.");
            }

            if (encChars == null)
            {
                this._encChars = new EncodingCharacters();
            }
            else
            {
                this._encChars = encChars;
            }

            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                this._fileExtension = EncoderContainer.CSTS_DEFAULT_EXTENSION_HL7;
            }
            else
            {
                this._fileExtension = fileExtension;
            }

            if (string.IsNullOrWhiteSpace(validationFileExtension))
            {
                this._validationFileExtension = EncoderContainer.CSTS_DEFAULT_EXTENSION_VALIDATION;
            }
            else
            {
                this._validationFileExtension = validationFileExtension;
            }

            this._msgControlIdInMilliseconds    = msgControlIdInMilliseconds;
            this._version                       = version;
            this._countryCode                   = countryCode;
            this._exportPaths                   = exportPaths;
            this._createValidationFile          = createValidationFile;
        }
    
        public EncodingCharacters EncodingChars
        {
            get
            {
                return this._encChars;
            }
        }

        public bool MsgControlIdInMilliseconds
        {
            get
            {
                return this._msgControlIdInMilliseconds;
            }
        }

        public string Version
        {
            get
            {
                return this._version;
            }
        }

        public string CountryCode
        {
            get
            {
                return this._countryCode;
            }
        }

        public List<string> ExportPaths
        {
            get
            {
                return this._exportPaths;
            }
        }

        public bool CreateValidationFile
        {
            get
            {
                return this._createValidationFile;
            }
        }

        public string FileExtension
        {
            get
            {
                return this._fileExtension;
            }
        }

        public string ValidationFileExtension
        {
            get
            {
                return this._validationFileExtension;
            }
        }

        /// <summary>
        /// Ajout d'un chemin à la liste des chemins d'export.
        /// </summary>
        /// <param name="exportPath">Chemin d'export à ajouter.</param>
        public void AddExportPath(string exportPath)
        {
            if (string.IsNullOrWhiteSpace(exportPath))
            {
                throw new ArgumentNullException(nameof(exportPath));
            }

            if (this._exportPaths == null)
            {
                this._exportPaths = new List<string>();
            }

            this._exportPaths.Add(exportPath);
        }
    }
}