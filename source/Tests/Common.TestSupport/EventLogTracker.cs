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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport
{
    /// <summary>
    /// A helper class that encapsulates the gyrations needed to get new
    /// items out of an event log. It marks the current time and returns
    /// entries that have occurred since that time.
    /// </summary>
    public class EventLogTracker : IDisposable
    {
        private DateTime startTime;
        private EventLog eventLog;

        public EventLogTracker(string logName)
            : this(new EventLog(logName))
        {
        }
        
        public EventLogTracker(EventLog eventLog)
        {
            this.eventLog = eventLog;
            startTime = DateTime.Now;

            // Event log granularity is down to the second.
            // Wait one second to ensure any new log messages
            // have an actual newer timestamp.
            Thread.Sleep(1000);
        }

        public void Dispose()
        {
            if(eventLog != null)
            {
                eventLog.Dispose();
                eventLog = null;
            }
        }

        /// <summary>
        /// Return new event log entries created since this
        /// object was instantiated. Returns the newest entries
        /// first, proceeding backwards.
        /// </summary>
        /// <returns>The sequence of <see cref="EventLogEntry"/>
        /// objects that are newer than the time this object was
        /// created.</returns>
        public IEnumerable<EventLogEntry> NewEntries()
        {
            return eventLog.GetEntriesSince(startTime);
        }
    }
}
