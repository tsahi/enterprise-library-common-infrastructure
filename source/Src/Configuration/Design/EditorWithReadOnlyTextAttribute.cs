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
    /// <summary>
    /// Attribute that instructs the designtime to make the textbox for a property readonly. <br/>
    /// This property can is used together with an <see cref="EditorAttribute"/>, in which the created text box is readonly, 
    /// though the property can be edited by the editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public class EditorWithReadOnlyTextAttribute : Attribute
    {
        readonly bool readonlyText;

        /// <summary>
        /// Creates a new instance of <see cref="EditorWithReadOnlyTextAttribute"/>.
        /// </summary>
        /// <param name="readonlyText"><see langword="true"/> if the textbox created for this property should be readonly, otherwise <see langword="false"/>.</param>
        public EditorWithReadOnlyTextAttribute(bool readonlyText)
        {
            this.readonlyText = readonlyText;
        }

        /// <summary>
        /// Returns <see langword="true"/> if the textbox created for this property should be readonly, otherwise <see langword="false"/>.
        /// </summary>
        public bool ReadonlyText
        {
            get { return readonlyText; }
        }
    }
}
