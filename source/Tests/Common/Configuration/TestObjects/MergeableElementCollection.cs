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

using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects
{
    [ConfigurationCollection(typeof(TestLeafConfigurationElement))]
    public class MergeableElementCollection : ConfigurationElementCollection, IMergeableConfigurationElementCollection
    {
        public MergeableElementCollection()
        {
        }

        public MergeableElementCollection(IEnumerable<TestLeafConfigurationElement> elements)
        {
            foreach (var e in elements)
            {
                base.BaseAdd(e);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TestLeafConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TestLeafConfigurationElement)element).ID;
        }

        public void ResetCollection(IEnumerable<ConfigurationElement> configurationElements)
        {
            base.BaseClear();
            foreach (var element in configurationElements)
            {
                base.BaseAdd(element);
            }
        }


        ConfigurationElement IMergeableConfigurationElementCollection.CreateNewElement(Type configurationType)
        {
            return new TestLeafConfigurationElement();
        }
    }
}
