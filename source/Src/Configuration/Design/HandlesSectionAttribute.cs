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
using System.Configuration;
using System.Linq;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    ///<summary>
    /// Indicates that this assembly handles the <see cref="ConfigurationSection"/>.
    ///</summary>
    [AttributeUsage(AttributeTargets.Assembly,AllowMultiple=true)]
    public class HandlesSectionAttribute : Attribute
    {
        private readonly string sectionName;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandlesSectionAttribute"/> class.
        /// </summary>
        /// <param name="sectionName"></param>
        public HandlesSectionAttribute(string sectionName)
        {
            this.sectionName = sectionName;
        }

        ///<summary>
        /// Name of the section handled by this assembly.
        ///</summary>
        public string SectionName
        {
            get { return sectionName; }
        }

        /// <summary>
        /// Indicates this section should be cleared during save, but there is no 
        /// direct handler for it.
        /// </summary>
        public bool ClearOnly { get; set; }
    }
}
