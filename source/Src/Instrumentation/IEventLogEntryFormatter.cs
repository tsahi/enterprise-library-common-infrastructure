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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Formats an event log entry for logging to event log.
    /// </summary>
    public interface IEventLogEntryFormatter
    {
        /// <overloads>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </overloads>
        /// <summary>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </summary>
        /// <param name="message">Message to be formatted, with format tags embedded.</param>
        /// <param name="extraInformation">Extra strings to be matched up with the format tags provided in <paramref name="message"></paramref>.</param>
        /// <returns>Formatted message, suitable for logging to the event log.</returns>
        string GetEntryText(string message, params string[] extraInformation);

        /// <summary>
        /// Creates a formatted message, suitable for logging to the event log.
        /// </summary>
        /// <param name="message">Message to be formatted, with format tags embedded.</param>
        /// <param name="exception">Exception containing message text to be added to event log message produced by this method</param>
        /// <param name="extraInformation">Extra strings to be matched up with the format tags provided in <paramref name="message"></paramref>.</param>
        /// <returns>Formatted message, suitable for logging to the event log.</returns>
        string GetEntryText(string message, Exception exception, params string[] extraInformation);
    }
}
