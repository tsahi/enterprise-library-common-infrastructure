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
using System.IO;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    [TestClass]
    public class SaveFileConfigurationFixture
    {
        string file;

        [TestInitialize]
        public void TestInitialize()
        {
            file = CreateFile();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (File.Exists(file)) File.Delete(file);
        }

        [TestMethod]
        public void CanSaveConfigurationSectionToFile()
        {
            FileConfigurationSource source = new FileConfigurationSource(file, false);
            source.Save(TestConfigurationSection.SectionName, CreateTestSection());

            ValidateConfiguration(file);
        }

        string CreateFile()
        {
            string tempFile = Path.Combine(Directory.GetCurrentDirectory(), @"app.config");
            XmlDocument doc = new XmlDocument();
            XmlElement elem = doc.CreateElement("configuration");
            doc.AppendChild(elem);
            doc.Save(tempFile);
            return tempFile;
        }

        void ValidateConfiguration(string configFile)
        {
            TestConfigurationSection section = GetSection(configFile);

            Assert.AreEqual(true, section.BoolValue);
            Assert.AreEqual(42, section.IntValue);
        }

        TestConfigurationSection GetSection(string configFile)
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = configFile;
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            TestConfigurationSection section = (TestConfigurationSection)config.GetSection(TestConfigurationSection.SectionName);
            return section;
        }

        [TestMethod]
        public void TryToSaveWithAFileConfigurationSaveParameter()
        {
            FileConfigurationSource source = new FileConfigurationSource(file, false);
            source.Add(TestConfigurationSection.SectionName, CreateTestSection());

            ValidateConfiguration(file);
        }

        [TestMethod]
        public void TryToSaveWithConfigurationMultipleTimes()
        {
            string tempFile = CreateFile();
            try
            {
                using (var source = new FileConfigurationSource(tempFile, false))
                {
                    source.Add(TestConfigurationSection.SectionName, CreateTestSection());
                    ValidateConfiguration(tempFile);
                    source.Add(TestConfigurationSection.SectionName, CreateTestSection());
                    ValidateConfiguration(tempFile);
                    source.Add(TestConfigurationSection.SectionName, CreateTestSection());
                    ValidateConfiguration(tempFile);
                }
            }
            finally
            {
                if (File.Exists(tempFile)) File.Delete(tempFile);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TryToSaveWithNullOrEmptySectionNameThrows()
        {
            FileConfigurationSource source = new FileConfigurationSource(file, false);
            source.Save(null, CreateTestSection());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryToSaveWithNullSectionThrows()
        {
            FileConfigurationSource source = new FileConfigurationSource(file, false);
            source.Save(TestConfigurationSection.SectionName, null);
        }

        TestConfigurationSection CreateTestSection()
        {
            return new TestConfigurationSection { BoolValue = true, IntValue = 42 };
        }
    }

    public class TestConfigurationSection : ConfigurationSection
    {
        public const string SectionName = "testSection";

        [ConfigurationProperty("boolValue")]
        public bool BoolValue
        {
            get { return (bool)this["boolValue"]; }
            set { this["boolValue"] = value; }
        }

        [ConfigurationProperty("intValue")]
        public int IntValue
        {
            get { return (int)this["intValue"]; }
            set { this["intValue"] = value; }
        }
    }
}
