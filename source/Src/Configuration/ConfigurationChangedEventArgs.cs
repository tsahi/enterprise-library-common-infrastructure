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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Event handler called after a configuration has changed.
    /// </summary>
    /// <param name="sender">
    /// <para>The source of the event.</para>
    /// </param>
    /// <param name="e">
    /// <para>A <see cref="ConfigurationChangedEventArgs"/> that contains the event data.</para>
    /// </param>
    public delegate void ConfigurationChangedEventHandler(object sender, ConfigurationChangedEventArgs e);

    /// <summary>
    /// </summary>
    [Serializable]
    public class ConfigurationChangedEventArgs : EventArgs
    {
        private readonly string sectionName;

        /// <summary>
        /// <para>Initialize a new instance of the <see cref="ConfigurationChangedEventArgs"/> class with the section name</para>
        /// </summary>
        /// <param name="sectionName"><para>The section name of the changes.</para></param>
        public ConfigurationChangedEventArgs(string sectionName)
        {
            this.sectionName = sectionName;
        }

        /// <summary>
        /// <para>Gets the section name where the changes occurred.</para>
        /// </summary>
        /// <value>
        /// <para>The section name where the changes occurred.</para>
        /// </value>
        public string SectionName
        {
            get { return sectionName; }
        }
    }
    
}
