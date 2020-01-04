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
using System.ComponentModel;
using System.Globalization;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents a configuration converter that converts a byte array to and from a string representation by using base64 encoding.
    /// </summary>
    public class ByteArrayTypeConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="sourceType">A <see cref="Type"/> that represents the type you want to convert from. </param>
        /// <returns><see langword="true"/> if this converter can perform the conversion; otherwise, <see langword="falase"/>. </returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType;
        }

        /// <summary>
        /// Converts the given value to the type of this converter.
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="culture">A <see cref="CultureInfo"/> object.</param>
        /// <param name="value">An <see cref="Object"/> that represents the converted value. </param>
        /// <returns>An <see cref="Object"/> that represents the converted value. </returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            return Convert.FromBase64String((string) value);
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="destinationType">A <see cref="Type"/> that represents the type you want to convert to..</param>
        /// <returns><b>true</b> if the converter can convert to the specified type, <b>false</b> otherwise.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return typeof(byte[]) == destinationType;
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the arguments. 
        /// </summary>
        /// <param name="context">An <see cref="ITypeDescriptorContext"/> object.</param>
        /// <param name="culture">A <see cref="CultureInfo"/> object.</param>
        /// <param name="value">The <see cref="Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="Type"/> to convert the value parameter to.</param>
        /// <returns>The converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return Convert.ToBase64String((byte[])value);
        }
    }
}
