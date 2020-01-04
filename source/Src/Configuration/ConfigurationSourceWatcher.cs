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

using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Storage;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Reacts to changes on the medium on which a set of configuration sections are serialized.
    /// </summary>
    public abstract class ConfigurationSourceWatcher
    {
        private string configurationSource;
        private IList<string> watchedSections;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationSourceWatcher"/> class.
        /// </summary>
        /// <param name="configSource">The identification of the medium.</param>
        /// <param name="refresh"><b>true</b> if changes should be notified, <b>false</b> otherwise.</param>
        /// <param name="changed">The callback for changes notification.</param>
        protected ConfigurationSourceWatcher(string configSource, bool refresh, ConfigurationChangedEventHandler changed)
        {
            this.configurationSource = configSource;
            this.watchedSections = new List<string>();
        }

        /// <summary>
        /// Gets or sets the identification of the medium where the watched set of configuration sections is stored.
        /// </summary>
        public string ConfigSource
        {
            get { return configurationSource; }
            set { configurationSource = value; }
        }

        /// <summary>
        /// Gets or sets the collection of watched sections.
        /// </summary>
        public IList<string> WatchedSections
        {
            get { return watchedSections; }
            set { watchedSections = value; }
        }

        /// <summary>
        /// Starts watching for changes on the serialization medium.
        /// </summary>
        public void StartWatching()
        {
            if (this.Watcher != null)
            {
                this.Watcher.StartWatching();
            }
        }

        /// <summary>
        /// Stops watching for changes on the serialization medium.
        /// </summary>
        public void StopWatching()
        {
            if (this.Watcher != null)
            {
                this.Watcher.StopWatching();
            }
        }

        /// <summary>
        /// Gets the watcher over the serialization medium.
        /// </summary>
        public abstract ConfigurationChangeWatcher Watcher { get; }
    }
}
