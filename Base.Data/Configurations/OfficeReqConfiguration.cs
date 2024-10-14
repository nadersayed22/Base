using System.Data.Entity.ModelConfiguration;
using Base.Model1;

namespace Base.Data
{
       public class OfficeReqConfiguration : EntityTypeConfiguration<OfficeReq>
    {
        public OfficeReqConfiguration() 
        {
            ToTable("OfficeReq");
            Property(p => p.ID).IsRequired();
            Property(p => p.officeID).IsRequired();
            Property(p => p.reqID).IsRequired();
            Property(p => p.isBool).IsRequired();
			Property(p => p.Amount);
        }
    }
}
