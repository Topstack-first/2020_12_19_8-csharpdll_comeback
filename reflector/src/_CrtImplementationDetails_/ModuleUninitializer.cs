namespace _CrtImplementationDetails_
{
    using System;
    using System.Collections;
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution;
    using System.Security;
    using System.Threading;

    internal class ModuleUninitializer : Stack
    {
        private static object @lock = new object();
        internal static ModuleUninitializer _ModuleUninitializer = new ModuleUninitializer();

        [SecuritySafeCritical]
        private ModuleUninitializer()
        {
            EventHandler handler = new EventHandler(this.SingletonDomainUnload);
            AppDomain.CurrentDomain.DomainUnload += handler;
            AppDomain.CurrentDomain.ProcessExit += handler;
        }

        [SecuritySafeCritical]
        internal void AddHandler(EventHandler handler)
        {
            bool lockTaken = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                RuntimeHelpers.PrepareConstrainedRegions();
                Monitor.Enter(@lock, ref lockTaken);
                RuntimeHelpers.PrepareDelegate(handler);
                this.Push(handler);
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(@lock);
                }
            }
        }

        [SecurityCritical, PrePrepareMethod]
        private void SingletonDomainUnload(object source, EventArgs arguments)
        {
            bool lockTaken = false;
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                RuntimeHelpers.PrepareConstrainedRegions();
                Monitor.Enter(@lock, ref lockTaken);
                IEnumerator enumerator = this.GetEnumerator();
                while (true)
                {
                    try
                    {
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                return;
                            }
                            else
                            {
                                ((EventHandler) enumerator.Current)(source, arguments);
                            }
                            break;
                        }
                    }
                    finally
                    {
                        IEnumerator enumerator2 = enumerator;
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            finally
            {
                if (lockTaken)
                {
                    Monitor.Exit(@lock);
                }
            }
        }
    }
}

