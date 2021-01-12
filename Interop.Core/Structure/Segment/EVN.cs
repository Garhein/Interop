using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using Interop.Core.Structure.DataType;
using System;

namespace Interop.Core.Structure.Segment
{
    /// <summary>
    /// EVN - Event Type.
    /// </summary>
    [Serializable]
    public class EVN : AbstractSegment
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public EVN()
        {
            this.InitField(typeof(ID), "Event Type Code", 3, 1, false);
            this.InitField(typeof(TS), "Recorded Date/Time", 26, 1, true);
            this.InitField(typeof(TS), "Date/Time Planned Event", 26, 1, false);
            this.InitField(typeof(IS), "Event Reason Code", 3, 1, false);
            this.InitField(typeof(XCN), "Operator Id", 250, 0, false);
            this.InitField(typeof(TS), "Event Occurred", 26, 1, false);
            this.InitField(typeof(HD), "Event Facility", 241, 1, false);
        }

        /// <summary>
        /// Event Type Code (EVN-1).
        /// </summary>
        public ID EventTypeCode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this.GetField(1, 1) as ID;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Recorded Date/Time (EVN-2).
        /// </summary>
        public TS RecordedDateTime
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this.GetField(2, 1) as TS;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Date/Time Planned Event (EVN-3).
        /// </summary>
        public TS DateTimePlannedEvent
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this.GetField(3, 1) as TS;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Event Reason Code (EVN-4).
        /// </summary>
        public IS EventReasonCode
        {
            get
            {
                IS ret = null;

                try
                {
                    ret = this.GetField(4, 1) as IS;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Operator Id (EVN-5).
        /// </summary>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        public XCN GetOperatorId(int numRepetition)
        {
            XCN ret = null;

            try
            {
                ret = this.GetField(5, numRepetition) as XCN;
            }
            catch (SegmentException)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// Operator Id (EVN-5).
        /// </summary>
        /// <returns></returns>
        public XCN[] GetOperatorId()
        {
            XCN[] ret = null;

            try
            {
                IType[] repetitions = this.GetField(5);
                ret = new XCN[repetitions.Length];

                for (int i = 0; i < ret.Length; i++)
                {
                    ret[i] = repetitions[i] as XCN;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// Event Occurred (EVN-6).
        /// </summary>
        public TS EventOccurred
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this.GetField(6, 1) as TS;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Event Facility (EVN-7).
        /// </summary>
        public HD EventFacility
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this.GetField(7, 1) as HD;
                }
                catch (SegmentException)
                {
                    throw;
                }

                return ret;
            }
        }
    }
}