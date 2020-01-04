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
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Event arguments describing which sections have changed in a configuration source.
    /// </summary>
    public class ConfigurationSourceChangedEventArgs : EventArgs
    {
        private readonly IConfigurationSource configurationSource;
        private readonly ReadOnlyCollection<string> changedSectionNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceChangedEventArgs"/> class.
        /// </summary>
        /// <param name="configurationSource">Configuration source that changed.</param>
        /// <param name="changedSectionNames">Sequence of the section names in <paramref name="configurationSource"/>
        /// that have changed.</param>
        public ConfigurationSourceChangedEventArgs(IConfigurationSource configurationSource,
            IEnumerable<string> changedSectionNames)
        {
            this.configurationSource = configurationSource;
            this.changedSectionNames = new ReadOnlyCollection<string>(changedSectionNames.ToArray());
        }

        /// <summary>
        /// The configuration source that has changed.
        /// </summary>
        public IConfigurationSource ConfigurationSource
        {
            get { return configurationSource; }
        }

        /// <summary>
        /// The set of section names that have changed.
        /// </summary>
        public ReadOnlyCollection<string> ChangedSectionNames
        {
            get { return changedSectionNames; }
        }
    }
}
