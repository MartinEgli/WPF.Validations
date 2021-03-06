﻿// -----------------------------------------------------------------------
// <copyright file="LocalizationProviderBase.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Localizations.Pi4
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Windows;

    using WPFLocalizeExtension.Providers;

    /// <inheritdoc />
    /// <summary>
    ///     SQL Localization Provider Base.
    /// </summary>
    /// <seealso cref="T:WPFLocalizeExtension.Providers.ILocalizationProvider" />
    public abstract class LocalizationProviderBase : ILocalizationProvider
    {
        /// <inheritdoc />
        /// <summary>
        ///     An event that is fired when the provider changed.
        /// </summary>
        public event ProviderChangedEventHandler ProviderChanged;

        /// <inheritdoc />
        /// <summary>
        ///     An event that is fired when an error occurred.
        /// </summary>
        public event ProviderErrorEventHandler ProviderError;

        /// <inheritdoc />
        /// <summary>
        ///     An event that is fired when a value changed.
        /// </summary>
        public event ValueChangedEventHandler ValueChanged;

        /// <inheritdoc />
        /// <summary>
        ///     Gets or sets the observable list of available cultures.
        /// </summary>
        public ObservableCollection<CultureInfo> AvailableCultures { get; protected set; }

        /// <summary>
        ///     Uses the key and target to build a fully qualified resource key (Assembly, Dictionary, Key)
        /// </summary>
        /// <param name="key">Key used as a base to find the full key</param>
        /// <param name="target">Target used to help determine key information</param>
        /// <returns>
        ///     Returns an object with all possible pieces of the given key (Assembly, Dictionary, Key)
        /// </returns>
        public FullyQualifiedResourceKeyBase GetFullyQualifiedResourceKey(string key, DependencyObject target)
        {
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            LocalizationProviderHelpers.ParseKey(key, out var assembly, out var dictionary, out key);

            // if (target == null)
            // {
            // return new FQAssemblyDictionaryKey(key, assembly, dictionary);
            // }
            if (string.IsNullOrEmpty(assembly))
            {
                assembly = this.GetAssembly(target);
            }

            if (string.IsNullOrEmpty(dictionary))
            {
                dictionary = this.GetDictionary(target);
            }

            return new FQAssemblyDictionaryKey(key, assembly, dictionary);
        }

        /// <inheritdoc />
        /// <summary>
        ///     Get the localized object.
        /// </summary>
        /// <param name="key">The key to the value.</param>
        /// <param name="target">The target <see cref="T:System.Windows.TargetObject" />.</param>
        /// <param name="culture">The culture to use.</param>
        /// <returns>
        ///     The value corresponding to the source/dictionary/key path for the given culture (otherwise NULL).
        /// </returns>
        public object GetLocalizedObject(string key, DependencyObject target, CultureInfo culture)
        {
            var fullyQualifiedKey = (FQAssemblyDictionaryKey)this.GetFullyQualifiedResourceKey(key, target);

            // Final validation of the values.
            // Most important is key. fqKey may be null.
            if (string.IsNullOrEmpty(fullyQualifiedKey?.Key))
            {
                this.OnProviderError(target, key, "No key provided.");
                return null;
            }

            // fqKey cannot be null now
            if (string.IsNullOrEmpty(fullyQualifiedKey.Assembly))
            {
                this.OnProviderError(target, key, "No assembly provided.");
                return null;
            }

            if (string.IsNullOrEmpty(fullyQualifiedKey.Dictionary))
            {
                this.OnProviderError(target, key, "No dictionary provided.");
                return null;
            }

            try
            {
                // var service = this.LocalizationService;
                // if (service != null)
                // {
                // return service.GetText(key, culture);
                // }
            }
            catch (Exception e)
            {
                this.OnProviderError(target, key, "Error retrieving the resource manager.\r\n" + e.Message);
                return null;
            }

            // finally, return the searched object as type of the generic type
            try
            {
                // resManager.IgnoreCase = _ignoreCase;
                // var result = resManager.GetObject(fqKey.Key, culture);
                object result = null;
                if (result == null)
                {
                    this.OnProviderError(target, key, "Missing key.");
                }

                return result;
            }
            catch (Exception e)
            {
                this.OnProviderError(target, key, "Error retrieving the resource.\r\n" + e.Message);
                return null;
            }
        }

        /// <summary>
        ///     Get the assembly from the context, if possible.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <returns>The assembly name, if available.</returns>
        protected abstract string GetAssembly(DependencyObject target);

        /// <summary>
        ///     Gets the dictionary.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns>The dictionary string</returns>
        protected abstract string GetDictionary(DependencyObject target);

        /// <summary>
        ///     Calls the <see cref="ILocalizationProvider.ProviderChanged" /> event.
        /// </summary>
        /// <param name="target">The target object.</param>
        protected virtual void OnProviderChanged(DependencyObject target)
        {
            try
            {
                var assembly = this.GetAssembly(target);
                var dictionary = this.GetDictionary(target);

                if (!string.IsNullOrEmpty(assembly) && !string.IsNullOrEmpty(dictionary))
                {
                }

                // GetResourceManager(assembly, dictionary);
            }
            catch
            {
                // ignored
            }

            this.ProviderChanged?.Invoke(this, new ProviderChangedEventArgs(target));
        }

        /// <summary>
        ///     Calls the <see cref="ILocalizationProvider.ProviderError" /> event.
        /// </summary>
        /// <param name="target">The target object.</param>
        /// <param name="key">The key.</param>
        /// <param name="message">The error message.</param>
        protected virtual void OnProviderError(DependencyObject target, string key, string message)
        {
            this.ProviderError?.Invoke(this, new ProviderErrorEventArgs(target, key, message));
        }

        /// <summary>
        ///     Calls the <see cref="ILocalizationProvider.ValueChanged" /> event.
        /// </summary>
        /// <param name="key">The key where the value was changed.</param>
        /// <param name="value">The new value.</param>
        /// <param name="tag">A custom tag.</param>
        protected virtual void OnValueChanged(string key, object value, object tag)
        {
            this.ValueChanged?.Invoke(this, new ValueChangedEventArgs(key, value, tag));
        }
    }
}