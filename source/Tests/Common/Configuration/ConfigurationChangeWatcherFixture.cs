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
using System.Threading;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    [TestClass]
    public class ConfigurationChangeWatcherFixture
    {
        int notifications;

        [TestInitialize]
        public void SetUp()
        {
            notifications = 0;
        }

        [TestMethod]
        public void RunningWatcherKeepsOnlyOnePollingThread()
        {
            using (TestConfigurationChangeWatcher watcher = new TestConfigurationChangeWatcher(50))
            {
                try
                {
                    watcher.ConfigurationChanged += new ConfigurationChangedEventHandler(OnConfigurationChanged);

                    for (int i = 0; i < 20; i++)
                    {
                        watcher.StopWatching();
                        watcher.StartWatching();
                    }

                    // ramp up
                    Thread.Sleep(50);

                    watcher.DoNotification();

                    // wait for notification
                    Thread.Sleep(150);

                    Assert.AreEqual(1, notifications);
                }
                finally
                {
                    watcher.StopWatching();
                }
            }
        }

        void OnConfigurationChanged(object sender, ConfigurationChangedEventArgs e)
        {
            lock (this)
            {
                notifications++;
            }
        }
    }

    class TestConfigurationChangeWatcher : ConfigurationChangeWatcher
    {
        public TestConfigurationChangeWatcher(int pollDelay)
        {
            SetPollDelayInMilliseconds(pollDelay);
        }

        static bool notified;

        DateTime lastWriteTime = DateTime.Now;
        bool notify = false;

        public override string SectionName
        {
            get { return "section"; }
        }

        protected override ConfigurationChangedEventArgs BuildEventData()
        {
            return new ConfigurationChangedEventArgs(SectionName);
        }

        internal void DoNotification()
        {
            notify = true;
        }

        protected override DateTime GetCurrentLastWriteTime()
        {
            if (notify && !notified)
            {
                notified = true;
                lastWriteTime = DateTime.Now;
            }
            return lastWriteTime;
        }

        protected override string GetEventSourceName()
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
