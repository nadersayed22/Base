using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;
using Base.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Base.Service.Services
{
    public class HajjReqService : IHajjReqService
	{
        private readonly IHajjReqRepository hajjReqRepository;
        private readonly IUnitOfWork unitOfWork;

        public HajjReqService(IHajjReqRepository hajjReqRepository, IUnitOfWork unitOfWork)
        {
            this.hajjReqRepository = hajjReqRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBaseService Members

        public void CreateEntity(HajjReq Entity)
        {
			hajjReqRepository.Add(Entity);
        }

        public IEnumerable<HajjReq>  GetEntities()
        {
            return hajjReqRepository.GetAll();
        }

        public HajjReq GetEntity(int id)
        {
            return hajjReqRepository.GetById(id);
        }

		public IEnumerable<HajjReq> Getmany(Expression<Func<HajjReq, bool>> where)
		{
			return hajjReqRepository.GetMany(where);
		}

		public void Update(HajjReq Entity)
		{
			hajjReqRepository.Update(Entity);
		}

		public void SaveEnitiy()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
