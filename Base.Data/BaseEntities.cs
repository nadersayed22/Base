using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Base.Model;
using Base.Model1;

namespace Base.Data
{
    public class BaseEntities : DbContext
    {
        public BaseEntities() : base("BaseEntities") { }

        public DbSet<UserModel> users { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new HajjOfficeConfiguration());
            modelBuilder.Configurations.Add(new HajjReqConfiguration());
            modelBuilder.Configurations.Add(new OfficeReqConfiguration());
        }
    }
}
