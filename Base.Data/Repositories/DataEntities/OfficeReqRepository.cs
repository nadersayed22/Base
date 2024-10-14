using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;

namespace Base.Data.Repositories.DataEntities
{
    public class OfficeReqRepository : RepositoryBase<OfficeReq>, IOfficeReqRepository
	{
        public OfficeReqRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
