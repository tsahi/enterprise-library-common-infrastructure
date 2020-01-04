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
using System.Diagnostics;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Defines an event source to be installed by the reflection based installer system. Each field
    /// in this attribute is a placeholder for the same field as defined in the <see cref="EventLogInstaller"></see>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
    public sealed class EventLogDefinitionAttribute : Attribute
    {
        string logName;
        string sourceName;
        int categoryCount;
        string categoryResourceFile;
        string messageResourceFile;
        string parameterResourceFile;

        /// <summary>
        /// Gets the event log name.
        /// </summary>
        public string LogName
        {
            get { return logName; }
        }

        /// <summary>
        /// Gets the event source name.
        /// </summary>
        public string SourceName
        {
            get { return sourceName; }
        }

        /// <summary>
        /// Gets and sets the category count.
        /// </summary>
        public int CategoryCount
        {
            get { return categoryCount; }
            set { categoryCount = value; }
        }

        /// <summary>
        /// Gets the category resource file name.
        /// </summary>
        public string CategoryResourceFile
        {
            get { return categoryResourceFile; }
            set { categoryResourceFile = value; }
        }

        /// <summary>
        /// Gets and sets the message resource file name.
        /// </summary>
        public string MessageResourceFile
        {
            get { return messageResourceFile; }
            set { messageResourceFile = value; }
        }

        /// <summary>
        /// Gets and sets the parameter resource file name.
        /// </summary>
        public string ParameterResourceFile
        {
            get { return parameterResourceFile; }
            set { parameterResourceFile = value; }
        }

        /// <summary>
        /// Initializes this object with the event log name and source to be installed.
        /// </summary>
        /// <param name="logName">Event log name to which the source should be added.</param>
        /// <param name="sourceName">Event log source to be added.</param>
        public EventLogDefinitionAttribute(string logName, string sourceName)
        {
            this.logName = logName;
            this.sourceName = sourceName;
        }
    }
}
