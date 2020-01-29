// -----------------------------------------------------------------------
// <copyright file="LocalizationProvider.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations
{
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;

    using WPFLocalizeExtension.Engine;
    using WPFLocalizeExtension.Providers;

    using XAMLMarkupExtensions.Base;

    /// <inheritdoc />
    /// <summary>
    ///     A singleton provider that uses attached properties and the Parent property to iterate through the visual tree.
    /// </summary>
    public class LocalizationProvider : LocalizationProviderBase
    {
        /// <summary>
        ///     <see cref="DependencyProperty" /> DefaultAssembly to set the fallback assembly.
        /// </summary>
        public static readonly DependencyProperty DefaultProviderProperty = DependencyProperty.RegisterAttached(
            "DefaultProvider",
            typeof(string),
            typeof(LocalizationProvider),
            new PropertyMetadata(null, DefaultProviderChanged));

        /// <summary>
        ///     <see cref="DependencyProperty" /> IgnoreCase to set the case sensitivity.
        /// </summary>
        public static readonly DependencyProperty IgnoreCaseProperty = DependencyProperty.RegisterAttached(
            "IgnoreCase",
            typeof(bool),
            typeof(LocalizationProvider),
            new PropertyMetadata(true, IgnoreCaseChanged));

        /// <summary>
        ///     Lock object for the creation of the singleton instance.
        /// </summary>
        private static readonly object InstanceLock = new object();

        /// <summary>
        ///     The instance of the singleton.
        /// </summary>
        private static volatile LocalizationProvider instance;

        /// <summary>
        ///     A dictionary for notification classes for changes of the individual target Parent changes.
        /// </summary>
        private readonly ParentNotifiers parentNotifiers = new ParentNotifiers();

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocalizationProvider" /> class.
        /// </summary>
        protected LocalizationProvider()
        {
            this.AvailableCultures = new ObservableCollection<CultureInfo> { CultureInfo.InvariantCulture };
        }

        /// <summary>
        ///     Gets  the <see cref="LocalizationProvider" /> singleton.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static LocalizationProvider Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new LocalizationProvider();
                    }
                }

                // return the existing/new instance
                return instance;
            }

            private set
            {
                lock (InstanceLock)
                {
                    instance = value;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the fallback assembly to use when no assembly is specified.
        /// </summary>
        /// <value>
        ///     The fallback provider.
        /// </value>
        public string FallbackProvider { get; set; }

        /// <summary>
        ///     Getter of <see cref="DependencyProperty" /> default assembly.
        /// </summary>
        /// <param name="obj">The dependency object to get the default assembly from.</param>
        /// <returns>
        ///     The default assembly.
        /// </returns>
        public static string GetDefaultProvider(DependencyObject obj)
        {
            return obj.GetValueSync<string>(DefaultProviderProperty);
        }

        /// <summary>
        ///     Getter of <see cref="DependencyProperty" /> ignore case flag.
        /// </summary>
        /// <param name="obj">The dependency object to get the ignore case flag from.</param>
        /// <returns>
        ///     The ignore case flag.
        /// </returns>
        public static bool GetIgnoreCase(DependencyObject obj)
        {
            return obj.GetValueSync<bool>(IgnoreCaseProperty);
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public static void Reset()
        {
            Instance = null;
        }

        /// <summary>
        ///     Setter of <see cref="DependencyProperty" /> default assembly.
        /// </summary>
        /// <param name="obj">The dependency object to set the default assembly to.</param>
        /// <param name="value">The assembly.</param>
        public static void SetDefaultProvider(DependencyObject obj, string value)
        {
            obj.SetValueSync(DefaultProviderProperty, value);
        }

        /// <summary>
        ///     Setter of <see cref="DependencyProperty" /> ignore case flag.
        /// </summary>
        /// <param name="obj">The dependency object to set the ignore case flag to.</param>
        /// <param name="value">The ignore case flag.</param>
        public static void SetIgnoreCase(DependencyObject obj, bool value)
        {
            obj.SetValueSync(IgnoreCaseProperty, value);
        }

        /// <summary>
        ///     Get the assembly from the context, if possible.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>The assembly name, if available.</returns>
        protected override string GetProvider(DependencyObject target)
        {
            if (target == null)
            {
                return this.FallbackProvider;
            }

            var provider = target.GetValueOrRegisterParentNotifier<string>(
                DefaultProviderProperty,
                this.ParentChangedAction,
                this.parentNotifiers);
            return string.IsNullOrEmpty(provider) ? this.FallbackProvider : provider;
        }

        /// <summary>
        ///     Indicates, that the <see cref="DefaultProviderProperty" /> attached property changed.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="e">The event argument.</param>
        private static void DefaultProviderChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Instance.FallbackProvider = e.NewValue?.ToString();
            Instance.OnProviderChanged(obj);
        }

        /// <summary>
        ///     Indicates, that the <see cref="IgnoreCaseProperty" /> attached property changed.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="e">The event argument.</param>
        private static void IgnoreCaseChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // Instance.IgnoreCase = (bool)e.NewValue;
            Instance.OnProviderChanged(obj);
        }

        /// <summary>
        ///     An action that will be called when a parent of one of the observed target objects changed.
        /// </summary>
        /// <param name="obj">The target <see cref="DependencyObject" />.</param>
        private void ParentChangedAction(DependencyObject obj)
        {
            this.OnProviderChanged(obj);
        }
    }
}