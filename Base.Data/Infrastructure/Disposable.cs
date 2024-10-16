﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (/*!isDisposed && */disposing)
            {
                DisposeCore();
            }

            //isDisposed = true;
        }
        // Ovveride this to dispose custom objects
        protected virtual void DisposeCore()
        {
            
        }
    }
}
