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
using System.Configuration;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Provides validation for a <see cref="TimeSpan"/> object allowing non-negative spans and 
    /// the value for <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </summary>
    public class NonNegativeOrInfiniteTimeSpanValidator : TimeSpanValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NonNegativeOrInfiniteTimeSpanValidator"/> class.
        /// </summary>
        public NonNegativeOrInfiniteTimeSpanValidator()
            : base(TimeSpan.Zero, TimeSpan.MaxValue)
        {
        }

        /// <summary>
        /// Determines whether the value of an object is valid.
        /// </summary>
        /// <param name="value">The value of an object.</param>
        public override void Validate(object value)
        {
            if (!(value is TimeSpan && ((TimeSpan)value) == Timeout.InfiniteTimeSpan))
            {
                base.Validate(value);
            }
        }
    }
}
