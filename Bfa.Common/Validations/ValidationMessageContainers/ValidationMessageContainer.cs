// -----------------------------------------------------------------------
// <copyright file="ValidationMessageContainer.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations.ValidationMessageContainers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using Bfa.Common.Collections;
    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationMessageContainer class
    /// </summary>
    /// <seealso cref="IValidationMessageContainer" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ValidationMessageContainer : IValidationMessageContainer, INotifyPropertyChanged
    {
        /// <summary>
        ///     The messageCollection
        /// </summary>
        private readonly ObservableCollection<IValidationMessage> messageCollection;

        /// <summary>
        ///     The messageDictionary
        /// </summary>
        private readonly Dictionary<string, ValidationMessageCollection> messageDictionary =
            new Dictionary<string, ValidationMessageCollection>();

        /// <summary>
        ///     The last property validated
        /// </summary>
        protected string lastPropertyValidated;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationMessageContainer" /> class.
        /// </summary>
        public ValidationMessageContainer()
        {
            this.messageCollection = new ObservableCollection<IValidationMessage>();
            this.Errors = ReadOnlyObservableCollection<IValidationMessage>.CreateInstance(this.messageCollection);
        }

        /// <summary>
        ///     Occurs when [messageDictionary changed].
        /// </summary>
        public event EventHandler<MessageChangedEventArgs> MessageChanged;

        /// <summary>
        ///     Occurs when [errors changed].
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets the current validation message.
        /// </summary>
        /// <value>
        ///     The current validation message.
        /// </value>
        public virtual IValidationMessage CurrentValidationError
        {
            get
            {
                if (this.ErrorCount == 0)
                {
                    return null;
                }

                return this.messageCollection.FirstOrDefault();
            }
        }

        /// <summary>
        ///     Gets the <see cref="ReadOnlyObservableCollection{IValidationMessage}" /> with the specified name.
        /// </summary>
        /// <value>
        ///     The <see cref="ReadOnlyObservableCollection{IValidationMessage}" />.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public ReadOnlyObservableCollection<IValidationMessage> this[[NotNull] string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                if (!this.messageDictionary.ContainsKey(name))
                {
                    this.messageDictionary.Add(name, new ValidationMessageCollection());
                }

                return this.messageDictionary[name]?.ReadOnlyObservableCollection;
            }
        }

        /// <summary>
        ///     Gets the message count.
        /// </summary>
        /// <value>
        ///     The message count.
        /// </value>
        public int ErrorCount => this.messageCollection.Count;

        /// <summary>
        ///     Gets the errors.
        /// </summary>
        /// <value>
        ///     The errors.
        /// </value>
        public ReadOnlyObservableCollection<IValidationMessage> Errors { get; }

        /// <summary>
        ///     Gets a value indicating whether this instance has messageDictionary.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has messageDictionary; otherwise, <c>false</c>.
        /// </value>
        public bool HasErrors => this.messageCollection.Any();

        /// <summary>
        ///     Adds the message from view.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        public virtual bool AddCatchValidationError([NotNull] IValidationMessage message, bool isWarning = false)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var propertyName = message.PropertyName;

            if (!this.messageDictionary.ContainsKey(propertyName))
            {
                this.messageDictionary[propertyName] = new ValidationMessageCollection();
            }

            this.lastPropertyValidated = propertyName;
            if (isWarning)
            {
                this.messageDictionary[propertyName].Add(message);
                this.messageCollection.Add(message);
            }
            else
            {
                this.messageDictionary[propertyName].Insert(0, message);
                this.messageCollection.Insert(0, message);
            }

            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.Errors));
            this.NotifyPropertyChanged(nameof(this.HasErrors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Adds the message.
        /// </summary>
        /// <param name="error">The message.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        public virtual bool AddError([NotNull] IValidationMessage error, bool isWarning = false)
        {
            if (error == null)
            {
                throw new ArgumentNullException(nameof(error));
            }

            if (!this.Add(error, isWarning))
            {
                return false;
            }

            var propertyName = error.PropertyName;

            this.NotifyDataErrorInfoChanged(propertyName);
            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.HasErrors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Gets the property messageDictionary.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public System.Collections.IEnumerable GetPropertyErrors([NotNull] string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (propertyName == "")
            {
                return null;
            }

            if (!this.messageDictionary.Keys.Contains(propertyName))
            {
                return null;
            }

            var list = this.messageDictionary[propertyName].OrderBy(i => i is IValidationWarning ? 1 : 0);
            return list;
        }

        /// <summary>
        ///     Gets the validation message messages as string.
        /// </summary>
        /// <returns></returns>
        public string GetValidationErrorMessagesAsString()
        {
            var builder = new StringBuilder();
            var count = 0;
            builder.Append("ValidationMessageContainer contents:(")
                .Append(this.ErrorCount)
                .Append(" messageDictionary)\n{\n");
            foreach (var error in this.messageDictionary.Values.SelectMany(propertyErrors => propertyErrors))
            {
                builder.Append(count.ToString()).Append(". ").Append(error.Description).Append("\n");
                count++;
            }

            builder.Append("}");
            return builder.ToString();
        }

        /// <summary>
        ///     Removes the message from view.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The message identifier.</param>
        /// <returns></returns>
        public virtual bool RemoveCatchValidationError([NotNull] string propertyName, [NotNull] string errorId)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (errorId == null)
            {
                throw new ArgumentNullException(nameof(errorId));
            }

            if (!this.Remove(propertyName, errorId))
            {
                return false;
            }

            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.Errors));
            this.NotifyPropertyChanged(nameof(this.HasErrors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Removes the message.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The message identifier.</param>
        /// <returns></returns>
        public virtual bool RemoveError([NotNull] string propertyName, [NotNull] string errorId)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (errorId == null)
            {
                throw new ArgumentNullException(nameof(errorId));
            }

            if (!this.Remove(propertyName, errorId))
            {
                return false;
            }

            this.NotifyDataErrorInfoChanged(propertyName);
            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.HasErrors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Notifies the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Adds the specified message.
        /// </summary>
        /// <param name="error">The message.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        private bool Add([NotNull] IValidationMessage error, bool isWarning)
        {
            var propertyName = error.PropertyName;

            if (!this.messageDictionary.ContainsKey(propertyName))
            {
                this.messageDictionary[propertyName] = new ValidationMessageCollection();
            }

            this.lastPropertyValidated = propertyName;
            if (this.messageDictionary[propertyName].Contains(error))
            {
                return false;
            }

            if (isWarning)
            {
                this.messageDictionary[propertyName].Add(error);
                this.messageCollection.Add(error);
            }
            else
            {
                this.messageDictionary[propertyName].Insert(0, error);
                this.messageCollection.Insert(0, error);
            }

            return true;
        }

        /// <summary>
        ///     Notifies the messageDictionary changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyDataErrorInfoChanged([NotNull] string propertyName)
        {
            if (this.ErrorsChanged == null)
            {
                return;
            }

            this.ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            this.NotifyPropertyChanged(nameof(this.Errors));
        }

        /// <summary>
        ///     Removes the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The message identifier.</param>
        /// <returns></returns>
        private bool Remove([NotNull] string propertyName, [NotNull] string errorId)
        {
            if (!this.messageDictionary.ContainsKey(propertyName))
            {
                return false;
            }

            var messages = this.messageDictionary[propertyName];
            var message = messages.FirstOrDefault(i => i.PropertyName == propertyName && i.Id == errorId);
            if (message == null)
            {
                return false;
            }

            if (messages.Remove(message))
            {
                this.messageCollection.RemoveLast(message);
            }

            if (messages.Count != 0)
            {
                return true;
            }

            if (messages.KeepAlive)
            {
                return true;
            }

            this.messageDictionary.Remove(propertyName);
            if (this.messageDictionary.Count == 0)
            {
                this.lastPropertyValidated = null;
            }
            else
            {
                this.lastPropertyValidated = this.messageDictionary.First().Key;
            }

            return true;
        }

        /// <summary>
        ///     Notifies the errors changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void NotifyErrorsChanged([NotNull] string propertyName)
        {
            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            this.MessageChanged?.Invoke(this, new MessageChangedEventArgs(propertyName));
        }
    }
}