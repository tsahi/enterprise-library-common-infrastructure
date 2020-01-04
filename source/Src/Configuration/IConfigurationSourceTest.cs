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

using System.Collections.Generic;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// This interface supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
    /// Augmented version of the <see cref="IConfigurationSource"/> interface intended to be used by unit tests.
    /// </summary>
    public interface IConfigurationSourceTest : IConfigurationSource
    {
        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        void ConfigSourceChanged(string configSource);

        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        void ExternalConfigSourceChanged(string configSource);

        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        IDictionary<string, ConfigurationSourceWatcher> ConfigSourceWatcherMappings { get; }

        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        ICollection<string> WatchedConfigSources { get; }

        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// </summary>
        ICollection<string> WatchedSections { get; }
    }
}
