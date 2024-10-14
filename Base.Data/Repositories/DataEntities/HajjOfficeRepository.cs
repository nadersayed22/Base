using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;

namespace Base.Data.Repositories.DataEntities
{
    public class HajjOfficeRepository : RepositoryBase<HajjOffice>, IHajjOfficeRepository
	{
        public HajjOfficeRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
