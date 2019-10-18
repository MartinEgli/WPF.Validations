// -----------------------------------------------------------------------
// <copyright file="Controller.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Adder
{
    using System;

    using Bfa.Common.WPF.Validations.ValidationTestGui;

    using ValidationToolkit;

    public class Controller
    {
        private MainWindow MainWindow;

        /// <summary>
        ///     Registers the view.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="ViewModelType">Type of the view model.</param>
        public static void RegisterView(ViewBase view, Type ViewModelType)
        {
            view.DataContext = CreateViewModel(ViewModelType);
        }

        /// <summary>
        ///     Creates the view model.
        /// </summary>
        /// <param name="ViewModelType">Type of the view model.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unable to create ViewModel " + ViewModelType.FullName</exception>
        public static ViewModel CreateViewModel(Type ViewModelType)
        {
            var assembly = ViewModelType.Assembly;
            var ViewModel = (AdderViewModel)assembly.CreateInstance(ViewModelType.FullName);
            if (ViewModel == null)
            {
                throw new Exception("Unable to create ViewModel " + ViewModelType.FullName);
            }

            // Setup command processing.
            ViewModel.CalculateCommand = new RelayCommand(
                z =>
                    {
                        try
                        {
                            // Shouldn't get to here if the controls do not have valid values.
                            var x = ViewModel.X.Value;
                            var y = ViewModel.Y.Value;

                            ViewModel.Sum = CalculationService.Add(x, y);
                        }
                        catch (Exception)
                        {
                        }
                    },
                ViewModel.CanCalculate);

            return ViewModel;
        }

        /// <summary>
        ///     Creates the main window.
        /// </summary>
        public void CreateMainWindow()
        {
            this.MainWindow = new MainWindow();
            this.MainWindow.Show();
        }
    }
}