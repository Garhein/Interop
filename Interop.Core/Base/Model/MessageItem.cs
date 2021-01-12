using Interop.Core.Exceptions;
using Interop.Core.Util;
using System;
using System.Collections.Generic;

namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Représente un groupement de segments d'un message.
    /// </summary>
    public class MessageItem
    {
        private List<ISegment>  _repetitions;
        private Type            _type;
        private string          _description;
        private int             _maxRepetitions;
        private bool            _required;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="type">Type du segment.</param>
        /// <param name="description">Description du segment.</param>
        /// <param name="maxRepetitions">Nombre maximum de répétitions autorisées.</param>
        /// <param name="required">Indique si le segment est obligatoire.</param>
        public MessageItem(Type type, string description, int maxRepetitions, bool required)
        {
            if (!typeof(ISegment).IsAssignableFrom(type))
            {
                throw new SegmentException($"Le segment '{type.FullName}' n'hérite pas de '{typeof(ISegment).FullName}'.");
            }

            this._repetitions       = new List<ISegment>();
            this._type              = type;
            this._description       = description;
            this._maxRepetitions    = maxRepetitions;
            this._required          = required;
        }
    
        /// <summary>
        /// Liste des répétitions.
        /// </summary>
        public List<ISegment> Repetitions
        {
            get
            {
                return this._repetitions;
            }
        }
    
        /// <summary>
        /// Nom du segment.
        /// </summary>
        public string SegmentName
        {
            get
            {
                return TypeUtil.GetTypeName(this._type);
            }
        }

        /// <summary>
        /// Type du segment.
        /// </summary>
        public Type Type
        {
            get
            {
                return this._type;
            }
        }
    
        /// <summary>
        /// Description du segment.
        /// </summary>
        public string Description
        {
            get
            {
                return this._description;
            }
        }

        /// <summary>
        /// Nombre maximum de répétitions autorisées.
        /// </summary>
        public int MaxRepetitions
        {
            get
            {
                return this._maxRepetitions > 0 ? this._maxRepetitions : int.MaxValue;
            }
        }
    
        /// <summary>
        /// Indique si le segment est obligatoire.
        /// </summary>
        public bool IsRequired
        {
            get
            {
                return this._required;
            }
        }

        /// <summary>
        /// Récupère une répétition du groupement de segments.
        // Les répétitions sont stockées à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="index">Index de la répétition.</param>
        /// <returns></returns>
        public ISegment this[int index]
        {
            get
            {
                try
                {
                    if (index > 0)
                    {
                        return this._repetitions[index - 1];
                    }
                    else
                    {
                        throw new SegmentException($"L'accès à une répétition du groupement de segments '{this.SegmentName}' doit être réalisé à partir de l'index 1.");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new SegmentException($"La répétition à la position {index} n'existe pas dans le groupement de segment '{this.SegmentName}'.");
                }
            }
        }

        /// <summary>
        /// Convertit la liste des répétitions en un tableau de <see cref="ISegment"/>.
        /// </summary>
        public ISegment[] ConvertRepetitionsToISegmentArray
        {
            get
            {
                ISegment[] repetitions = new ISegment[this._repetitions.Count];

                int i = 0;

                foreach (ISegment rep in this._repetitions)
                {
                    repetitions[i] = rep;
                    i++;
                }

                return repetitions;
            }
        }
    }
}
