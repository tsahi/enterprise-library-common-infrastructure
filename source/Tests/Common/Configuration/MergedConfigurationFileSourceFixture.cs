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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.ContextBase;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration
{
    public abstract class Given_ConfigurationFileWithParentSource : ArrangeActAssert
    {
        protected string FileSourceDummySectionName = "externaldummy.filesource";
        protected IConfigurationSource MergedSource;

        protected override void Arrange()
        {
            MergedSource = new FileConfigurationSource(@"MergedConfigurationFile.config");
        }
    }

    [TestClass]
    public class When_CallingGetSection : Given_ConfigurationFileWithParentSource
    {
        DummySection section;

        protected override void Act()
        {
            section = (DummySection)MergedSource.GetSection(FileSourceDummySectionName);
        }

        [TestMethod]
        public void Then_LocalSourceReturnsValueFromParentSource()
        {
            Assert.AreEqual(11, section.Value);
        }
    }

}
