using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Base.Data
{
    public class BaseSeedData : DropCreateDatabaseIfModelChanges<BaseEntities>
    {
        protected override void Seed(BaseEntities context)
        {
            context.Commit();
        }
        
    }
}
