using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
