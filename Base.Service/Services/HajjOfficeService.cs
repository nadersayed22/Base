using Base.Data.Infrastructure;
using Base.Data.Interfaces;
using Base.Model1;
using Base.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;

namespace Base.Service.Services
{
    public class HajjOfficeService : IHajjOfficeService
	{
        private readonly IHajjOfficeRepository hajjOfficeService;
        private readonly IUnitOfWork unitOfWork;

        public HajjOfficeService(IHajjOfficeRepository hajjOfficeService, IUnitOfWork unitOfWork)
        {
            this.hajjOfficeService = hajjOfficeService;
            this.unitOfWork = unitOfWork;
        }

        #region IBaseService Members

        public void CreateEntity(HajjOffice Entity)
        {
			hajjOfficeService.Add(Entity);
        }

        public IEnumerable<HajjOffice>  GetEntities()
        {
            return hajjOfficeService.GetAll();
        }

        public HajjOffice GetEntity(int id)
        {
            return hajjOfficeService.GetById(id);
        }

		public IEnumerable<HajjOffice> Getmany(Expression<Func<HajjOffice, bool>> where)
		{
			return hajjOfficeService.GetMany(where);
		}

		public void Update(HajjOffice Entity)
		{
			hajjOfficeService.Update(Entity);
		}

        public void Delete(HajjOffice hajjOffice)
        {
            var entity = hajjOfficeService.GetById(hajjOffice.ID);
            if (entity != null)
            {
                hajjOfficeService.Delete(entity);

                SaveEnitiy();
            }
        }

        public void SaveEnitiy()
        {
            unitOfWork.Commit();
        }

 
        #endregion
    }
}
