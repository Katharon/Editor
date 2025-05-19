// <copyright file="ApplicationService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Presentation.Services
{
    using System.Windows;
    using Editor.Application;

    /// <summary>
    /// Provides application-level services such as shutting down the application.
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        /// <inheritdoc/>
        public void Shutdown()
        {
            Application.Current.Shutdown();
        }
    }
}