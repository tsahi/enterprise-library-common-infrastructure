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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents a configuration section that can be serialized and deserialized to XML.
    /// </summary>
    public class SerializableConfigurationSection : ConfigurationSection, IXmlSerializable
    {
        private const string SourceProperty = "source";

        /// <summary>
        /// Returns the XML schema for the configuration section.
        /// </summary>
        /// <returns>A string with the XML schema, or <see langword="null"/> (<b>Nothing</b> 
        /// in Visual Basic) if there is no schema.</returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Updates the configuration section with the values from an <see cref="XmlReader"/>.
        /// </summary>
        /// <param name="reader">The <see cref="XmlReader"/> that reads the configuration source located at the element that describes the configuration section.</param>
        public void ReadXml(XmlReader reader)
        {
            if (reader == null) throw new ArgumentNullException("reader");

            reader.Read();
            DeserializeSection(reader);

        }

        /// <summary>
        /// Writes the configuration section values as an XML element to an <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> that writes to the configuration store.</param>
        public void WriteXml(XmlWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");

            String serialized = SerializeSection(this, "SerializableConfigurationSection", ConfigurationSaveMode.Full);
            writer.WriteRaw(serialized);
        }
    }
}
