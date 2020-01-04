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

using System.Reflection;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests
{
    [TestClass]
    public class StringTranslatorFixture
    {
        [TestMethod]
        public void ReturnsTranslatedStringForGivenResourceAndLabel()
        {
            StringTranslator translator = new StringTranslator();
            ResourceManager manager = new ResourceManager(
                "Microsoft.Practices.EnterpriseLibrary.Common.Tests.Properties.Resources",
                Assembly.GetExecutingAssembly());
            Assert.AreEqual("Foo Text", translator.Translate(manager, "FooLabel"));
        }

        [TestMethod]
        public void ReturnsNullIfLabelCannotBeFound()
        {
            StringTranslator translator = new StringTranslator();
            ResourceManager manager = new ResourceManager(
                "Microsoft.Practices.EnterpriseLibrary.Common.Tests.Properties.Resources",
                Assembly.GetExecutingAssembly());
            Assert.IsNull(translator.Translate(manager, "UnknownLabel"));
        }

        [TestMethod, ExpectedException(typeof(MissingManifestResourceException))]
        public void ExceptionThrownIfResourcesCannotBeFound()
        {
            StringTranslator translator = new StringTranslator();
            ResourceManager manager = new ResourceManager(
                "UnknownResources",
                Assembly.GetExecutingAssembly());
            Assert.IsNull(translator.Translate(manager, "UnknownLabel"));
        }
    }

    public class StringTranslator
    {
        public string Translate(ResourceManager manager,
                                string resourceLabel)
        {
            return manager.GetString(resourceLabel);
        }
    }
}
