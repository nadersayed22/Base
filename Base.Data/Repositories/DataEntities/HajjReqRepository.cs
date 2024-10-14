using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;

namespace Base.Data.Repositories.DataEntities
{
    public class HajjReqRepository : RepositoryBase<HajjReq>, IHajjReqRepository
	{
        public HajjReqRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
