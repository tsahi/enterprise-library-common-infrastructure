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

using System.ComponentModel;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SysConfig = System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    [TestClass]
    public class ByteArrayConverterFixture
    {
        const string sectionName = "byteArrayConverter";

        [TestInitialize]
        public void TestInitialize()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.Sections.Remove(sectionName);
            config.Save();
        }

        [TestMethod]
        public void SerializeAndDeserializeAByteArray()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConverterSection section = new ConverterSection();
            section.ByteArray = new byte[] { 1, 2, 3, 4 };
            config.Sections.Add(sectionName, section);
            config.Save();

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            section = config.Sections[sectionName] as ConverterSection;
            Assert.IsNotNull(section);
            byte actual = 1;
            Assert.AreEqual(section.ByteArray[0], actual);
        }

        [TestMethod]
        public void SerializeAndDeserialzieANullByteArray()
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConverterSection section = new ConverterSection();
            section.ByteArray = null;
            config.Sections.Add(sectionName, section);
            config.Save();

            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            section = config.Sections[sectionName] as ConverterSection;
            Assert.IsNotNull(section);
            Assert.IsNull(section.ByteArray);
        }

        public class ConverterSection : SerializableConfigurationSection
        {
            const string propertyName = "property";

            [ConfigurationProperty(propertyName)]
            [TypeConverter(typeof(ByteArrayTypeConverter))]
            public byte[] ByteArray
            {
                get { return (byte[])base[propertyName]; }
                set { base[propertyName] = value; }
            }
        }
    }
}
