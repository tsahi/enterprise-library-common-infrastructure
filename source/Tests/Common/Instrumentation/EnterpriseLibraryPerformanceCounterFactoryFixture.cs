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

using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation.Tests
{
    [TestClass]
    public class EnterpriseLibraryPerformanceCounterFactoryFixture
    {
        static readonly string categoryName = EnterpriseLibraryPerformanceCounterFixture.counterCategoryName;
        static readonly string counterName = EnterpriseLibraryPerformanceCounterFixture.counterName;
        static readonly string differentCounterName = "SecondTestCounter";

        EnterpriseLibraryPerformanceCounterFactory factory;

        [TestInitialize]
        public void SetUp()
        {
            factory = new EnterpriseLibraryPerformanceCounterFactory();

            try
            {
                factory.CreateCounter(categoryName, counterName, new string[] { "Total" });
            }
            catch (InvalidOperationException)
            {
                Assert.Inconclusive("In order to run the test, please run RegAssemblies.bat script first as an Administrator.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CrearingPerformanceCounterThroughFactoryWithNullInstanceNamesThrowsArgumentNullException()
        {
            EnterpriseLibraryPerformanceCounter counter = factory.CreateCounter(categoryName, counterName, (string[])null);
        }

        [TestMethod]
        public void WillCreateEnterpriseLibraryCounterWithSingleEmbeddedCounterWhenGivenSingleInstanceName()
        {
            EnterpriseLibraryPerformanceCounter counter = factory.CreateCounter(categoryName, counterName, new string[] { "foo" });
            PerformanceCounter[] counters = counter.Counters;

            Assert.AreEqual(1, counters.Length);
            Assert.AreEqual("foo", counters[0].InstanceName);
            Assert.AreEqual(counterName, counters[0].CounterName);
        }

        [TestMethod]
        public void WillCreateELCounterWithTwoEmbeddedCountersWhenGivenTwoInstanceNames()
        {
            EnterpriseLibraryPerformanceCounter counter = factory.CreateCounter(categoryName, counterName, new string[] { "foo", "bar" });
            PerformanceCounter[] counters = counter.Counters;

            Assert.AreEqual(2, counters.Length);
            Assert.AreEqual(counterName, counters[0].CounterName);
            Assert.AreEqual("foo", counters[0].InstanceName);
            Assert.AreEqual("bar", counters[1].InstanceName);
        }

        [TestMethod]
        public void WillEmbedSameNamedCounterInMultipleInstancesOfELCounter()
        {
            EnterpriseLibraryPerformanceCounter first = factory.CreateCounter(categoryName, counterName, new string[] { "foo" });
            EnterpriseLibraryPerformanceCounter second = factory.CreateCounter(categoryName, counterName, new string[] { "foo" });

            Assert.AreSame(first.Counters[0], second.Counters[0]);
        }

        [TestMethod]
        public void CounterCreatedThroughFactoryCanBeIncremented()
        {
            EnterpriseLibraryPerformanceCounter counter = factory.CreateCounter(categoryName, counterName, new string[] { "foo", "bar" });
            counter.Clear();
            counter.Increment();

            Assert.AreEqual(1L, counter.Counters[0].RawValue);
            Assert.AreEqual(1L, counter.Counters[1].RawValue);
        }

        [TestMethod]
        public void CreatingTwoDifferentCountersWithSameInstanceNameResultsInTwoSeparateCountersBeingCreated()
        {
            EnterpriseLibraryPerformanceCounter first = factory.CreateCounter(categoryName, counterName, new string[] { "foo" });
            EnterpriseLibraryPerformanceCounter second = factory.CreateCounter(categoryName, differentCounterName, new string[] { "foo" });

            Assert.IsFalse(ReferenceEquals(first.Counters[0], second.Counters[0]));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CrearingPerformanceCounterWithNullInstanceNamesThrowsArgumentNullException()
        {
            new EnterpriseLibraryPerformanceCounter(categoryName, counterName, (string[])null);
        }

    }
}
