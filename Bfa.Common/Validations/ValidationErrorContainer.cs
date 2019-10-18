// -----------------------------------------------------------------------
// <copyright file="ValidationErrorContainer.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using Bfa.Common.Collections;

    using JetBrains.Annotations;

    /// <summary>
    ///     ValidationErrorContainer class
    /// </summary>
    /// <seealso cref="IValidationErrorContainer" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class ValidationErrorContainer : IValidationErrorContainer, INotifyPropertyChanged
    {
        /// <summary>
        ///     The errorCollection
        /// </summary>
        private readonly ObservableCollection<IValidationMessage> errorCollection;

        /// <summary>
        ///     The errorDictionary
        /// </summary>
        private readonly Dictionary<string, ObservableCollection<IValidationMessage>> errorDictionary =
            new Dictionary<string, ObservableCollection<IValidationMessage>>();

        /// <summary>
        ///     The read only errorCollection
        /// </summary>
        private readonly ReadOnlyObservableCollection<IValidationMessage> errors;

        /// <summary>
        ///     The last property validated
        /// </summary>
        protected string lastPropertyValidated;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ValidationErrorContainer" /> class.
        /// </summary>
        public ValidationErrorContainer()
        {
            this.errorCollection = new ObservableCollection<IValidationMessage>();
            this.errors = ReadOnlyObservableCollection<IValidationMessage>.CreateInstance(this.errorCollection);
        }

        /// <summary>
        ///     Occurs when [errorDictionary changed].
        /// </summary>
        public event EventHandler<ErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Occurs when [errors changed].
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> NotifyDataErrorInfoErrorsChanged;

        /// <summary>
        ///     Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Gets the current validation error.
        /// </summary>
        /// <value>
        ///     The current validation error.
        /// </value>
        public virtual IValidationMessage CurrentValidationError
        {
            get
            {
                if (this.ErrorCount == 0)
                {
                    return null;
                }

                return this.errorCollection.FirstOrDefault();
            }
        }

        /// <summary>
        ///     Gets the error count.
        /// </summary>
        /// <value>
        ///     The error count.
        /// </value>
        public int ErrorCount => this.errorCollection.Count;

        /// <summary>
        ///     Gets the validation errorDictionary.
        /// </summary>
        /// <value>
        ///     The validation errorDictionary.
        /// </value>
        public ReadOnlyObservableCollection<IValidationMessage> Errors
        {
            get
            {
                if (this.ErrorCount == 0)
                {
                    return null;
                }

                return this.errors;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this instance has errorDictionary.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has errorDictionary; otherwise, <c>false</c>.
        /// </value>
        public bool HasErrors => this.errorCollection.Any();

        /// <summary>
        ///     Adds the error from view.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        public virtual bool AddCatchValidationError(IValidationMessage error, bool isWarning = false)
        {
            var propertyName = error.PropertyName;

            if (!this.errorDictionary.ContainsKey(propertyName))
            {
                this.errorDictionary[propertyName] = new ObservableCollection<IValidationMessage>();
            }

            this.lastPropertyValidated = propertyName;
            if (isWarning)
            {
                this.errorDictionary[propertyName].Add(error);
                this.errorCollection.Add(error);
            }
            else
            {
                this.errorDictionary[propertyName].Insert(0, error);
                this.errorCollection.Insert(0, error);
            }

            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.Errors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Adds the error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        public virtual bool AddError(IValidationMessage error, bool isWarning = false)
        {
            if (!this.Add(error, isWarning))
            {
                return false;
            }

            var propertyName = error.PropertyName;

            this.NotifyDataErrorInfoChanged(propertyName);
            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Gets the property errorDictionary.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public System.Collections.IEnumerable GetPropertyErrors(string propertyName)
        {
            if (propertyName == "")
            {
                return null;
            }

            if (!this.errorDictionary.Keys.Contains(propertyName))
            {
                return null;
            }

            var list = this.errorDictionary[propertyName].OrderBy(i => i is IValidationWarning ? 1 : 0);
            return list;
        }

        /// <summary>
        ///     Gets the validation error messages as string.
        /// </summary>
        /// <returns></returns>
        public string GetValidationErrorMessagesAsString()
        {
            var builder = new StringBuilder();
            var count = 0;
            builder.Append("ValidationErrorContainer contents:(")
                .Append(this.ErrorCount)
                .Append(" errorDictionary)\n{\n");
            foreach (var error in this.errorDictionary.Values.SelectMany(propertyErrors => propertyErrors))
            {
                builder.Append(count.ToString()).Append(". ").Append(error.Description).Append("\n");
                count++;
            }

            builder.Append("}");
            return builder.ToString();
        }

        /// <summary>
        ///     Removes the error from view.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        public virtual bool RemoveCatchValidationError(string propertyName, string errorId)
        {
            if (!this.Remove(propertyName, errorId))
            {
                return false;
            }

            this.NotifyErrorsChanged(propertyName);
            this.NotifyPropertyChanged(nameof(this.Errors));
            this.NotifyPropertyChanged(nameof(this.ErrorCount));
            this.NotifyPropertyChanged(nameof(this.CurrentValidationError));

            return true;
        }

        /// <summary>
        ///     Removes the error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        public virtual bool RemoveError(string propertyName, string errorId)
        {
            if (!this.Remove(propertyName, errorId))
            {
                return false;
            }

            this.NotifyDataErrorInfoChanged(propertyName);
            this.NotifyErrorsChanged(propertyName);
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
        ///     Adds the specified error.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="isWarning">if set to <c>true</c> [is warning].</param>
        /// <returns></returns>
        private bool Add(IValidationMessage error, bool isWarning)
        {
            var propertyName = error.PropertyName;

            if (!this.errorDictionary.ContainsKey(propertyName))
            {
                this.errorDictionary[propertyName] = new ObservableCollection<IValidationMessage>();
            }

            this.lastPropertyValidated = propertyName;
            if (this.errorDictionary[propertyName].Contains(error))
            {
                return false;
            }

            if (isWarning)
            {
                this.errorDictionary[propertyName].Add(error);
                this.errorCollection.Add(error);
            }
            else
            {
                this.errorDictionary[propertyName].Insert(0, error);
                this.errorCollection.Insert(0, error);
            }

            return true;
        }

        /// <summary>
        ///     Notifies the errorDictionary changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyDataErrorInfoChanged(string propertyName)
        {
            if (this.NotifyDataErrorInfoErrorsChanged == null)
            {
                return;
            }

            this.NotifyDataErrorInfoErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            this.NotifyPropertyChanged(nameof(this.Errors));
        }

        /// <summary>
        ///     Removes the specified property name.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="errorId">The error identifier.</param>
        /// <returns></returns>
        private bool Remove(string propertyName, string errorId)
        {
            if (!this.errorDictionary.ContainsKey(propertyName))
            {
                return false;
            }

            var messages = this.errorDictionary[propertyName];
            var message = messages.FirstOrDefault(i => i.PropertyName == propertyName && i.Id == errorId);
            if (message == null)
            {
                return false;
            }

            if (messages.Remove(message))
            {
                this.errorCollection.RemoveLast(message);
            }

            if (messages.Count != 0)
            {
                return true;
            }

            this.errorDictionary.Remove(propertyName);
            if (this.errorDictionary.Count == 0)
            {
                this.lastPropertyValidated = null;
            }
            else
            {
                this.lastPropertyValidated = this.errorDictionary.First().Key;
            }

            return true;
        }

        /// <summary>
        ///     Notifies the errors changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void NotifyErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new ErrorsChangedEventArgs(propertyName));
        }
    }
}