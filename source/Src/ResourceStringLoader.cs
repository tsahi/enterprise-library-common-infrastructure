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
using System.Reflection;
using System.Resources;

namespace Microsoft.Practices.EnterpriseLibrary.Common
{
    /// <summary>
    /// Helper class to load resources strings.
    /// </summary>
    public static class ResourceStringLoader
    {
        /// <summary>
        /// Load a resource string.
        /// </summary>
        /// <param name="baseName">The base name of the resource.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <returns>The string from the resource.</returns>
        public static string LoadString(string baseName, string resourceName)
        {
            return LoadString(baseName, resourceName, Assembly.GetCallingAssembly());
        }

        /// <summary>
        /// Load a resource string.
        /// </summary>
        /// <param name="baseName">The base name of the resource.</param>
        /// <param name="resourceName">The resource name.</param>
        /// <param name="asm">The assembly to load the resource from.</param>
        /// <returns>The string from the resource.</returns>
        public static string LoadString(string baseName, string resourceName, Assembly asm)
        {
            if (string.IsNullOrEmpty(baseName)) throw new ArgumentNullException("baseName");
            if (string.IsNullOrEmpty(resourceName)) throw new ArgumentNullException("resourceName");


            string value = null;

            if (null != asm) value = LoadAssemblyString(asm, baseName, resourceName);
            if (null == value && null != asm) value = SearchForResource(asm, resourceName);
            if (null == value) value = LoadAssemblyString(Assembly.GetExecutingAssembly(), baseName, resourceName);
            if (null == value) return string.Empty;

            return value;
        }

        private static string SearchForResource(Assembly asm, string resourceName)
        {
            string[] resources = asm.GetManifestResourceNames();

            foreach (string resource in resources)
            {
                // Remove additional .resource token
                const string token = ".resources";
                string resourceToUse = resource;
                if (resource.EndsWith(token, StringComparison.OrdinalIgnoreCase))
                {
                    resourceToUse = resource.Replace(token, string.Empty);
                }

                string result = LoadAssemblyString(asm, resourceToUse, resourceName);

                if (!string.IsNullOrEmpty(result))
                {
                    return result;
                }
            }
            
            return null;
        }

        private static string LoadAssemblyString(Assembly asm, string baseName, string resourceName)
        {
            try
            {
                ResourceManager rm = new ResourceManager(baseName, asm);
                return rm.GetString(resourceName);
            }
            catch (MissingManifestResourceException)
            {
            }
            return null;
        }
    }
}
