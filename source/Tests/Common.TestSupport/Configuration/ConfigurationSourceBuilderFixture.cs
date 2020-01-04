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

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Configuration
{

    public abstract class Given_AConfigurationSourceBuilder : ArrangeActAssert
    {
        public IConfigurationSourceBuilder Builder { get; private set; }

        protected override void Arrange()
        {
            base.Arrange();
            Builder = new ConfigurationSourceBuilder();
        }
    }

    //// TODO replace with other section from common
    //[TestClass]
    //public class When_GivenAnEmptyConfigurationSource : Given_AConfigurationSourceBuilder
    //{
    //    private IConfigurationSource mergedConfiguration;

    //    protected override void Arrange()
    //    {
    //        base.Arrange();

    //        Builder
    //            .ConfigureInstrumentation()
    //                .EnableLogging();

    //    }

    //    protected override void Act()
    //    {
    //        mergedConfiguration = new DictionaryConfigurationSource();
    //        Builder.UpdateConfigurationWithReplace(mergedConfiguration);
    //    }

    //    [TestMethod]
    //    public void Then_MergingConfigurationSourceMovesSections()
    //    {
    //        Assert.IsNotNull(mergedConfiguration.GetSection(InstrumentationConfigurationSection.SectionName));
    //    }
    //}

    //[TestClass]
    //public class When_GivenAPopulatedConfigurationSection : Given_AConfigurationSourceBuilder
    //{
    //    private IConfigurationSource mergedConfiguration;
    //    protected override void Arrange()
    //    {
    //        base.Arrange();

    //        mergedConfiguration = new DictionaryConfigurationSource();
    //        mergedConfiguration.Add(
    //                       InstrumentationConfigurationSection.SectionName,
    //                       new InstrumentationConfigurationSection(false, true));

    //        Builder
    //            .ConfigureInstrumentation()
    //                .EnablePerformanceCounters();
    //    }

    //    protected override void Act()
    //    {
    //        mergedConfiguration = new DictionaryConfigurationSource();
    //        Builder.UpdateConfigurationWithReplace(mergedConfiguration);
    //    }

    //    [TestMethod]
    //    public void Then_MergingConfigurationSourceMovesSections()
    //    {
    //        var section = (InstrumentationConfigurationSection)mergedConfiguration
    //                                                                .GetSection(InstrumentationConfigurationSection.SectionName);

    //        Assert.IsFalse(section.EventLoggingEnabled);
    //        Assert.IsTrue(section.PerformanceCountersEnabled);
    //    }
    //}
}
