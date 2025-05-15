// <copyright file="IApplicationService.cs" company="Fachhochschule Wiener Neustadt GmbH">
// Copyright (c) Lukas Stumpfel. All rights reserved.
// </copyright>

namespace Editor.Services
{
    /// <summary>
    /// Defines a service that provides application-level operations such as shutdown.
    /// </summary>
    public interface IApplicationService
    {
        /// <summary>
        /// Shuts down the current application.
        /// </summary>
        void Shutdown();
    }
}