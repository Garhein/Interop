using System;
using System.IO;
using System.Text;

namespace Interop.Core.Util
{
    /// <summary>
    /// Fonctions de manipulation des fichiers.
    /// </summary>
    public static class FileUtil
    {
        /// <summary>
        /// Nettoie une extension de fichier.
        /// </summary>
        /// <param name="extension">Extension à vérifier et nettoyer.</param>
        /// <returns></returns>
        public static string CheckAndSanitizeFileExtension(string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
            {
                throw new ArgumentNullException(nameof(extension));
            }
            else if (extension.Equals("."))
            {
                throw new ArgumentException("Extension non valide.");
            }

            if (extension.Substring(0, 1).Equals("."))
            {
                return extension.Substring(1);
            }
            else
            {
                return extension;
            }
        }
        
        /// <summary>
        /// Crée un fichier.
        /// </summary>
        /// <param name="name">Nom du fichier.</param>
        /// <param name="extension">Extension du fichier.</param>
        /// <param name="content">Contenu du fichier.</param>
        /// <param name="dirPath">Chemin du répertoire de création.</param>
        /// <param name="overwrite">Indique si on écrase le fichier portant le même nom.</param>
        /// <param name="encoding">Encodage du fichier.</param>
        public static void CreateFile(string name,
                                      string extension,
                                      string content,
                                      string dirPath,
                                      bool overwrite = true,
                                      Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(dirPath))
            {
                throw new ArgumentNullException(nameof(dirPath));
            }

            if (!Directory.Exists(dirPath))
            {
                throw new DirectoryNotFoundException($"Le répertoire '{dirPath}' n'existe pas.");
            }
                        
            string pathFile = Path.Combine(dirPath, $"{name}.{FileUtil.CheckAndSanitizeFileExtension(extension)}");

            if (!overwrite && File.Exists(pathFile))
            {
                throw new IOException($"Le fichier '{pathFile}' existe déjà.");
            }
            
            if (encoding == null)
            {
                encoding = Encoding.Default;
            }

            using (StreamWriter writer = new StreamWriter(pathFile, !overwrite, encoding))
            {
                writer.Write(content);
            }
        }
    }
}