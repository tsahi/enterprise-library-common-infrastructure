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
    /// Marks the annotated class as a configuration wizard that can be found
    /// by the configuration design time tools.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = true)]
    public class WizardCommandAttribute : CommandAttribute
    {
        ///<summary>
        /// Initializes a new instance of the <see cref="WizardCommandAttribute"/>
        /// with the default wizard command model type specified.
        ///</summary>
        public WizardCommandAttribute() : this(CommonDesignTime.CommandTypeNames.WizardCommand)
        {
        }

        ///<summary>
        /// Initializes a new instance of the <see cref="WizardCommandAttribute"/>
        /// with the command model type specified as a string.
        ///</summary>
        ///<param name="commandModelTypeName"></param>
        public WizardCommandAttribute(string commandModelTypeName)
            : base(commandModelTypeName)
        {
            if (String.IsNullOrEmpty(commandModelTypeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "commandModelTypeName");

            this.CommandPlacement = CommandPlacement.WizardMenu;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardCommandAttribute"/> with 
        /// the command model type specified by <see cref="Type"/>.
        /// </summary>
        /// <param name="commandModelType"></param>
        public WizardCommandAttribute(Type commandModelType)
            : this(commandModelType == null ? null : commandModelType.AssemblyQualifiedName)
        {
        }

        /// <summary>
        /// The type of the wizard to instantiate must derive from WizardModel or will result on an error at runtime.
        /// </summary>
        public Type WizardType 
        {
            get { return Type.GetType(this.WizardTypeName, true, true); }
            set 
            {
                if (value == null) throw new ArgumentNullException("value");
                this.WizardTypeName = value.AssemblyQualifiedName; 
            }
        }

        /// <summary>
        /// The name of the type of the wizard to instantiate.
        /// </summary>
        public string WizardTypeName
        {
            get;
            set;
        }
    }
}
