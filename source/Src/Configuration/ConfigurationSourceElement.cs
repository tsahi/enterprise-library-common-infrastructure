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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using System.ComponentModel;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents the configuration settings that describe an <see cref="IConfigurationSource"/>.
    /// </summary>
    [Browsable(false)]
    [Command(ConfigurationSourcesDesignTime.CommandTypeNames.ConfigurationSourceElementDeleteCommand, 
        CommandPlacement = CommandPlacement.ContextDelete,
        Replace = CommandReplacement.DefaultDeleteCommandReplacement)]
    public class ConfigurationSourceElement : NameTypeConfigurationElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceElement"/> class with default values.
        /// </summary>
        public ConfigurationSourceElement() 
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceElement"/> class with a name and an type.
        /// </summary>
        /// <param name="name">The instance name.</param>
        /// <param name="type">The type for the represented <see cref="IConfigurationSource"/>.</param>
        public ConfigurationSourceElement(string name, Type type)
            : base(name, type)
        {
        }

        /// <summary>
        /// Returns a new <see cref="IConfigurationSource"/> configured with the receiver's settings.
        /// </summary>
        /// <returns>A new configuration source.</returns>
        public virtual IConfigurationSource CreateSource()
        {
            throw new ConfigurationErrorsException(Resources.ExceptionBaseConfigurationSourceElementIsInvalid);
        }

        ///<summary>
        /// Returns a new <see cref="IDesignConfigurationSource"/> configured based on this configuration element.
        ///</summary>
        ///<returns>Returns a new <see cref="IDesignConfigurationSource"/> or null if this source does not have design-time support.</returns>
        public virtual IDesignConfigurationSource CreateDesignSource(IDesignConfigurationSource rootSource)
        {
            
            return null;
        }
    }
}
