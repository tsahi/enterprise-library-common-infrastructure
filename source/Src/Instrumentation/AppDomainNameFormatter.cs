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
using System.Text.RegularExpressions;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Provides the friendly name of the application domain as the prefix in formatting a 
    /// particular instance of a performance counter.
    /// </summary>
    public class AppDomainNameFormatter : IPerformanceCounterNameFormatter
    {
        private string applicationInstanceName;
        private const string InvalidCharacters = @"\()/#*";

        /// <summary>
        /// Creates an instance of the <see cref="AppDomainNameFormatter"/>
        /// </summary>
        public AppDomainNameFormatter()
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="AppDomainNameFormatter"/> with an Application Instance Name
        /// </summary>
        /// <param name="applicationInstanceName"></param>
        public AppDomainNameFormatter(string applicationInstanceName)
        {
            this.applicationInstanceName = applicationInstanceName;
        }

        /// <summary>
        /// Creates the formatted instance name for a performance counter, providing the Application
        /// Domain friendly name for the prefix for the instance.
        /// </summary>
        /// <param name="nameSuffix">Performance counter name, as defined during installation of the counter</param>
        /// <returns>Formatted instance name in form of "appDomainFriendlyName - nameSuffix"</returns>
        public string CreateName(string nameSuffix)
        {
            string replacePattern = "[\\\\()#/\\*]*";
            string appDomainFriendlyName = string.IsNullOrEmpty(this.applicationInstanceName) ? AppDomain.CurrentDomain.FriendlyName : this.applicationInstanceName;

            Regex filter = new Regex(replacePattern);
            appDomainFriendlyName = filter.Replace(appDomainFriendlyName, string.Empty);

            PerformanceCounterInstanceName instanceName = new PerformanceCounterInstanceName(appDomainFriendlyName, nameSuffix);
            return instanceName.ToString();
        }
    }
}
