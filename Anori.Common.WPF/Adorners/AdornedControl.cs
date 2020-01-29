// -----------------------------------------------------------------------
// <copyright file="AdornedControl.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.Common.WPF.Adorners
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;

    /// <summary>
    ///     A content control that allows an adorner for the content to
    ///     be defined in XAML.
    /// </summary>
    public class AdornedControl : ContentControl
    {
        /// <summary>
        ///     The adorner content property
        /// </summary>
        public static readonly DependencyProperty AdornerContentProperty = DependencyProperty.Register(
            "AdornerContent",
            typeof(FrameworkElement),
            typeof(AdornedControl),
            new FrameworkPropertyMetadata(OnAdornerContentPropertyChanged));

        /// <summary>
        ///     The adorner offset x property
        /// </summary>
        public static readonly DependencyProperty AdornerOffsetXProperty =
            DependencyProperty.Register("AdornerOffsetX", typeof(double), typeof(AdornedControl));

        /// <summary>
        ///     The adorner offset y property
        /// </summary>
        public static readonly DependencyProperty AdornerOffsetYProperty =
            DependencyProperty.Register("AdornerOffsetY", typeof(double), typeof(AdornedControl));

        /// <summary>
        ///     The hide adorner command
        /// </summary>
        public static readonly RoutedCommand HideAdornerCommand = new RoutedCommand(
            "HideAdorner",
            typeof(AdornedControl));

        /// <summary>
        ///     The horizontal adorner placement property
        /// </summary>
        public static readonly DependencyProperty HorizontalAdornerPlacementProperty = DependencyProperty.Register(
            "HorizontalAdornerPlacement",
            typeof(AdornerPlacement),
            typeof(AdornedControl),
            new FrameworkPropertyMetadata(AdornerPlacement.Inside));

        /// <summary>
        ///     The is adorner visible property
        /// </summary>
        public static readonly DependencyProperty IsAdornerVisibleProperty = DependencyProperty.Register(
            "IsAdornerVisible",
            typeof(bool),
            typeof(AdornedControl),
            new FrameworkPropertyMetadata(OnIsAdornerVisiblePropertyChanged));

        /// <summary>
        ///     The show adorner command
        /// </summary>
        public static readonly RoutedCommand ShowAdornerCommand = new RoutedCommand(
            "ShowAdorner",
            typeof(AdornedControl));

        /// <summary>
        ///     The vertical adorner placement property
        /// </summary>
        public static readonly DependencyProperty VerticalAdornerPlacementProperty = DependencyProperty.Register(
            "VerticalAdornerPlacement",
            typeof(AdornerPlacement),
            typeof(AdornedControl),
            new FrameworkPropertyMetadata(AdornerPlacement.Inside));

        /// <summary>
        ///     The hide adorner command binding
        /// </summary>
        private static readonly CommandBinding HideAdornerCommandBinding =
            new CommandBinding(HideAdornerCommand, OnHideAdornerCommandExecuted);

        /// <summary>
        ///     The show adorner command binding
        /// </summary>
        private static readonly CommandBinding ShowAdornerCommandBinding =
            new CommandBinding(ShowAdornerCommand, OnShowAdornerCommandExecuted);

        /// <summary>
        ///     The actual adorner create to contain our 'adorner UI content'.
        /// </summary>
        private FrameworkElementAdorner adorner;

        /// <summary>
        ///     Caches the adorner layer.
        /// </summary>
        private AdornerLayer adornerLayer;

        /// <summary>
        ///     Static constructor to register command bindings.
        /// </summary>
        static AdornedControl()
        {
            CommandManager.RegisterClassCommandBinding(typeof(AdornedControl), ShowAdornerCommandBinding);
            CommandManager.RegisterClassCommandBinding(typeof(AdornedControl), HideAdornerCommandBinding);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdornedControl" /> class.
        /// </summary>
        public AdornedControl()
        {
            this.Focusable = false; // By default don't want 'AdornedControl' to be focusable.

            this.DataContextChanged += this.OnAdornedControlDataContextChanged;
        }

        /// <summary>
        ///     Used in XAML to define the UI content of the adorner.
        /// </summary>
        public FrameworkElement AdornerContent
        {
            get => (FrameworkElement)this.GetValue(AdornerContentProperty);
            set => this.SetValue(AdornerContentProperty, value);
        }

        /// <summary>
        ///     X offset of the adorner.
        /// </summary>
        public double AdornerOffsetX
        {
            get => (double)this.GetValue(AdornerOffsetXProperty);
            set => this.SetValue(AdornerOffsetXProperty, value);
        }

        /// <summary>
        ///     Y offset of the adorner.
        /// </summary>
        public double AdornerOffsetY
        {
            get => (double)this.GetValue(AdornerOffsetYProperty);
            set => this.SetValue(AdornerOffsetYProperty, value);
        }

        /// <summary>
        ///     Specifies the horizontal placement of the adorner relative to the adorned control.
        /// </summary>
        public AdornerPlacement HorizontalAdornerPlacement
        {
            get => (AdornerPlacement)this.GetValue(HorizontalAdornerPlacementProperty);
            set => this.SetValue(HorizontalAdornerPlacementProperty, value);
        }

        /// <summary>
        ///     Shows or hides the adorner.
        ///     Set to 'true' to show the adorner or 'false' to hide the adorner.
        /// </summary>
        public bool IsAdornerVisible
        {
            get => (bool)this.GetValue(IsAdornerVisibleProperty);
            set => this.SetValue(IsAdornerVisibleProperty, value);
        }

        /// <summary>
        ///     Specifies the vertical placement of the adorner relative to the adorned control.
        /// </summary>
        public AdornerPlacement VerticalAdornerPlacement
        {
            get => (AdornerPlacement)this.GetValue(VerticalAdornerPlacementProperty);
            set => this.SetValue(VerticalAdornerPlacementProperty, value);
        }

        /// <summary>
        ///     Hide the adorner.
        /// </summary>
        public void HideAdorner() => this.IsAdornerVisible = false;

        /// <summary>
        ///     When overridden in a derived class, is invoked whenever application code or internal processes call
        ///     <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.ShowOrHideAdornerInternal();
        }

        /// <summary>
        ///     Show the adorner.
        /// </summary>
        public void ShowAdorner() => this.IsAdornerVisible = true;

        /// <summary>
        ///     Event raised when the value of AdornerContent has changed.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnAdornerContentPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var c = (AdornedControl)o;
            c.ShowOrHideAdornerInternal();
        }

        /// <summary>
        ///     Event raised when the Hide command is executed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs" /> instance containing the event data.</param>
        private static void OnHideAdornerCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var c = (AdornedControl)target;
            c.HideAdorner();
        }

        /// <summary>
        ///     Event raised when the value of IsAdornerVisible has changed.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnIsAdornerVisiblePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var c = (AdornedControl)o;
            c.ShowOrHideAdornerInternal();
        }

        /// <summary>
        ///     Event raised when the Show command is executed.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs" /> instance containing the event data.</param>
        private static void OnShowAdornerCommandExecuted(object target, ExecutedRoutedEventArgs e)
        {
            var c = (AdornedControl)target;
            c.ShowAdorner();
        }

        /// <summary>
        ///     Internal method to hide the adorner.
        /// </summary>
        private void HideAdornerInternal()
        {
            if (this.adornerLayer == null || this.adorner == null)
            {
                // Not already adorned.
                return;
            }

            this.adornerLayer.Remove(this.adorner);
            this.adorner.DisconnectChild();

            this.adorner = null;
            this.adornerLayer = null;
        }

        /// <summary>
        ///     Event raised when the DataContext of the adorned control changes.
        /// </summary>
        private void OnAdornedControlDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) =>
            this.UpdateAdornerDataContext();

        /// <summary>
        ///     Internal method to show the adorner.
        /// </summary>
        private void ShowAdornerInternal()
        {
            if (this.adorner != null)
            {
                // Already adorned.
                return;
            }

            if (this.AdornerContent == null)
            {
                return;
            }

            if (this.adornerLayer == null)
            {
                this.adornerLayer = AdornerLayer.GetAdornerLayer(this);
            }

            if (this.adornerLayer == null)
            {
                return;
            }

            this.adorner = new FrameworkElementAdorner(
                this.AdornerContent,
                this,
                this.HorizontalAdornerPlacement,
                this.VerticalAdornerPlacement,
                this.AdornerOffsetX,
                this.AdornerOffsetY);
            this.adornerLayer.Add(this.adorner);

            this.UpdateAdornerDataContext();
        }

        /// <summary>
        ///     Internal method to show or hide the adorner based on the value of IsAdornerVisible.
        /// </summary>
        private void ShowOrHideAdornerInternal()
        {
            if (this.IsAdornerVisible)
            {
                this.ShowAdornerInternal();
            }
            else
            {
                this.HideAdornerInternal();
            }
        }

        /// <summary>
        ///     Update the DataContext of the adorner from the adorned control.
        /// </summary>
        private void UpdateAdornerDataContext()
        {
            if (this.AdornerContent != null)
            {
                this.AdornerContent.DataContext = this.DataContext;
            }
        }
    }
}