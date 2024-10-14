using System.Data.Entity.ModelConfiguration;
using Base.Model1;

namespace Base.Data
{
       public class HajjOfficeConfiguration : EntityTypeConfiguration<HajjOffice>
    {
        public HajjOfficeConfiguration() 
        {
            ToTable("HajjOffice");
            Property(p => p.ID).IsRequired();
            Property(p => p.OfficeName).IsRequired().HasMaxLength(50);
            Property(p => p.OfficeRepresentativeID);
            Property(p => p.OfficePhone).HasMaxLength(12);
        }
    }
}
