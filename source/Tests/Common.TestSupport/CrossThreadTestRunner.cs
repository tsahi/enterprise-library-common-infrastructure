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
using System.Reflection;
using System.Security.Permissions;
using System.Threading;

namespace Microsoft.Practices.EnterpriseLibrary.Common.TestSupport
{
    public class CrossThreadTestRunner
    {
        private ThreadStart userDelegate;
        private Exception lastException;

        public CrossThreadTestRunner(ThreadStart userDelegate)
        {
            this.userDelegate = userDelegate;
        }

        public void Run()
        {
            Thread t = new Thread(new ThreadStart(this.MultiThreadedWorker));

            t.Start();
            t.Join();

            if (lastException != null)
            {
                ThrowExceptionPreservingStack(lastException);
            }
        }

        [ReflectionPermission(SecurityAction.Demand)]
        private static void ThrowExceptionPreservingStack(Exception exception)
        {
            FieldInfo remoteStackTraceString = typeof(Exception).GetField("_remoteStackTraceString", BindingFlags.Instance | BindingFlags.NonPublic);
            remoteStackTraceString.SetValue(exception, exception.StackTrace + Environment.NewLine);
            throw exception;
        }

        private void MultiThreadedWorker()
        {
            try
            {
                userDelegate.Invoke();
            }
            catch (Exception e)
            {
                lastException = e;
            }
        }
    }
}

