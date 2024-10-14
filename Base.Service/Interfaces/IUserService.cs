using Base.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Base.Service.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetEntities();
		UserModel GetEntity(int id);
        void CreateEntity(UserModel Entity);
        void SaveEnitiy();
		IEnumerable<UserModel> Getmany(Expression<Func<UserModel, bool>> where);
		void Update(UserModel Entity);
	}
}
