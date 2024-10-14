using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;
using Base.Model;

namespace Base.Data
{
       public class UserConfiguration : EntityTypeConfiguration<UserModel>
    {
        public UserConfiguration() 
        {
            ToTable("Users");
            Property(p => p.ID).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.Password).HasMaxLength(50);
            Property(p => p.Email).HasMaxLength(50);
            Property(p => p.UserType);
            Property(p => p.PhoneNumber);
        }
    }
}
