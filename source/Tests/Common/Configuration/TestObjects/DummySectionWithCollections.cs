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
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects
{
    public class DummySectionWithCollections : DummySection
    {
        private const string leafElementProperty = "leaf";
        private const string elementCollectionProperty = "collection";
        private const string polymorphicCollectionProperty = "polymorphicCollection";
        private const string connectionStringsProperty = "connectionStrings";
        private const string settingsProperty = "settings";

        [ConfigurationProperty(leafElementProperty)]
        public TestLeafConfigurationElement LeafElement
        {
            get { return (TestLeafConfigurationElement)base[leafElementProperty]; }
            set { base[leafElementProperty] = value; }
        }

        [ConfigurationProperty(elementCollectionProperty)]
        public MergeableElementCollection LeafElementCollection
        {
            get { return (MergeableElementCollection)base[elementCollectionProperty]; }
            set { base[elementCollectionProperty] = value; }
        }

        [ConfigurationProperty(polymorphicCollectionProperty)]
        public PolymorphicElementCollection PolymorphicCollection
        {
            get { return (PolymorphicElementCollection)base[polymorphicCollectionProperty]; }
            set { base[polymorphicCollectionProperty] = value; }
        }

        [ConfigurationProperty(connectionStringsProperty)]
        public ConnectionStringSettingsCollection ConnectionStringSettingsCollection
        {
            get { return (ConnectionStringSettingsCollection)base[connectionStringsProperty]; }
            set { base[connectionStringsProperty] = value; }
        }

        [ConfigurationProperty(settingsProperty)]
        public KeyValueConfigurationCollection AppSettingsLikeCollection
        {
            get { return (KeyValueConfigurationCollection)base[settingsProperty]; }
            set { base[settingsProperty] = value; }
        }

    }
}
