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
    /// Specifies additional metadata for the FilteredFileNameEditor editor.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments"), AttributeUsage(AttributeTargets.Property)]
    public sealed class FilteredFileNameEditorAttribute : Attribute
    {
        private string filter;

        /// <summary>
        /// Initialize a new instance of the <see cref="FilteredFileNameEditorAttribute"/> class with the <see cref="Type"/> containing the resources and the resource key.
        /// </summary>
        /// <param name="resourceType">The <see cref="Type"/> containing the resources.</param>
        /// <param name="resourceKey">The resource key.</param>
        public FilteredFileNameEditorAttribute(Type resourceType, string resourceKey)
        {
            if (null == resourceType) throw new ArgumentNullException("resourceType");

            this.filter = ResourceStringLoader.LoadString(resourceType.FullName, resourceKey, resourceType.Assembly);
            this.CheckFileExists = true;
        }

        /// <summary>
        /// Gets the filter for the dialog.
        /// </summary>
        /// <value>
        /// The filter for the dialog.
        /// </value>
        public string Filter
        {
            get { return this.filter; }
        }

        /// <summary>
        /// Gets or sets whether the Open File Dialog should only allow existing files to be selected.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the Open File Dialog is used to open existing files. Otherwise <see langword="false"/>.
        /// </value>
        public bool CheckFileExists
        {
            get;
            set;
        }
    }
}
