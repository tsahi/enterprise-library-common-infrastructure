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

using System.Collections;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.Tests
{
    public static class ThreadStressHelper
    {
        public static void ThreadStress(ThreadStart testMethod, int threadCount)
        {
            ArrayList threads = new ArrayList();
            for (int i = 0; i < threadCount; i++)
            {
                threads.Add(new Thread(testMethod));
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}

