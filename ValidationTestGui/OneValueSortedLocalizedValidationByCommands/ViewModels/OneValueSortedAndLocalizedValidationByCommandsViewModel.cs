// -----------------------------------------------------------------------
// <copyright file="OneValueSortedAndLocalizedValidationByCommandsViewModel.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Validations.ValidationTestGui.OneValueSortedLocalizedValidationByCommands.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Input;

    using Anori.Common.Validations.ValidationMessageContainers;
    using Anori.Common.Validations.Validators;
    using Anori.Common.WPF.Localizations;
    using Anori.Common.WPF.Validations.ValidationMessageContainers;

    using ValidationToolkit;

    /// <summary>
    /// </summary>
    /// <seealso cref="Anori.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class OneValueSortedLocalizedValidationByCommandsViewModel : Binders.Bindable,
                                                                        INotifyDataErrorInfo,
                                                                        IDisposable
    {
        /// <summary>
        ///     The text key1
        /// </summary>
        private string textKey1;

        /// <summary>
        ///     The value1
        /// </summary>
        private string value1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="OneValueSortedLocalizedValidationByCommandsViewModel" /> class.
        /// </summary>
        public OneValueSortedLocalizedValidationByCommandsViewModel()
        {
            this.Validator = new ValidatorBuilder<OneValueSortedLocalizedValidationByCommandsViewModel>().Build(this);

            this.Validator.ValidationMessages.ErrorsChanged += this.ValidationMessagesOnErrorsChanged;

            this.TextKey1 = "Source1:Group1:Error1";

            this.Error1Command = new RelayCommand<object>(this.OnError1Command);
            this.Error2Command = new RelayCommand<object>(this.OnError2Command);
            this.Warning1Command = new RelayCommand<object>(this.OnWarning1Command);
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <value>
        ///     The validator.
        /// </value>
        public Validator<OneValueSortedLocalizedValidationByCommandsViewModel> Validator { get; }

        /// <summary>
        ///     Gets or sets the value1.
        /// </summary>
        /// <value>
        ///     The value1.
        /// </value>
        public string Value1
        {
            get => this.value1;
            set => this.SetProperty(ref this.value1, value);
        }

        /// <summary>
        ///     Gets the error1 Command.
        /// </summary>
        /// <value>
        ///     The error1 Command.
        /// </value>
        public ICommand Error1Command { get; }

        /// <summary>
        ///     Gets the error2 Command.
        /// </summary>
        /// <value>
        ///     The error2 Command.
        /// </value>
        public ICommand Error2Command { get; }

        /// <summary>
        ///     Gets the warning1 Command.
        /// </summary>
        /// <value>
        ///     The warning1 Command.
        /// </value>
        public ICommand Warning1Command { get; }

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.Validator.ValidationMessages.HasErrors;

        /// <summary>
        ///     Gets or sets the text key1.
        /// </summary>
        /// <value>
        ///     The text key1.
        /// </value>
        public string TextKey1
        {
            get => this.textKey1;
            set => this.SetProperty(ref this.textKey1, value);
        }

        /// <summary>
        ///     Validations the messages on errors changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e) =>
            this.OnErrorsChanged(e);

        /// <summary>
        ///     Called when [warning1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnWarning1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationLocWarning(
                        "Value1",
                        "warning1",
                        "Warning 1",
                        new LanguageKey("Warning1", "Group1", "Source1")));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError("Value1", "warning1");
            }
        }

        /// <summary>
        ///     Called when [error1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnError1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationLocError(
                        "Value1",
                        "error1",
                        "Error 1",
                        new LanguageKey("Error1", "Group1", "Source1")));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError("Value1", "error1");
            }
        }

        /// <summary>
        ///     Called when [error2 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnError2Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationLocError(
                        "Value1",
                        "error2",
                        "Error 2",
                        new LanguageKey("Error2", "Group1", "Source1")));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError("Value1", "error2");
            }
        }

        /// <summary>
        ///     Gets the validation errors for a specified property or for the entire entity.
        /// </summary>
        /// <param name="propertyName">
        ///     The name of the property to retrieve validation errors for; or <see langword="null" /> or
        ///     <see cref="F:System.String.Empty" />, to retrieve entity-level errors.
        /// </param>
        /// <returns>
        ///     The validation errors for the property or entity.
        /// </returns>
        public IEnumerable GetErrors(string propertyName) =>
            this.Validator.ValidationMessages.GetPropertyErrors(propertyName);

        /// <summary>
        ///     Raises the <see cref="E:ErrorsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e) => this.ErrorsChanged?.Invoke(this, e);

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() =>
            this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;
    }
}