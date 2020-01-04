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
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects
{
    public class PolymorphicConfigurationElementCollectionTestSection : ConfigurationSection
    {
        [ConfigurationProperty("withOverrides")]
        public TestNameTypeConfigurationElementCollectionWithOverridenAddAndClearNames<BasePolymorphicObjectData, CustomPolymorphicObjectData> WithOverrides
        {
            get { return (TestNameTypeConfigurationElementCollectionWithOverridenAddAndClearNames<BasePolymorphicObjectData, CustomPolymorphicObjectData>)this["withOverrides"]; }
            set { this["withOverrides"] = value; }
        }

        [ConfigurationProperty("withoutOverrides")]
        public NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData> WithoutOverrides
        {
            get { return (NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData>)this["withoutOverrides"]; }
            set { this["withoutOverrides"] = value; }
        }
    }
}
