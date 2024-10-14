using AutoMapper;
using Base.Model;
using Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.App_Start.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public DomainToViewModelMappingProfile()
        {
            CreateMap<UserModel, BaseViewModel>();
        }

        //protected void Configure()
        //{

        //}
    }
}