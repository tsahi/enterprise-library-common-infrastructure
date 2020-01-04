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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Constructs an instance name for a <see cref="PerformanceCounter"></see> following embedded
    /// formatting rules.
    /// </summary>
    public class PerformanceCounterInstanceName
    {
        const int MaxPrefixLength = 32;
        const int MaxSuffixLength = 32;

        readonly string prefix;
        readonly string suffix;

        /// <overloads>
        /// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
        /// instance name.
        /// </overloads>
        /// <summary>
        /// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
        /// instance name.
        /// </summary>
        /// <param name="prefix">Counter name prefix.</param>
        /// <param name="suffix">Counter name suffix.</param>
        public PerformanceCounterInstanceName(string prefix,
                                              string suffix)
            : this(prefix, suffix, MaxPrefixLength, MaxSuffixLength) {}

        /// <overloads>
        /// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
        /// instance name.
        /// </overloads>
        /// <summary>
        /// Initializes this object with information needed to construct a <see cref="PerformanceCounter"></see>\
        /// instance name.
        /// </summary>
        /// <param name="prefix">Counter name prefix.</param>
        /// <param name="suffix">Counter name suffix.</param>
        /// <param name="maxPrefixLength">Max prefix length.</param>
        /// <param name="maxSuffixLength">Max suffix length.</param>
        public PerformanceCounterInstanceName(string prefix,
                                              string suffix,
                                              int maxPrefixLength,
                                              int maxSuffixLength)
        {
            this.prefix = NormalizeStringLength(prefix, maxPrefixLength);
            this.suffix = NormalizeStringLength(suffix, maxSuffixLength);
        }

        static string NormalizeStringLength(string namePart,
                                            int namePartMaxLength)
        {
            return (namePart.Length > namePartMaxLength) ? namePart.Substring(0, namePartMaxLength) : namePart;
        }

        /// <summary>
        /// Returns properly formatted counter name as a string.
        /// </summary>
        /// <returns>Formatted counter name.</returns>
        public override string ToString()
        {
            string namePrefix = "";
            if (prefix.Length > 0) namePrefix += (prefix + " - ");
            return namePrefix + suffix;
        }
    }
}
