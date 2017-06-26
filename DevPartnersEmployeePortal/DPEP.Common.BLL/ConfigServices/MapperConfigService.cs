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
            CreateMap<AspNetUser, AddEmployeeModel>();
            CreateMap<Company, AddEmployeeModel>()
                .ForMember(dest => dest.employeeID, opt => opt.MapFrom(src => src.CompanyCode))
                .ForMember(dest => dest.emailAddress, opt => opt.MapFrom(src => src.EmailAddress));
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
