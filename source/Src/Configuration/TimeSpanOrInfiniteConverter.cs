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
using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Converts a <see cref="TimeSpan"/> expressed in as formatted string or as a standard infinite timeout.
    /// </summary>
    public class TimeSpanOrInfiniteConverter : TimeSpanConverter
    {
        /// <summary>
        /// The string representation of an infinite timeout.
        /// </summary>
        public const string Infinite = "infinite";

        /// <summary>
        /// Converts the given object to a <see cref="T:System.TimeSpan" />.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">An optional <see cref="T:System.Globalization.CultureInfo" />. If not supplied, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that represents the converted value.
        /// </returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var text = value as string;

            if (text != null && string.Equals(text, Infinite, StringComparison.OrdinalIgnoreCase))
            {
                return Timeout.InfiniteTimeSpan;
            }

            return base.ConvertFrom(context, culture, value);
        }

        /// <summary>
        /// Converts the given object to another type.
        /// </summary>
        /// <param name="context">A formatter context.</param>
        /// <param name="culture">The culture into which <paramref name="value" /> will be converted.</param>
        /// <param name="value">The object to convert.</param>
        /// <param name="destinationType">The type to convert the object to.</param>
        /// <returns>
        /// The converted object.
        /// </returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (((TimeSpan)value) == Timeout.InfiniteTimeSpan)
                {
                    return Infinite;
                }
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
