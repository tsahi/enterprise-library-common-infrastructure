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
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents a source for getting configuration information.
    /// </summary>
    public interface IConfigurationSource : IDisposable
    {
        /// <summary>
        /// Retrieves the specified <see cref="ConfigurationSection"/>.
        /// </summary>
        /// <param name="sectionName">The name of the section to be retrieved.</param>
        /// <returns>The specified <see cref="ConfigurationSection"/>, or <see langword="null"/> (<b>Nothing</b> in Visual Basic)
        /// if a section by that name is not found.</returns>
        ConfigurationSection GetSection(string sectionName);

        /// <summary>
        /// Adds a <see cref="ConfigurationSection"/> to the configuration source and saves the configuration source.
        /// </summary>
        /// <remarks>
        /// If a configuration section with the specified name already exists it will be replaced.
        /// </remarks>
        /// <param name="sectionName">The name by which the <paramref name="configurationSection"/> should be added.</param>
        /// <param name="configurationSection">The configuration section to add.</param>
        void Add(string sectionName, ConfigurationSection configurationSection);

        /// <summary>
        /// Removes a <see cref="ConfigurationSection"/> from the configuration source.
        /// </summary>
        /// <param name="sectionName">The name of the section to remove.</param>
        void Remove(string sectionName);

        /// <summary>
        /// Event raised when any section in this configuration source changes.
        /// </summary>
        event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;

        /// <summary>
        /// Adds a handler to be called when changes to the section named <paramref name="sectionName"/> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler for the change event to add.</param>
        void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler);

        /// <summary>
        /// Removes a handler to be called when changes to section <code>sectionName</code> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the watched section.</param>
        /// <param name="handler">The handler for the change event to remove.</param>
        void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler);
    }
}
