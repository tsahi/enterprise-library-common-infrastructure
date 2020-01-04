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
    /// Registers a class as a metadata body class for another class.
    /// </summary>
    /// <remarks>
    /// When applying metadata attributes to classes, the target class might not always allow itself to be anotated. <br/>
    /// This attribute can be used to nominate another class to contain the metadata attributes. <br/>
    /// The metadata type should follow the same structure as the target type and its members cab be decorated with the metadata attributes.<br/>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class RegisterAsMetadataTypeAttribute : Attribute
    {
        private readonly Type targetType;

        /// <summary>
        /// Creates a new instance of <see cref="RegisterAsMetadataTypeAttribute"/>.
        /// </summary>
        /// <param name="targetType">The type for which this class should contain metadata attributes.</param>
        public RegisterAsMetadataTypeAttribute(Type targetType)
        {
            this.targetType = targetType;
        }

        /// <summary>
        /// Gets the type for which this class should contain metadata attributes.
        /// </summary>
        /// <value>
        /// The type for which this class should contain metadata attributes.
        /// </value>
        public Type TargetType
        {
            get { return targetType; }
        }
    }
}
