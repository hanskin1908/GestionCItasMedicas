using AutoMapper;
using MediatR;
using Recetas.Api.Controllers;
using Recetas.Application;
using Recetas.Application.Commands;
using Recetas.Application.DTOs;
using Recetas.Application.Queries;
using Recetas.Domain.Interfaces;
using Recetas.Infrastructure.Data;
using Recetas.Infrastructure.Repositories;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace Recetas.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Registro de DbContext
            container.RegisterType<RecetasDbContext>(new HierarchicalLifetimeManager());

            // Registro de repositorios
            container.RegisterType<IRecetaRepository, RecetaRepository>(new HierarchicalLifetimeManager());

            // Registro de MediatR
            container.RegisterType<IMediator, Mediator>(new HierarchicalLifetimeManager());
            //container.RegisterFactory<ServiceFactory>(c => type => c.Resolve(type));

            // Registro de Handlers de MediatR
            container.RegisterType<IRequestHandler<CreateRecetaCommand, RecetaDto>, CreateRecetaCommandHandler>();
            container.RegisterType<IRequestHandler<GetRecetaByCodigoQuery, RecetaDto>, GetRecetaByCodigoQueryHandler>();

            // Registro de AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = mapperConfig.CreateMapper();
            container.RegisterInstance(mapper);

            // Registro del controlador
            //container.RegisterType<RecetasController>(
            //    new InjectionConstructor(
            //        new ResolvedParameter<IMediator>()
            //    )
            //);

            // Configurar el resolver de dependencias de Unity en Web API
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}