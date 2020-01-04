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
    /// This class does no formatting, returning the provided name suffix as the counter name.
    /// </summary>
    public class NoPrefixNameFormatter : IPerformanceCounterNameFormatter
    {
        /// <summary>
        /// Returns the given <paramref name="nameSuffix"></paramref> as the created name.
        /// </summary>
        /// <param name="nameSuffix">Performance counter name, as defined during installation of the counter</param>
        /// <returns>Formatted instance name in form of "<paramref name="nameSuffix"/>"</returns>
        public string CreateName(string nameSuffix)
        {
            return new PerformanceCounterInstanceName("", nameSuffix).ToString();
        }
    }
}
