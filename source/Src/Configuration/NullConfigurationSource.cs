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
    /// Represents a null configuration source that always returns null for a section.
    /// </summary>
    public sealed class NullConfigurationSource : IConfigurationSource
    {
        /// <summary>
        /// Event raised when configuration source contents have changed.
        /// </summary>
        /// <remarks>This class never raises this event.</remarks>
#pragma warning disable 67
        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;
#pragma warning restore 67

        /// <summary>
        /// Returns null for the section.
        /// </summary>
        /// <param name="sectionName">The section name to retrieve.</param>
        /// <returns>Always <see langword="null"/>.</returns>
        public ConfigurationSection GetSection(string sectionName)
        {
            return null;
        }

        /// <summary>
        /// Null implementation of <see cref="IConfigurationSource.Add(string, ConfigurationSection)"/> that 
        /// ignores the request.
        /// </summary>
        /// <param name="sectionName">The name by which the <paramref name="configurationSection"/> should be added.</param>
        /// <param name="configurationSection">The configuration section to add.</param>
        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
        }

        /// <summary>
        /// Null implementation of <see cref="IConfigurationSource.Remove(string)"/> that 
        /// ignores the request.
        /// </summary>
        /// <param name="sectionName">The name of the section to remove.</param>
        public void Remove(string sectionName)
        {
        }

        /// <summary>
        /// Adds a handler to be called when changes to section <code>sectionName</code> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler.</param>
        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
        }

        /// <summary>
        /// Remove a handler to be called when changes to section <code>sectionName</code> are detected.
        /// </summary>
        /// <param name="sectionName">The name of the section to watch for.</param>
        /// <param name="handler">The handler.</param>
        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
