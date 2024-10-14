using AutoMapper;
using Base.Model;
using Base.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.App_Start.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }


        public ViewModelToDomainMappingProfile()
        {
            CreateMap<BaseViewModel, UserModel>()
                .ForMember(g => g.ID, map => map.MapFrom(vm => vm.ID))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));
        }

        //protected void Configure()
        //{
            
        //}
    }
}