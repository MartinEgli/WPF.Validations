// -----------------------------------------------------------------------
// <copyright file="FrameworkElementAdorner.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Adorners
{
    using System;
    using System.Collections;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Media;

    using JetBrains.Annotations;

    /// <summary>
    ///     The framework element adorner
    /// </summary>
    /// <seealso cref="System.Windows.Documents.Adorner" />
    public class FrameworkElementAdorner : Adorner
    {
        /// <summary>
        ///     The framework element that is the adorner.
        /// </summary>
        private readonly FrameworkElement child;

        /// <summary>
        ///     The horizontal adorner placement
        /// </summary>
        private readonly AdornerPlacement horizontalAdornerPlacement = AdornerPlacement.Inside;

        /// <summary>
        ///     The offset x
        /// </summary>
        private readonly double offsetX;

        /// <summary>
        ///     The offset y
        /// </summary>
        private readonly double offsetY;

        /// <summary>
        ///     The vertical adorner placement
        /// </summary>
        private readonly AdornerPlacement verticalAdornerPlacement = AdornerPlacement.Inside;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameworkElementAdorner" /> class.
        /// </summary>
        /// <param name="adornerChildElement">The adorner child element.</param>
        /// <param name="adornedElement">The adorned element.</param>
        /// <exception cref="ArgumentNullException">adornerChildElement</exception>
        public FrameworkElementAdorner(
            [NotNull] FrameworkElement adornerChildElement,
            [NotNull] FrameworkElement adornedElement)
            : base(adornedElement)
        {
            this.child = adornerChildElement ?? throw new ArgumentNullException(nameof(adornerChildElement));

            this.AddLogicalChild(adornerChildElement);
            this.AddVisualChild(adornerChildElement);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrameworkElementAdorner" /> class.
        /// </summary>
        /// <param name="adornerChildElement">The adorner child element.</param>
        /// <param name="adornedElement">The adorned element.</param>
        /// <param name="horizontalAdornerPlacement">The horizontal adorner placement.</param>
        /// <param name="verticalAdornerPlacement">The vertical adorner placement.</param>
        /// <param name="offsetX">The offset x.</param>
        /// <param name="offsetY">The offset y.</param>
        /// <exception cref="ArgumentNullException">adornerChildElement</exception>
        public FrameworkElementAdorner(
            [NotNull] FrameworkElement adornerChildElement,
            [NotNull] FrameworkElement adornedElement,
            AdornerPlacement horizontalAdornerPlacement,
            AdornerPlacement verticalAdornerPlacement,
            double offsetX,
            double offsetY)
            : base(adornedElement)
        {
            this.child = adornerChildElement ?? throw new ArgumentNullException(nameof(adornerChildElement));
            this.horizontalAdornerPlacement = horizontalAdornerPlacement;
            this.verticalAdornerPlacement = verticalAdornerPlacement;
            this.offsetX = offsetX;
            this.offsetY = offsetY;

            adornedElement.SizeChanged += this.OnAdornedElementSizeChanged;

            this.AddLogicalChild(adornerChildElement);
            this.AddVisualChild(adornerChildElement);
        }

        /// <summary>
        ///     Override AdornedElement from base class for less type-checking.
        /// </summary>
        public new FrameworkElement AdornedElement => (FrameworkElement)base.AdornedElement;

        /// <summary>
        ///     Gets or sets the position x.
        /// </summary>
        /// <value>
        ///     The position x.
        /// </value>
        public double PositionX { get; set; } = double.NaN;

        /// <summary>
        ///     Gets or sets the position y.
        /// </summary>
        /// <value>
        ///     The position y.
        /// </value>
        public double PositionY { get; set; } = double.NaN;

        /// <summary>
        ///     Gets an enumerator for logical child elements of this element.
        /// </summary>
        protected override IEnumerator LogicalChildren
        {
            get
            {
                var list = new ArrayList { this.child };
                return list.GetEnumerator();
            }
        }

        /// <summary>
        ///     Gets the number of visual child elements within this element.
        /// </summary>
        protected override int VisualChildrenCount => 1;

        /// <summary>
        ///     Disconnect the child element from the visual tree so that it may be reused later.
        /// </summary>
        public void DisconnectChild()
        {
            this.RemoveLogicalChild(this.child);
            this.RemoveVisualChild(this.child);
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
            var x = this.PositionX;
            if (double.IsNaN(x))
            {
                x = this.DetermineX();
            }

            var y = this.PositionY;
            if (double.IsNaN(y))
            {
                y = this.DetermineY();
            }

            var adornerWidth = this.DetermineWidth();
            var adornerHeight = this.DetermineHeight();
            this.child.Arrange(new Rect(x, y, adornerWidth, adornerHeight));
            return finalSize;
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
        protected override Visual GetVisualChild(int index) => this.child;

        /// <summary>
        ///     Implements any custom measuring behavior for the adorner.
        /// </summary>
        /// <param name="constraint">A size to constrain the adorner to.</param>
        /// <returns>
        ///     A <see cref="T:System.Windows.Size" /> object representing the amount of layout space needed by the adorner.
        /// </returns>
        protected override Size MeasureOverride(Size constraint)
        {
            this.child.Measure(constraint);
            return this.child.DesiredSize;
        }

        /// <summary>
        ///     Determine the height of the child.
        /// </summary>
        /// <returns></returns>
        private double DetermineHeight()
        {
            if (!double.IsNaN(this.PositionY))
            {
                return this.child.DesiredSize.Height;
            }

            switch (this.child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Bottom:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Center:
                    {
                        return this.child.DesiredSize.Height;
                    }
                case VerticalAlignment.Stretch:
                    {
                        return this.AdornedElement.ActualHeight;
                    }
            }

            return 0.0;
        }

        /// <summary>
        ///     Determine the width of the child.
        /// </summary>
        /// <returns></returns>
        private double DetermineWidth()
        {
            if (!double.IsNaN(this.PositionX))
            {
                return this.child.DesiredSize.Width;
            }

            switch (this.child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Right:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Center:
                    {
                        return this.child.DesiredSize.Width;
                    }
                case HorizontalAlignment.Stretch:
                    {
                        return this.AdornedElement.ActualWidth;
                    }
            }

            return 0.0;
        }

        /// <summary>
        ///     Determine the X coordinate of the child.
        /// </summary>
        private double DetermineX()
        {
            switch (this.child.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    {
                        if (this.horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -this.child.DesiredSize.Width + this.offsetX;
                        }

                        return this.offsetX;
                    }
                case HorizontalAlignment.Right:
                    {
                        if (this.horizontalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            var adornedWidth = this.AdornedElement.ActualWidth;
                            return adornedWidth + this.offsetX;
                        }
                        else
                        {
                            var adornerWidth = this.child.DesiredSize.Width;
                            var adornedWidth = this.AdornedElement.ActualWidth;
                            var x = adornedWidth - adornerWidth;
                            return x + this.offsetX;
                        }
                    }
                case HorizontalAlignment.Center:
                    {
                        var adornerWidth = this.child.DesiredSize.Width;
                        var adornedWidth = this.AdornedElement.ActualWidth;
                        var x = (adornedWidth / 2) - (adornerWidth / 2);
                        return x + this.offsetX;
                    }
                case HorizontalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        /// <summary>
        ///     Determine the Y coordinate of the child.
        /// </summary>
        private double DetermineY()
        {
            switch (this.child.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    {
                        if (this.verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            return -this.child.DesiredSize.Height + this.offsetY;
                        }

                        return this.offsetY;
                    }
                case VerticalAlignment.Bottom:
                    {
                        if (this.verticalAdornerPlacement == AdornerPlacement.Outside)
                        {
                            var adornedHeight = this.AdornedElement.ActualHeight;
                            return adornedHeight + this.offsetY;
                        }
                        else
                        {
                            var adornerHeight = this.child.DesiredSize.Height;
                            var adornedHeight = this.AdornedElement.ActualHeight;
                            var x = adornedHeight - adornerHeight;
                            return x + this.offsetY;
                        }
                    }
                case VerticalAlignment.Center:
                    {
                        var adornerHeight = this.child.DesiredSize.Height;
                        var adornedHeight = this.AdornedElement.ActualHeight;
                        var x = (adornedHeight / 2) - (adornerHeight / 2);
                        return x + this.offsetY;
                    }
                case VerticalAlignment.Stretch:
                    {
                        return 0.0;
                    }
            }

            return 0.0;
        }

        /// <summary>
        ///     Event raised when the adorned control's size has changed.
        /// </summary>
        private void OnAdornedElementSizeChanged(object sender, SizeChangedEventArgs e) => this.InvalidateMeasure();
    }
}