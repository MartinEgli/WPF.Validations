// -----------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="Anori Soft">
// Copyright (c) Anori Soft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace ValidationToolkit
{
    using System;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        private readonly Action<object> action;

        private readonly Predicate<object> condition;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.action = execute ?? throw new ArgumentNullException("No action to execute for this command.");
            this.condition = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => this.condition?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => this.action(parameter);
    }

    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> action;

        private readonly Predicate<T> condition;

        public RelayCommand(Action<T> execute)
        {
            this.action = execute ?? throw new ArgumentNullException("No action to execute for this command.");
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.action = execute ?? throw new ArgumentNullException("No action to execute for this command.");
            this.condition = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) => this.condition?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => this.action((T)parameter);
    }
}