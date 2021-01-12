using Interop.Core.Base.Model;
using Interop.Core.Exceptions;
using System;

namespace Interop.Core.Structure.DataType
{
    /// <summary>
    /// XCN - Extended Composite ID Number and Name for Persons.
    /// </summary>
    [Serializable]
    public class XCN : AbstractTypeComposite
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="description">Description de la donnée.</param>
        /// <param name="maxLength">Longueur maximale autorisée.</param>
        /// <param name="required">Indique si la donnée est obligatoire.</param>        
        public XCN(string description, int maxLength, bool required) : base(description, maxLength, required, 23)
        {
            this.Components[1] = new ST("Id Number", 15, false);
            this.Components[2] = new FN("Family Name", 194, false);
            this.Components[3] = new ST("Given Name", 30, false);
            this.Components[4] = new ST("Second And Further Given Names Or Initials Thereof", 30, false);
            this.Components[5] = new ST("Suffix", 20, false);
            this.Components[6] = new ST("Prefix", 20, false);
            this.Components[7] = new IS("Degree", 5, false);
            this.Components[8] = new IS("Source Table", 4, false);
            this.Components[9] = new HD("Assigning Authority", 227, false);
            this.Components[10] = new ID("Name Type Code", 1, false);
            this.Components[11] = new ST("Identifier Check Digit", 1, false);
            this.Components[12] = new ID("Check Digit Scheme", 3, false);
            this.Components[13] = new ID("Identifier Type Code", 5, false);
            this.Components[14] = new HD("Assigning Facility", 227, false);
            this.Components[15] = new ID("Name Representation Code", 1, false);
            this.Components[16] = new CE("Name Context", 483, false);
            this.Components[17] = new DR("Name Validity Range", 53, false);
            this.Components[18] = new ID("Name Assembly Order", 1, false);
            this.Components[19] = new TS("Effective Date", 26, false);
            this.Components[20] = new TS("Expiration Date", 26, false);
            this.Components[21] = new ST("Professional Suffix", 199, false);
            this.Components[22] = new CWE("Assigning Jurisdiction", 705, false);
            this.Components[23] = new CWE("Assigning Agency Or Department", 705, false);
        }

        /// <summary>
        /// XCN.1 - Id Number.
        /// </summary>
        public ST IdNumber
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[1] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[1] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.2 - Family Name.
        /// </summary>
        public FN FamilyName
        {
            get
            {
                FN ret = null;

                try
                {
                    ret = this[2] as FN;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[2] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.3 - Given Name.
        /// </summary>
        public ST GivenName
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[3] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[3] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.4 - Second And Further Given Names Or Initials Thereof.
        /// </summary>
        public ST SecondAndFurtherGivenNamesOrInitialsThereof
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[4] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[4] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.5 - Suffix.
        /// </summary>
        public ST Suffix
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[5] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[5] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.6 - Prefix.
        /// </summary>
        public ST Prefix
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[6] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[6] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.7 - Degree.
        /// </summary>
        public IS Degree
        {
            get
            {
                IS ret = null;

                try
                {
                    ret = this[7] as IS;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[7] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.8 - Source Table.
        /// </summary>
        public IS SourceTable
        {
            get
            {
                IS ret = null;

                try
                {
                    ret = this[8] as IS;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[8] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.9 - Assigning Authority.
        /// </summary>
        public HD AssigningAuthority
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this[9] as HD;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[9] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.10 - Name Type Code.
        /// </summary>
        public ID NameTypeCode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[10] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[10] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.11 - Identifier Check Digit.
        /// </summary>
        public ST IdentifierCheckDigit
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[11] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[11] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.12 - Check Digit Scheme.
        /// </summary>
        public ID CheckDigitScheme
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[12] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[12] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.13 - Identifier Type Code.
        /// </summary>
        public ID IdentifierTypeCode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[13] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[13] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.14 - Assigning Facility.
        /// </summary>
        public HD AssigningFacility
        {
            get
            {
                HD ret = null;

                try
                {
                    ret = this[14] as HD;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[14] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.15 - Name Representation Code.
        /// </summary>
        public ID NameRepresentationCode
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[15] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[15] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.16 - Name Context.
        /// </summary>
        public CE NameContext
        {
            get
            {
                CE ret = null;

                try
                {
                    ret = this[16] as CE;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[16] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.17 - Name Validity Range.
        /// </summary>
        public DR NameValidityRange
        {
            get
            {
                DR ret = null;

                try
                {
                    ret = this[17] as DR;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[17] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.18 - Name Assembly Order.
        /// </summary>
        public ID NameAssemblyOrder
        {
            get
            {
                ID ret = null;

                try
                {
                    ret = this[18] as ID;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[18] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.19 - Effective Date.
        /// </summary>
        public TS EffectiveDate
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this[19] as TS;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[19] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.20 - Expiration Date.
        /// </summary>
        public TS ExpirationDate
        {
            get
            {
                TS ret = null;

                try
                {
                    ret = this[20] as TS;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[20] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.21 - Professional Suffix.
        /// </summary>
        public ST ProfessionalSuffix
        {
            get
            {
                ST ret = null;

                try
                {
                    ret = this[21] as ST;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[21] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.22 - Assigning Jurisdiction.
        /// </summary>
        public CWE AssigningJurisdiction
        {
            get
            {
                CWE ret = null;

                try
                {
                    ret = this[22] as CWE;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[22] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// XCN.23 - Assigning Agency Or Department.
        /// </summary>
        public CWE AssigningAgencyOrDepartment
        {
            get
            {
                CWE ret = null;

                try
                {
                    ret = this[23] as CWE;
                }
                catch (DataTypeException)
                {
                    throw;
                }

                return ret;
            }
            set
            {
                try
                {
                    this[23] = value;
                }
                catch (DataTypeException)
                {
                    throw;
                }
            }
        }
    }
}