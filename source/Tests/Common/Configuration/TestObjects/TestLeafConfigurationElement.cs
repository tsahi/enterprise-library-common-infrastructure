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
using System.Configuration;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests.Configuration.TestObjects
{
    public class TestLeafConfigurationElement : ConfigurationElement
    {
        private const string idProperty = "id";
        private const string otherKeyPartProperty = "otherKeyPart";
        private const string randomOtherProperty = "randomOther";
        private const string anIntProperty = "anInt";

        [ConfigurationProperty(idProperty, IsKey=true)]
        public Guid ID
        {
            get{return (Guid) base[idProperty];}
            set{base[idProperty] = value;}
        }

        [ConfigurationProperty(otherKeyPartProperty, IsKey = true)]
        public string OtherKeyPart
        {
            get { return (string) base[otherKeyPartProperty]; }
            set { base[otherKeyPartProperty] = value; }
        }

        [ConfigurationProperty(randomOtherProperty)]
        public string SomeOtherValue
        {
            get { return (string)base[randomOtherProperty]; }
            set { base[randomOtherProperty] = value; }
        }

        [ConfigurationProperty(anIntProperty)]
        public int AnInt
        {
            get { return (int)base[anIntProperty]; }
            set { base[anIntProperty] = value; }
        }
    }
}
