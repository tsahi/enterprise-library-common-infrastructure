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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.ContextBase;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using System.Collections.Specialized;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    [TestClass]
    public class ConfigurationSectionClonerFixture : ArrangeActAssert
    {
        ConfigurationSectionCloner cloner;
        TestConfigurationSection section;
        TestConfigurationSection clonedSection;

        protected override void Arrange()
        {
            cloner = new ConfigurationSectionCloner();
            section = new TestConfigurationSection();
            section.Custom.Name = "custom";
            section.Custom.Attributes.Add("k1", "v1");
            section.Custom.Attributes.Add("k2", "v2");
        }

        protected override void Act()
        {
            clonedSection = cloner.Clone(section) as TestConfigurationSection;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void then_cloning_null_section_throws_argument_null_exception()
        {
            cloner.Clone(null);
        }

        [TestMethod]
        public void then_attributes_are_cloned_too()
        {
            Assert.IsTrue(clonedSection.Custom.Attributes.Cast<string>().Any(x => x == "k1"));
            Assert.IsTrue(clonedSection.Custom.Attributes.Cast<string>().Any(x => x == "k2"));
        }


        protected class TestConfigurationSection : ConfigurationSection
        {
            public TestConfigurationSection()
            {
                Custom = new CustomProvider();
            }

            [ConfigurationProperty("Custom")]
            public CustomProvider Custom
            {
                get { return (CustomProvider)base["Custom"]; }
                set { base["Custom"] = value; }
            }
        }

        public class CustomProvider : ConfigurationElement, ICustomProviderData
        {
            NameValueCollection attributes = new NameValueCollection();

            [ConfigurationProperty("Name")]
            public string Name
            {
                get { return (string)base["Name"]; }
                set { base["Name"] = value; }
            }

            public System.Collections.Specialized.NameValueCollection Attributes
            {
                get { return attributes;}
            }
        }
    }
}
