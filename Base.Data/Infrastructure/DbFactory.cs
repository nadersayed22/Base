using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        BaseEntities dbContext;

        public BaseEntities Init()
        {
            return dbContext ?? (dbContext = new BaseEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
