// -----------------------------------------------------------------------
// <copyright file="Bindable.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.Binders
{
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    using JetBrains.Annotations;

    /// <summary>
    ///     Bindable class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanging" />
    public abstract class Bindable : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        ///     Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Occurs when [property changing].
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        ///     Called when [property changing].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <returns></returns>
        protected bool OnPropertyChanging<T>(
            [CanBeNull] T originalValue,
            [CanBeNull] T newValue,
            [CallerMemberName] string propertyName = null)
        {
            var propertyChanging = this.PropertyChanging;
            if (propertyChanging == null)
            {
                return true;
            }

            // ReSharper disable once AssignNullToNotNullAttribute
            var args = new PropertyChangingCancelEventArgs<T>(propertyName, originalValue, newValue);
            propertyChanging(this, args);
            return !args.Cancel;
        }

        /// <summary>
        /// Called when [property changing].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="cleanValue">The clean value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected bool OnPropertyChanging<T>(
            [CanBeNull] T originalValue,
            [CanBeNull] ref T newValue,
             [CallerMemberName] string propertyName = null)
        {
            var propertyChanging = this.PropertyChanging;
            if (propertyChanging == null)
            {
                return true;
            }

            // ReSharper disable once AssignNullToNotNullAttribute
            var args = new PropertyChangingCancelEventArgs<T>(propertyName, originalValue, newValue);
            propertyChanging(this, args);
            newValue = args.NewValue;
            return !args.Cancel;
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="previousValue">The previous value.</param>
        /// <param name="currentValue">The current value.</param>
        protected void OnPropertyChanged<T>(
            [CanBeNull] T previousValue,
            [CanBeNull] T currentValue,
            [CallerMemberName] string propertyName = null)
        {
            var propertyChanged = this.PropertyChanged;

            // ReSharper disable once AssignNullToNotNullAttribute
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs<T>(propertyName, previousValue, currentValue));
        }

        /// <summary>
        ///     Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The storage.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        [NotifyPropertyChangedInvocator]
        protected virtual bool SetProperty<T>(
            [CanBeNull] ref T storage,
            [CanBeNull] T value,
            [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            if (!this.OnPropertyChanging(storage, ref value, propertyName))
            {
                return false;
            }

            var previousValue = storage;
            storage = value;
            this.OnPropertyChanged(previousValue, value, propertyName);
            return true;
        }

        /// <summary>
        ///     Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setter">The setter.</param>
        /// <param name="getter">The getter.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected virtual bool SetProperty<T>(
            [NotNull] Action<T> setter,
            [NotNull] Func<T> getter,
            [CanBeNull] T value,
            [CallerMemberName] string propertyName = null)
        {
            if (setter == null)
            {
                throw new ArgumentNullException(nameof(setter));
            }

            if (getter == null)
            {
                throw new ArgumentNullException(nameof(getter));
            }

            var storage = getter();
            if (Equals(storage, value))
            {
                return false;
            }

            if (!this.OnPropertyChanging(storage, value, propertyName))
            {
                return false;
            }

            var previousValue = storage;
            setter(value);
            this.OnPropertyChanged(previousValue, value, propertyName);
            return true;
        }

        /// <summary>
        ///     Sets the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setter">The setter.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        protected virtual bool SetProperty<T>(
            [NotNull] Action<T> setter,
            [CanBeNull] T originalValue,
            [CanBeNull] T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (setter == null)
            {
                throw new ArgumentNullException(nameof(setter));
            }

            if (Equals(originalValue, newValue))
            {
                return false;
            }

            if (!this.OnPropertyChanging(originalValue, newValue, propertyName))
            {
                return false;
            }

            var previousValue = originalValue;
            setter(newValue);
            this.OnPropertyChanged(previousValue, newValue, propertyName);
            return true;
        }

        /// <summary>
        ///     Sets the sub property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setter">The setter.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">setter</exception>
        protected virtual bool SetSubProperty<T>(
            [NotNull] Action<T> setter,
            [CanBeNull] T originalValue,
            [CanBeNull] T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (setter == null)
            {
                throw new ArgumentNullException(nameof(setter));
            }

            if (Equals(originalValue, newValue))
            {
                return false;
            }

            if (!this.OnPropertyChanging(originalValue, newValue, propertyName))
            {
                return false;
            }

            setter(newValue);
            return true;
        }

        /// <summary>
        ///     Sets the sub property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="setter">The setter.</param>
        /// <param name="originalValue">The original value.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">setter</exception>
        protected virtual bool SetSubProperty<T>(
            [NotNull] Func<T, bool> setter,
            [CanBeNull] T originalValue,
            [CanBeNull] T newValue,
            [CallerMemberName] string propertyName = null)
        {
            if (setter == null)
            {
                throw new ArgumentNullException(nameof(setter));
            }

            if (Equals(originalValue, newValue))
            {
                return false;
            }

            if (!this.OnPropertyChanging(originalValue, newValue, propertyName))
            {
                return false;
            }

            return setter(newValue);
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///     Called when [property changed].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyExpression">The property expression.</param>
        protected void OnPropertyChanged<T>([NotNull] Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
            {
                throw new ArgumentNullException(nameof(propertyExpression));
            }

            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }
    }
}