using Autofac;
using AutoMapper;
using eBank.Business.DTO.DTO;
using eBank.Business.Interfaces;
using eBank.Business.Services;
using eBank.Domain.Interfaces.Repositories;
using eBank.Domain.Interfaces.Services;
using eBank.Domain.Models;
using eBank.Domain.Services;
using eBank.Infra.Repository;
using System.Collections.Generic;

namespace eBank.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC Application

            builder.RegisterType<BusinessServiceManagementBank>().As<IBusinessServiceManagementBank>();
            builder.RegisterType<BusinessServiceManagementAccount>().As<IBusinessServiceManagementAccount>();
            builder.RegisterType<BusinessServiceManagementOwner>().As<IBusinessServiceManagementOwner>();

            #endregion

            #region IOC Services

            builder.RegisterType<ServiceBank>().As<IServiceBank>();
            builder.RegisterType<ServiceAccount>().As<IServiceAccount>();
            builder.RegisterType<ServiceOwner>().As<IServiceOwner>();

            #endregion

            #region IOC Repositorys SQL

            builder.RegisterType<RepositoryBank>().As<IRepositoryBank>();
            builder.RegisterType<RepositoryAccount>().As<IRepositoryAccount>();
            builder.RegisterType<RepositoryOwner>().As<IRepositoryOwner>();

            #endregion

            #region IOC Mapper

            builder.Register(context => new MapperConfiguration(cfg =>
            {

                #region Bank
                cfg.CreateMap<Bank, BankDTO>();
                cfg.CreateMap<BankDTO, Bank>();
                cfg.CreateMap<List<BankDTO>, List<Bank>>();
                cfg.CreateMap<List<Bank>, List<BankDTO>>();
                #endregion

                #region Account
                cfg.CreateMap<Account, AccountDTO>();
                cfg.CreateMap<AccountDTO, Account>();
                cfg.CreateMap<List<AccountDTO>, List<Account>>();
                cfg.CreateMap<List<Account>, List<AccountDTO>>();
                #endregion

                #region Owner
                cfg.CreateMap<Owner, OwnerDTO>();
                cfg.CreateMap<OwnerDTO, Owner>();
                cfg.CreateMap<List<OwnerDTO>, List<Owner>>();
                cfg.CreateMap<List<Owner>, List<OwnerDTO>>();
                #endregion


            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            #endregion
        }
    }
}
