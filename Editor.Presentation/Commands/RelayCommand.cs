// <copyright file="RelayCommand.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Commands
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Represents a command that relays its functionality to delegates.
    /// Typically used in MVVM to bind actions from the view to the view model.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        private readonly Func<bool>? canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The action to execute when the command is invoked.</param>
        /// <param name="canExecute">The function that determines whether the command can execute. If null, the command is always executable.</param>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute();
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            this.execute();
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event to notify the UI that the execution status has changed.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}