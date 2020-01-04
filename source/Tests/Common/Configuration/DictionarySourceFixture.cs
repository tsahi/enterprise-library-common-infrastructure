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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    [TestClass]
    public class DictionarySourceFixture
    {
        [TestMethod]
        public void CanRetrieveSectionFromSource()
        {
            DictionaryConfigurationSource source = LocalConfigurationSource.Create();

            Assert.IsTrue(source.Contains("test"));
            Assert.AreEqual(source.GetSection("test").GetType(), typeof(LocalConfigurationSection));
            source.Remove("test");
            Assert.IsNull(source.GetSection("random"));
        }

        class LocalConfigurationSection : SerializableConfigurationSection {}

        static class LocalConfigurationSource
        {
            public static DictionaryConfigurationSource Create()
            {
                DictionaryConfigurationSource source = new DictionaryConfigurationSource();
                source.Add("test", new LocalConfigurationSection());
                return source;
            }
        }
    }
}
