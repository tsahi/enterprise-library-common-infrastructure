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
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using System.Globalization;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents a collection of <see cref="NameTypeConfigurationElement"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="NameTypeConfigurationElement"/> object this collection contains.</typeparam>
    /// <typeparam name="TCustomElementData">The type used for Custom configuration elements in this collection.</typeparam>
    public class NameTypeConfigurationElementCollection<T, TCustomElementData> : PolymorphicConfigurationElementCollection<T>
        where T : NameTypeConfigurationElement, new()
        where TCustomElementData : T, new()
    {
        private const string typeAttribute = "type";

        /// <summary>
        /// Get the configuration object for each <see cref="NameTypeConfigurationElement"/> object in the collection.
        /// </summary>
        /// <param name="reader">The <see cref="XmlReader"/> that is deserializing the element.</param>
        protected override Type RetrieveConfigurationElementType(XmlReader reader)
        {
            Type configurationElementType = null;
            if (reader.AttributeCount > 0)
            {
                // expect the first attribute to be the name
                for (bool go = reader.MoveToFirstAttribute(); go; go = reader.MoveToNextAttribute())
                {
                    if (typeAttribute.Equals(reader.Name))
                    {
                        Type providerType = Type.GetType(reader.Value, false);
                        if (providerType == null)
                        {
                            configurationElementType = typeof(TCustomElementData);
                            break;
                        }

                        Attribute attribute = Attribute.GetCustomAttribute(providerType, typeof(ConfigurationElementTypeAttribute));
                        if (attribute == null)
                        {
                            throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionNoConfigurationElementAttribute, providerType.Name));
                        }

                        configurationElementType = ((ConfigurationElementTypeAttribute)attribute).ConfigurationType;
                        break;
                    }
                }

                if (configurationElementType == null)
                {
                    throw new ConfigurationErrorsException(string.Format(CultureInfo.CurrentCulture, Resources.ExceptionNoTypeAttribute, reader.Name));
                }

                // cover the traces ;)
                reader.MoveToElement();
            }
            return configurationElementType;
        }
    }
}
