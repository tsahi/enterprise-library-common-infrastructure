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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Configuration
{
    public class ConfigurationSourceUpdatable : IConfigurationSource
    {
        Dictionary<string, ConfigurationSection> configurationsections = new Dictionary<string, ConfigurationSection>();
        #region IConfigurationSource Members

        public ConfigurationSection GetSection(string sectionName)
        {
            ConfigurationSection section;
            configurationsections.TryGetValue(sectionName, out section);
            return section;
        }

        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            configurationsections[sectionName] = configurationSection;
        }

        public void Remove(string sectionName)
        {
            configurationsections[sectionName] = null;
        }

        public void DoSourceChanged(IEnumerable<string> sectionNames)
        {
            if (SourceChanged != null)
            {
                SourceChanged(this, new ConfigurationSourceChangedEventArgs(this, sectionNames));
            }
        }

        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;

        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {

        }

        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {

        }

        #endregion

        void IDisposable.Dispose()
        { }
    }
}
