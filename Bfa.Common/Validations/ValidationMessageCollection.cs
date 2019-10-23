// -----------------------------------------------------------------------
// <copyright file="ValidationMessageCollection.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Validations
{
    using System;

    using Bfa.Common.Collections;

    /// <summary>
    /// Validation Message Collection class.
    /// </summary>
    /// <seealso cref="Bfa.Common.Collections.ObservableCollection{IValidationMessage}" />
    public class ValidationMessageCollection : ObservableCollection<IValidationMessage>
    {
        /// <summary>
        /// The read only observable collection
        /// </summary>
        private readonly Lazy<ReadOnlyObservableCollection<IValidationMessage>> readOnlyObservableCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationMessageCollection"/> class.
        /// </summary>
        public ValidationMessageCollection()
        {
            this.readOnlyObservableCollection = new Lazy<ReadOnlyObservableCollection<IValidationMessage>>(
                () =>
                    {
                        this.KeepAlive = true;
                        return ReadOnlyObservableCollection<IValidationMessage>.CreateInstance(this);
                    });
        }

        /// <summary>
        /// Gets a value indicating whether [keep alive].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [keep alive]; otherwise, <c>false</c>.
        /// </value>
        public bool KeepAlive { get; private set; }

        /// <summary>
        /// Gets the read only observable collection.
        /// </summary>
        /// <value>
        /// The read only observable collection.
        /// </value>
        public ReadOnlyObservableCollection<IValidationMessage> ReadOnlyObservableCollection =>
            this.readOnlyObservableCollection.Value;
    }
}