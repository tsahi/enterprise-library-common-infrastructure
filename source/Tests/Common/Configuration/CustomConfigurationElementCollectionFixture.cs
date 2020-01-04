﻿/*
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

using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.ContextBase;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    [TestClass]
    public class CustomConfigurationElementCollectionFixture : ArrangeActAssert
    {
        string configurationFilePath;

        protected override void Arrange()
        {
            var resourceHelper = new ResourceHelper<CustomConfigurationElementCollectionFixture>();
            configurationFilePath = resourceHelper.DumpResourceFileToDisk("ConfigSourceWithInvalidType.config");
        }


        [TestMethod]
        public void ThenThrowsExceptionWhenTypeIsInvalid()
        {
            try
            {
                IConfigurationSource config = new FileConfigurationSource(configurationFilePath);
                var sources = config.GetSection("enterpriseLibrary.ConfigurationSource");
                Assert.Fail("Should have thrown");
            }
            catch (ConfigurationException ex)
            {
                Assert.IsTrue(ex.Message.Contains("The type 'Microsoft.Practices.EnterpriseLibrary.Common.Configuration.InvalidType, Microsoft.Practices.EnterpriseLibrary.Common' defined in the 'InvalidType' configuration source is invalid"));
            }
        }
    }
}
