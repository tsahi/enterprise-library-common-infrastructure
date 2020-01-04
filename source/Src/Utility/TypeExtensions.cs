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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Utility
{
    /// <summary>
    /// Extensios to <see cref="Type"/>
    /// </summary>
    public static class TypeExtensions
    {
        ///<summary>
        /// Locates the generic parent of the type
        ///</summary>
        ///<param name="rootType">Type to begin search from.</param>
        ///<param name="parentType">Open generic type to seek</param>
        ///<returns>The found parent that is a closed generic of the <paramref name="parentType"/> or null</returns>
        public static Type FindGenericParent(this Type rootType, Type parentType)
        {
            if (parentType == null) throw new ArgumentNullException("parentType");
            if (rootType == null) throw new ArgumentNullException("rootType");

            if (!parentType.IsGenericType) return null;

            Type currentType = rootType;
            while (currentType != typeof(object))
            {
                if (!currentType.IsGenericType)
                {
                    currentType = currentType.BaseType;
                    continue;
                }

                var genericType = currentType.GetGenericTypeDefinition();
                if (genericType == parentType) return currentType;

                currentType = currentType.BaseType;
            }

            return null;
        }
    }
}
