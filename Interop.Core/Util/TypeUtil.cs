using System;

namespace Interop.Core.Util
{
    /// <summary>
    /// 
    /// </summary>
    public static class TypeUtil
    {
        /// <summary>
        /// Récupère le nom du type d'une instance d'un objet.        
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetTypeName(Object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return TypeUtil.GetTypeName(obj.GetType());
        }

        /// <summary>
        /// Récupère le nom du type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetTypeName(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            string className = type.FullName;
            return className.Substring(className.LastIndexOf('.') + 1);
        }
    }
}