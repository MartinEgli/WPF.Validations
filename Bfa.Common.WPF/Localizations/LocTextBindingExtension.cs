// -----------------------------------------------------------------------
// <copyright file="LocTextBindingExtension.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    using Bfa.Common.Strings;
    using Bfa.Common.WPF.Localizations.Converters;
    using Bfa.Common.WPF.Localizations.Exceptions;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Engine;
    using WPFLocalizeExtension.Extensions;

#pragma warning disable SA1202 // Elements must be ordered by access

    /// <summary>
    ///     Localization Text Binding
    /// </summary>
    /// <seealso cref="System.Windows.Markup.MarkupExtension" />
    /// <seealso cref="T:System.Windows.Markup.MarkupExtension" />
    [MarkupExtensionReturnType(typeof(string))]
    [ContentProperty("KeyBinding")]
    public sealed class LocTextBindingExtension : MarkupExtension
    {
        /// <summary>
        ///     The identifier source
        /// </summary>
        private static int IdSource;

        /// <summary>
        ///     The format segment1
        /// </summary>
        [CanBeNull]
        private string formatSegment0;

        /// <summary>
        ///     The format segment2
        /// </summary>
        [CanBeNull]
        private string formatSegment1;

        /// <summary>
        ///     The format segment3
        /// </summary>
        [CanBeNull]
        private string formatSegment2;

        /// <summary>
        ///     The format segment4
        /// </summary>
        [CanBeNull]
        private string formatSegment3;

        /// <summary>
        ///     The format segment5
        /// </summary>
        [CanBeNull]
        private string formatSegment4;

        /// <summary>
        ///     The format segment binding1
        /// </summary>
        [CanBeNull]
        private BindingBase formatSegmentBinding0;

        /// <summary>
        ///     The format segment binding2
        /// </summary>
        [CanBeNull]
        private BindingBase formatSegmentBinding1;

        /// <summary>
        ///     The format segment binding3
        /// </summary>
        [CanBeNull]
        private BindingBase formatSegmentBinding2;

        /// <summary>
        ///     The format segment binding4
        /// </summary>
        [CanBeNull]
        private BindingBase formatSegmentBinding3;

        /// <summary>
        ///     The format segment binding5
        /// </summary>
        [CanBeNull]
        private BindingBase formatSegmentBinding4;

        /// <summary>
        ///     The has segments
        /// </summary>
        private bool hasSegments;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingExtension" /> class.
        /// </summary>
        public LocTextBindingExtension()
        {
            this.Id = Interlocked.Increment(ref IdSource);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LocTextBindingExtension" /> class.
        /// </summary>
        /// <param name="keyBinding">The key binding.</param>
        /// <exception cref="ArgumentNullException">keyBinding is null.</exception>
        public LocTextBindingExtension([NotNull] Binding keyBinding)
            : this()
        {
            this.KeyBinding = keyBinding ?? throw new ArgumentNullException(nameof(keyBinding));
        }

        public int Id { get; }

        /// <summary>
        ///     Gets or sets the default.
        /// </summary>
        /// <value>
        ///     The default.
        /// </value>
        public string Default { get; set; }

        /// <summary>
        ///     Gets or sets the force culture.
        /// </summary>
        /// <value>
        ///     The force culture.
        /// </value>
        [CanBeNull]
        public CultureInfo ForceCulture { get; set; }

        /// <summary>
        ///     Gets or sets the force culture binding.
        /// </summary>
        /// <value>
        ///     The force culture binding.
        /// </value>
        [CanBeNull]
        public Binding ForceCultureBinding { get; set; }

        /// <summary>
        ///     Gets or sets the format segment1.
        /// </summary>
        /// <value>
        ///     The format segment1.
        /// </value>
        [CanBeNull]
        public string FormatSegment0
        {
            get => this.formatSegment0;
            set
            {
                this.formatSegment0 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment2.
        /// </summary>
        /// <value>
        ///     The format segment2.
        /// </value>
        [CanBeNull]
        public string FormatSegment1
        {
            get => this.formatSegment1;
            set
            {
                this.formatSegment1 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment3.
        /// </summary>
        /// <value>
        ///     The format segment3.
        /// </value>
        [CanBeNull]
        public string FormatSegment2
        {
            get => this.formatSegment2;
            set
            {
                this.formatSegment2 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment4.
        /// </summary>
        /// <value>
        ///     The format segment4.
        /// </value>
        [CanBeNull]
        public string FormatSegment3
        {
            get => this.formatSegment3;
            set
            {
                this.formatSegment3 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment5.
        /// </summary>
        /// <value>
        ///     The format segment5.
        /// </value>
        [CanBeNull]
        public string FormatSegment4
        {
            get => this.formatSegment4;
            set
            {
                this.formatSegment4 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment binding1.
        /// </summary>
        /// <value>
        ///     The format segment binding1.
        /// </value>
        [CanBeNull]
        public BindingBase FormatSegmentBinding0
        {
            get => this.formatSegmentBinding0;
            set
            {
                this.formatSegmentBinding0 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment binding2.
        /// </summary>
        /// <value>
        ///     The format segment binding2.
        /// </value>
        [CanBeNull]
        public BindingBase FormatSegmentBinding1
        {
            get => this.formatSegmentBinding1;
            set
            {
                this.formatSegmentBinding1 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment binding3.
        /// </summary>
        /// <value>
        ///     The format segment binding3.
        /// </value>
        [CanBeNull]
        public BindingBase FormatSegmentBinding2
        {
            get => this.formatSegmentBinding2;
            set
            {
                this.formatSegmentBinding2 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment binding4.
        /// </summary>
        /// <value>
        ///     The format segment binding4.
        /// </value>
        [CanBeNull]
        public BindingBase FormatSegmentBinding3
        {
            get => this.formatSegmentBinding3;
            set
            {
                this.formatSegmentBinding3 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the format segment binding5.
        /// </summary>
        /// <value>
        ///     The format segment binding5.
        /// </value>
        [CanBeNull]
        public BindingBase FormatSegmentBinding4
        {
            get => this.formatSegmentBinding4;
            set
            {
                this.formatSegmentBinding4 = value;
                this.hasSegments = true;
            }
        }

        /// <summary>
        ///     Gets or sets the group.
        /// </summary>
        /// <value>
        ///     The group.
        /// </value>
        public string Group { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the group binding.
        /// </summary>
        /// <value>
        ///     The group binding.
        /// </value>
        public Binding GroupBinding { get; set; }

        /// <summary>
        ///     Gets or sets the key.
        /// </summary>
        /// <value>
        ///     The key.
        /// </value>
        [CanBeNull]
        public string Key { get; set; }

        /// <summary>
        ///     Gets or sets the key binding.
        /// </summary>
        /// <value>
        ///     The key binding.
        /// </value>
        [CanBeNull]
        public Binding KeyBinding { get; set; }

        /// <summary>
        ///     Gets or sets the object binding.
        /// </summary>
        /// <value>
        ///     The object binding.
        /// </value>
        [CanBeNull]
        public Binding ObjectBinding { get; set; }

        /// <summary>
        ///     Gets or sets the source.
        /// </summary>
        /// <value>
        ///     The source.
        /// </value>
        public string Source { get; set; } = string.Empty;

        /// <summary>
        ///     Gets or sets the source binding.
        /// </summary>
        /// <value>
        ///     The source binding.
        /// </value>
        public Binding SourceBinding { get; set; }

        /// <summary>
        ///     Gets the target object.
        /// </summary>
        /// <value>
        ///     The target object.
        /// </value>
        public DependencyObject TargetObject { get; private set; }

        /// <summary>
        ///     Gets the target property.
        /// </summary>
        /// <value>
        ///     The target property.
        /// </value>
        public DependencyProperty TargetProperty { get; private set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the text binding.
        /// </summary>
        /// <value>
        ///     The text binding.
        /// </value>
        [CanBeNull]
        public Binding TextBinding { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is empty use default.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is empty use default; otherwise, <c>false</c>.
        /// </value>
        public bool UseDefaultIsEmpty { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether [use text as fallback].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [use text as fallback]; otherwise, <c>false</c>.
        /// </value>
        public bool UseTextAsFallback { get; set; } = false;

        /// <summary>
        ///     Gets or sets the format segment binding map.
        /// </summary>
        /// <value>
        ///     The format segment binding map.
        /// </value>
        internal List<int> FormatSegmentBindingMap { get; set; }

        /// <summary>
        ///     Gets or sets the format segment bindings.
        /// </summary>
        /// <value>
        ///     The format segment bindings.
        /// </value>
        internal List<BindingBase> FormatSegmentBindings { get; set; }

        /// <summary>
        ///     Gets the format segment count.
        /// </summary>
        /// <value>
        ///     The format segment count.
        /// </value>
        internal int FormatSegmentCount { get; private set; }

        /// <summary>
        ///     Gets or sets the formatter.
        /// </summary>
        /// <value>
        ///     The formatter.
        /// </value>
        [CanBeNull]
        internal string Formatter { get; set; }

        /// <summary>
        ///     Gets the notify property changed.
        /// </summary>
        /// <value>
        ///     The notify property changed.
        /// </value>
        internal INotifyPropertyChanged NotifyPropertyChanged { get; private set; }

        /// <summary>
        ///     Gets the fully qualified key.
        /// </summary>
        /// <value>
        ///     The fully qualified key.
        /// </value>
        private string FullyQualifiedKey
        {
            get
            {
                var key = this.Key;
                return key != null
                           ? LocalizationProviderHelpers.FullyQualifiedKey(this.Source, this.Group, key)
                           : string.Empty;
            }
        }

        /// <summary>
        ///     When implemented in a derived class, returns an object that is provided as the value of the target property for
        ///     this markup extension.
        /// </summary>
        /// <param name="serviceProvider">A service provider helper that can provide services for the markup extension.</param>
        /// <returns>
        ///     The object value to set on the property where the extension is applied.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">KeyBinding</exception>
        /// <inheritdoc />
        [NotNull]
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            this.SetDefault();

            if (serviceProvider == null)
            {
                return this.Default;
            }

#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(serviceProvider.GetService(typeof(IProvideValueTarget)) is IProvideValueTarget provideValueTarget))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return this.Default;
            }

            if (provideValueTarget.TargetObject.IsSharedDp())
            {
                return this;
            }

            if ((this.TargetObject = provideValueTarget.TargetObject as DependencyObject) == null)
            {
                //if (provideValueTarget.TargetObject.GetType().FullName == "System.Windows.SharedDp")
                //{
                //    return this;
                //}

                return provideValueTarget.TargetObject;
            }

            this.TargetProperty = (DependencyProperty)provideValueTarget.TargetProperty;

            var result = this.ProvideRunTimeValue(serviceProvider);
#pragma warning disable SA1119 // Statement must not use unnecessary parenthesis
            if (!(result is string str))
#pragma warning restore SA1119 // Statement must not use unnecessary parenthesis
            {
                return result ?? this.Default;
            }

            if (str.IsNullOrEmpty() && this.UseDefaultIsEmpty)
            {
                return this.Default;
            }

            return result ?? this.Default;
        }

        /// <summary>
        ///     Updates the notify property changed.
        /// </summary>
        /// <param name="notifyPropertyChanged">The notify property changed.</param>
        internal void UpdateNotifyPropertyChanged(INotifyPropertyChanged notifyPropertyChanged)
        {
            //lock (this.updateLook)
            {
                if (!Equals(notifyPropertyChanged, this.NotifyPropertyChanged))
                {
                    if (this.NotifyPropertyChanged != null)
                    {
                        this.NotifyPropertyChanged.PropertyChanged -= this.UpdateTargetOnPropertyChanged;
                    }

                    this.NotifyPropertyChanged = notifyPropertyChanged;

                    if (this.NotifyPropertyChanged != null)
                    {
                        this.NotifyPropertyChanged.PropertyChanged += this.UpdateTargetOnPropertyChanged;
                    }
                }
            }
        }

        /// <summary>
        ///     Creates the by key and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="cultureBinding">The culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase cultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyAndCultureBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(cultureBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key and group binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyAndGroupBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding groupBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyAndGroupBindingConverter.Instance, ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(groupBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key and group binding and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyAndGroupBindingAndSourceBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyAndSourceBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the instance by key binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            if (keyBinding == null)
            {
                throw new ArgumentNullException(nameof(keyBinding));
            }

            var multiBinding =
                new MultiBinding { Converter = KeyBindingConverter.Instance, ConverterParameter = parameter };
            multiBinding.Bindings.Add(keyBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndCultureConverter.Instance,
                                       ConverterParameter = parameter
                                   };

            multiBinding.Bindings.Add(keyBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="cultureBinding">The culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase cultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndCultureBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(cultureBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and group binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">Bad</exception>
        private static object CreateByKeyBindingAndGroupBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndGroupBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(groupBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and group binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndObject(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and object and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndObjectAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and object and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndObjectAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and segment.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSegment(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and segment and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSegmentAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            List<BindingBase> formatSegmentBindings,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and segment and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSegmentAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndObject(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and object and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndObjectAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and object and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndObjectAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and segment.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegment(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and segment and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegmentAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and segment and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegmentAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and group binding and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndText(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObject(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding textBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding and object binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and group binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndText(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextAndObject(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding groupBinding,
            [NotNull] Binding textBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding and object binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and group binding and text binding and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding textBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndObject(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndObjectConverter.Instance,
                                       ConverterParameter = parameter,
                                       Mode = BindingMode.OneWay
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(objectBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and object and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndObjectAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndObjectAndCultureConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(objectBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and object and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="cultureBinding">The culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndObjectAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase objectBinding,
            [NotNull] BindingBase cultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndObjectAndCultureBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(objectBinding);
            multiBinding.Bindings.Add(cultureBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and segment.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndSegment(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingConverter.Instance, ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            foreach (var binding in formatSegmentBindings)
            {
                multiBinding.Bindings.Add(binding);
            }

            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and segment and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSegmentAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and segment and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSegmentAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding objectBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndObject(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and object and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndObjectAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and object and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndObjectAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and segment.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndSegment(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and segment and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="formatSegmentBindings">The format segment bindings.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndSegmentAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] List<BindingBase> formatSegmentBindings,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and segment and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndSegmentAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding objectBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and source binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndText(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextAndObject(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding textBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] Binding sourceBinding,
            [NotNull] Binding textBinding,
            [NotNull] Binding forceCultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding and object binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and source binding and text binding and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndText(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] Binding keyBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextAndObject(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndTextBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase textBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndTextBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(textBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and text binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndTextBindingAndCulture(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase textBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndTextBindingAndCultureConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(textBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and text binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="cultureBinding">The culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyBindingAndTextBindingAndCultureBinding(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase keyBinding,
            [NotNull] BindingBase textBinding,
            [NotNull] BindingBase cultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyBindingAndTextBindingAndCultureConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(textBinding);
            multiBinding.Bindings.Add(cultureBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key binding and text binding and object binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object CreateByKeyBindingAndTextBindingAndObjectBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            var converter = new KeyBindingAndTextBindingAndObjectConverter(
                this.TargetObject,
                this.Source,
                this.Group,
                this.UseTextAsFallback);
            var multiBinding = new MultiBinding { Converter = converter };
            multiBinding.Bindings.Add(keyBinding);
            multiBinding.Bindings.Add(textBinding);
            multiBinding.Bindings.Add(objectBinding);
            var obj = multiBinding.ProvideValue(serviceProvider);
            if (obj is MultiBindingExpression expression)
            {
                converter.Expression = expression;
            }

            return obj;
        }

        /// <summary>
        ///     Creates the by key binding and text binding and object binding and culture.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextBindingAndObjectBindingAndCulture(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding textBinding,
            Binding objectBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key binding and text binding and object binding and culture binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The loc text binding extension.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private static object CreateByKeyBindingAndTextBindingAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding textBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Creates the by key object and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="cultureBinding">The culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyObjectAndCultureBindingBindings(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase objectBinding,
            [NotNull] BindingBase cultureBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyObjectAndCultureBindingConverter.Instance,
                                       ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(objectBinding);
            multiBinding.Bindings.Add(cultureBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key object and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyObjectAndCultureBindings(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyObjectAndCultureConverter.Instance, ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(objectBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by key object bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByKeyObjectBindings(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase objectBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = KeyObjectConverter.Instance, ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(objectBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Creates the by text binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private static object CreateByTextBindingBindings(
            [NotNull] IServiceProvider serviceProvider,
            [NotNull] BindingBase textBinding,
            [NotNull] LocTextBindingExtension parameter)
        {
            var multiBinding = new MultiBinding
                                   {
                                       Converter = TextBindingConverter.Instance, ConverterParameter = parameter
                                   };
            multiBinding.Bindings.Add(textBinding);
            return multiBinding.ProvideValue(serviceProvider);
        }

        /// <summary>
        ///     Checks the segments.
        /// </summary>
        /// <exception cref="LocTextBindingException">
        ///     Properties FormatSegment0 and FormatSegmentBinding0 are set!
        ///     or
        ///     Properties FormatSegment1 and FormatSegmentBinding1 are set!
        ///     or
        ///     Properties FormatSegment2 and FormatSegmentBinding2 are set!
        ///     or
        ///     Properties FormatSegment3 and FormatSegmentBinding3 are set!
        ///     or
        ///     Properties FormatSegment4 and FormatSegmentBinding4 are set!
        ///     or
        ///     Property FormatSegment0 or FormatSegmentBinding0 is not set!
        ///     or
        ///     Property FormatSegment1 or FormatSegmentBinding1 is not set!
        ///     or
        ///     Property FormatSegment2 or FormatSegmentBinding2 is not set!
        ///     or
        ///     Property FormatSegment3 or FormatSegmentBinding3 is not set!
        /// </exception>
        private void CheckSegments()
        {
            if (this.FormatSegment0 != null && this.FormatSegmentBinding0 != null)
            {
                throw new LocTextBindingException("Properties FormatSegment0 and FormatSegmentBinding0 are set!");
            }

            if (this.FormatSegment1 != null && this.FormatSegmentBinding1 != null)
            {
                throw new LocTextBindingException("Properties FormatSegment1 and FormatSegmentBinding1 are set!");
            }

            if (this.FormatSegment2 != null && this.FormatSegmentBinding2 != null)
            {
                throw new LocTextBindingException("Properties FormatSegment2 and FormatSegmentBinding2 are set!");
            }

            if (this.FormatSegment3 != null && this.FormatSegmentBinding3 != null)
            {
                throw new LocTextBindingException("Properties FormatSegment3 and FormatSegmentBinding3 are set!");
            }

            if (this.FormatSegment4 != null && this.FormatSegmentBinding4 != null)
            {
                throw new LocTextBindingException("Properties FormatSegment4 and FormatSegmentBinding4 are set!");
            }

            if (!((this.FormatSegment0 != null) ^ (this.FormatSegmentBinding0 != null))
                && (this.FormatSegment1 != null) ^ (this.FormatSegmentBinding1 != null))
            {
                throw new LocTextBindingException("Property FormatSegment0 or FormatSegmentBinding0 is not set!");
            }

            if (!((this.FormatSegment1 != null) ^ (this.FormatSegmentBinding1 != null))
                && (this.FormatSegment2 != null) ^ (this.FormatSegmentBinding2 != null))
            {
                throw new LocTextBindingException("Property FormatSegment1 or FormatSegmentBinding1 is not set!");
            }

            if (!((this.FormatSegment2 != null) ^ (this.FormatSegmentBinding2 != null))
                && (this.FormatSegment3 != null) ^ (this.FormatSegmentBinding3 != null))
            {
                throw new LocTextBindingException("Property FormatSegment2 or FormatSegmentBinding2 is not set!");
            }

            if (!((this.FormatSegment3 != null) ^ (this.FormatSegmentBinding3 != null))
                && (this.FormatSegment4 != null) ^ (this.FormatSegmentBinding4 != null))
            {
                throw new LocTextBindingException("Property FormatSegment3 or FormatSegmentBinding3 is not set!");
            }
        }

        /// <summary>
        ///     Creates the by key binding and group binding and source binding and text binding and object binding and culture
        ///     binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="keyBinding">The key binding.</param>
        /// <param name="groupBinding">The group binding.</param>
        /// <param name="sourceBinding">The source binding.</param>
        /// <param name="textBinding">The text binding.</param>
        /// <param name="objectBinding">The object binding.</param>
        /// <param name="forceCultureBinding">The force culture binding.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBindingAndCultureBinding(
            IServiceProvider serviceProvider,
            Binding keyBinding,
            Binding groupBinding,
            Binding sourceBinding,
            Binding textBinding,
            Binding objectBinding,
            Binding forceCultureBinding,
            LocTextBindingExtension parameter)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Provides the key.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKey(IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                return this.OnlyKeyAndCultureBindings();
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyAndObjectBinding(IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                return this.KeyAndObjectAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyAndObjectAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyAndObjectBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key and segments.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyAndSegments(IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                if (this.ForceCultureBinding != null)
                {
                    throw new LocTextBindingException("Properties ForceCultureBinding and ForceCulture are set!");
                }

                return this.KeyAndSegmentsAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyAndSegmentsAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyAndSegmentsBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        /// <exception cref="LocTextBindingException">Properties ForceCultureBinding and ForceCulture are set!</exception>
        private object CultureProvideKeyBinding([NotNull] IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                if (this.ForceCultureBinding != null)
                {
                    throw new LocTextBindingException("Properties ForceCultureBinding and ForceCulture are set!");
                }

                return this.KeyBindingAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyBindingBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and object binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        /// <exception cref="LocTextBindingException">Properties ForceCultureBinding and ForceCulture are set!</exception>
        private object CultureProvideKeyBindingAndObjectBinding(IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                if (this.ForceCultureBinding != null)
                {
                    throw new LocTextBindingException("Properties ForceCultureBinding and ForceCulture are set!");
                }

                return this.KeyBindingAndObjectAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndObjectAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyBindingAndObjectBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and segments.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyBindingAndSegments([NotNull] IServiceProvider serviceProvider)
        {
            this.CheckSegments();

            if (this.ForceCulture != null)
            {
                if (this.ForceCultureBinding != null)
                {
                    throw new LocTextBindingException("Properties ForceCultureBinding and ForceCulture are set!");
                }

                return this.KeyBindingAndSegmentAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndSegmentAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyBindingAndSegmentBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyBindingAndText(IServiceProvider serviceProvider)
        {
            if (this.ForceCulture != null)
            {
                if (this.ForceCultureBinding != null)
                {
                    throw new LocTextBindingException("Properties ForceCultureBinding and ForceCulture are set!");
                }

                return this.KeyBindingKeyBindingAndTextAndCultureBindings(serviceProvider);
            }

            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndTextAndCultureBindingBindings(serviceProvider);
            }

            return this.KeyBindingAndTextBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyBindingAndTextAndObjectBinding(IServiceProvider serviceProvider)
        {
            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndTextAndObjectBindingAndCultureBindingBindings(serviceProvider);
            }

            if (this.ForceCulture != null)
            {
                return this.KeyBindingAndTextAndObjectBindingAndCultureBindings(serviceProvider);
            }

            return this.KeyBindingAndTextAndObjectBindingBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text and segments.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object CultureProvideKeyBindingAndTextAndSegments(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Provides the key binding and text binding.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object CultureProvideKeyBindingAndTextBinding(IServiceProvider serviceProvider)
        {
            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndTextBindingAndCultureBindingBindings(serviceProvider);
            }

            if (this.ForceCulture != null)
            {
                return this.KeyBindingAndTextBindingAndCultureBindings(serviceProvider);
            }

            return this.KeyBindingAndTextBindingBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text binding and object.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private object CultureProvideKeyBindingAndTextBindingAndObjectBinding(IServiceProvider serviceProvider)
        {
            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndTextBindingAndObjectBindingAndCultureBindingBindings(serviceProvider);
            }

            if (this.ForceCulture != null)
            {
                return this.KeyBindingAndTextBindingAndObjectBindingAndCultureBindings(serviceProvider);
            }

            return this.KeyBindingAndTextBindingAndObjectBindingBindings(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text binding and segment.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private object CultureProvideKeyBindingAndTextBindingAndSegments(IServiceProvider serviceProvider)
        {
            if (this.ForceCultureBinding != null)
            {
                return this.KeyBindingAndTextBindingAndSegmentsAndCultureBindingBindings(serviceProvider);
            }

            if (this.ForceCulture != null)
            {
                return this.KeyBindingAndTextBindingAndSegmentsAndCultureBindings(serviceProvider);
            }

            return this.KeyBindingAndTextBindingAndSegmentsBindings(serviceProvider);
        }

        /// <summary>
        ///     Gets the segments.
        /// </summary>
        private void GetSegments()
        {
            if (this.FormatSegmentBinding0 != null)
            {
                this.FormatSegmentBindingMap.Add(0);
                this.FormatSegmentBindings.Add(this.FormatSegmentBinding0);
            }
            else if (this.FormatSegment0 == null)
            {
                this.FormatSegmentCount = 0;
                return;
            }

            if (this.FormatSegmentBinding1 != null)
            {
                this.FormatSegmentBindingMap.Add(1);
                this.FormatSegmentBindings.Add(this.FormatSegmentBinding1);
            }
            else if (this.FormatSegment1 == null)
            {
                this.FormatSegmentCount = 1;
                return;
            }

            if (this.FormatSegmentBinding2 != null)
            {
                this.FormatSegmentBindingMap.Add(2);
                this.FormatSegmentBindings.Add(this.FormatSegmentBinding2);
            }
            else if (this.FormatSegment2 == null)
            {
                this.FormatSegmentCount = 2;
                return;
            }

            if (this.FormatSegmentBinding3 != null)
            {
                this.FormatSegmentBindingMap.Add(3);
                this.FormatSegmentBindings.Add(this.FormatSegmentBinding3);
            }
            else if (this.FormatSegment3 == null)
            {
                this.FormatSegmentCount = 3;
                return;
            }

            if (this.FormatSegmentBinding4 != null)
            {
                this.FormatSegmentBindingMap.Add(4);
                this.FormatSegmentBindings.Add(this.FormatSegmentBinding4);
                this.FormatSegmentCount = 5;
            }
            else if (this.FormatSegment4 == null)
            {
                this.FormatSegmentCount = 4;
            }
            else
            {
                this.FormatSegmentCount = 5;
            }
        }

        /// <summary>
        ///     Keys the and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            return CreateByKeyAndCultureBinding(serviceProvider, this.ForceCultureBinding, this);
        }

        /// <summary>
        ///     Keys an culture bindings.
        /// </summary>
        /// <returns>The object.</returns>
        private object OnlyKeyAndCultureBindings()
        {
            this.Formatter = LocExtension.GetLocalizedValue<string>(
                this.FullyQualifiedKey,
                this.ForceCulture,
                this.TargetObject);

            if (this.UseDefaultIsEmpty)
            {
                return this.OnlyKeyEmptyUseDefaultBindings();
            }

            return this.Formatter.IsNullOrEmpty() ? null : this.Formatter;
        }

        /// <summary>
        ///     Keys the object and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyAndObjectAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            return CreateByKeyObjectAndCultureBindingBindings(
                serviceProvider,
                this.ObjectBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the object and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyAndObjectAndCultureBindings([NotNull] IServiceProvider serviceProvider)
        {
            this.Formatter = LocExtension.GetLocalizedValue<string>(this.FullyQualifiedKey, this.TargetObject);

            return CreateByKeyObjectAndCultureBindings(serviceProvider, this.ObjectBinding, this);
        }

        /// <summary>
        ///     Keys the object bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyAndObjectBindings([NotNull] IServiceProvider serviceProvider)
        {
            this.Formatter = LocExtension.GetLocalizedValue<string>(this.FullyQualifiedKey, this.TargetObject);

            return CreateByKeyObjectBindings(serviceProvider, this.ObjectBinding, this);
        }

        /// <summary>
        ///     Keys the and segments and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyAndSegmentsAndCultureBindingBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the and segments and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyAndSegmentsAndCultureBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the and segments bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyAndSegmentsBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the binding and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindingAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindingAndCultureBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this);
            }

            return CreateByKeyBindingAndCulture(serviceProvider, this.KeyBinding, this);
        }

        /// <summary>
        ///     Keys the binding and object bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindingAndObjectAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndObjectAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndObjectAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndObjectAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndObjectAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.ObjectBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and object bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindingAndObjectAndCultureBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndObjectAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndObjectAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndObjectAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this);
            }

            return CreateByKeyBindingAndObjectAndCulture(serviceProvider, this.KeyBinding, this.ObjectBinding, this);
        }

        /// <summary>
        ///     Keys the binding and object bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindingAndObjectBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndObject(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndObject(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndObject(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this);
            }

            return CreateByKeyBindingAndObject(serviceProvider, this.KeyBinding, this.ObjectBinding, this);
        }

        /// <summary>
        ///     Keys the binding and segment and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndSegmentAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegmentAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndSegmentAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndSegmentAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndSegmentAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.ObjectBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and segment and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndSegmentAndCultureBindings([NotNull] IServiceProvider serviceProvider)
        {
            this.FormatSegmentBindingMap = new List<int>();
            this.FormatSegmentBindings = new List<BindingBase>();
            this.FormatSegmentCount = 0;
            this.GetSegments();

            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegmentAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.FormatSegmentBindings,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndSegmentAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.FormatSegmentBindings,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndSegmentAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.FormatSegmentBindings,
                    this);
            }

            return CreateByKeyBindingAndSegmentAndCulture(
                serviceProvider,
                this.KeyBinding,
                this.FormatSegmentBindings,
                this);
        }

        /// <summary>
        ///     Keys the binding and segment bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private object KeyBindingAndSegmentBindings([NotNull] IServiceProvider serviceProvider)
        {
            this.FormatSegmentBindingMap = new List<int>();
            this.FormatSegmentBindings = new List<BindingBase>();
            this.FormatSegmentCount = 0;
            this.GetSegments();

            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndSegment(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.FormatSegmentBindings,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndSegment(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.FormatSegmentBindings,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndSegment(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.FormatSegmentBindings,
                    this);
            }

            return CreateByKeyBindingAndSegment(serviceProvider, this.KeyBinding, this.FormatSegmentBindings, this);
        }

        /// <summary>
        ///     Keys the binding and text and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private object KeyBindingAndTextAndCultureBindingBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndTextAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text and object binding and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextAndObjectBindingAndCultureBindingBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObjectBindingAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextAndObjectBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextAndObjectBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndTextAndObjectBindingAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.ObjectBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text and object binding and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextAndObjectBindingAndCultureBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObjectBindingAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextAndObjectBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextAndObjectBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this);
            }

            return CreateByKeyBindingAndTextAndObjectBindingAndCulture(
                serviceProvider,
                this.KeyBinding,
                this.ObjectBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text and object binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextAndObjectBindingBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndObject(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextAndObject(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextAndObject(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.ObjectBinding,
                    this);
            }

            return CreateByKeyBindingAndTextAndObject(serviceProvider, this.KeyBinding, this.ObjectBinding, this);
        }

        /// <summary>
        ///     Keys the binding and text binding and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextBindingAndCultureBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndCultureBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.TextBinding,
                        this.ForceCultureBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndTextBindingAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.TextBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text binding and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextBindingAndCultureBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.TextBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this);
            }

            return CreateByKeyBindingAndTextBindingAndCulture(serviceProvider, this.KeyBinding, this.TextBinding, this);
        }

        /// <summary>
        ///     Keys the binding and text binding and object binding and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextBindingAndObjectBindingAndCultureBindingBindings(
            IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return this
                        .CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBindingAndCultureBinding(
                            serviceProvider,
                            this.KeyBinding,
                            this.GroupBinding,
                            this.SourceBinding,
                            this.TextBinding,
                            this.ObjectBinding,
                            this.ForceCultureBinding,
                            this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBindingAndCultureBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this.ForceCultureBinding,
                    this);
            }

            return CreateByKeyBindingAndTextBindingAndObjectBindingAndCultureBinding(
                serviceProvider,
                this.KeyBinding,
                this.TextBinding,
                this.ObjectBinding,
                this.ForceCultureBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text binding and object binding and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextBindingAndObjectBindingAndCultureBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBindingAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.TextBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBindingAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this);
            }

            return CreateByKeyBindingAndTextBindingAndObjectBindingAndCulture(
                serviceProvider,
                this.KeyBinding,
                this.TextBinding,
                this.ObjectBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text binding and object binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingAndTextBindingAndObjectBindingBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBindingAndObjectBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.TextBinding,
                        this.ObjectBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBindingAndObjectBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBindingAndObjectBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this.ObjectBinding,
                    this);
            }

            return this.CreateByKeyBindingAndTextBindingAndObjectBinding(
                serviceProvider,
                this.KeyBinding,
                this.TextBinding,
                this.ObjectBinding,
                this);
        }

        /// <summary>
        ///     Keys the binding and text binding and segments and culture binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyBindingAndTextBindingAndSegmentsAndCultureBindingBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the binding and text binding and segments and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyBindingAndTextBindingAndSegmentsAndCultureBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the binding and text binding and segments bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object KeyBindingAndTextBindingAndSegmentsBindings(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Keys the binding and text binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        [NotNull]
        private object KeyBindingAndTextBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this.TextBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this.TextBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextBinding(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this.TextBinding,
                    this);
            }

            return CreateByKeyBindingAndTextBinding(serviceProvider, this.KeyBinding, this.TextBinding, this);
        }

        /// <summary>
        ///     Keys the binding and text bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        private object KeyBindingAndTextBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndText(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndText(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndText(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this);
            }

            return CreateByKeyBindingAndText(serviceProvider, this.KeyBinding, this);
        }

        /// <summary>
        ///     Keys the binding bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        [NotNull]
        private object KeyBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBinding(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBinding(serviceProvider, this.KeyBinding, this.SourceBinding, this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBinding(serviceProvider, this.KeyBinding, this.GroupBinding, this);
            }

            return CreateByKeyBinding(serviceProvider, this.KeyBinding, this);
        }

        /// <summary>
        ///     Keys the binding key binding and text and culture bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object KeyBindingKeyBindingAndTextAndCultureBindings(IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyBindingAndGroupBindingAndSourceBindingAndTextAndCulture(
                        serviceProvider,
                        this.KeyBinding,
                        this.GroupBinding,
                        this.SourceBinding,
                        this);
                }

                return CreateByKeyBindingAndSourceBindingAndTextAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.SourceBinding,
                    this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyBindingAndGroupBindingAndTextAndCulture(
                    serviceProvider,
                    this.KeyBinding,
                    this.GroupBinding,
                    this);
            }

            return CreateByKeyBindingAndTextAndCulture(serviceProvider, this.KeyBinding, this);
        }

        /// <summary>
        ///     Keys the bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object KeyBindings([NotNull] IServiceProvider serviceProvider)
        {
            if (this.SourceBinding != null)
            {
                if (this.GroupBinding != null)
                {
                    return CreateByKeyAndGroupBindingAndSourceBinding(
                        serviceProvider,
                        this.GroupBinding,
                        this.SourceBinding,
                        this);
                }

                return CreateByKeyAndSourceBinding(serviceProvider, this.SourceBinding, this);
            }

            if (this.GroupBinding != null)
            {
                return CreateByKeyAndGroupBinding(serviceProvider, this.GroupBinding, this);
            }

            return this.OnlyKeyBindings(serviceProvider);
        }

        /// <summary>
        ///     Called when [key bindings].
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object OnlyKeyBindings([NotNull] IServiceProvider serviceProvider)
        {
            this.Formatter = LocExtension.GetLocalizedValue<string>(this.FullyQualifiedKey, this.TargetObject);

            if (this.UseDefaultIsEmpty)
            {
                return this.OnlyKeyEmptyUseDefaultBindings();
            }

            return new LocExtension(this.FullyQualifiedKey).ProvideValue(serviceProvider) ?? this.Text;
        }

        /// <summary>
        ///     Called when [key empty use default bindings].
        /// </summary>
        /// <returns>The object.</returns>
        private object OnlyKeyEmptyUseDefaultBindings()
        {
            var key = this.Key;
            if (key != null)
            {
                Localization.Instance.Subscribe(this.Group, key, s => this.SetTextValue());
            }

            if (this.Formatter.IsNullOrEmpty())
            {
                return this.Text;
            }

            return this.Formatter;
        }

        /// <summary>
        ///     Provides the key and text binding value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object ProvideKeyAndTextBindingValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Provides the key and text value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="NotImplementedException">not yet implemented! You can do it of your own free will!</exception>
        private object ProvideKeyAndTextValue(IServiceProvider serviceProvider)
        {
            throw new NotImplementedException("not yet implemented! You can do it of your own free will!");
        }

        /// <summary>
        ///     Provides the key binding and text binding value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="LocTextBindingException">Properties Object and Segments are set!</exception>
        private object ProvideKeyBindingAndTextBindingValue(IServiceProvider serviceProvider)
        {
            if (this.hasSegments && this.ObjectBinding != null)
            {
                throw new LocTextBindingException("Properties Object and Segments are set!");
            }

            if (this.hasSegments)
            {
                return this.CultureProvideKeyBindingAndTextBindingAndSegments(serviceProvider);
            }

            if (this.ObjectBinding != null)
            {
                return this.CultureProvideKeyBindingAndTextBindingAndObjectBinding(serviceProvider);
            }

            return this.CultureProvideKeyBindingAndTextBinding(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding and text value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="LocTextBindingException">Properties Object and Segments are set!</exception>
        private object ProvideKeyBindingAndTextValue(IServiceProvider serviceProvider)
        {
            if (this.hasSegments && this.ObjectBinding != null)
            {
                throw new LocTextBindingException("Properties Object and Segments are set!");
            }

            if (this.hasSegments)
            {
                return this.CultureProvideKeyBindingAndTextAndSegments(serviceProvider);
            }

            if (this.ObjectBinding != null)
            {
                return this.CultureProvideKeyBindingAndTextAndObjectBinding(serviceProvider);
            }

            return this.CultureProvideKeyBindingAndText(serviceProvider);
        }

        /// <summary>
        ///     Provides the key binding value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>
        ///     The object.
        /// </returns>
        /// <exception cref="LocTextBindingException">
        ///     Properties Object and Segments are set!
        ///     or
        ///     Properties ForceCultureBinding and ForceCulture are set!
        /// </exception>
        private object ProvideKeyBindingValue([NotNull] IServiceProvider serviceProvider)
        {
            if (this.hasSegments && this.ObjectBinding != null)
            {
                throw new LocTextBindingException("Properties Object and Segments are set!");
            }

            if (this.hasSegments)
            {
                return this.CultureProvideKeyBindingAndSegments(serviceProvider);
            }

            if (this.ObjectBinding != null)
            {
                return this.CultureProvideKeyBindingAndObjectBinding(serviceProvider);
            }

            return this.CultureProvideKeyBinding(serviceProvider);
        }

        /// <summary>
        ///     Provides the key value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object ProvideKeyValue(IServiceProvider serviceProvider)
        {
            if (this.hasSegments && this.ObjectBinding != null)
            {
                throw new LocTextBindingException("Properties Object and Segments are set!");
            }

            if (this.hasSegments)
            {
                return this.CultureProvideKeyAndSegments(serviceProvider);
            }

            if (this.ObjectBinding != null)
            {
                return this.CultureProvideKeyAndObjectBinding(serviceProvider);
            }

            return this.CultureProvideKey(serviceProvider);
        }

        /// <summary>
        ///     Provides the run time value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        /// <exception cref="Exception">KeyBinding</exception>
        [NotNull]
        private object ProvideRunTimeValue([NotNull] IServiceProvider serviceProvider)
        {
            object result;

            //if (this.UseDefaultIsEmpty && this.Default == null)
            //{
            //    throw new LocTextBindingException("Property UseDefaultIsEmpty is set but Default is not set!");
            //}

            if (this.KeyBinding != null)
            {
                if (this.Key != null)
                {
                    throw new LocTextBindingException("Properties KeyBinding and Key are set!");
                }

                if (this.TextBinding == null && this.Text == null)
                {
                    result = this.ProvideKeyBindingValue(serviceProvider);
                }
                else if (this.UseTextAsFallback)
                {
                    if (this.TextBinding == null && this.Text == null)
                    {
                        throw new LocTextBindingException(
                            "Properties UseTextAsFallback is set, but TextBinding and Text are not set!");
                    }

                    if (this.TextBinding != null && this.Text != null)
                    {
                        throw new LocTextBindingException("Properties TextBinding and Text are set!");
                    }

                    if (this.TextBinding != null)
                    {
                        result = this.ProvideKeyBindingAndTextBindingValue(serviceProvider);
                    }
                    else if (this.Text != null)
                    {
                        result = this.ProvideKeyBindingAndTextValue(serviceProvider);
                    }
                    else
                    {
                        result = null;
                    }
                }
                else if (this.TextBinding != null)
                {
                    throw new LocTextBindingException("Properties KeyBinding and TextBinding are set!");
                }
                else if (this.Text != null)
                {
                    throw new LocTextBindingException("Properties KeyBinding and Text are set!");
                }
                else
                {
                    throw new LocTextBindingException("Unknown error!");
                }
            }
            else if (this.Key != null)
            {
                if (this.TextBinding == null && this.Text == null)
                {
                    result = this.ProvideKeyValue(serviceProvider);
                }
                else if (this.TextBinding != null)
                {
                    result = this.ProvideKeyAndTextBindingValue(serviceProvider);
                }
                else if (this.Text != null)
                {
                    result = this.ProvideKeyAndTextValue(serviceProvider);
                }
                else
                {
                    result = null;
                }
            }
            else if (this.TextBinding != null)
            {
                result = this.ProvideTextBindingValue(serviceProvider);
            }
            else if (this.Text != null)
            {
                result = this.ProvideTextValue(serviceProvider);
            }
            else
            {
                throw new LocTextBindingNoKeyException();
            }

            if (result is MultiBindingExpression bindingExpression)
            {
                var updater = new Updater(bindingExpression);
                LocalizeDictionary.Instance.PropertyChanged += updater.InstanceOnPropertyChanged;
            }

            return result;
        }

        /// <summary>
        ///     Provides the text binding value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object ProvideTextBindingValue(IServiceProvider serviceProvider)
        {
            var result = this.TextBindingBindings(serviceProvider);
            return result;
        }

        /// <summary>
        ///     Provides the text value.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        private object ProvideTextValue(IServiceProvider serviceProvider)
        {
            var result = this.TextBindingBindings(serviceProvider);
            return result;
        }

        /// <summary>
        ///     Sets the default.
        /// </summary>
        private void SetDefault()
        {
            if (this.Default == null)
            {
                if (this.Key.IsNullOrEmpty())
                {
                    return;
                }

                if (this.Group.IsNullOrEmpty())
                {
                    this.Default = "Key: " + this.Key;
                }
                else if (this.Source.IsNullOrEmpty())
                {
                    this.Default = "Key: " + this.Group + ":" + this.Key;
                }
                else
                {
                    this.Default = "Key: " + this.SourceBinding + ":" + this.Group + ":" + this.Key;
                }
            }
        }

        /// <summary>
        ///     Sets the text value.
        /// </summary>
        private void SetTextValue()
        {
            var formatter = LocExtension.GetLocalizedValue<string>(this.FullyQualifiedKey, this.TargetObject);
            this.TargetObject.Dispatcher.Invoke(
                () => this.TargetObject.SetValue(
                    this.TargetProperty,
                    formatter.IsNullOrEmpty() ? this.Text : formatter));
        }

        /// <summary>
        ///     Keys the bindings.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The object.</returns>
        [NotNull]
        private object TextBindingBindings([NotNull] IServiceProvider serviceProvider)
        {
            return CreateByTextBindingBindings(serviceProvider, this.TextBinding, this);
        }

        /// <summary>
        ///     Updates the target on property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void UpdateTargetOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //ToDo
            //           this.UpdateTarget();
        }

        public class Updater
        {
            private readonly MultiBindingExpression multiBindingExpression;

            /// <summary>
            ///     The update look
            /// </summary>
            private readonly object updateLook = new object();

            public Updater(MultiBindingExpression multiBindingExpression)
            {
                this.multiBindingExpression = multiBindingExpression;
            }

            /// <summary>
            ///     Instances the on property changed.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
            public void InstanceOnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                this.UpdateTarget();
            }

            /// <summary>
            ///     Instances the on property changed.
            /// </summary>
            internal void UpdateTarget()
            {
                if (this.multiBindingExpression == null)
                {
                    return;
                }

                lock (this.updateLook)

                {
                    if (this.multiBindingExpression.Status == BindingStatus.Detached)
                    {
                        return;
                    }

                    this.multiBindingExpression.UpdateTarget();
                    //foreach (var bindingExpressionBindingExpression in this.multiBindingExpression.BindingExpressions)
                    //{
                    //    bindingExpressionBindingExpression.Target.Dispatcher?.Invoke(
                    //        () => bindingExpressionBindingExpression.UpdateTarget());
                    //}
                }
            }
        }
    }
}