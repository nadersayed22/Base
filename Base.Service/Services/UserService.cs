using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Data.Repositories.DataEntities;
using Base.Model;
using Base.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Base.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository UserRepository, IUnitOfWork unitOfWork)
        {
            this.UserRepository = UserRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBaseService Members

        public void CreateEntity(UserModel Entity)
        {
			UserRepository.Add(Entity);
        }

        public IEnumerable<UserModel>  GetEntities()
        {
            return UserRepository.GetAll();
        }

        public UserModel GetEntity(int id)
        {
            return UserRepository.GetById(id);
        }

		public IEnumerable<UserModel> Getmany(Expression<Func<UserModel, bool>> where)
		{
			return UserRepository.GetMany(where);
		}

		public void Update(UserModel Entity)
		{
			UserRepository.Update(Entity);
		}

		public void SaveEnitiy()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
