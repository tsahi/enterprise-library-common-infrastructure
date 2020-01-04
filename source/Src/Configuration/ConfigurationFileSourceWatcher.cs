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
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Storage;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Watcher for configuration sections in configuration files.
    /// </summary>
    /// <remarks>
    /// This implementation uses a <see cref="ConfigurationChangeFileWatcher"/> to watch for changes 
    /// in the configuration files.
    /// </remarks>
    public class ConfigurationFileSourceWatcher : ConfigurationSourceWatcher, IDisposable
    {
        private readonly string configurationFilepath;
        private ConfigurationChangeFileWatcher configWatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationFileSourceWatcher"/> class.
        /// </summary>
        /// <param name="configurationFilepath">The path for the configuration file to watch.</param>
        /// <param name="configSource">The identification of the configuration source.</param>
        /// <param name="refresh"><b>true</b> if changes should be notified, <b>false</b> otherwise.</param>
        /// <param name="refreshInterval">The poll interval in milliseconds.</param>
        /// <param name="changed">The callback for changes notification.</param>
        public ConfigurationFileSourceWatcher(
            string configurationFilepath,
            string configSource,
            bool refresh,
            int refreshInterval,
            ConfigurationChangedEventHandler changed)
            : base(configSource, refresh, changed)
        {
            this.configurationFilepath = configurationFilepath;

            if (refresh)
            {
                SetUpWatcher(refreshInterval, changed);
            }
        }

        private void SetUpWatcher(int refreshInterval, ConfigurationChangedEventHandler changed)
        {
            this.configWatcher =
                new ConfigurationChangeFileWatcher(
                    GetFullFileName(this.configurationFilepath, this.ConfigSource),
                    this.ConfigSource);
            this.configWatcher.SetPollDelayInMilliseconds(refreshInterval);
            this.configWatcher.ConfigurationChanged += changed;
        }

        /// <summary>
        /// Gets the full file name associated to the configuration source.
        /// </summary>
        /// <param name="configurationFilepath">The path for the main configuration file.</param>
        /// <param name="configSource">The configuration source to watch.</param>
        /// <returns>The path to the configuration file to watch. It will be the same as <paramref name="configurationFilepath"/>
        /// if <paramref name="configSource"/> is empty, or the full path for <paramref name="configSource"/> considered as a 
        /// file name relative to the main configuration file.</returns>
        public static string GetFullFileName(string configurationFilepath, string configSource)
        {
            if (string.Empty == configSource)
            {
                // watch app.config/web.config
                return configurationFilepath;
            }
            else
            {
                // watch an external file
                if (!Path.IsPathRooted(configSource))
                {
                    // REVIEW - this is ok?
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configSource);
                }
                else
                {
                    return configSource;
                }
            }
        }

        /// <summary>
        /// Gets the watcher over the serialization medium.
        /// </summary>
        public override ConfigurationChangeWatcher Watcher
        {
            get { return this.configWatcher; }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.configWatcher != null)
                {
                    this.configWatcher.Dispose();
                    this.configWatcher = null;
                }
            }
        }
    }
}
