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
using System.ComponentModel;
using System.Configuration;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Design.Validation;
using Microsoft.Practices.EnterpriseLibrary.Common.Properties;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents the configuration settings that describe a <see cref="FileConfigurationSource"/>.
    /// </summary>
    [ResourceDescription(typeof(DesignResources), "FileConfigurationSourceElementDescription")]
    [ResourceDisplayName(typeof(DesignResources), "FileConfigurationSourceElementDisplayName")]
    [Browsable(true)]
    [EnvironmentalOverrides(false)]
    public class FileConfigurationSourceElement : ConfigurationSourceElement
    {
        private const string filePathProperty = "filePath";

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigurationSourceElement"/> class with a default name and an empty path.
        /// </summary>
        public FileConfigurationSourceElement()
            : this(Resources.FileConfigurationSourceName, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileConfigurationSourceElement"/> class with a name and an path.
        /// </summary>
        /// <param name="name">The instance name.</param>
        /// <param name="filePath">The file path.</param>
        public FileConfigurationSourceElement(string name, string filePath)
            : base(name, typeof(FileConfigurationSource))
        {
            this.FilePath = filePath;
        }


        /// <summary>
        /// Gets or sets the file path. This is a required field.
        /// </summary>
        [ConfigurationProperty(filePathProperty, IsRequired = true)]
        [ResourceDescription(typeof(DesignResources), "FileConfigurationSourceElementFilePathDescription")]
        [ResourceDisplayName(typeof(DesignResources), "FileConfigurationSourceElementFilePathDisplayName")]
        [Editor(CommonDesignTime.EditorTypes.FilteredFilePath, CommonDesignTime.EditorTypes.UITypeEditor)]
        [FilteredFileNameEditorAttribute(typeof(DesignResources), "FileConfigurationSourceElementFilePathFilter", CheckFileExists = false)]
        [Validation(CommonDesignTime.ValidationTypeNames.PathExistsValidator)]
        [Validation(CommonDesignTime.ValidationTypeNames.FileWritableValidator)]
        public string FilePath
        {
            get { return (string)this[filePathProperty]; }
            set { this[filePathProperty] = value; }
        }

        /// <summary>
        /// Returns a new <see cref="FileConfigurationSource"/> configured with the receiver's settings.
        /// </summary>
        /// <returns>A new configuration source.</returns>
        public override IConfigurationSource CreateSource()
        {
            IConfigurationSource createdObject = new FileConfigurationSource(FilePath);

            return createdObject;
        }

        ///<summary>
        /// Returns a new <see cref="IDesignConfigurationSource"/> configured based on this configuration element.
        ///</summary>
        ///<returns>Returns a new <see cref="IDesignConfigurationSource"/> or null if this source does not have design-time support.</returns>
        public override IDesignConfigurationSource CreateDesignSource(IDesignConfigurationSource rootSource)
        {
            return DesignConfigurationSource.CreateDesignSource(rootSource, FilePath);


        }
    }
}
