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
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Attribute class that allows to specify a property that should be used as the Element View Model's name.<br/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class NamePropertyAttribute : Attribute
    {
        private readonly string propertyName;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamePropertyAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">The reflection name of the property that will be used as the Element View Model's name.</param>
        public NamePropertyAttribute(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "propertyName");
            
            this.propertyName =  propertyName;
            this.NamePropertyDisplayFormat = "{0}";
        }

        /// <summary>
        /// Gets the reflection name of the property that will be used as the Element View Model's name.
        /// </summary>
        public string PropertyName
        {
            get { return propertyName; }
        }

        /// <summary>
        /// Gets the Display Format that will be used to display the name property.<br/>
        /// The Display Format should be a Format-string with 1 argument:<Br/>
        /// The token '{0}' will be replaced with the Name Properties value.
        /// </summary>
        public string NamePropertyDisplayFormat { get; set; }
    }
}
