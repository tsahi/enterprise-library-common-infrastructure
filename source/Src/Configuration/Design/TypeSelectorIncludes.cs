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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// Provides attributes for the filter of types.
    /// </summary>
    [Flags]
    public enum TypeSelectorIncludes
    {
        /// <summary>
        /// No filter are applied to types.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Inclue abstract types in the filter.
        /// </summary>
        AbstractTypes = 0x01,
        /// <summary>
        /// Inclue interfaces in the filter.
        /// </summary>
        Interfaces = 0x02,
        /// <summary>
        /// Inclue base types in the filter.
        /// </summary>
        BaseType = 0x04,
        /// <summary>
        /// Inclue non public types in the filter.
        /// </summary>
        NonpublicTypes = 0x08,
        /// <summary>
        /// Include all types in the filter.
        /// </summary>
        All = 0x0F
    }
}
