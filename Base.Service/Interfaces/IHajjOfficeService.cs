using Base.Model1;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Base.Service.Interfaces
{
    public interface IHajjOfficeService
	{
        IEnumerable<HajjOffice> GetEntities();
		HajjOffice GetEntity(int id);
        void CreateEntity(HajjOffice Entity);
        void SaveEnitiy();
		IEnumerable<HajjOffice> Getmany(Expression<Func<HajjOffice, bool>> where);
		void Update(HajjOffice Entity);
        void Delete(HajjOffice hajjOffice);
    }
}
