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

using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.ContextBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    public abstract class Given_EmptyConfigurationSourceBuilder : ArrangeActAssert
    {
        protected IConfigurationSourceBuilder ConfigurationSourceBuilder;

        protected override void Arrange()
        {
            ConfigurationSourceBuilder = new ConfigurationSourceBuilder();
        }

        protected IConfigurationSource GetConfigurationSource()
        {
            var configSource = new DictionaryConfigurationSource();
            ConfigurationSourceBuilder.UpdateConfigurationWithReplace(configSource);
            return configSource;
        }
    }


    [TestClass]
    public class When_AccessingConfigurationSourceBuilderMembers : ArrangeActAssert
    {
        [TestMethod]
        public void Then_ObjectMembersAreHiddenFromIntellisense()
        {
            Assert.IsTrue(typeof(IFluentInterface).IsAssignableFrom(typeof(IConfigurationSourceBuilder)));
        }
    }


    [TestClass]
    public class When_GettingConfigurationSoruceSettingsToConfigurationSourceBuilder : Given_EmptyConfigurationSourceBuilder
    {
        protected override void Arrange()
        {
            base.Arrange();

            ConfigurationSourceBuilder = new ConfigurationSourceBuilder();
        }

        [TestMethod]
        public void Then_ConfigurationSourceContainsNoInstrumentationSection()
        {
            var configurationSource = GetConfigurationSource();
            var instrumentationSettings = (ConfigurationSourceSection)configurationSource.GetSection(ConfigurationSourceSection.SectionName);

            Assert.IsNull(instrumentationSettings);
        }
    }

    [TestClass]
    public class When_AddingSectionsToSourceBuilder : Given_EmptyConfigurationSourceBuilder
    {
        private ConfigurationSourceSection section;

        protected override void Act()
        {
            section = new ConfigurationSourceSection();
            base.ConfigurationSourceBuilder.AddSection(ConfigurationSourceSection.SectionName,
                                                       section);
        }

        [TestMethod]
        public void Then_CanRetrieveAddedSection()
        {
            Assert.AreSame(section, ConfigurationSourceBuilder.Get(ConfigurationSourceSection.SectionName));
        }

        [TestMethod]
        public void Then_ReturnsNullIfCannotFind()
        {
            Assert.IsNull(ConfigurationSourceBuilder.Get("unknown section name"));
        }

        [TestMethod]
        public void Then_ReturnsNullIfCannotFindViaGeneric()
        {
            Assert.IsNull(ConfigurationSourceBuilder.Get<ConfigurationSourceSection>("unknown section name"));
        }
    }
}
