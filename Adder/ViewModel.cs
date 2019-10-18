// -----------------------------------------------------------------------
// <copyright file="ViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Adder
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using ValidationToolkit;
    using ValidationToolkit.Annotations;

    /// <summary>
    /// ViewModel Class
    /// </summary>
    /// <seealso cref="ValidationToolkit.IValidationErrorsAware" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class ViewModel : INotifyPropertyChanged, IValidationErrorsAware
    {
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Gets the validation errors.
        /// </summary>
        /// <value>
        /// The validation errors.
        /// </value>
        public IValidationErrorContainer ValidationErrors { get; } = new ValidationErrorContainer();
    }
}