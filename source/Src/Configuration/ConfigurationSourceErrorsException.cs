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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;
using System.Runtime.Serialization;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Exception class for exceptions that occur when reading configuration metadata from a <see cref="ConfigurationSourceSection"/>.
    /// </summary>
    /// <seealso cref="ConfigurationSourceSection"/>
    [Serializable]
    public class ConfigurationSourceErrorsException : ConfigurationErrorsException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceErrorsException"/> class.
        /// </summary>
        public ConfigurationSourceErrorsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceErrorsException"/> class.
        /// </summary>
        /// <param name="message">A message that describes why this <see cref="ConfigurationSourceErrorsException"/> exception was thrown.</param>
        public ConfigurationSourceErrorsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceErrorsException"/> class.
        /// </summary>
        /// <param name="message">A message that describes why this <see cref="ConfigurationSourceErrorsException"/> exception was thrown.</param>
        /// <param name="innerException">The inner exception that caused this <see cref="ConfigurationSourceErrorsException"/> exception to be thrown.</param>
        public ConfigurationSourceErrorsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceErrorsException"/> class.
        /// </summary>
        /// <param name="message">A message that describes why this <see cref="ConfigurationSourceErrorsException"/> exception was thrown.</param>
        /// <param name="innerException">The inner exception that caused this <see cref="ConfigurationSourceErrorsException"/> exception to be thrown.</param>
        /// <param name="filename">The path to the configuration file that caused this <see cref="ConfigurationSourceErrorsException"/> exception to be thrown.</param>
        /// <param name="line">The line number within the configuration file at which this <see cref="ConfigurationSourceErrorsException"/> exception was thrown.</param>
        public ConfigurationSourceErrorsException(string message, Exception innerException, string filename, int line)
            :base(message, innerException, filename, line)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceErrorsException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the information to be serialized.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected ConfigurationSourceErrorsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
