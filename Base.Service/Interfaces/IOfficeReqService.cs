using Base.Model1;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Base.Service.Interfaces
{
    public interface IOfficeReqService
	{
        IEnumerable<OfficeReq> GetEntities();
		OfficeReq GetEntity(int id);
        void CreateEntity(OfficeReq Entity);
        void SaveEnitiy();
		IEnumerable<OfficeReq> Getmany(Expression<Func<OfficeReq, bool>> where);
		void Update(OfficeReq Entity);
	}
}
