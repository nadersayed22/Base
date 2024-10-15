using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;
using Base.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Base.Service.Services
{
    public class OfficeReqService : IOfficeReqService
	{
        private readonly IOfficeReqRepository officeReqRepository;
        private readonly IUnitOfWork unitOfWork;

        public OfficeReqService(IOfficeReqRepository officeReqRepository, IUnitOfWork unitOfWork)
        {
            this.officeReqRepository = officeReqRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IBaseService Members
        public void Delete(OfficeReq hajjOfficeReq)
        {
            var entity = officeReqRepository.GetById(hajjOfficeReq.ID);
            if (entity != null)
            {
                officeReqRepository.Delete(entity);

                SaveEnitiy();
            }
        }

        public void CreateEntity(OfficeReq Entity)
        {
			officeReqRepository.Add(Entity);
        }

        public IEnumerable<OfficeReq>  GetEntities()
        {
            return officeReqRepository.GetAll();
        }

        public OfficeReq GetEntity(int id)
        {
            return officeReqRepository.GetById(id);
        }

		public IEnumerable<OfficeReq> Getmany(Expression<Func<OfficeReq, bool>> where)
		{
			return officeReqRepository.GetMany(where);
		}

		public void Update(OfficeReq Entity)
		{
			officeReqRepository.Update(Entity);
		}


        public void SaveEnitiy()
        {
            unitOfWork.Commit();
        }

        public List<OfficeReq> GetAllOfficeReqs(params string[] includeProperties)
        {
            var x= officeReqRepository.QueryableGetAll(null,includeProperties);
            return x;
        }
        #endregion
    }
}
