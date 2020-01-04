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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation.Tests
{
    [TestClass]
    public class AppDomainNameFormatterFixture : MarshalByRefObject
    {
        [TestMethod]
        public void WillFormatNameWithAppDomainNamePrefix()
        {
            AppDomainNameFormatter nameFormatter = new AppDomainNameFormatter();

            string createdName = nameFormatter.CreateName("MyInstance");
            Assert.IsTrue(createdName.EndsWith(" - MyInstance"));
            Assert.IsTrue(createdName.Length <= 128);
        }

        [TestMethod]
        public void WillFormatNameUsingApplicationInstanceName()
        {
            string applicationInstanceName = "ApplicationInstanceName";
            string suffix = "MySuffix";
            string expectedInstanceName = string.Concat(applicationInstanceName, " - ", suffix);

            AppDomainNameFormatter formatter = new AppDomainNameFormatter(applicationInstanceName);

            string createdName = formatter.CreateName(suffix);
            Assert.AreEqual(expectedInstanceName, createdName);
        }

        /// <summary>
        /// Filter the invalid chars documented in http://msdn2.microsoft.com/en-us/library/aa373193.aspx
        /// </summary>
        [TestMethod]
        public void ShouldReplaceInvalidCharacters()
        {
            string invalidApplicationInstanceName = @"\\computer\object(parent/instance#index)\counter";
            string validApplicationIntanceName = "computerobjectparentinstanceindexcounter";

            //Normalize string length
            validApplicationIntanceName = validApplicationIntanceName.Substring(0, 32);

            string suffix = "MySuffix";
            string expectedInstanceName = string.Concat(validApplicationIntanceName, " - ", suffix);

            AppDomainNameFormatter formatter = new AppDomainNameFormatter(invalidApplicationInstanceName);

            string createdName = formatter.CreateName(suffix);
            Assert.AreEqual(expectedInstanceName, createdName);
        }
    }
}
