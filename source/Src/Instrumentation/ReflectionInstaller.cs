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
using System.Collections;
using System.Configuration.Install;
using System.Reflection;
using System.Security;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Instrumentation
{
    /// <summary>
    /// Generic installer wrapper around installer builder. Used to find and install 
    /// given type of installable resource.
    /// </summary>
    /// <typeparam name="TInstallerBuilder">Specific type of installer builder to instantiate</typeparam>
    [SecurityCritical]
    public class ReflectionInstaller<TInstallerBuilder> : Installer
        where TInstallerBuilder : AbstractInstallerBuilder
    {
        /// <summary>
        /// Installs the instrumentation resources
        /// </summary>
        /// <param name="stateSaver">An <see cref="IDictionary"/> used to save information needed to perform a commit, rollback, or uninstall operation.</param>
        [SecurityCritical]
        public override void Install(IDictionary stateSaver)
        {
            PrepareInstaller();
            base.Install(stateSaver);
        }

        /// <summary>
        /// Uninstalls the instrumentation resources
        /// </summary>
        /// <param name="stateSaver">An <see cref="IDictionary"/> that contains the state of the computer after the installation was complete.</param>
        [SecurityCritical]
        public override void Uninstall(IDictionary stateSaver)
        {
            PrepareInstaller();
            base.Uninstall(stateSaver);
        }

        private void PrepareInstaller()
        {
            string assemblyName = this.Context.Parameters["assemblypath"];
            Type[] types = Assembly.LoadFile(assemblyName).GetTypes();

            TInstallerBuilder builder = (TInstallerBuilder)Activator.CreateInstance(typeof(TInstallerBuilder), new object[] { types });

            builder.Fill(this);
        }
    }
}
