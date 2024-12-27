using AutoMapper;
using Cita.Infrastructure.MessageBus;
using Cita.Infrastructure.Repositories;
using Citas.Application;
using Citas.Application.Commands;
using Citas.Application.DTOs;
using Citas.Application.Queries;
using Citas.Domain.Interfaces;
using Citas.Infrastructure.Data;
using MediatR;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace Citas.APi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registro de dependencias básicas
            container.RegisterType<CitasDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<ICitaRepository, CitaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMediator, Mediator>(new HierarchicalLifetimeManager());

            // Registrar Handlers manualmente
            container.RegisterType<IRequestHandler<CreateCitaCommand, CitaDto>, CreateCitaCommandHandler>();
            container.RegisterType<IRequestHandler<GetCitaByIdQuery, CitaDto>, GetCitaByIdQueryHandler>();

            // Configurar AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            container.RegisterInstance(mapperConfig.CreateMapper());

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}