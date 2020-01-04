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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// A set of string constants listing the names of the configuration
    /// sections used by the standard set of Entlib blocks.
    /// </summary>
    public static class BlockSectionNames
    {
        /// <summary>
        /// Data Access Application Block custom settings
        /// </summary>
        public const string Data = "dataConfiguration";

        /// <summary>
        /// Logging Application Block section name
        /// </summary>
        public const string Logging = "loggingConfiguration";

        /// <summary>
        /// Exception Handling Application Block section name
        /// </summary>
        public const string ExceptionHandling = "exceptionHandling";

        /// <summary>
        /// Policy injection section name
        /// </summary>
        public const string PolicyInjection = "policyInjection";

        ///<summary>
        /// Validation section name
        ///</summary>
        public const string Validation = "validation";
    }
}
