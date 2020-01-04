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
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Configuration element for a redirected section.<br/>
    /// The <see cref="NamedConfigurationElement.Name"/> property is used to identify the redireced section, based on its section name.<br/>
    /// </summary>
    /// <seealso cref="ConfigurationSourceSection"/>
    [ResourceDescription(typeof(DesignResources), "RedirectedSectionElementDescription")]
    [ResourceDisplayName(typeof(DesignResources), "RedirectedSectionElementDisplayName")]
    public class RedirectedSectionElement : NamedConfigurationElement
    {
        private const string sourceNameProperty = "sourceName";

        /// <summary>
        /// Gets the name of the <see cref="ConfigurationSourceElement"/> which contains the configuration section.
        /// </summary>
        /// <value>
        /// The name of the <see cref="ConfigurationSourceElement"/> which contains the configuration section.
        /// </value>
        [ConfigurationProperty(sourceNameProperty, IsRequired = true)]
        [ResourceDescription(typeof(DesignResources), "RedirectedSectionElementSourceNameDescription")]
        [ResourceDisplayName(typeof(DesignResources), "RedirectedSectionElementSourceNameDisplayName")]
        [Reference(typeof(CustomConfigurationElementCollection<ConfigurationSourceElement, ConfigurationSourceElement>), typeof(ConfigurationSourceElement))]
        [ViewModel(CommonDesignTime.ViewModelTypeNames.RedirectedSectionSourceProperty)]
        [EnvironmentalOverrides(false)]
        public string SourceName
        {
            get { return (string)this[sourceNameProperty]; }
            set { this[sourceNameProperty] = value; }
        }

    }
}
