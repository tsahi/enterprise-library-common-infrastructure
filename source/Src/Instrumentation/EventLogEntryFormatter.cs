﻿/*
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
using System.Globalization;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Formats an event log entry to the defined format.
    /// </summary>
    public class EventLogEntryFormatter : IEventLogEntryFormatter
    {
        private string applicationName;
        private string blockName;

        private static readonly string[] emptyExtraInformation = new string[0];

        /// <overloads>
        /// Initializes this object with the specified information.
        /// </overloads>
        /// <summary>
        /// Initializes this object with the name of the specific block using this class.
        /// </summary>
        /// <param name="blockName">Name of block using this functionality.</param>
        public EventLogEntryFormatter(string blockName)
            : this(GetApplicationName(), blockName)
        {
        }

        /// <summary>
        /// Initializes this object    with the given application and block names.
        /// </summary>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="blockName">Name of the block using this functionality.</param>
        public EventLogEntryFormatter(string applicationName, string blockName)
        {
            this.applicationName = applicationName;
            this.blockName = blockName;
        }

        /// <overloads>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </overloads>
        /// <summary>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </summary>
        /// <param name="message">Message to be formatted, with format tags embedded.</param>
        /// <param name="extraInformation">Extra strings to be matched up with the format tags provided in <paramref name="message"></paramref>.</param>
        /// <returns>Formatted message, suitable for logging to the event log.</returns>
        public string GetEntryText(string message, params string[] extraInformation)
        {
            return BuildEntryText(message, null, extraInformation);
        }

        /// <summary>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </summary>
        /// <param name="message">Message to be formatted, with format tags embedded.</param>
        /// <param name="exception">Exception containing message text to be added to event log message produced by this method</param>
        /// <param name="extraInformation">Extra strings to be matched up with the format tags provided in <paramref name="message"></paramref>.</param>
        /// <returns>Formatted message, suitable for logging to the event log.</returns>
        public string GetEntryText(string message, Exception exception, params string[] extraInformation)
        {
            return BuildEntryText(message, exception, extraInformation);
        }

        private string BuildEntryText(string message, Exception exception, string[] extraInformation)
        {
            // add header
            StringBuilder entryTextBuilder
                = new StringBuilder(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        Resources.EventLogEntryHeaderTemplate,
                        applicationName,
                        blockName));
            entryTextBuilder.AppendLine();

            // add message
            entryTextBuilder.AppendLine(message);

            //add extra info
            for (int i = 0; i < extraInformation.Length; i++)
            {
                entryTextBuilder.AppendLine(extraInformation[i]);
            }

            // add exception
            if (exception != null)
            {
                entryTextBuilder.AppendLine(
                   string.Format(
                       CultureInfo.CurrentCulture,
                       Resources.EventLogEntryExceptionTemplate,
                       exception.ToString()));
            }

            return entryTextBuilder.ToString();
        }

        private static string GetApplicationName()
        {
            return AppDomain.CurrentDomain.FriendlyName;
        }

        private string EntryTemplate
        {
            get
            {
                return "";
            }
        }
    }
}
