// -----------------------------------------------------------------------
// <copyright file="TwoValueValidationByCommandsViewModel.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.ValidationTestGui.TwoValueSortedValidationByCommands.ViewModels
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Input;

    using Bfa.Common.Validations.ValidationMessageContainers;
    using Bfa.Common.Validations.Validators;

    using ValidationToolkit;

    /// <summary>
    /// </summary>
    /// <seealso cref="Bfa.Common.Binders.Bindable" />
    /// <seealso cref="System.ComponentModel.INotifyDataErrorInfo" />
    /// <seealso cref="System.IDisposable" />
    public class TwoValueSortedValidationByCommandsViewModel : Binders.Bindable, INotifyDataErrorInfo, IDisposable
    {
        /// <summary>
        ///     The object name
        /// </summary>
        private const string ObjectName = "Object";

        /// <summary>
        ///     The value1 name
        /// </summary>
        private const string Value1Name = "Value1";

        /// <summary>
        ///     The value2 name
        /// </summary>
        private const string Value2Name = "Value2";

        /// <summary>
        ///     The value1
        /// </summary>
        private string value1;

        /// <summary>
        ///     The value2
        /// </summary>
        private string value2;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TwoValueSortedValidationByCommandsViewModel" /> class.
        /// </summary>
        public TwoValueSortedValidationByCommandsViewModel()
        {
            this.Validator = new ValidatorBuilder<TwoValueSortedValidationByCommandsViewModel>().Build(this);

            this.Validator.ValidationMessages.ErrorsChanged += this.ValidationMessagesOnErrorsChanged;

            this.Value1Error1Command = new RelayCommand<object>(this.OnValue1Error1Command);
            this.Value1Error2Command = new RelayCommand<object>(this.OnValue1Error2Command);
            this.Value1Warning1Command = new RelayCommand<object>(this.OnValue1Warning1Command);

            this.Value2Error1Command = new RelayCommand<object>(this.OnValue2Error1Command);
            this.Value2Error2Command = new RelayCommand<object>(this.OnValue2Error2Command);
            this.Value2Warning1Command = new RelayCommand<object>(this.OnValue2Warning1Command);

            this.ObjectError1Command = new RelayCommand<object>(this.OnObjectError1Command);
            this.ObjectWarning1Command = new RelayCommand<object>(this.OnObjectWarning1Command);
        }

        /// <summary>
        ///     Occurs when the validation errors have changed for a property or for the entire entity.
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        /// <summary>
        ///     Gets a value that indicates whether the entity has validation errors.
        /// </summary>
        public bool HasErrors => this.Validator.ValidationMessages.HasErrors;

        /// <summary>
        ///     Gets the object error1 Command.
        /// </summary>
        /// <value>
        ///     The object error1 Command.
        /// </value>
        public ICommand ObjectError1Command { get; }

        /// <summary>
        ///     Gets the object warning1 Command.
        /// </summary>
        /// <value>
        ///     The object warning1 Command.
        /// </value>
        public ICommand ObjectWarning1Command { get; }

        /// <summary>
        ///     Gets the validator.
        /// </summary>
        /// <value>
        ///     The validator.
        /// </value>
        public Validator<TwoValueSortedValidationByCommandsViewModel> Validator { get; }

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
        ///     Gets or sets the value2.
        /// </summary>
        /// <value>
        ///     The value2.
        /// </value>
        public string Value2
        {
            get => this.value2;
            set => this.SetProperty(ref this.value2, value);
        }

        /// <summary>
        ///     Gets the error1 Command.
        /// </summary>
        /// <value>
        ///     The error1 Command.
        /// </value>
        public ICommand Value1Error1Command { get; }

        /// <summary>
        ///     Gets the error2 Command.
        /// </summary>
        /// <value>
        ///     The error2 Command.
        /// </value>
        public ICommand Value1Error2Command { get; }

        /// <summary>
        ///     Gets the warning1 Command.
        /// </summary>
        /// <value>
        ///     The warning1 Command.
        /// </value>
        public ICommand Value1Warning1Command { get; }

        /// <summary>
        ///     Gets the value2 error1 Command.
        /// </summary>
        /// <value>
        ///     The value2 error1 Command.
        /// </value>
        public ICommand Value2Error1Command { get; }

        /// <summary>
        ///     Gets the value2 error2 Command.
        /// </summary>
        /// <value>
        ///     The value2 error2 Command.
        /// </value>
        public ICommand Value2Error2Command { get; }

        /// <summary>
        ///     Gets the value2 warning1 Command.
        /// </summary>
        /// <value>
        ///     The value2 warning1 Command.
        /// </value>
        public ICommand Value2Warning1Command { get; }

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Validator.ValidationMessages.ErrorsChanged -= this.ValidationMessagesOnErrorsChanged;
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
        public IEnumerable GetErrors(string propertyName)
        {
            return this.Validator.ValidationMessages.GetPropertyErrors(propertyName);
        }

        /// <summary>
        ///     Raises the <see cref="E:ErrorsChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            this.ErrorsChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Called when [error1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnObjectError1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(new ValidationError(ObjectName, "error1", "Object Error 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(ObjectName, "error1");
            }
        }

        /// <summary>
        ///     Called when [warning1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnObjectWarning1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationWarning(ObjectName, "warning1", "Object Warning 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(ObjectName, "warning1");
            }
        }

        /// <summary>
        ///     Called when [error1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue1Error1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(new ValidationError(Value1Name, "error1", "Value1 Error 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value1Name, "error1");
            }
        }

        /// <summary>
        ///     Called when [error2 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue1Error2Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(new ValidationError(Value1Name, "error2", "Value1 Error 2"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value1Name, "error2");
            }
        }

        /// <summary>
        ///     Called when [warning1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue1Warning1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationWarning(Value1Name, "warning1", "Value1 Warning 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value1Name, "warning1");
            }
        }

        /// <summary>
        ///     Called when [error1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue2Error1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(new ValidationError(Value2Name, "error1", "Value2 Error 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value2Name, "error1");
            }
        }

        /// <summary>
        ///     Called when [error2 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue2Error2Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(new ValidationError(Value2Name, "error2", "Value2 Error 2"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value2Name, "error2");
            }
        }

        /// <summary>
        ///     Called when [warning1 Command].
        /// </summary>
        /// <param name="state">if set to <c>true</c> [state].</param>
        private void OnValue2Warning1Command(object state)
        {
            if ((bool)state)
            {
                this.Validator.ValidationMessages.AddError(
                    new ValidationWarning(Value2Name, "warning1", "Value2 Warning 1"));
            }
            else
            {
                this.Validator.ValidationMessages.RemoveError(Value2Name, "warning1");
            }
        }

        /// <summary>
        ///     Validations the messages on errors changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DataErrorsChangedEventArgs" /> instance containing the event data.</param>
        private void ValidationMessagesOnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            this.OnErrorsChanged(e);
        }
    }
}