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

using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Declaratively instructs the .NET Framework to perform time validation on a configuration property. This class cannot be inherited.
    /// </summary>
    public sealed class NonNegativeOrInfiniteTimeSpanValidatorAttribute : ConfigurationValidatorAttribute
    {
        /// <summary>
        /// Gets the validator attribute instance.
        /// </summary>
        /// <returns>The current <see cref="NonNegativeOrInfiniteTimeSpanValidator" />.</returns>
        public override ConfigurationValidatorBase ValidatorInstance
        {
            get
            {
                return new NonNegativeOrInfiniteTimeSpanValidator();
            }
        }
    }
}
