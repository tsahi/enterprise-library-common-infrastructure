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
using System.Management;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport.Instrumentation
{
    public class WmiEventWatcher : IDisposable
    {
        readonly object eventsCollectionLock = new object();
        readonly List<ManagementBaseObject> eventsReceived = new List<ManagementBaseObject>();
        readonly ManagementEventWatcher eventWatcher;
        readonly int numberOfEventsToWatchFor;

        public WmiEventWatcher(int numberOfEventsToWatchFor)
            : this(numberOfEventsToWatchFor, "BaseWmiEvent") {}

        public WmiEventWatcher(int numberOfEventsToWatchFor,
                               string query)
        {
            this.numberOfEventsToWatchFor = numberOfEventsToWatchFor;

            WqlEventQuery eventQuery = new WqlEventQuery(query);
            ManagementScope scope = new ManagementScope(@"\\.\root\EnterpriseLibrary");

            eventWatcher = new ManagementEventWatcher(scope, eventQuery);
            eventWatcher.EventArrived += delegate_EventArrived;

            eventWatcher.Start();
        }

        public List<ManagementBaseObject> EventsReceived
        {
            get { return eventsReceived; }
        }

        public void delegate_EventArrived(object sender,
                                          EventArrivedEventArgs e)
        {
            lock (eventsCollectionLock)
            {
                eventsReceived.Add(e.NewEvent);
            }
        }

        public void Dispose()
        {
            eventWatcher.Stop();
            eventWatcher.Dispose();
        }

        public void WaitForEvents()
        {
            for (int i = 0; i < numberOfEventsToWatchFor * 2; i++)
            {
                Thread.Sleep(100);
                lock (eventsCollectionLock)
                {
                    if (eventsReceived.Count == numberOfEventsToWatchFor) break;
                }
            }
        }
    }
}
