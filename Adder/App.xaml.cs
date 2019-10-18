// -----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Adder
{
    using System.Windows;

    using Bfa.Common.WPF.Validations.ValidationTestGui;

    public partial class App : Application
    {
        private void AdderStartup(object sender, StartupEventArgs e)
        {
            var controller = new Controller();
            controller.CreateMainWindow();
        }
    }
}