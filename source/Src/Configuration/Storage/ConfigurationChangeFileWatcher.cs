﻿/*
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
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Storage
{
    /// <summary>
    /// <para>Represents an <see cref="IConfigurationChangeWatcher"/> that watches a file.</para>
    /// </summary>
    public class ConfigurationChangeFileWatcher : ConfigurationChangeWatcher
    {
        private const string eventSourceName = "Enterprise Library Configuration";
        private string configurationSectionName;
        private string configFilePath;

        /// <summary>
        /// <para>Initialize a new <see cref="ConfigurationChangeFileWatcher"/> class with the path to the configuration file and the name of the section</para>
        /// </summary>
        /// <param name="configFilePath">
        /// <para>The full path to the configuration file.</para>
        /// </param>
        /// <param name="configurationSectionName">
        /// <para>The name of the configuration section to watch.</para>
        /// </param>
        public ConfigurationChangeFileWatcher(string configFilePath, string configurationSectionName)
        {
            if (string.IsNullOrEmpty(configFilePath)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "configFilePath");
            if (null == configurationSectionName) throw new ArgumentNullException("configurationSectionName");

            this.configurationSectionName = configurationSectionName;
            this.configFilePath = configFilePath;
        }

        /// <summary>
        /// <para>Gets the name of the configuration section being watched.</para>
        /// </summary>
        /// <value>
        /// <para>The name of the configuration section being watched.</para>
        /// </value>
        public override string SectionName
        {
            get { return configurationSectionName; }
        }

        /// <summary>
        /// <para>Returns the <see cref="DateTime"/> of the last change of the information watched</para>
        /// <para>The information is retrieved using the watched file modification timestamp</para>
        /// </summary>
        /// <returns>The <see cref="DateTime"/> of the last modificaiton, or <code>DateTime.MinValue</code> if the information can't be retrieved</returns>
        protected override DateTime GetCurrentLastWriteTime()
        {
            if (File.Exists(configFilePath) == true)
            {
                return File.GetLastWriteTime(configFilePath);
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Builds the change event data, including the full path of the watched file
        /// </summary>
        /// <returns>The change event information</returns>
        protected override ConfigurationChangedEventArgs BuildEventData()
        {
            return new ConfigurationFileChangedEventArgs(Path.GetFullPath(configFilePath), configurationSectionName);
        }

        /// <summary>
        /// Returns the source name to use when logging events
        /// </summary>
        /// <returns>The event source name</returns>
        protected override string GetEventSourceName()
        {
            return eventSourceName;
        }
    }
}
