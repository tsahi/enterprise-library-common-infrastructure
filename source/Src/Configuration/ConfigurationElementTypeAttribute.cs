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
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Indicates the configuration object type that is used for the attributed object.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ConfigurationElementTypeAttribute : Attribute
    {
        //private Type configurationType;
        private string typeName;

        /// <summary>
        /// Initialize a new instance of the <see cref="EnterpriseLibrary.Common.Configuration.ConfigurationElementTypeAttribute"/> class.
        /// </summary>
        public ConfigurationElementTypeAttribute()
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="ConfigurationElementTypeAttribute"/> class with the configuration object type.
        /// </summary>
        /// <param name="configurationType">The <see cref="Type"/> of the configuration object.</param>
        public ConfigurationElementTypeAttribute(Type configurationType)
            : this(configurationType == null ? null : configurationType.AssemblyQualifiedName)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="ConfigurationElementTypeAttribute"/> class with the configuration object type.
        /// </summary>
        /// <param name="typeName">The <see cref="Type"/> name of the configuration object.</param>
        public ConfigurationElementTypeAttribute(string typeName)
        {
            if (string.IsNullOrEmpty(typeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "typeName");
            this.typeName = typeName;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> of the configuration object.
        /// </summary>
        /// <value>
        /// The <see cref="Type"/> of the configuration object.
        /// </value>
        public Type ConfigurationType
        {
            get { return Type.GetType(TypeName); }
        }

        /// <summary>
        /// Gets <see cref="Type"/> name of the configuration object.
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
        }
    }
}
