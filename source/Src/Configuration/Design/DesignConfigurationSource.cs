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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design
{
    /// <summary>
    /// configuration source to support design-time configuration of <see cref="FileConfigurationSource"/>
    /// </summary>
    public class DesignConfigurationSource : FileConfigurationSource, IDesignConfigurationSource
    {
        
        ///<summary>
        /// Initializes a new instance of <see cref="DesignConfigurationSource"/> based on file path.
        ///</summary>
        ///<param name="configurationFilePath"></param>
        public DesignConfigurationSource(string configurationFilePath)
            :base(configurationFilePath)
        {
        }

        ///<summary>
        /// Retrieves a local section from the configuration source.
        ///</summary>
        ///<param name="sectionName"></param>
        ///<returns>The configuration section or null if it does not contain the section.</returns>
        public System.Configuration.ConfigurationSection GetLocalSection(string sectionName)
        {
            return DoGetSection(sectionName);
        }

        /// <summary>
        /// Adds a local section to the configuration source.
        /// </summary>
        /// <param name="sectionName"></param>
        /// <param name="section"></param>
        public void AddLocalSection(string sectionName, System.Configuration.ConfigurationSection section)
        {
            DoAdd(sectionName, section);
        }

        ///<summary>
        /// Removes a local section from the configuration source.
        ///</summary>
        ///<param name="sectionName"></param>
        public void RemoveLocalSection(string sectionName)
        {
            DoRemove(sectionName);
        }

        /// <summary>
        /// Gets the path of the configuration file for the configuration source.
        /// </summary>
        public new string ConfigurationFilePath
        {
            get { return base.ConfigurationFilePath; }
        }


        /// <summary>
        /// Creates a new instance of <see cref="DesignConfigurationSource"/> based on <paramref name="rootSource"/> and <paramref name="filePath"/>.
        /// </summary>
        /// <param name="rootSource">The source that was used to open the main conifguration file.</param>
        /// <param name="filePath">An absolute of relative path to the file to which the source should be created.</param>
        /// <returns>A new instance of <see cref="DesignConfigurationSource"/>.</returns>
        public static IDesignConfigurationSource CreateDesignSource(IDesignConfigurationSource rootSource, string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException(Resources.ExceptionStringNullOrEmpty);

            DesignConfigurationSource rootSourceAsDesignSource = rootSource as DesignConfigurationSource;
            if (rootSourceAsDesignSource == null)
                throw new ArgumentException(Resources.CannotCreateDesignSource, "rootSource");

            {
                string mainConfigurationFileDirectory =
                    Path.GetDirectoryName(rootSourceAsDesignSource.ConfigurationFilePath);

                string fullFilePath = Path.Combine(mainConfigurationFileDirectory, filePath);

                if (!File.Exists(fullFilePath))
                {
                    File.WriteAllText(fullFilePath, @"<configuration />");
                }

                return new DesignConfigurationSource(fullFilePath);
            }
        }
    }
}
