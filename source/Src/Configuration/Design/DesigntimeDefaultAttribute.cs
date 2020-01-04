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
    /// Specifies a default value for a configuration property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class DesigntimeDefaultAttribute : Attribute
    {
        readonly string bindableDefaultValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="DesigntimeDefaultAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// The default value is a string representation which will be converted using <see cref="System.Globalization.CultureInfo.InvariantCulture"/>.
        /// </remarks>
        /// <param name="bindableDefaultValue">The string representation of the default value.</param>
        public DesigntimeDefaultAttribute(string bindableDefaultValue)
        {
            this.bindableDefaultValue = bindableDefaultValue;
        }

        /// <summary>
        /// Gets the string reprentation of the default value.
        /// </summary>
        /// <value>
        /// The string reprentation of the default value.
        /// </value>
        public string BindableDefaultValue
        {
            get { return bindableDefaultValue; }
        }
    }
}
