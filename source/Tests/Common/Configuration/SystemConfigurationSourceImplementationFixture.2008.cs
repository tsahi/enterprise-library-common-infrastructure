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
using System.Configuration;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Tests
{
    /// <summary>
    /// Summary description for SystemConfigurationSourceFixture
    /// </summary>
    public partial class SystemConfigurationSourceFixture2
    {
        [TestMethod]
        public void CanGetExistingSectionInAppConfigEvenIfTheAppDomainDoesNotHaveFileIOPermission()
        {
            var evidence = new Evidence();
            evidence.AddHostEvidence(new Zone(SecurityZone.Internet));
            var set = SecurityManager.GetStandardSandbox(evidence);
            set.AddPermission(new ReflectionPermission(ReflectionPermissionFlag.MemberAccess));
            set.AddPermission(new ConfigurationPermission(PermissionState.Unrestricted));
            set.RemovePermission(typeof(FileIOPermission));

            var domain = AppDomain.CreateDomain("partial trust", null, AppDomain.CurrentDomain.SetupInformation, set);

            try
            {
                domain.DoCallBack(CheckSource);
            }
            catch
            {
                throw;
            }
            finally
            {
                AppDomain.Unload(domain);
            }
        }

        public static void CheckSource()
        {
            var source = new SystemConfigurationSource(false);
            object section = source.GetSection(localSection);

            if (section == null)
            {
                throw new Exception("could not get section");
            }
        }
    }
}
