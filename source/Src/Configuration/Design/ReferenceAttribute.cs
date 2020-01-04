﻿/*
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
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Attribute class used to indicate that the property is a reference to provider. <br/>
    /// Reference properties will show an editable dropdown that allows the referred element to be selected.<br/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public sealed class ReferenceAttribute : Attribute
    {
        private readonly string scopeTypeName;
        private readonly string targetTypeName;
        private Type cachedType;
        private Type cachedScopeType;
        private bool scopeTypeCached = false;


        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceAttribute"/> class.
        /// </summary>
        /// <param name="targetTypeName">The configuration type name of the provider that used as a reference.</param>
        public ReferenceAttribute(string targetTypeName)
        {
            if (string.IsNullOrEmpty(targetTypeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "targetTypeName");
            this.targetTypeName = targetTypeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceAttribute"/> class.
        /// </summary>
        /// <param name="scopeTypeName">The name of a configuration type that contains the references.</param>
        /// <param name="targetTypeName">The configuration type name of the provider that used as a reference.</param>
        public ReferenceAttribute(string scopeTypeName, string targetTypeName)
        {
            if (string.IsNullOrEmpty(scopeTypeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "scopeTypeName");
            if (string.IsNullOrEmpty(targetTypeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "targetTypeName");

            this.scopeTypeName = scopeTypeName;
            this.targetTypeName = targetTypeName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceAttribute"/> class.
        /// </summary>
        /// <param name="targetType">The configuration type of the provider that used as a reference.</param>
        public ReferenceAttribute(Type targetType)
        {
            if (targetType == null) throw new ArgumentNullException("targetType");

            this.targetTypeName = targetType.AssemblyQualifiedName;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceAttribute"/> class.
        /// </summary>
        /// <param name="scopeType">The configuration type that contains the references.</param>
        /// <param name="targetType">The configuration type of the provider that used as a reference.</param>
        public ReferenceAttribute(Type scopeType, Type targetType)
        {
            if (targetType == null) throw new ArgumentNullException("targetType");
            if (scopeType == null) throw new ArgumentNullException("scopeType");

            this.scopeTypeName = scopeType.AssemblyQualifiedName;
            this.targetTypeName = targetType.AssemblyQualifiedName;
        }

        /// <summary>
        /// Gets the configuration type that contains the references.
        /// </summary>
        public Type ScopeType
        {
            get
            {
                if (!scopeTypeCached)
                {
                    cachedScopeType = string.IsNullOrEmpty(scopeTypeName) ? null : Type.GetType(scopeTypeName);
                    scopeTypeCached = true;
                }

                return cachedScopeType;
            }
        }

        /// <summary>
        /// Gets or sets a boolean indicating whether only providers can be used that are contained in the current Element View Model.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if only providers can be used that are contained in the current Element View Model. Otherwise <see langword="false"/>.
        /// </value>
        public bool ScopeIsDeclaringElement
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the configuration type of the provider that used as a reference.
        /// </summary>
        public Type TargetType
        {
            get
            {
                if (cachedType == null)
                {
                    cachedType = Type.GetType(targetTypeName);
                }
                
                return cachedType;
            }
        }
    }
}
