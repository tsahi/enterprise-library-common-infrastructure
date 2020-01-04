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
using System.Configuration;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{

    ///<summary>
    ///Container class for types and identifiers used to decorate the appSettings configuration schema with designtime information.
    ///</summary>
    public static class AppSettingsDesignTime
    {
        ///<summary>
        ///Name of appSettings section.
        ///</summary>
        public const string AppSettingsSectionName = "appSettings";

        ///<summary>
        ///Container class for View Model Types used to decorate the appSettings configuration schema with designtime information.
        ///</summary>
        internal static class ViewModelTypeNames
        {
            ///<summary>
            ///Type Name of the Section View Model used to display application settings.
            ///</summary>
            public const string AppSettingsSectionViewModel = "Microsoft.Practices.EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.AppSettingsViewModel, Microsoft.Practices.EnterpriseLibrary.Configuration.DesignTime";
        }

        /// <summary>
        /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public static class MetadataTypes
        {
            /// <summary>
            /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            [ViewModel(ViewModelTypeNames.AppSettingsSectionViewModel)]
            [ResourceDisplayName(typeof(DesignResources), "AppSettingsSectionMetadataDisplayName")]
            [ResourceDescription(typeof(DesignResources), "AppSettingsSectionMetadataDescription")]
            [RegisterAsMetadataType(typeof(AppSettingsSection))]
            public abstract class AppSettingsSectionMetadata
            {

            }

            /// <summary>
            /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            [ResourceDisplayName(typeof(DesignResources), "KeyValueConfigurationCollectionMetadataDisplayName")]
            [ResourceDescription(typeof(DesignResources), "KeyValueConfigurationCollectionMetadataDescription")]
            [RegisterAsMetadataType(typeof(KeyValueConfigurationCollection))]
            public abstract class KeyValueConfigurationCollectionMetadata
            {
            }

            /// <summary>
            /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            [NameProperty("Key", NamePropertyDisplayFormat = "Setting : '{0}'")]
            [ResourceDisplayName(typeof(DesignResources), "KeyValueConfigurationElementMetadataDisplayName")]
            [ResourceDescription(typeof(DesignResources), "KeyValueConfigurationElementMetadataDescription")]
            [RegisterAsMetadataType(typeof(KeyValueConfigurationElement))]
            public abstract class KeyValueConfigurationElementMetadata
            {
                /// <summary>
                /// This property supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
                /// </summary>
                [ResourceDisplayName(typeof(DesignResources), "KeyValueConfigurationElementMetadataKeyDisplayName")]
                [ResourceDescription(typeof(DesignResources), "KeyValueConfigurationElementMetadataKeyDescription")]
                [EnvironmentalOverridesAttribute(false)]
                [ViewModel(CommonDesignTime.ViewModelTypeNames.ConfigurationPropertyViewModel)]
                public abstract string Key { get; set; }

                /// <summary>
                /// This property supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
                /// </summary>
                [ResourceDisplayName(typeof(DesignResources), "KeyValueConfigurationElementMetadataValueDisplayName")]
                [ResourceDescription(typeof(DesignResources), "KeyValueConfigurationElementMetadataValueDescription")]
                public abstract string Value { get; set; }
            }
        }
    }
}
