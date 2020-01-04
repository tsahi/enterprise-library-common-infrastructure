/*
Copyright 2013 Microsoft Corporation
Licensed under the Apache License, Version 2.0 (the "License");

you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Storage
{
    /// <summary>
    /// <para>Provides a way to watch for changes to configuration in storage.</para>
    /// </summary>
    public interface IConfigurationChangeWatcher : IDisposable
    {
        /// <summary>
        /// Event raised when the underlying persistence mechanism for configuration notices that
        /// the persistent representation of configuration information has changed.
        /// </summary>
        event ConfigurationChangedEventHandler ConfigurationChanged;

        /// <summary>
        /// When implemented by a subclass, starts the object watching for configuration changes
        /// </summary>
        void StartWatching();

        /// <summary>
        /// When implemented by a subclass, stops the object from watching for configuration changes
        /// </summary>
        void StopWatching();

        /// <summary>
        /// When implemented by a subclass, returns the section name that is being watched.
        /// </summary>
        string SectionName { get; }
    }
}
