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
using Microsoft.Practices.EnterpriseLibrary.Common.Tests.Properties;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Utility
{
    [TestClass]
    public class StringResolverFixture
    {
        [TestMethod]
        public void CanGetValueFromConstantStringResolver()
        {
            string value = "test string";

            IStringResolver resolver = new ConstantStringResolver(value);

            Assert.AreEqual(value, resolver.GetString());
        }

        [TestMethod]
        public void CanGetValueFromDelegateStringResolver()
        {
            string value = "test string";

            IStringResolver resolver = new DelegateStringResolver(() => value);

            Assert.AreEqual(value, resolver.GetString());
        }

        [TestMethod]
        public void ResourceStringResolverUsesTypeAndNameIfBothAreAvailable()
        {
            Type resourceType = typeof(Resources);
            string resourceName = "CategoryHelp";
            string fallbackValue = "fallback";

            IStringResolver resolver = new ResourceStringResolver(resourceType, resourceName, fallbackValue);

            Assert.AreEqual(Resources.CategoryHelp, resolver.GetString());
        }

        [TestMethod]
        public void ResourceStringResolverUsesFallbackValueIfTypeIsNull()
        {
            Type resourceType = null;
            string resourceName = "CategoryHelp";
            string fallbackValue = "fallback";

            IStringResolver resolver = new ResourceStringResolver(resourceType, resourceName, fallbackValue);

            Assert.AreEqual(fallbackValue, resolver.GetString());
        }

        [TestMethod]
        public void ResourceStringResolverUsesFallbackValueIfResourceNameIsNull()
        {
            Type resourceType = typeof(Resources);
            string resourceName = null;
            string fallbackValue = "fallback";

            IStringResolver resolver = new ResourceStringResolver(resourceType, resourceName, fallbackValue);

            Assert.AreEqual(fallbackValue, resolver.GetString());
        }

        [TestMethod]
        public void ResourceStringResolverUsesTypeNameAndNameIfBothAreAvailable()
        {
            string resourceTypeName = typeof(Resources).AssemblyQualifiedName;
            string resourceName = "CategoryHelp";
            string fallbackValue = "fallback";

            IStringResolver resolver = new ResourceStringResolver(resourceTypeName, resourceName, fallbackValue);

            Assert.AreEqual(Resources.CategoryHelp, resolver.GetString());
        }
    }
}
