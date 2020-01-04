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
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    ///<summary>
    /// Determines if the corresponding property is read-only at designtime.
    ///</summary>
    ///<remarks>
    /// This attribute is used to mark properties that should be presented as read-only, but underlying code may change the value on.
    /// <seealso cref="ReadOnlyAttribute"/></remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class DesignTimeReadOnlyAttribute : Attribute
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="DesignTimeReadOnlyAttribute"/> class.
        ///</summary>
        ///<param name="readOnly"><see langword="true"/> if the property should be read-only at designtime.</param>
        public DesignTimeReadOnlyAttribute(bool readOnly)
        {
            ReadOnly = readOnly;
        }

        ///<summary>
        /// Determines if the property is read-only by design-time.
        /// Returns <see langword="true" /> if the property is read-only at design-time
        /// and <see langword="false" /> otherwise.
        ///</summary>
        public bool ReadOnly { get; private set; }

    }
}
