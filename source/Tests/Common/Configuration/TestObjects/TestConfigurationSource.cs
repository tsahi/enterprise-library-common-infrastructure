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
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using System.ComponentModel;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects
{
    [ConfigurationElementType(typeof(TestConfigurationSourceElement))]
    public class TestConfigurationSource : IConfigurationSource
    {
        public static Dictionary<string, System.Configuration.ConfigurationSection> ConfigurationSourceContents = new Dictionary<string, ConfigurationSection>();

        private Dictionary<string, System.Configuration.ConfigurationSection> contents;
        private CompositeConfigurationSourceHandler CompositeConfigurationSource;
        private HierarchicalConfigurationSourceHandler HierarchicalConfigurationSource;
        public EventHandlerList SectionChangedHandlers = new EventHandlerList();

        public TestConfigurationSource()
        {
            contents = new Dictionary<string, ConfigurationSection>();
            foreach (var section in ConfigurationSourceContents)
            {
                contents.Add(section.Key, section.Value);
            }

            SetCompositeHandler(new CompositeConfigurationSourceHandler(this));
            SetHierarchyHandler(new HierarchicalConfigurationSourceHandler(this));
        }

        public void SetHierarchyHandler(HierarchicalConfigurationSourceHandler handler)
        {
            HierarchicalConfigurationSource = handler;
            HierarchicalConfigurationSource.ConfigurationSectionChanged += new ConfigurationChangedEventHandler(compositeConfigurationSource_ConfigurationSectionChanged);
            HierarchicalConfigurationSource.ConfigurationSourceChanged += new EventHandler<ConfigurationSourceChangedEventArgs>(CompositeConfigurationSource_ConfigurationSourceChanged);
        }

        public void SetCompositeHandler(CompositeConfigurationSourceHandler handler)
        {
            CompositeConfigurationSource = handler;
            CompositeConfigurationSource.ConfigurationSectionChanged += new ConfigurationChangedEventHandler(compositeConfigurationSource_ConfigurationSectionChanged);
            CompositeConfigurationSource.ConfigurationSourceChanged += new EventHandler<ConfigurationSourceChangedEventArgs>(CompositeConfigurationSource_ConfigurationSourceChanged);
        }

        void CompositeConfigurationSource_ConfigurationSourceChanged(object sender, ConfigurationSourceChangedEventArgs e)
        {
            DoSourceChanged(e.ChangedSectionNames);
        }

        void compositeConfigurationSource_ConfigurationSectionChanged(object sender, ConfigurationChangedEventArgs e)
        {
            DoSourceSectionChanged(e.SectionName);
        }

        public ConfigurationSection GetSection(string sectionName)
        {
            ConfigurationSection section;
            contents.TryGetValue(sectionName, out section);

            return CompositeConfigurationSource.CheckGetSection(sectionName, section);
        }

        public void Add(string sectionName, ConfigurationSection configurationSection)
        {
            if (CompositeConfigurationSource.CheckAddSection(sectionName, configurationSection)) return;
            
            contents.Add(sectionName, configurationSection);
            
        }

        public void Remove(string sectionName)
        {
            if (CompositeConfigurationSource.CheckRemoveSection(sectionName)) return;

            contents.Remove(sectionName);
        }

        public event EventHandler<ConfigurationSourceChangedEventArgs> SourceChanged;

        public void AddSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            SectionChangedHandlers.AddHandler(sectionName, handler);
        }

        public void RemoveSectionChangeHandler(string sectionName, ConfigurationChangedEventHandler handler)
        {
            SectionChangedHandlers.RemoveHandler(sectionName, handler);
        }

        public int DisposeCallCount = 0;
        public void Dispose()
        {
            DisposeCallCount++;
        }

        internal void DoSourceSectionChanged(string section)
        {
            if (DisposeCallCount > 0) throw new Exception();

            ConfigurationChangedEventHandler handler = SectionChangedHandlers[section] as ConfigurationChangedEventHandler;
            if (handler != null)
            {
                handler(this, new ConfigurationChangedEventArgs(section));
            }
        }

        internal void DoSourceChanged(IEnumerable<string> affectedSections)
        {
            var handler = SourceChanged;
            if (handler != null)
            {
                handler(this, new ConfigurationSourceChangedEventArgs(this, affectedSections));
            }
        }

        internal EventHandler<ConfigurationSourceChangedEventArgs> SourceChangedHandler
        {
            get
            {
                return SourceChanged;
            }
        }
    }

    public class TestConfigurationSourceElement : ConfigurationSourceElement
    {
        public TestConfigurationSourceElement()
        { }

        public TestConfigurationSourceElement(string name)
            : base(name, typeof(TestConfigurationSource))
        { }

        public override IConfigurationSource CreateSource()
        {
            return new TestConfigurationSource();
        }
    }
}
