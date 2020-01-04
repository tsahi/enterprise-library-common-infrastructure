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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Provides a pluggable way to format the name given to a particular instance of a performance counter.
    /// Each instance of a performance counter in Enterprise Library is given a name of the format
    /// "Name prefix - counter name"
    /// </summary>
    public interface IPerformanceCounterNameFormatter
    {
        /// <summary>
        /// Creates the formatted instance name for a performance counter, providing the prefix for the
        /// instance.
        /// </summary>
        /// <param name="nameSuffix">Performance counter name, as defined during installation of the counter</param>
        /// <returns>Formatted instance name in form of "prefix - nameSuffix"</returns>
        string CreateName(string nameSuffix);
    }
}
