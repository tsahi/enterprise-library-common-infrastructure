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
using System.ComponentModel;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{

    /// <summary>
    /// Attribute class used to indicate whether a property can be overwritten per environment.<br/>
    /// The default behavior is that any property can be overwritten.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class EnvironmentalOverridesAttribute : Attribute
    {
        private readonly bool canOverride;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnvironmentalOverridesAttribute"/> class.
        /// </summary>
        /// <param name="canOverride"><see langword="true"/> to specify the property can be overwritten per environment. Otherwise <see langword="false"/>.</param>
        public EnvironmentalOverridesAttribute(bool canOverride)
        {
            this.canOverride = canOverride;
        }

        /// <summary>
        /// <see langword="true"/> if the property can be overwritten per environment. Otherwise <see langword="false"/>.
        /// </summary>
        public bool CanOverride
        {
            get { return canOverride; }
        }

        /// <summary>
        /// Specifies a custom property type for the overrides property.<br/>
        /// </summary>
        public Type CustomOverridesPropertyType
        {
            get;
            set;
        }

        /// <summary>
        /// Specifies a <see cref="TypeConverter"/> that should be used to serialize the overriden value to the delta configuration file. <br/>
        /// This can be used to overwrite a property that doesnt implement <see cref="IConvertible"/>.  <br/>
        /// </summary>
        public Type StorageConverterType
        {
            get;
            set;
        }
    }
}
