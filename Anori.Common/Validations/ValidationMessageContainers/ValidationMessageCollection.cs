﻿// -----------------------------------------------------------------------
// <copyright file="ValidationMessageCollection.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.Validations.ValidationMessageContainers
{
    using System;

    using Anori.Common.Collections;
    using Anori.Common.Validations.ValidationMessageContainers.Interfaces;

    /// <summary>
    /// Validation Message Collection class.
    /// </summary>
    /// <seealso cref="Anori.Common.Collections.ObservableCollection{IValidationMessage}" />
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