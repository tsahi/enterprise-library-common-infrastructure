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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Attribute class used to decorate the design time view model with a Add Application Block command. <br/>
    /// Add Application Block commands are added to the configuration tools main menu, underneath the 'Blocks' menu item.
    /// </summary>
    public class AddApplicationBlockCommandAttribute : CommandAttribute
    {
        private readonly string sectionName;
        private readonly Type configurationSectionType;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddApplicationBlockCommandAttribute"/> class.
        /// </summary>
        /// <param name="sectionName">The name of the configuration section that belongs to the application block that will be added.</param>
        /// <param name="configurationSectionType">The type of the configuration section that belongs to the application block that will be added.</param>
        public AddApplicationBlockCommandAttribute(string sectionName, Type configurationSectionType)
            : base(CommonDesignTime.CommandTypeNames.AddApplicationBlockCommand)
        {
            CommandPlacement = CommandPlacement.BlocksMenu;

            this.sectionName = sectionName;
            this.configurationSectionType = configurationSectionType;
        }

        /// <summary>
        /// Gets the name of the configuration section that belongs to the application block that will be added.
        /// </summary>
        public string SectionName
        {
            get { return sectionName; }
        }

        /// <summary>
        /// Gets the type of the configuration section that belongs to the application block that will be added.
        /// </summary>
        public Type ConfigurationSectionType
        {
            get { return configurationSectionType; }
        }
    }
}
