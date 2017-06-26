using AutoMapper;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DPEP.Common.BLL.ConfigServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AddEmployeeModel, AspNetUser>();
            CreateMap<AddEmployeeModel, Company>()
                .ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => src.employeeID))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.emailAddress));
        }
    }

    public static class MapperConfigService
    {
        public static IServiceCollection RegisterMapper(this IServiceCollection services)
        {
            services.AddAutoMapper();

            return services;
        }
    }
}
