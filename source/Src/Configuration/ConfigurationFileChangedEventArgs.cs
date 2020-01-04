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
    /// </summary>
    [Serializable]
    public class ConfigurationFileChangedEventArgs : ConfigurationChangedEventArgs
    {
        private readonly string configurationFile;


        /// <summary>
        /// <para>Initialize a new instance of the <see cref="ConfigurationChangedEventArgs"/> class with the 
        /// configuration file and the section name.</para>
        /// </summary>
        /// <param name="configurationFile"><para>The configuration file where the change occured.</para></param>
        /// <param name="sectionName"><para>The section name of the changes.</para></param>
        public ConfigurationFileChangedEventArgs(string configurationFile, string sectionName) : base(sectionName)
        {
            this.configurationFile = configurationFile;
        }

        /// <summary>
        /// <para>Gets the configuration file of the data that changed.</para>
        /// </summary>
        /// <value>
        /// <para>The configuration file of the data that changed.</para>
        /// </value>
        public string ConfigurationFile
        {
            get { return configurationFile; }
        }
    }
}
