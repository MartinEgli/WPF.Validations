// -----------------------------------------------------------------------
// <copyright file="AdornerContentPresenter.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Adorners
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;

    using JetBrains.Annotations;

    /// <summary>
    ///     The adorner content presenter class
    /// </summary>
    /// <seealso cref="System.Windows.Documents.Adorner" />
    public class AdornerContentPresenter : Adorner
    {
        /// <summary>
        ///     The content presenter
        /// </summary>
        [NotNull]
        private readonly ContentPresenter contentPresenter;

        /// <summary>
        ///     The visuals
        /// </summary>
        [NotNull]
        private readonly VisualCollection visuals;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdornerContentPresenter" /> class.
        /// </summary>
        /// <param name="adornedElement">The element to bind the adorner to.</param>
        public AdornerContentPresenter([NotNull] UIElement adornedElement)
            : base(adornedElement)
        {
            if (adornedElement == null)
            {
                throw new ArgumentNullException(nameof(adornedElement));
            }

            this.visuals = new VisualCollection(this);
            this.contentPresenter = new ContentPresenter();
            this.visuals.Add(this.contentPresenter);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdornerContentPresenter" /> class.
        /// </summary>
        /// <param name="adornedElement">The adorned element.</param>
        /// <param name="content">The content.</param>
        /// <exception cref="ArgumentNullException">content</exception>
        public AdornerContentPresenter([NotNull] UIElement adornedElement, [NotNull] Visual content)
            : this(adornedElement)
        {
            this.Content = content ?? throw new ArgumentNullException(nameof(content));
        }

        /// <summary>
        ///     Gets the number of visual child elements within this element.
        /// </summary>
        protected override int VisualChildrenCount => this.visuals.Count;

        /// <summary>
        ///     Gets or sets the content.
        /// </summary>
        /// <value>
        ///     The content.
        /// </value>
        public object Content
        {
            get => this.contentPresenter.Content;
            set => this.contentPresenter.Content = value;
        }

        /// <summary>
        ///     Implements any custom measuring behavior for the adorner.
        /// </summary>
        /// <param name="constraint">A size to constrain the adorner to.</param>
        /// <returns>
        ///     A <see cref="T:System.Windows.Size" /> object representing the amount of layout space needed by the adorner.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            this.contentPresenter.Measure(constraint);
            return this.contentPresenter.DesiredSize;
        }

        /// <summary>
        ///     When overridden in a derived class, positions child elements and determines a size for a
        ///     <see cref="T:System.Windows.FrameworkElement" /> derived class.
        /// </summary>
        /// <param name="finalSize">
        ///     The final area within the parent that this element should use to arrange itself and its
        ///     children.
        /// </param>
        /// <returns>
        ///     The actual size used.
        /// </returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            this.contentPresenter.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            return this.contentPresenter.RenderSize;
        }

        /// <summary>
        ///     Overrides <see cref="M:System.Windows.Media.Visual.GetVisualChild(System.Int32)" />, and returns a child at the
        ///     specified index from a collection of child elements.
        /// </summary>
        /// <param name="index">The zero-based index of the requested child element in the collection.</param>
        /// <returns>
        ///     The requested child element. This should not return <see langword="null" />; if the provided index is out of range,
        ///     an exception is thrown.
        /// </returns>
        [NotNull]
        protected override Visual GetVisualChild(int index) => this.visuals[index];
    }
}