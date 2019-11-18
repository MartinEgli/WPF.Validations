namespace Bfa.Common.WPF.Validations.ValidationTestGui.Localizations
{
    using Bfa.Pi.Infrastructure.Common.LocalizationProviders;
    using System.Windows;
    using WPFLocalizeExtension.Engine;
    using WPFLocalizeExtension.Providers;
    using XAMLMarkupExtensions.Base;

    /// <inheritdoc />
    /// <summary>
    /// A singleton provider that uses attached properties  the Parent property to iterate through the visual tree.
    /// </summary>
    public class LocalizationRepositoryProvider : LocalizationRepositoryProviderBase
    {
        #region Abstract assembly & dictionary lookup

        /// <summary>
        /// <see cref="DependencyProperty"/> DefaultGroup to set the fallback assembly.
        /// </summary>
        public static readonly DependencyProperty DefaultGroupProperty = DependencyProperty.RegisterAttached(
            "DefaultGroup",
            typeof(string),
            typeof(LocalizationRepositoryProvider),
            new PropertyMetadata(null, DefaultGroupChanged));

        /// <summary>
        /// The default source property
        /// </summary>
        public static readonly DependencyProperty DefaultSourceProperty = DependencyProperty.RegisterAttached(
            "DefaultSource",
            typeof(string),
            typeof(LocalizationRepositoryProvider),
            new PropertyMetadata(null, DefaultSourceChanged));

        /// <summary>
        /// <see cref="DependencyProperty"/> IgnoreCase to set the case sensitivity.
        /// </summary>
        public static readonly DependencyProperty IgnoreCaseProperty = DependencyProperty.RegisterAttached(
            "IgnoreCase",
            typeof(bool),
            typeof(LocalizationRepositoryProvider),
            new PropertyMetadata(true, IgnoreCaseChanged));

        /// <summary>
        /// Lock object for the creation of the singleton instance.
        /// </summary>
        private static readonly object InstanceLock = new object();

        /// <summary>
        /// The instance of the singleton.
        /// </summary>
        private static volatile LocalizationRepositoryProvider instance;

        /// <summary>
        /// A dictionary for notification classes for changes of the individual target Parent changes.
        /// </summary>
        private readonly ParentNotifiers parentNotifiers = new ParentNotifiers();

        /// <summary>
        /// The singleton constructor.
        /// </summary>
        protected LocalizationRepositoryProvider()
        {
        }

        /// <summary>
        /// Gets  the <see cref="LocalizationRepositoryProvider" /> singleton.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static LocalizationRepositoryProvider Instance
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
                        instance = new LocalizationRepositoryProvider();
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
        /// Gets or sets the fallback assembly to use when no assembly is specified.
        /// </summary>
        /// <value>
        /// The fallback group.
        /// </value>
        public string FallbackGroup { get; set; }

        /// <summary>
        /// Gets or sets the fallback source.
        /// </summary>
        /// <value>
        /// The fallback source.
        /// </value>
        public string FallbackSource { get; set; }

        /// <summary>
        /// Getter of <see cref="DependencyProperty" /> default assembly.
        /// </summary>
        /// <param name="obj">The dependency object to get the default assembly from.</param>
        /// <returns>
        /// The default assembly.
        /// </returns>
        public static string GetDefaultGroup(DependencyObject obj)
        {
            return obj.GetValueSync<string>(DefaultGroupProperty);
        }

        /// <summary>
        /// Gets the default source.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string GetDefaultSource(DependencyObject obj)
        {
            return obj.GetValueSync<string>(DefaultSourceProperty);
        }

        /// <summary>
        /// Getter of <see cref="DependencyProperty" /> ignore case flag.
        /// </summary>
        /// <param name="obj">The dependency object to get the ignore case flag from.</param>
        /// <returns>
        /// The ignore case flag.
        /// </returns>
        public static bool GetIgnoreCase(DependencyObject obj)
        {
            return obj.GetValueSync<bool>(IgnoreCaseProperty);
        }

        /// <summary>
        /// Resets the instance that is used for the SqlLocationProvider
        /// </summary>
        public static void Reset()
        {
            Instance = null;
        }

        /// <summary>
        /// Setter of <see cref="DependencyProperty" /> default assembly.
        /// </summary>
        /// <param name="obj">The dependency object to set the default assembly to.</param>
        /// <param name="value">The assembly.</param>
        public static void SetDefaultGroup(DependencyObject obj, string value)
        {
            obj.SetValueSync(DefaultGroupProperty, value);
        }

        /// <summary>
        /// Sets the default source.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="value">The value.</param>
        public static void SetDefaultSource(DependencyObject obj, string value)
        {
            obj.SetValueSync(DefaultSourceProperty, value);
        }

        /// <summary>
        /// Setter of <see cref="DependencyProperty" /> ignore case flag.
        /// </summary>
        /// <param name="obj">The dependency object to set the ignore case flag to.</param>
        /// <param name="value">The ignore case flag.</param>
        public static void SetIgnoreCase(DependencyObject obj, bool value)
        {
            obj.SetValueSync(IgnoreCaseProperty, value);
        }

        /// <summary>
        /// Get the assembly from the context, if possible.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>The assembly name, if available.</returns>
        protected override string GetGroup(DependencyObject target)
        {
            if (target == null)
            {
                return this.FallbackGroup;
            }

            var group = target.GetValueOrRegisterParentNotifier<string>(
                DefaultGroupProperty,
                this.ParentChangedAction,
                this.parentNotifiers);
            return string.IsNullOrEmpty(group) ? this.FallbackGroup : group;
        }

        protected override string GetSource(DependencyObject target)
        {
            if (target == null)
            {
                return this.FallbackSource;
            }

            var source = target.GetValueOrRegisterParentNotifier<string>(
                DefaultSourceProperty,
                this.ParentChangedAction,
                this.parentNotifiers);
            return string.IsNullOrEmpty(source) ? this.FallbackSource : source;
        }

        /// <summary>
        /// Indicates, that the <see cref="DefaultGroupProperty"/> attached property changed.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="e">The event argument.</param>
        private static void DefaultGroupChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Instance.FallbackGroup = e.NewValue?.ToString();
            Instance.OnProviderChanged(obj);
        }

        /// <summary>
        /// Defaults the source changed.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void DefaultSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Instance.FallbackSource = e.NewValue?.ToString();
            Instance.OnProviderChanged(obj);
        }

        /// <summary>
        /// Indicates, that the <see cref="IgnoreCaseProperty"/> attached property changed.
        /// </summary>
        /// <param name="obj">The dependency object.</param>
        /// <param name="e">The event argument.</param>
        private static void IgnoreCaseChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // Instance.IgnoreCase = (bool)e.NewValue;
            Instance.OnProviderChanged(obj);
        }

        /// <summary>
        /// An action that will be called when a parent of one of the observed target objects changed.
        /// </summary>
        /// <param name="obj">The target <see cref="DependencyObject" />.</param>
        private void ParentChangedAction(DependencyObject obj)
        {
            this.OnProviderChanged(obj);
        }

        #endregion Abstract assembly & dictionary lookup
    }
}