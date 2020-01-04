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

namespace Microsoft.Practices.EnterpriseLibrary.Common.Utility
{
    /// <summary>
    /// Resolves strings by invoking a delegate and returning the resulting value.
    /// </summary>
    public sealed class DelegateStringResolver : IStringResolver
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ConstantStringResolver"/> with a delegate.
        /// </summary>
        /// <param name="resolverDelegate">The delegate to invoke when resolving a string.</param>
        public DelegateStringResolver(Func<string> resolverDelegate)
        {
            this.resolverDelegate = resolverDelegate;
        }

        private readonly Func<string> resolverDelegate;

        string IStringResolver.GetString()
        {
            return this.resolverDelegate();
        }
    }
}
