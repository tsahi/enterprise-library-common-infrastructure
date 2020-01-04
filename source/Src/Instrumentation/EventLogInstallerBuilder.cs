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
using System.Configuration.Install;
using System.Diagnostics;
using System.Security;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Add event log source definitions for classes that have been attributed
    /// with HasInstallableResourceAttribute and EventLogDefinition attributes to EventLogInstallers.
    /// One installer is created for each unique event log source that is found.
    /// </summary>
    [SecurityCritical]
    public class EventLogInstallerBuilder : AbstractInstallerBuilder
    {
        /// <summary>
        /// Initializes this object with a list of types that may potentially be attributed appropriately.
        /// </summary>
        /// <param name="potentialTypes">Array of types to inspect check for event log sources needing installation</param>
        public EventLogInstallerBuilder(Type[] potentialTypes)
            : base(potentialTypes, typeof(EventLogDefinitionAttribute))
        {
        }

        /// <summary>
        /// Creates <see cref="EventLogInstaller"></see> instances for each separate event log source needing installation.
        /// </summary>
        /// <param name="instrumentedTypes">Collection of <see cref="Type"></see>s that represent types defining
        /// event log sources to be installed.</param>
        /// <returns>Collection of installers containing event log sources to be installed.</returns>
        [SecurityCritical]
        protected override ICollection<Installer> CreateInstallers(ICollection<Type> instrumentedTypes)
        {
            IList<Installer> installers = new List<Installer>();

            foreach (Type instrumentedType in instrumentedTypes)
            {
                EventLogDefinitionAttribute attribute
                    = (EventLogDefinitionAttribute)instrumentedType.GetCustomAttributes(typeof(EventLogDefinitionAttribute), false)[0];

                EventLogInstaller installer = new EventLogInstaller();
                installer.Log = attribute.LogName;
                installer.Source = attribute.SourceName;
                installer.CategoryCount = attribute.CategoryCount;
                if (attribute.CategoryResourceFile != null) installer.CategoryResourceFile = attribute.CategoryResourceFile;
                if (attribute.MessageResourceFile != null) installer.MessageResourceFile = attribute.MessageResourceFile;
                if (attribute.ParameterResourceFile != null) installer.ParameterResourceFile = attribute.ParameterResourceFile;

                installers.Add(installer);
            }

            return installers;
        }
    }
}
