// -----------------------------------------------------------------------
// <copyright file="CatchValidationErrorBehavior.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Validations.Behaviors
{
    using System;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    using Bfa.Common.Validations.ValidationMessageContainers;
    using Bfa.Common.Validations.ValidationMessageContainers.Interfaces;
    using Bfa.Common.Validations.ValidationMessageContainers.Internals;
    using Bfa.Common.WPF.Validations.ValidationRules.Interfaces;

    using Microsoft.Xaml.Behaviors;

    using ValidationToolkit.Annotations;

    using ValidationError = Bfa.Common.Validations.ValidationMessageContainers.ValidationError;

    /// <summary>
    ///     Catch Validation Error Behavior class.
    /// </summary>
    /// <seealso cref="Behavior{T}" />
    public class CatchValidationErrorBehavior : Behavior<FrameworkElement>
    {
        /// <summary>
        ///     The element property
        /// </summary>
        public static readonly DependencyProperty ElementProperty = DependencyProperty.Register(
            nameof(Element),
            typeof(FrameworkElement),
            typeof(CatchValidationErrorBehavior),
            new PropertyMetadata(default(FrameworkElement), OnElementPropertyChanged));

        /// <summary>
        ///     The validation errors property
        /// </summary>
        public static readonly DependencyProperty ValidationErrorsProperty = DependencyProperty.Register(
            nameof(ValidationErrors),
            typeof(ICatchValidationErrorContainer),
            typeof(CatchValidationErrorBehavior),
            new PropertyMetadata(default(ICatchValidationErrorContainer)));

        /// <summary>
        ///     The error container
        /// </summary>
        private ICatchValidationErrorContainer errorContainer;

        /// <summary>
        ///     The framework element
        /// </summary>
        private FrameworkElement frameworkElement;

        /// <summary>
        ///     Gets or sets the element.
        /// </summary>
        /// <value>
        ///     The element.
        /// </value>
        public FrameworkElement Element
        {
            get => (FrameworkElement)this.GetValue(ElementProperty);
            set => this.SetValue(ElementProperty, value);
        }

        /// <summary>
        ///     Gets or sets the validation errors.
        /// </summary>
        /// <value>
        ///     The validation errors.
        /// </value>
        public ICatchValidationErrorContainer ValidationErrors
        {
            get => (ICatchValidationErrorContainer)this.GetValue(ValidationErrorsProperty);
            set => this.SetValue(ValidationErrorsProperty, value);
        }

        /// <summary>
        ///     Called when [element property changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnElementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is CatchValidationErrorBehavior behavior))
            {
                return;
            }

            if (e.NewValue == e.OldValue)
            {
                return;
            }

            if (e.NewValue is FrameworkElement frameworkElement)
            {
                behavior.UpdateFrameworkElement(frameworkElement);
            }
        }

        /// <summary>
        ///     Updates the framework element.
        /// </summary>
        /// <param name="newElement">The new element.</param>
        private void UpdateFrameworkElement([CanBeNull] FrameworkElement newElement)
        {
            var oldElement = this.frameworkElement;
            if (oldElement != null)
            {
                oldElement.Loaded -= this.OnLoaded;

                oldElement.Unloaded -= this.OnUnloaded;
            }

            this.frameworkElement = newElement;

            if (newElement != null)
            {
                newElement.Loaded += this.OnLoaded;
                newElement.Unloaded += this.OnUnloaded;
            }
        }

        /// <summary>
        ///     Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>
        ///     Override this to hook up functionality to the AssociatedObject.
        /// </remarks>
        protected override void OnAttached()
        {
            if (this.Element == null)
            {
                this.frameworkElement = this.AssociatedObject;
            }
            else
            {
                this.frameworkElement = this.Element;
            }

            var element = this.frameworkElement;
            if (element != null)
            {
                element.Loaded += this.OnLoaded;
                element.Unloaded += this.OnUnloaded;
            }

            base.OnAttached();
        }

        /// <summary>
        ///     Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>
        ///     Override this to unhook functionality from the AssociatedObject.
        /// </remarks>
        protected override void OnDetaching()
        {
            this.frameworkElement.Loaded -= this.OnLoaded;
            this.frameworkElement.Unloaded -= this.OnUnloaded;
            base.OnDetaching();
        }

        /// <summary>
        ///     Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            var element = this.AssociatedObject;
            if (element == null)
            {
                return;
            }

            var dataContext = element.DataContext;
            switch (dataContext)
            {
                case IValidationMessagesAware aware:
                    this.errorContainer = aware.ValidationMessages;
                    break;

                case ICatchValidationErrorContainer container:
                    this.errorContainer = container;
                    break;
            }

            element.DataContextChanged += this.OnDataContextChanged;
            element.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.OnErrorEvent), true);
        }

        /// <summary>
        ///     Called when [data context changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var element = this.AssociatedObject;
            if (element != null)
            {
                this.errorContainer = (ICatchValidationErrorContainer)element.DataContext;
            }
        }

        /// <summary>
        ///     Called when [unloaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            var element = this.AssociatedObject;
            if (element == null)
            {
                return;
            }

            element.RemoveHandler(Validation.ErrorEvent, new RoutedEventHandler(this.OnErrorEvent));
            element.DataContextChanged -= this.OnDataContextChanged;
        }

        /// <summary>
        ///     Called when [error event].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        /// <exception cref="Exception">Unknown state!</exception>
        private void OnErrorEvent(object sender, RoutedEventArgs e)
        {
            var args = e as ValidationErrorEventArgs;
            var validationError = args?.Error;
            if (validationError == null)
            {
                return;
            }

            if (!(validationError.RuleInError is ValidationRule validationRule))
            {
                return;
            }

            if (validationRule is NotifyDataErrorValidationRule)
            {
                return;
            }

            if (this.errorContainer == null)
            {
                return;
            }

            if (!(args.Error.BindingInError is BindingExpression bindingExpression))
            {
                return;
            }

            var propertyName = bindingExpression.ParentBinding?.Path?.Path;
            if (propertyName == null)
            {
                throw new Exception("PropertyName is null.");
            }

            if (!(args.OriginalSource is DependencyObject originalSource))
            {
                return;
            }

            var errorMessage = GetErrorMessage(propertyName, validationError);
            var errorId = GetErrorId(validationError);

            switch (args.Action)
            {
                case ValidationErrorEventAction.Added:
                    {
                        IValidationMessage message;
                        if (!(args.Error.ErrorContent is IValidationRuleMessage ruleMessage))
                        {
                            message = new ValidationError(propertyName, errorId, errorMessage);
                        }
                        else
                        {
                            switch (ruleMessage)
                            {
                                case IValidationRuleWarning ruleWarning:
                                    message = new ValidationWarning(propertyName, errorId, ruleWarning.Message);
                                    break;

                                case IValidationRuleError ruleError:
                                    message = new ValidationError(propertyName, errorId, ruleError.Message);
                                    break;

                                default:
                                    message = new ValidationError(propertyName, errorId, ruleMessage.Message);
                                    break;
                            }
                        }

                        this.errorContainer.AddCatchValidationError(message);
                        break;
                    }

                case ValidationErrorEventAction.Removed:
                    this.errorContainer.RemoveCatchValidationError(propertyName, errorId);
                    break;

                default:
                    throw new Exception("Unknown state!");
            }
        }

        /// <summary>
        ///     Gets the error identifier.
        /// </summary>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        private static string GetErrorId(System.Windows.Controls.ValidationError error)
        {
            var errorId = new StringBuilder();
            errorId.Append(error.RuleInError);
            return errorId.ToString();
        }

        /// <summary>
        ///     Gets the error message.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="error">The error.</param>
        /// <returns></returns>
        private static string GetErrorMessage(string propertyName, System.Windows.Controls.ValidationError error)
        {
            var builder = new StringBuilder();
            builder.Append(propertyName).Append(":");

            if (error.Exception?.InnerException == null)
            {
                builder.Append(error.ErrorContent);
            }
            else
            {
                builder.Append(error.Exception.InnerException.Message);
            }

            return builder.ToString();
        }
    }
}