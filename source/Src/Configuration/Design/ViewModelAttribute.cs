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
    /// Attribute class used to specify a specific View Model derivement or visual representation to be used on the target element.
    /// </summary>
    /// <remarks>
    /// 
    /// <para>The View Model Type should derive from the ElementViewModel or Property class in the Configuration.Design assembly. <br/>
    /// As this attribute can be applied to the configuration directly and we dont want to force a dependency on the Configuration.Design assembly <br/>
    /// You can specify the View Model Type in a loosy coupled fashion, passing a qualified name of the type.</para>
    ///
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class ViewModelAttribute : Attribute
    {
        private readonly string modelTypeName;

        ///<summary>
        /// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
        ///</summary>
        ///<param name="modelType">The type of the View Model that should be used for the annotated element.</param>
        public ViewModelAttribute(Type modelType)
            : this(modelType != null ? modelType.AssemblyQualifiedName : null)
        { }


        ///<summary>
        /// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
        ///</summary>
        ///<param name="modelTypeName">The type name of the View Model that should be used for the annotated element.</param>
        public ViewModelAttribute(string modelTypeName)
        {
            if (String.IsNullOrEmpty(modelTypeName)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty, "modelTypeName");

            this.modelTypeName = modelTypeName;
        }

        ///<summary>
        /// Gets the View Model Type that should be used to bind the annotated element to its view.
        ///</summary>
        public Type ModelType
        {
            get { return Type.GetType(modelTypeName, true, true); }
        }


    }
}
