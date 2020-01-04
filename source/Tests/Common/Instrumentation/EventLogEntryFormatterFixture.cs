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
    public class EventLogEntryFormatterFixture
    {
        const string applicationName = "Application.exe";
        const string blockName = "Test Block";
        const string exceptionMessage = "Exception message";
        const string errorMessage = "Error Message";
        const string extraInformation1 = "extra 1";
        const string extraInformation2 = "extra 2";

        [TestMethod]
        public void CanGetFormattedEntryWithMessage()
        {
            EventLogEntryFormatter formatter = new EventLogEntryFormatter(applicationName, blockName);

            string entryText = formatter.GetEntryText(errorMessage);

            Assert.IsNotNull(entryText);
            Assert.IsTrue(entryText.IndexOf(applicationName) > 0);
            Assert.IsTrue(entryText.IndexOf(blockName) > 0);
            Assert.IsTrue(entryText.IndexOf(errorMessage) > 0);
        }

        [TestMethod]
        public void CanGetFormattedEntryWithMessageAndExtraInformation()
        {
            EventLogEntryFormatter formatter = new EventLogEntryFormatter(applicationName, blockName);
            string[] extraInformation = new string[] { extraInformation1, extraInformation2 };

            string entryText = formatter.GetEntryText(errorMessage, extraInformation);

            Assert.IsNotNull(entryText);
            Assert.IsTrue(entryText.IndexOf(applicationName) > 0);
            Assert.IsTrue(entryText.IndexOf(blockName) > 0);
            Assert.IsTrue(entryText.IndexOf(errorMessage) > 0);
            Assert.IsTrue(entryText.IndexOf(extraInformation1) > 0);
            Assert.IsTrue(entryText.IndexOf(extraInformation2) > 0);
        }

        [TestMethod]
        public void CanGetFormattedEntryWithMessageAndExceptionAndExtraInformation()
        {
            EventLogEntryFormatter formatter = new EventLogEntryFormatter(applicationName, blockName);
            Exception ex = null;
            string[] extraInformation = new string[] { extraInformation1, extraInformation2 };

            try
            {
                throw new Exception(exceptionMessage);
            }
            catch (Exception e)
            {
                ex = e;
            }

            string entryText = formatter.GetEntryText(errorMessage, ex, extraInformation);

            Assert.IsNotNull(entryText);
            Assert.IsTrue(entryText.IndexOf(errorMessage) > 0);
            Assert.IsTrue(entryText.IndexOf(applicationName) > 0);
            Assert.IsTrue(entryText.IndexOf(blockName) > 0);
            Assert.IsTrue(entryText.IndexOf(exceptionMessage) > 0);
            Assert.IsTrue(entryText.IndexOf(extraInformation1) > 0);
            Assert.IsTrue(entryText.IndexOf(extraInformation2) > 0);
        }
    }
}
