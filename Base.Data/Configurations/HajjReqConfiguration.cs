using System.Data.Entity.ModelConfiguration;
using Base.Model1;

namespace Base.Data
{
       public class HajjReqConfiguration : EntityTypeConfiguration<HajjReq>
    {
        public HajjReqConfiguration() 
        {
            ToTable("HajjReq");
            Property(p => p.ID).IsRequired();
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}
