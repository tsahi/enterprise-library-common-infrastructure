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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents the configuration settings that describe an <see cref="SystemConfigurationSource"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "SystemConfigurationSourceElementDescription")]
    [ResourceDisplayName(typeof(DesignResources), "SystemConfigurationSourceElementDisplayName")]
    [Browsable(true)]
    public class SystemConfigurationSourceElement : ConfigurationSourceElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemConfigurationSourceElement"/> class with default values.
        /// </summary>
        public SystemConfigurationSourceElement()
            : this(Resources.SystemConfigurationSourceName)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemConfigurationSourceElement"/> class with a name and an type.
        /// </summary>
        /// <param name="name">The instance name.</param>
        public SystemConfigurationSourceElement(string name)
            : base(name, typeof(SystemConfigurationSource))
        { }

        /// <summary>
        /// Returns a new <see cref="SystemConfigurationSource"/>.
        /// </summary>
        /// <returns>A new configuration source.</returns>
        public override IConfigurationSource CreateSource()
        {
            IConfigurationSource createdObject = new SystemConfigurationSource();

            return createdObject;
        }
    }
}
