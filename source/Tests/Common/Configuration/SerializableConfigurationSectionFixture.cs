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

using System.IO;
using System.Text;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    [TestClass]
    public class SerializableConfigurationSectionFixture
    {
        DummySection configSection = null;

        [TestInitialize]
        public void TestInitialize()
        {
            configSection = new DummySection();
        }

        [TestMethod]
        public void SerializeSqlTestConfiguration()
        {
            MemoryStream stream = new MemoryStream();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                // Write XML data.
                configSection.WriteXml(writer);

                Assert.IsNotNull(writer);

                writer.Close();
                Assert.IsTrue(stream.Length > 0);

                writer.Flush();
            }
        }

        [TestMethod]
        public void SerializeAndDeserializeSqlTestConfiguration()
        {
            StringBuilder output = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            using (XmlWriter writer = XmlWriter.Create(output, settings))
            {
                // Add a testObject and serialize it the configuration section
                configSection.Value = 20;
                configSection.WriteXml(writer);

                Assert.IsNotNull(writer);

                writer.Close();
                Assert.IsTrue(output.Length > 0);
                writer.Flush();
            }

            DummySection configSection2 = new DummySection();
            XmlReaderSettings settings2 = new XmlReaderSettings();
            StringReader input = new StringReader(output.ToString());
            using (XmlReader reader = XmlReader.Create(input, settings2))
            {
                //deserialize the configuration section
                configSection2.ReadXml(reader);

                Assert.AreEqual(configSection2.Value, configSection.Value);
            }
        }
    }
}
