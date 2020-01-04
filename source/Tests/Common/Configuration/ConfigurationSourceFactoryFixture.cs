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
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    [TestClass]
    public class ConfigurationSourceFactoryFixture
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AppDomain.CurrentDomain.SetData("APPBASE", Environment.CurrentDirectory);
        }

        [TestMethod]
        public void CanCreateAConfigurationSourceThatExistsInConfig()
        {
            using (var source = ConfigurationSourceFactory.Create("fileSource"))
            {
                Assert.AreEqual(typeof(FileConfigurationSource), source.GetType());
            }
        }

        [TestMethod]
        public void DefaultConfigurationSourceIsSystemSource()
        {
            using (var defaultSource = ConfigurationSourceFactory.Create())
            {
                Assert.AreEqual(typeof(SystemConfigurationSource), defaultSource.GetType());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RequestForNullNameThrows()
        {
            ConfigurationSourceFactory.Create(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void RequestForNonExistentNameThrows()
        {
            ConfigurationSourceFactory.Create("invalid");
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationErrorsException))]
        public void RequestForNameWithoutSectionThrows()
        {
            System.Configuration.Configuration configuration = ConfigurationTestHelper.GetConfigurationForCustomFile("test.exe.config");
            configuration.Sections.Remove(ConfigurationSourceSection.SectionName);
            configuration.Save();

            AppDomainSetup setupInfo = new AppDomainSetup();
            setupInfo.ConfigurationFile = configuration.FilePath;
            setupInfo.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            AppDomain newDomain = AppDomain.CreateDomain("test", null, setupInfo);

            try
            {
                ConfigurationSourceFactoryFixtureHelper helper =
                    (ConfigurationSourceFactoryFixtureHelper)newDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, typeof(ConfigurationSourceFactoryFixtureHelper).FullName);

                helper.RequestForNameWithoutSectionThrows();
            }
            finally
            {
                AppDomain.Unload(newDomain);
            }
        }
    }

    public class ConfigurationSourceFactoryFixtureHelper : MarshalByRefObject
    {
        public void RequestForNameWithoutSectionThrows()
        {
            ConfigurationSourceFactory.Create("name");
        }
    }
}
