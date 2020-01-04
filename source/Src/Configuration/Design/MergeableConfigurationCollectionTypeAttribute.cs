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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Attribute class used to associate a <see cref="System.Configuration.ConfigurationElementCollection"/> class with an <see cref="IMergeableConfigurationElementCollection"/> implementation.
    /// </summary>
    /// <seealso cref="IMergeableConfigurationElementCollection"/>
    [AttributeUsage(AttributeTargets.Class)]
    public class MergeableConfigurationCollectionTypeAttribute : Attribute
    {
        private readonly Type mergeableConfigurationCollectionType;

        /// <summary>
        /// Creates a new instance of the <see cref="MergeableConfigurationCollectionTypeAttribute"/> class.
        /// </summary>
        /// <param name="mergeableConfigurationCollectionType">The type of <see cref="IMergeableConfigurationElementCollection"/> that should be associated with the target <see cref="System.Configuration.ConfigurationElementCollection"/> class.</param>
        public MergeableConfigurationCollectionTypeAttribute(Type mergeableConfigurationCollectionType)
        {
            this.mergeableConfigurationCollectionType = mergeableConfigurationCollectionType;
        }

        /// <summary>
        /// Gets the type of <see cref="IMergeableConfigurationElementCollection"/> that should be associated with the target <see cref="System.Configuration.ConfigurationElementCollection"/> class.
        /// </summary>
        /// <value>
        /// The type of <see cref="IMergeableConfigurationElementCollection"/> that should be associated with the target <see cref="System.Configuration.ConfigurationElementCollection"/> class.
        /// </value>
        public Type MergeableConfigurationCollectionType
        {
            get { return mergeableConfigurationCollectionType; }
        }
    }
}
