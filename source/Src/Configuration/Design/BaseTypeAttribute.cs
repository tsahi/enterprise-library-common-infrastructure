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
    /// Indicates the base class or interface that must be assignable from the type specified in the property that this attribute decorates.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public sealed class BaseTypeAttribute : Attribute
    {
        private readonly Type configurationType;
        private readonly Type baseType;
        private readonly TypeSelectorIncludes typeSelectorIncludes;

        /// <summary>
        /// Initializes a new instance of the  <see cref="BaseTypeAttribute"/> class with the specified <see cref="Type"/> object.
        /// </summary>
        /// <param name="baseType">
        /// The <see cref="Type"/> to filter selections.
        /// </param>
        public BaseTypeAttribute(Type baseType)
            : this(baseType, TypeSelectorIncludes.None)
        {
        }

        /// <summary>
        /// Initializes a new instance of the  <see cref="BaseTypeAttribute"/> class with the specified base <see cref="Type"/> object and configuration <see cref="Type"/>.
        /// </summary>
        /// <param name="baseType">The base <see cref="Type"/> to filter.</param>
        /// <param name="configurationType">The configuration object <see cref="Type"/>.</param>
        public BaseTypeAttribute(Type baseType, Type configurationType)
            : this(baseType, TypeSelectorIncludes.None, configurationType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseTypeAttribute"/> class with the specified <see cref="Type"/> object and <see cref="TypeSelectorIncludes"/>.
        /// </summary>
        /// <param name="baseType">
        /// The <see cref="Type"/> to filter selections.
        /// </param>
        /// <param name="typeSelectorIncludes">
        /// One of the <see cref="TypeSelectorIncludes"/> values.
        /// </param>
        public BaseTypeAttribute(Type baseType, TypeSelectorIncludes typeSelectorIncludes)
            : this(baseType, typeSelectorIncludes, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the  <see cref="BaseTypeAttribute"/> class with the specified base <see cref="Type"/> object and configuration <see cref="Type"/>.
        /// </summary>
        /// <param name="typeSelectorIncludes">
        /// One of the <see cref="typeSelectorIncludes"/> values.
        /// </param>
        /// <param name="baseType">The base <see cref="Type"/> to filter.</param>
        /// <param name="configurationType">The configuration object <see cref="Type"/>.</param>
        public BaseTypeAttribute(Type baseType, TypeSelectorIncludes typeSelectorIncludes, Type configurationType)
            : base()
        {
            if (null == baseType) throw new ArgumentNullException("baseType");
            this.configurationType = configurationType;
            this.baseType = baseType;
            this.typeSelectorIncludes = typeSelectorIncludes;
        }

        /// <summary>
        /// Gets the includes for the type selector.
        /// </summary>
        /// <value>
        /// The includes for the type selector.
        /// </value>
        public TypeSelectorIncludes TypeSelectorIncludes
        {
            get { return typeSelectorIncludes; }
        }

        /// <summary>
        /// Gets the <see cref="Type"/> to filter selections.
        /// </summary>
        /// <value>
        /// The <see cref="Type"/> to filter selections.
        /// </value>
        public Type BaseType
        {
            get { return baseType; }
        }

        /// <summary>
        /// Gets the configuration object <see cref="Type"/>.
        /// </summary>
        /// <value>
        /// The configuration object <see cref="Type"/>.
        /// </value>
        public Type ConfigurationType
        {
            get { return configurationType; }
        }
    }
}
