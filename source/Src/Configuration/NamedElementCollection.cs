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
using System.Linq;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Configuration
{
    /// <summary>
    /// Represents a collection of <see cref="NamedConfigurationElement"/> objects.
    /// </summary>
    /// <typeparam name="T">A newable object that inherits from <see cref="NamedConfigurationElement"/>.</typeparam>
    public class NamedElementCollection<T> : ConfigurationElementCollection, IMergeableConfigurationElementCollection, IEnumerable<T>
        where T : NamedConfigurationElement, new()
    {

        /// <summary>
        /// Performs the specified action on each element of the collection.
        /// </summary>
        /// <param name="action">The action to perform.</param>
        public void ForEach(Action<T> action)
        {
            for (int index = 0; index < Count; index++)
            {
                action(Get(index));
            }
        }

        /// <summary>
        /// Gets the configuration element at the specified index location. 
        /// </summary>
        /// <param name="index">The index location of the <see name="T"/> to return. </param>
        /// <returns>The <see name="T"/> at the specified index. </returns>
        public T Get(int index)
        {
            return (T)base.BaseGet(index);
        }

        /// <summary>
        /// Add an instance of <typeparamref name="T"/> to the collection.
        /// </summary>
        /// <param name="element">An instance of <typeparamref name="T"/>.</param>
        public void Add(T element)
        {
            BaseAdd(element, true);
        }

        /// <summary>
        /// Gets the named instance of <typeparamref name="T"/> from the collection.
        /// </summary>
        /// <param name="name">The name of the <typeparamref name="T"/> instance to retrieve.</param>
        /// <returns>The instance of <typeparamref name="T"/> with the specified key; otherwise, <see langword="null"/>.</returns>
        public T Get(string name)
        {
            return BaseGet(name) as T;
        }

        /// <summary>
        /// Determines if the name exists in the collection.
        /// </summary>
        /// <param name="name">The name to search.</param>
        /// <returns><see langword="true"/> if the name is contained in the collection; otherwise, <see langword="false"/>.</returns>
        public bool Contains(string name)
        {
            return BaseGet(name) != null;
        }

        /// <summary>
        /// Remove the named element from the collection.
        /// </summary>
        /// <param name="name">The name of the element to remove.</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// Clear the collection.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection. 
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public new IEnumerator<T> GetEnumerator()
        {
            return new GenericEnumeratorWrapper<T>(base.GetEnumerator());
        }

        /// <summary>
        /// Creates a new instance of a <typeparamref name="T"/> object.
        /// </summary>
        /// <returns>A new <see cref="ConfigurationElement"/>.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new T();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class. 
        /// </summary>
        /// <param name="element">The <see cref="ConfigurationElement"/> to return the key for. </param>
        /// <returns>An <see cref="Object"/> that acts as the key for the specified <see cref="ConfigurationElement"/>.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            T namedElement = (T)element;
            return namedElement.Name;
        }

        void IMergeableConfigurationElementCollection.ResetCollection(IEnumerable<ConfigurationElement> configurationElements)
        {
            foreach (T element in this)
            {
                Remove(element.Name);
            }

            foreach (T element in configurationElements.Reverse())
            {
                base.BaseAdd(0, element);
            }
        }

        ConfigurationElement IMergeableConfigurationElementCollection.CreateNewElement(Type configurationType)
        {
            return (ConfigurationElement)Activator.CreateInstance(configurationType);
        }
    }
}
