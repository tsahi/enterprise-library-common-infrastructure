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
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Configuration
{
    public class ConfigurationFileHelper : IDisposable
    {
        private System.Configuration.Configuration configuration;
        private IConfigurationSource configurationSource;
        private string configurationFileName;

        public ConfigurationFileHelper(IDictionary<string, ConfigurationSection> sections)
        {
            configurationFileName = Path.GetTempFileName();
            File.Copy("test.exe.config", configurationFileName, true);

            configuration = GetConfigurationForCustomFile(configurationFileName);

            SaveSections(configuration, sections);

            configurationSource = GetConfigurationSourceForCustomFile(configurationFileName);
        }

        public static IConfigurationSource GetConfigurationSourceForCustomFile(string fileName)
        {
            return new FileConfigurationSource(fileName, false);
        }

        public static System.Configuration.Configuration GetConfigurationForCustomFile(string fileName)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = fileName;
            File.SetAttributes(fileMap.ExeConfigFilename, FileAttributes.Normal);
            return ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        private static void SaveSections(System.Configuration.Configuration configuration,
                                    IDictionary<string, ConfigurationSection> sections)
        {
            foreach (string sectionName in sections.Keys)
            {
                configuration.Sections.Remove(sectionName);
                configuration.Sections.Add(sectionName, sections[sectionName]);
            }

            configuration.Save();
        }

        public IConfigurationSource ConfigurationSource
        {
            get { return this.configurationSource; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            File.Delete(this.configurationFileName);
        }

        #endregion
    }
}
