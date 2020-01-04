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

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport
{
    /// <summary>
    /// Helps manage embedded resources in test assemblies
    /// to avoid DeploymentItem issues.
    /// </summary>
    public class ResourceHelper<TResourceLocator>
    {
        public string DumpResourceFileToDisk(string resourceName)
        {
            return DumpResourceFileToDisk(resourceName, string.Empty);
        }

        public string DumpResourceFileToDisk(string resourceName, string relativeDirectoryPath)
        {
            string configurationFilePath;

            using (Stream resourceStream = GetResourceStream(resourceName))
            using (Stream outputStream = GetOutputStream(resourceName, relativeDirectoryPath, out configurationFilePath))
            {
                CopyStream(resourceStream, outputStream);
            }
            return configurationFilePath;

        }

        private static Stream GetResourceStream(string resourceName)
        {
            string fullResourceName = GetResourceNamespace() + "." + resourceName;

            var currentAssembly = typeof(TResourceLocator).Assembly;
            return currentAssembly.GetManifestResourceStream(fullResourceName);
        }

        private static string GetResourceNamespace()
        {
            return typeof(TResourceLocator).Namespace;
        }

        private static Stream GetOutputStream(string resourceName, string relativeDirectoryPath, out string configFilePath)
        {
            string configFileDir = AppDomain.CurrentDomain.BaseDirectory;
            configFileDir = Path.Combine(configFileDir, relativeDirectoryPath);
            if (!Directory.Exists(configFileDir)) Directory.CreateDirectory(configFileDir);

            configFilePath = Path.Combine(configFileDir, resourceName);

            return new FileStream(configFilePath, FileMode.Create, FileAccess.Write);
        }

        private static void CopyStream(Stream inputStream, Stream outputStream)
        {
            var buffer = new byte[4096];
            int numRead = inputStream.Read(buffer, 0, buffer.Length);
            while (numRead > 0)
            {
                outputStream.Write(buffer, 0, numRead);
                numRead = inputStream.Read(buffer, 0, buffer.Length);
            }
        }
    }
}
