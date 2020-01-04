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
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    ///<summary>
    /// Supports Enterprise Library design-time by providing ability to 
    /// retrieve, add, and remove sections.
    ///</summary>
    public interface IDesignConfigurationSource : IProtectedConfigurationSource
    {
        ///<summary>
        /// Retrieves a local section from the configuration source.
        ///</summary>
        ///<param name="sectionName"></param>
        ///<returns>The configuration section or null if it does not contain the section.</returns>
        ConfigurationSection GetLocalSection(string sectionName);

        /// <summary>
        /// Adds a local section to the configuration source.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="section"></param>
        void AddLocalSection(string sectionName, ConfigurationSection section);

        ///<summary>
        /// Removes a local section from the configuration source.
        ///</summary>
        ///<param name="sectionName"></param>
        void RemoveLocalSection(string sectionName);
    }
}
