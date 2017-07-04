using AutoMapper;
using DPEP.Common.BLL.Helpers;
using DPEP.Common.BLL.Interfaces;
using DPEP.Common.BLL.Repositories;
using DPEP.Common.DAL.Entities;
using DPEP.Common.DAL.Identity;
using DPEP.Common.DAL.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq;
using System;

namespace DPEP.Common.BLL.ConfigServices
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UpdateInfoModel, AspNetUser>();
            CreateMap<AddUpModel, Company>()
                .ForMember(a => a.EmailAddress, a => a.MapFrom(src => src.emailAddress))
                .ForMember(a => a.CompanyCode, a => a.MapFrom(b => b.employeeID));

            CreateMap<IOptions<AppSettingModel>, AppSettingModel>();
            CreateMap<IUserRepository, UserRepository>();


            #region from ApplicationUser to TEntity
            CreateMap<ApplicationUser, UserModel>();

            CreateMap<ApplicationUser, AspNetUser>()
               .ForMember(a => a.DateCreated, a => a.MapFrom(b => b.CreatedDate));

            CreateMap<ApplicationUser, CreatedUserModel>();

            CreateMap<ApplicationUser, UserModel>();

            CreateMap<ApplicationUser, AccountModel>();
            #endregion

            #region  from TEntity to ApplicationUser
            CreateMap<AddUpModel, ApplicationUser>()
               .ForMember(c => c.CreatedDate, f => f.ResolveUsing(c => DateTime.UtcNow))
               .ForMember(c => c.UserName, f => f.ResolveUsing(c => c.emailAddress.Split('@')[0]));

            CreateMap<AccountModel, ApplicationUser>()
               .ForMember(c => c.CreatedDate, f => f.ResolveUsing(c => DateTime.UtcNow))
               .ForMember(c => c.UserName, f => f.ResolveUsing(c => c.Email.Split('@')[0]))
               .ForMember(c => c.IsActive, f => f.ResolveUsing(c => true));

            CreateMap<Company, ApplicationUser>()
                .ForMember(a => a.Email, a => a.MapFrom(b => b.EmailAddress))
                .ForMember(a => a.CompanyId,  a => a.MapFrom(b => b.CompanyCode));
            #endregion

            #region from AspNetUser to TEntity
            CreateMap<AspNetUser, UserDetails>();
               // .ForMember(a => a.CompanyCode, a => a.ResolveUsing(b => b.CompanyId.));
            #endregion

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
