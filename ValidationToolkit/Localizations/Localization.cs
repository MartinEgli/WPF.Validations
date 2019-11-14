// -----------------------------------------------------------------------
// <copyright file="Localization.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.WPF.Localizations
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Reactive.Disposables;

    using JetBrains.Annotations;

    using WPFLocalizeExtension.Engine;

    /// <summary>
    ///     Localization Class
    /// </summary>
    public class Localization
    {
        /// <summary>
        ///     The default source
        /// </summary>
        private const string DefaultSource = "Text";

        /// <summary>
        ///     The localize group
        /// </summary>
        private readonly LocalizeDictionary localizeDictionary;

        /// <summary>
        ///     Initializes static members of the <see cref="Localization" /> class.
        /// </summary>
        static Localization()
        {
            Instance = new Localization();
        }

        /// <summary>
        ///     Prevents a default instance of the <see cref="Localization" /> class from being created.
        /// </summary>
        private Localization()
        {
            this.localizeDictionary = LocalizeDictionary.Instance;
            this.localizeDictionary.PropertyChanged += this.OnPropertyChanged;
        }

        /// <summary>
        ///     Occurs when [culture changed].
        /// </summary>
        public event EventHandler<CultureChangedEventArgs> CultureChanged;

        /// <summary>
        ///     Occurs when [language changed].
        /// </summary>
        public event Action<CultureInfo> LanguageChanged;

        /// <summary>
        ///     Gets the instance.
        /// </summary>
        /// <value>
        ///     The instance.
        /// </value>
        public static Localization Instance { get; }

        /// <summary>
        ///     Gets the culture.
        /// </summary>
        /// <value>
        ///     The culture.
        /// </value>
        public CultureInfo Culture => this.localizeDictionary.Culture;

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The string.</returns>
        /// <exception cref="ArgumentNullException">
        ///     source
        ///     or
        ///     group
        ///     or
        ///     key
        ///     or
        ///     culture
        /// </exception>
        [CanBeNull]
        public string GetText(
            [NotNull] string source,
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] CultureInfo culture)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            return this.localizeDictionary.GetLocalizedObject(source, group, key, culture) as string;
        }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="culture">The culture.</param>
        /// <returns>The text.</returns>
        /// <exception cref="ArgumentNullException">
        ///     group
        ///     or
        ///     key
        ///     or
        ///     culture
        /// </exception>
        [CanBeNull]
        public string GetText([NotNull] string group, [NotNull] string key, [NotNull] CultureInfo culture)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            return this.localizeDictionary.GetLocalizedObject(
                       LocalizationProviderHelpers.FullyQualifiedKey(DefaultSource, group, key),
                       null,
                       culture) as string;
        }

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <returns>The string.</returns>
        [CanBeNull]
        public string GetText([NotNull] string source, [NotNull] string group, [NotNull] string key) =>
            this.GetText(source, group, key, CultureInfo.CurrentCulture);

        /// <summary>
        ///     Gets the text.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <returns>The text.</returns>
        [CanBeNull]
        public string GetText([NotNull] string group, [NotNull] string key) =>
            this.GetText(group, key, CultureInfo.CurrentCulture);

        /// <summary>
        ///     Subscribes the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     source
        ///     or
        ///     group
        ///     or
        ///     key
        ///     or
        ///     action
        /// </exception>
        [NotNull]
        public IDisposable Subscribe(
            [NotNull] string source,
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] WeakReference<Action<string>> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return this.SubscribeInternal(source, group, key, action);
        }

        /// <summary>
        ///     Subscribes the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     group
        ///     or
        ///     key
        ///     or
        ///     action
        /// </exception>
        public IDisposable Subscribe(
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] WeakReference<Action<string>> action)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return Instance.SubscribeInternal(group, key, action);
        }

        /// <summary>
        ///     Subscribes the specified group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The text.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     group
        ///     or
        ///     key
        ///     or
        ///     action
        /// </exception>
        public IDisposable Subscribe([NotNull] string group, [NotNull] string key, [NotNull] Action<string> action)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return Instance.SubscribeInternal(group, key, action);
        }

        /// <summary>
        ///     Subscribes the internal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable.
        /// </returns>
        [NotNull]
        internal IDisposable SubscribeInternal(
            [NotNull] string source,
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] WeakReference<Action<string>> action)
        {
            void Handler(object sender, CultureChangedEventArgs args) =>
                this.GetTextSubscriber(source, group, key, action);

            Instance.CultureChanged += Handler;

            return Disposable.Create(() => Instance.CultureChanged -= Handler);
        }

        /// <summary>
        ///     Subscribes the internal.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable.
        /// </returns>
        [NotNull]
        internal IDisposable SubscribeInternal(
            [NotNull] string source,
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] Action<string> action)
        {
            void Handler(object sender, CultureChangedEventArgs args) =>
                this.GetTextSubscriber(source, group, key, action);

            Instance.CultureChanged += Handler;

            return Disposable.Create(() => Instance.CultureChanged -= Handler);
        }

        /// <summary>
        ///     Subscribes the internal.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable.
        /// </returns>
        [NotNull]
        internal IDisposable SubscribeInternal(
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] WeakReference<Action<string>> action)
        {
            void Handler(object sender, CultureChangedEventArgs args) => this.GetTextSubscriber(group, key, action);

            Instance.CultureChanged += Handler;
            return Disposable.Create(() => Instance.CultureChanged -= Handler);
        }

        /// <summary>
        ///     Subscribes the internal.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        ///     The Disposable.
        /// </returns>
        [NotNull]
        internal IDisposable SubscribeInternal(
            [NotNull] string group,
            [NotNull] string key,
            [NotNull] Action<string> action)
        {
            void Handler(object sender, CultureChangedEventArgs args) => this.GetTextSubscriber(group, key, action);

            Instance.CultureChanged += Handler;
            return Disposable.Create(() => Instance.CultureChanged -= Handler);
        }

        /// <summary>
        ///     Gets the text subscriber.
        /// </summary>
        /// <param name="assembly">The source.</param>
        /// <param name="dictionary">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        private void GetTextSubscriber(
            string assembly,
            string dictionary,
            string key,
            WeakReference<Action<string>> action)
        {
            if (action.TryGetTarget(out var a))
            {
                a(this.GetText(assembly, dictionary, key, this.localizeDictionary.Culture));
            }
        }

        /// <summary>
        ///     Gets the text subscriber.
        /// </summary>
        /// <param name="assembly">The source.</param>
        /// <param name="dictionary">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        private void GetTextSubscriber(string assembly, string dictionary, string key, Action<string> action)
        {
            action(this.GetText(assembly, dictionary, key, this.localizeDictionary.Culture));
        }

        /// <summary>
        ///     Gets the text subscriber.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        private void GetTextSubscriber(string group, string key, WeakReference<Action<string>> action)
        {
            if (action.TryGetTarget(out var a))
            {
                a(this.GetText(group, key, this.localizeDictionary.Culture));
            }
        }

        /// <summary>
        ///     Gets the text subscriber.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="key">The key.</param>
        /// <param name="action">The action.</param>
        private void GetTextSubscriber(string group, string key, Action<string> action)
        {
            action(this.GetText(group, key, this.localizeDictionary.Culture));
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(LocalizeDictionary.Culture))
            {
                return;
            }

            this.CultureChanged?.Invoke(this, new CultureChangedEventArgs(this.localizeDictionary.Culture));
            this.LanguageChanged?.Invoke(this.localizeDictionary.Culture);
        }

        /// <summary>
        ///     Language Changed Event Arguments
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        /// <inheritdoc />
        /// <seealso cref="T:System.EventArgs" />
        public class CultureChangedEventArgs : EventArgs
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="CultureChangedEventArgs" /> class.
            /// </summary>
            /// <param name="culture">The culture.</param>
            public CultureChangedEventArgs(CultureInfo culture)
            {
                this.CultureInfo = culture;
            }

            /// <summary>
            ///     Gets the culture.
            /// </summary>
            /// <value>
            ///     The culture.
            /// </value>
            public CultureInfo CultureInfo { get; }
        }
    }
}