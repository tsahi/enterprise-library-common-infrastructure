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

using System.ComponentModel;
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Entry point that is used for programatically building up a configution source.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Justification = "Using config source as a dictionary")]
    public class ConfigurationSourceBuilder : IConfigurationSourceBuilder, IFluentInterface
    {
        readonly DictionaryConfigurationSource configurationSource = new DictionaryConfigurationSource();

        /// <summary>
        /// Adds a <see cref="ConfigurationSection"/> to the builder.
        /// </summary>
        /// <param name="sectionName">Name of section to add.</param>
        /// <param name="configurationSection">Configuration section to add.</param>
        /// <returns></returns>
        public IConfigurationSourceBuilder AddSection(string sectionName, ConfigurationSection configurationSection)
        {
            configurationSource.Add(sectionName, configurationSection);
            return this;
        }

        /// <summary>
        /// Determines if a section name is contained in the builder.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>True if contained in the builder, false otherwise.</returns>
        public bool Contains(string sectionName)
        {
            return configurationSource.Contains(sectionName);
        }

        /// <summary>
        /// Returns a configuration section with the given name, if present in the builder.
        /// </summary>
        /// <param name="sectionName">Name of section to return.</param>
        /// <returns>A valid configuration section or null.</returns>
        public ConfigurationSection Get(string sectionName)
        {
            return configurationSource.GetSection(sectionName);
        }

        ///<summary>
        /// Returns a configuration section of type <typeparamref name="T"/>, if present in the builder.
        ///</summary>
        ///<param name="sectionName">Section name to retrieve</param>
        ///<typeparam name="T"><see cref="ConfigurationSection"/> type to return.</typeparam>
        ///<returns></returns>
        public T Get<T>(string sectionName) where T : ConfigurationSection
        {
            return (T)configurationSource.GetSection(sectionName);
        }

        /// <summary>
        /// Updates a configuration source replacing any existing sections with those 
        /// built up with the builder.
        /// </summary>
        /// <param name="source"></param>
        public void UpdateConfigurationWithReplace(IConfigurationSource source)
        {
            foreach (var section in configurationSource.sections)
            {
                source.Remove(section.Key);
                source.Add(section.Key, section.Value);
            }
        }

        ///<summary/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }
    }


    /// <summary>
    /// Defines a configuration source builder.
    /// </summary>
    public interface IConfigurationSourceBuilder : IFluentInterface
    {
        /// <summary>
        /// Adds a <see cref="ConfigurationSection"/> to the builder.
        /// </summary>
        /// <param name="sectionName">Name of section to add.</param>
        /// <param name="section">Configuration section to add.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IConfigurationSourceBuilder AddSection(string sectionName, ConfigurationSection section);

        /// <summary>
        /// Determines if a section name is contained in the builder.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns>True if contained in the builder, false otherwise.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Contains(string sectionName);

        /// <summary>
        /// Returns a configuration section with the given name, if present in the builder.
        /// </summary>
        /// <param name="sectionName">Name of section to return.</param>
        /// <returns>A valid configuration section or null.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        ConfigurationSection Get(string sectionName);

        ///<summary>
        /// Returns a configuration section of type <typeparamref name="T"/>, if present in the builder.
        ///</summary>
        ///<param name="sectionName">Section name to retrieve</param>
        ///<typeparam name="T"><see cref="ConfigurationSection"/> type to return.</typeparam>
        ///<returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        T Get<T>(string sectionName) where T : ConfigurationSection;

        /// <summary>
        /// Updates a configuration source replacing any existing sections with those 
        /// built up with the builder.
        /// </summary>
        /// <param name="source"></param>
        void UpdateConfigurationWithReplace(IConfigurationSource source);
    }
}
