using Interop.Core.Base.Parser;
using Interop.Core.Exceptions;
using Interop.Core.Structure.Segment;
using Interop.Core.Util;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Interop.Core.Base.Model
{
    /// <summary>
    /// Représente un message.
    /// </summary>
    public abstract class AbstractMessage : IMessage
    {
        private List<MessageItem>   _segments;
        private EncodingCharacters  _encodingCharacters;
        private object              _eventOperator;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="encChars">Caractères d'encodage utilisés par le message.</param>
        /// <param name="eventOperator">Informations de la personne à l'origine de l'événement.</param>
        /// <param name="messageCode">Valeur pour <see cref="MSG.MessageCode"/> (MSH-9).</param>
        /// <param name="triggerEvent">Valeur pour <see cref="MSG.TriggerEvent"/> (MSH-9).</param>
        /// <param name="messageStructure">Valeur pour <see cref="MSG.MessageStructure"/> (MSH-9).</param>
        public AbstractMessage(EncodingCharacters encChars,
                               object eventOperator,
                               string messageCode,
                               string triggerEvent,
                               string messageStructure)
        {
            this._segments              = new List<MessageItem>();
            this._encodingCharacters    = encChars;
            this._eventOperator         = eventOperator;

            // Initialisation des segments toujours présents dans un message
            this.InitSegment(typeof(MSH), "", 1, true);
            this.InitSegment(typeof(EVN), "", 1, true);

            // Initialisation de MSH-9
            this.MSH.MessageType.MessageCode.Value      = messageCode;
            this.MSH.MessageType.TriggerEvent.Value     = triggerEvent;
            this.MSH.MessageType.MessageStructure.Value = messageStructure;
        }

        /// <summary>
        /// Initialisation d'un groupement de segments du message.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="description"></param>
        /// <param name="maxRepetitions"></param>
        /// <param name="required"></param>
        protected void InitSegment(Type type,
                                   string description,
                                   int maxRepetitions,
                                   bool required)
        {
            if (!typeof(ISegment).IsAssignableFrom(type))
            {
                throw new DataTypeException($"Le segment '{type.FullName}' n'hérite pas de '{typeof(ISegment).FullName}'.");
            }

            this._segments.Add(new MessageItem(type, description, maxRepetitions, required));
        }

        /// <summary>
        /// Création d'un segment.
        /// </summary>
        /// <param name="numGroupement"></param>
        /// <returns></returns>
        private ISegment CreateNewMessageItem(int numGroupement)
        {
            ISegment newSegment = null;
            Type typeSegment = this._segments[numGroupement].Type;

            try
            {
                Object[] args    = new Object[0] { };
                Type[] argsTypes = new Type[0] { };
                newSegment       = (ISegment)typeSegment.GetConstructor(argsTypes).Invoke(args);
            }
            catch (UnauthorizedAccessException authAccessEx)
            {
                throw new MessageException($"Impossible d'accéder à la classe '{typeSegment.FullName}' ({authAccessEx.GetType().FullName}) : {authAccessEx.Message}", authAccessEx);
            }
            catch (TargetInvocationException targetIncovationEx)
            {
                throw new MessageException($"Impossible d'instancier la classe '{typeSegment.FullName}' ({targetIncovationEx.GetType().FullName}) : {targetIncovationEx.Message}", targetIncovationEx);
            }
            catch (MethodAccessException methodAccessEx)
            {
                throw new MessageException($"Impossible d'instancier la classe '{typeSegment.FullName}' ({methodAccessEx.GetType().FullName}) : {methodAccessEx.Message}", methodAccessEx);
            }
            catch (Exception ex)
            {
                throw new MessageException($"Impossible d'instancier la classe '{typeSegment.FullName}' ({ex.GetType().FullName}) : {ex.Message}", ex);
            }

            return newSegment;
        }

        #region Implémentations

        /// <summary>
        /// Récupère les caractères d'encodage utilisés par le message.
        /// </summary>
        public EncodingCharacters EncodingCharacters 
        { 
            get
            {
                return this._encodingCharacters;
            }
        }

        /// <summary>
        /// Récupère les informations de la personne à l'origine de l'événement.
        /// </summary>
        public object EventOperator 
        { 
            get
            {
                return this._eventOperator;
            }
        }

        /// <summary>
        /// MSH.
        /// </summary>
        public MSH MSH
        {
            get
            {
                MSH ret = null;

                try
                {
                    ret = this.GetSegment("MSH", 1) as MSH;
                }
                catch (MessageException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary> 
        /// EVN.
        /// </summary>
        public EVN EVN
        {
            get
            {
                EVN ret = null;

                try
                {
                    ret = this.GetSegment("EVN", 1) as EVN;
                }
                catch (MessageException)
                {
                    throw;
                }

                return ret;
            }
        }

        /// <summary>
        /// Récupère le nombre de groupements de segments.
        /// </summary>
        public int CountStructure 
        { 
            get
            {
                return this._segments.Count;
            }
        }

        /// <summary>
        /// Récupère une répétition d'un groupement de segments.
        /// Les groupements sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="name">Nom du groupement.</param>
        /// <param name="numRepetition">Numéro de la répétition.</param>
        /// <returns></returns>
        public ISegment GetSegment(string name, int numRepetition)
        {
            int grpPosition = this._segments.FindIndex(x => x.SegmentName.Equals(name));

            if (grpPosition < 0)
            {
                throw new MessageException($"Le message '{TypeUtil.GetTypeName(this)}' ne contient aucune définition pour le segment '{name}'.");
            }

            if (numRepetition <= 0)
            {
                new MessageException("L'accès à segment doit être réalisé à partir de l'index 1.");
            }

            int currentRep = this._segments[grpPosition].Repetitions.Count;

            // Création d'une répétition si nécessaire et si limite maximale non atteinte
            if (numRepetition > currentRep)
            {
                if (numRepetition > this._segments[grpPosition].MaxRepetitions)
                {
                    throw new MessageException($"Impossible d'ajouter une répétition du segment '{TypeUtil.GetTypeName(this)}' : le nombre maximal autorisé de répétitions est de {this._segments[grpPosition].MaxRepetitions}.");
                }
                else
                {
                    this._segments[grpPosition].Repetitions.Add(this.CreateNewMessageItem(grpPosition));
                }
            }

            return this._segments[grpPosition][numRepetition];
        }

        /// <summary>
        /// Récupère un groupement de segments.
        /// Les groupements sont stockés à partir de l'indice 0 mais une base 1 est utilisée pour les accès.
        /// </summary>
        /// <param name="numGroupement">Numéro du groupement.</param>
        /// <returns></returns>
        public MessageItem GetStructure(int numGroupement)
        {
            if (numGroupement <= 0)
            {
                new MessageException("L'accès à un groupement de segments doit être réalisé à partir de l'index 1.");
            }

            if (numGroupement > this._segments.Count)
            {
                new MessageException($"Impossible d'accéder au groupement {numGroupement} du message '{TypeUtil.GetTypeName(this)}'.");
            }

            return this._segments[numGroupement - 1];
        }

        #endregion
    }
}