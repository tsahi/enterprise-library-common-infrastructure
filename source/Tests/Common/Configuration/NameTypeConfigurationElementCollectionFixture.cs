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

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    [TestClass]
    public class NameTypeConfigurationElementCollectionFixture
    {
        [TestMethod]
        public void CanReadConfigurationElementsFromCollectionWithoutOverrides()
        {
            PolymorphicConfigurationElementCollectionTestSection section
                = ConfigurationManager.GetSection("withoutclear") as PolymorphicConfigurationElementCollectionTestSection;

            NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData> elements = section.WithoutOverrides;
            Assert.AreEqual(3, elements.Count);
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("provider1a").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject2Data), elements.Get("provider2").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("provider1b").GetType());
        }

        [TestMethod]
        public void CanReadConfigurationElementsFromCollectionWithOverrides()
        {
            PolymorphicConfigurationElementCollectionTestSection section
                = ConfigurationManager.GetSection("withoutclear") as PolymorphicConfigurationElementCollectionTestSection;

            NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData> elements = section.WithOverrides;
            Assert.AreEqual(3, elements.Count);
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("overrideprovider1a").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject2Data), elements.Get("overrideprovider2").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("overrideprovider1b").GetType());
        }

        [TestMethod]
        public void CanReadConfigurationElementsWithClearFromCollectionWithoutOverrides()
        {
            PolymorphicConfigurationElementCollectionTestSection section
                = ConfigurationManager.GetSection("withclear") as PolymorphicConfigurationElementCollectionTestSection;

            NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData> elements = section.WithoutOverrides;
            Assert.AreEqual(2, elements.Count);
            Assert.AreSame(typeof(DerivedPolymorphicObject2Data), elements.Get("provider2").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("provider1b").GetType());
        }

        [TestMethod]
        public void CanReadConfigurationElementsWithClearFromCollectionWithOverrides()
        {
            PolymorphicConfigurationElementCollectionTestSection section
                = ConfigurationManager.GetSection("withclear") as PolymorphicConfigurationElementCollectionTestSection;

            NameTypeConfigurationElementCollection<BasePolymorphicObjectData, CustomPolymorphicObjectData> elements = section.WithOverrides;
            Assert.AreEqual(2, elements.Count);
            Assert.AreSame(typeof(DerivedPolymorphicObject2Data), elements.Get("overrideprovider2").GetType());
            Assert.AreSame(typeof(DerivedPolymorphicObject1Data), elements.Get("overrideprovider1b").GetType());
        }
    }
}
