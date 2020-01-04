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
using System.Diagnostics;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Defines information needed to install a <see cref="PerformanceCounterCategory"></see>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class PerformanceCountersDefinitionAttribute : Attribute
    {
        PerformanceCounterCategoryType categoryType;
        string categoryName;
        string categoryHelp;

        /// <summary>
        /// Gets the <see cref="PerformanceCounter"></see> category type.
        /// </summary>
        public PerformanceCounterCategoryType CategoryType
        {
            get { return categoryType; }
        }

        /// <summary>
        /// Gets the <see cref="PerformanceCounter"></see> category name.
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }
        }

        /// <summary>
        /// Gets the <see cref="PerformanceCounter"></see> category help resource name.
        /// This is not the help text itself, 
        /// but is the resource name used to look up the internationalized help text at install-time.
        /// </summary>
        public string CategoryHelp
        {
            get { return categoryHelp; }
        }

        /// <overloads>
        /// Initializes this attribute with information needed to install this performance counter category.
        /// </overloads>
        /// <summary>
        /// Initializes this attribute with information needed to install this performance counter category.
        /// </summary>
        /// <param name="categoryName">Performance counter category name</param>
        /// <param name="categoryHelp">Counter category help resource name. 
        /// This is not the help text itself, 
        /// but is the resource name used to look up the internationalized help text at install-time.
        ///</param>
        public PerformanceCountersDefinitionAttribute(string categoryName, string categoryHelp)
            : this(categoryName, categoryHelp, PerformanceCounterCategoryType.MultiInstance)
        {
        }

        /// <summary>
        /// Initializes this attribute with information needed to install this performance counter category.
        /// </summary>
        /// <param name="categoryName">Performance counter category name</param>
        /// <param name="categoryHelp">Counter category help resource name. 
        /// This is not the help text itself, 
        /// but is the resource name used to look up the internationalized help text at install-time.
        ///</param>
        /// <param name="categoryType">Performance counter category type.</param>
        public PerformanceCountersDefinitionAttribute(string categoryName, string categoryHelp, PerformanceCounterCategoryType categoryType)
        {
            this.categoryName = categoryName;
            this.categoryHelp = categoryHelp;
            this.categoryType = categoryType;
        }
    }
}
