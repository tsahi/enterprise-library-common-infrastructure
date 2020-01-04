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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{


    /// <summary>
    /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
    /// </summary>
    internal static class ConfigurationSourcesDesignTime
    {
        /// <summary>
        /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public static class ViewModelTypeNames
        {
            /// <summary>
            /// This field supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            public const string ConfigurationSourcesSectionViewModel = "Microsoft.Practices.EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ConfigurationSourceSectionViewModel, Microsoft.Practices.EnterpriseLibrary.Configuration.DesignTime";

            /// <summary>
            /// This field supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            public const string ConfigurationSourceSectionViewModel =
                "Microsoft.Practices.EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ConfigurationSourceSectionViewModel, Microsoft.Practices.EnterpriseLibrary.Configuration.DesignTime";
        }

        /// <summary>
        /// This class supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        public static class CommandTypeNames
        {
            /// <summary>
            /// This field supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            public const string AddConfigurationSourcesBlockCommand = "Microsoft.Practices.EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.AddConfigurationSourcesBlockCommand, Microsoft.Practices.EnterpriseLibrary.Configuration.DesignTime";

            /// <summary>
            /// This field supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
            /// </summary>
            public const string ConfigurationSourceElementDeleteCommand = "Microsoft.Practices.EnterpriseLibrary.Configuration.Design.ViewModel.BlockSpecifics.ConfigurationSourceElementDeleteCommand, Microsoft.Practices.EnterpriseLibrary.Configuration.DesignTime";
        }
    }

}
