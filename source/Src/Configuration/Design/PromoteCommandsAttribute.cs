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
    /// Attribute class that can be oved to offer a properties add-commands to the containing Element View Model.<br/>
    /// This can be usefull for properties that contain a collection of providers, of which the Element Collection View Model is not shown in the UI (User Interface).
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=true)]
    public class PromoteCommandsAttribute : Attribute
    {
    }
}
