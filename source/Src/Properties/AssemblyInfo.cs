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
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;

[assembly: ReliabilityContract(Consistency.WillNotCorruptState, Cer.None)]
[assembly: AssemblyTitle("Enterprise Library Shared Library")]
[assembly: AssemblyDescription("Enterprise Library Shared Library")]
[assembly: AssemblyVersion("6.0.0.0")]
[assembly: AssemblyFileVersion("6.0.1311.0")]
[assembly: AssemblyInformationalVersion("6.0.1311-prerelease")]

[assembly: AllowPartiallyTrustedCallers]

[assembly: ComVisible(false)]

[assembly: HandlesSection(ConfigurationSourceSection.SectionName)]
[assembly: HandlesSection(AppSettingsDesignTime.AppSettingsSectionName)]

[assembly: AddApplicationBlockCommand(
                AppSettingsDesignTime.AppSettingsSectionName,
                typeof(AppSettingsSection),
                TitleResourceType = typeof(DesignResources),
                TitleResourceName = "AddApplicationSettingsTitle")]

[assembly: AddApplicationBlockCommand(ConfigurationSourceSection.SectionName,
            typeof(ConfigurationSourceSection),
            TitleResourceType = typeof(DesignResources),
            TitleResourceName = "AddConfigurationSourcesTitle",
            CommandModelTypeName = ConfigurationSourcesDesignTime.CommandTypeNames.AddConfigurationSourcesBlockCommand)]
