using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using Interop.Core.Structure.DataType;
using System;

namespace Interop.Core.Structure.Segment
{
    /// <summary>
    /// MSH - Message Header.
    /// </summary>
    [Serializable]
    public class MSH : AbstractSegment
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public MSH()
        {
            this.InitField(typeof(ST), "Field Separator", 1, 1, true);
            this.InitField(typeof(ST), "Encoding Characters", 4, 1, true);
            this.InitField(typeof(HD), "Sending Application", 227, 1, false);
            this.InitField(typeof(HD), "Sending Facility", 227, 1, false);
            this.InitField(typeof(HD), "Receiving Application", 227, 1, false);
            this.InitField(typeof(HD), "Receiving Facility", 227, 1, false);
            this.InitField(typeof(TS), "Date/Time Of Message", 26, 1, true);
            this.InitField(typeof(ST), "Security", 40, 1, false);
            this.InitField(typeof(MSG), "Message Type", 15, 1, true);
            this.InitField(typeof(ST), "Message Control Id", 20, 1, true);
            this.InitField(typeof(PT), "Processing Id", 3, 1, true);
            this.InitField(typeof(VID), "Version Id", 60, 1, true);
            this.InitField(typeof(NM), "Sequence Number", 15, 1, false);
            this.InitField(typeof(ST), "Continuation Pointer", 180, 1, false);
            this.InitField(typeof(ID), "Accept Acknowledgment Type", 2, 1, false);
            this.InitField(typeof(ID), "Application Acknowledgment Type", 2, 1, false);
            this.InitField(typeof(ID), "Country Code", 3, 1, false);
            this.InitField(typeof(ID), "Character Set", 16, 0, false);
            this.InitField(typeof(CE), "Principal Language Of Message", 250, 1, false);
            this.InitField(typeof(ID), "Alternate Character Set Handling Scheme", 20, 1, false);
            this.InitField(typeof(EI), "Message Profile Identifier", 427, 0, false);
        }

        /// <summary>
        /// Field Separator (MSH-1).
        /// </summary>
        public ST FieldSeparator
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this.GetField(1, 1) as ST;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Encoding Characters (MSH-2).
        /// </summary>
        public ST EncodingCharacters
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this.GetField(2, 1) as ST;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Sending Application (MSH-3).
        /// </summary>
        public HD SendingApplication
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this.GetField(3, 1) as HD;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Sending Facility (MSH-4).
        /// </summary>
        public HD SendingFacility
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this.GetField(4, 1) as HD;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Receiving Application (MSH-5).
        /// </summary>
        public HD ReceivingApplication
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this.GetField(5, 1) as HD;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Receiving Facility (MSH-6).
        /// </summary>
        public HD ReceivingFacility
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this.GetField(6, 1) as HD;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Date/Time Of Message (MSH-7).
        /// </summary>
        public TS DateTimeOfMessage
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this.GetField(7, 1) as TS;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Security (MSH-8).
        /// </summary>
        public ST Security
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this.GetField(8, 1) as ST;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Message Type (MSH-9).
        /// </summary>
        public MSG MessageType
        {
            get
            {
                MSG ret = null;

                try
                {
                    ret = this.GetField(9, 1) as MSG;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Message Control Id (MSH-10).
        /// </summary>
        public ST MessageControlId
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this.GetField(10, 1) as ST;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Processing Id (MSH-11).
        /// </summary>
        public PT ProcessingId
        {
            get
            {
                PT ret = null;

                try
                {
                    ret = this.GetField(11, 1) as PT;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Version Id (MSH-12).
        /// </summary>
        public VID VersionId
        {
            get
            {
                VID ret = null;

                try
                {
                    ret = this.GetField(12, 1) as VID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Sequence Number (MSH-13).
        /// </summary>
        public NM SequenceNumber
        {
            get
            {
                NM ret = null;

                try
                {
                    ret = this.GetField(13, 1) as NM;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Continuation Pointer (MSH-14).
        /// </summary>
        public ST ContinuationPointer
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this.GetField(14, 1) as ST;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Accept Acknowledgment Type (MSH-15).
        /// </summary>
        public ID AcceptAcknowledgmentType
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this.GetField(15, 1) as ID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Application Acknowledgment Type (MSH-16).
        /// </summary>
        public ID ApplicationAcknowledgmentType
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this.GetField(16, 1) as ID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Country Code (MSH-17).
        /// </summary>
        public ID CountryCode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this.GetField(17, 1) as ID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Character Set (MSH-18).
        /// </summary>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        public ID GetCharacterSet(int numRepetition)
        {
            ID ret = null;

            try
            {
                ret = this.GetField(18, numRepetition) as ID;
            }
            catch (SegmentException)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// Character Set (MSH-18).
        /// </summary>
        /// <returns></returns>
        public ID[] GetCharacterSet()
        {
            ID[] ret = null;

            try
            {
                IType[] repetitions = this.GetField(18);
                ret = new ID[repetitions.Length];

                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = repetitions[i] as ID;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// Principal Language Of Message (MSH-19).
        /// </summary>
        public CE PrincipalLanguageOfMessage
        {
            get
            {
                CE ret = null;

                try
                {
                    ret = this.GetField(19, 1) as CE;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Alternate Character Set Handling Scheme (MSH-20).
        /// </summary>
        public ID AlternateCharacterSetHandlingScheme
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this.GetField(20, 1) as ID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Message Profile Identifier (MSH-21).
        /// </summary>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        public EI GetMessageProfileIdentifier(int numRepetition)
        {
            EI ret = null;

            try
            {
                ret = this.GetField(21, numRepetition) as EI;
            }
            catch (SegmentException)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// Message Profile Identifier (MSH-21).
        /// </summary>
        /// <returns></returns>
        public EI[] GetMessageProfileIdentifier()
        {
            EI[] ret = null;

            try
            {
                IType[] repetitions = this.GetField(21);
                ret = new EI[repetitions.Length];

                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = repetitions[i] as EI;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }
    }
}