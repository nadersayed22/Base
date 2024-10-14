using Base.Model1;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Base.Service.Interfaces
{
    public interface IHajjReqService
	{
        IEnumerable<HajjReq> GetEntities();
		HajjReq GetEntity(int id);
        void CreateEntity(HajjReq Entity);
        void SaveEnitiy();
		IEnumerable<HajjReq> Getmany(Expression<Func<HajjReq, bool>> where);
		void Update(HajjReq Entity);
	}
}
