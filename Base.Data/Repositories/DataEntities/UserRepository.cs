using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model;

namespace Base.Data.Repositories.DataEntities
{
    public class UserRepository : RepositoryBase<UserModel>,IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
