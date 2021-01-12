using Interop.Core.Exceptions;
using Interop.Core.Util;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Représente un segment.
    /// </summary>
    public abstract class AbstractSegment : ISegment
    {
        private List<SegmentItem> _fields;

        /// <summary>
        /// Constructeur vide.
        /// </summary>
        public AbstractSegment()
        {
            this._fields = new List<SegmentItem>();
        }

        /// <summary>
        /// Initialisation d'un champ du segment.
        /// </summary>
        /// <param name="type">Type du champ.</param>
        /// <param name="description">Description du champ.</param>
        /// <param name="maxLength">Longueur maximale de chaque répétition.</param>
        /// <param name="maxRepetitions">Nombre maximum de répétitions autorisées.</param>
        /// <param name="required">Indique si le champ est obligatoire.</param>
        protected void InitField(Type type,
                                 string description,
                                 int maxLength,
                                 int maxRepetitions,
                                 bool required)
        {
            if (!typeof(IType).IsAssignableFrom(type))
            {
                throw new DataTypeException($"Le type '{type.FullName}' n'hérite pas de '{typeof(IType).FullName}'.");
            }

            this._fields.Add(new SegmentItem(type, description, maxLength, maxRepetitions, required));
        }

        /// <summary>
        /// Création d'un champ.
        /// Les champs sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="numField">Numéro du champ auquel ajouter la répétition.</param>
        /// <returns></returns>
        private IType CreateNewSegmentItem(int numField)
        {
            IType newType   = null;
            Type typeRep    = this._fields[numField - 1].Type;
            string descr    = this._fields[numField - 1].Description;
            int maxLenght   = this._fields[numField - 1].MaxLength;
            bool required   = this._fields[numField - 1].IsRequired;

            try
            {
                Object[] args    = new Object[3] { descr, maxLenght, required };
                Type[] argsTypes = new Type[3] { descr.GetType(), maxLenght.GetType(), required.GetType() };
                newType          = (IType)typeRep.GetConstructor(argsTypes).Invoke(args);
            }
            catch (UnauthorizedAccessException authAccessEx)
            {
                throw new DataTypeException($"Impossible d'accéder à la classe '{typeRep.FullName}' ({authAccessEx.GetType().FullName}) : {authAccessEx.Message}", authAccessEx);
            }
            catch (TargetInvocationException targetIncovationEx)
            {
                throw new DataTypeException($"Impossible d'instancier la classe '{typeRep.FullName}' ({targetIncovationEx.GetType().FullName}) : {targetIncovationEx.Message}", targetIncovationEx);
            }
            catch (MethodAccessException methodAccessEx)
            {
                throw new DataTypeException($"Impossible d'instancier la classe '{typeRep.FullName}' ({methodAccessEx.GetType().FullName}) : {methodAccessEx.Message}", methodAccessEx);
            }
            catch (Exception ex)
            {
                throw new DataTypeException($"Impossible d'instancier la classe '{typeRep.FullName}' ({ex.GetType().FullName}) : {ex.Message}", ex);
            }

            return newType;
        }

        #region Implémentations

        /// <summary>
        /// Récupère le nom du segment.
        /// </summary>
        public string SegmentName 
        { 
            get
            {
                return TypeUtil.GetTypeName(this);
            }
        }

        /// <summary>
        /// Récupère les champs composant le segment.
        /// </summary>
        public List<SegmentItem> Fields
        {
            get
            {
                return this._fields;
            }
        }

        /// <summary>
        /// Récupère les donnés d'un champ.
        /// Les champs sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="numField">Numéro du champ.</param>
        /// <returns>Tableau de longueur 1 pour les champs non répétables, et > 1 pour les champs répétables.</returns>
        public IType[] GetField(int numField)
        {
            try
            {
                if (numField > 0)
                {
                    return this._fields[numField - 1].ConvertRepetitionsToITypeArray;
                }
                else
                {
                    throw new SegmentException("L'accès à un champ doit être réalisé à partir de l'index 1.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new SegmentException($"Le champ {InteropUtil.ConstructFieldNumber(this.SegmentName, numField)} n'existe pas.");
            }
        }

        /// <summary>
        /// Récupère les données d'une répétition d'un champ.
        /// Les champs et répétitions sont stocké(e)s à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="numField">Numéro du champ.</param>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        public IType GetField(int numField, int numRepetition)
        {
            if (numField <= 0)
            {
                throw new SegmentException("L'accès à un champ doit être réalisé à partir de l'index 1.");
            }
            
            if (numField > this._fields.Count)
            {
                throw new SegmentException($"Le champ {InteropUtil.ConstructFieldNumber(this.SegmentName, numField)} n'existe pas.");
            }

            if (numRepetition <= 0)
            {
                throw new SegmentException($"L'accès à une répétition du champ {InteropUtil.ConstructFieldNumber(this.SegmentName, numField)} doit être réalisé à partir de l'index 1.");
            }

            int currentRep = this._fields[numField - 1].Repetitions.Count;
        
            // Création d'une répétition si nécessaire et si limite maximale non atteinte
            if (numRepetition > currentRep)
            {
                if (numRepetition > this._fields[numField - 1].MaxRepetitions)
                {
                    throw new SegmentException($"Impossible d'ajouter la répétition {InteropUtil.ConstructFieldNumber(this.SegmentName, numField, numRepetition)} : le nombre maximal autorisé de répétitions est de {this._fields[numField - 1].MaxRepetitions}.");
                }
                else
                {
                    this._fields[numField - 1].Repetitions.Add(this.CreateNewSegmentItem(numField));
                }
            }

            return this._fields[numField - 1][numRepetition];
        }

        #endregion
    }
}