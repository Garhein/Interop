using System;

namespace Interop.Core.Util
{
    /// <summary>
    /// Fonctions de manipulation des dates/heures.
    /// </summary>
    public static class DateTimeUtil
    {
        private const string FORMAT_DATE            = "yyyyMMdd";
        private const string FORMAT_DATE_MINUTE     = "yyyyMMddHHmm";
        private const string FORMAT_DATE_SECONDE    = "yyyyMMddHHmmss";

        /// <summary>
        /// Récupère la date courante au format YYYYMMDD.
        /// </summary>
        /// <returns></returns>
        public static string DateToString()
        {
            return DateTimeUtil.DateToString(DateTime.Now);
        }

        /// <summary>
        /// Récupère la date au format YYYYMMDD.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateToString(DateTime dt)
        {
            return dt.ToString(DateTimeUtil.FORMAT_DATE);
        }

        /// <summary>
        /// Récupère la date courante au format YYYYMMDDHHMM.
        /// </summary>
        /// <returns></returns>
        public static string DateMinuteToString()
        {
            return DateTimeUtil.DateMinuteToString(DateTime.Now);
        }

        /// <summary>
        /// Récupère la date au format YYYYMMDDHHMM.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateMinuteToString(DateTime dt)
        {
            return dt.ToString(DateTimeUtil.FORMAT_DATE_MINUTE);
        }

        /// <summary>
        /// Récupère la date courante au format YYYYMMDDHHMMSS.
        /// </summary>
        /// <returns></returns>
        public static string DateSecondeToString()
        {
            return DateTimeUtil.DateSecondeToString(DateTime.Now);
        }

        /// <summary>
        /// Récupère la date au format YYYYMMDDHHMMSS.
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string DateSecondeToString(DateTime dt)
        {
            return dt.ToString(DateTimeUtil.FORMAT_DATE_SECONDE);
        }
    }
}