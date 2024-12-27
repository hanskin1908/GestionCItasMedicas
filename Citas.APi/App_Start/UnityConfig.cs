using AutoMapper;
using Cita.Infrastructure.MessageBus;
using Cita.Infrastructure.Repositories;
using Citas.APi.Controllers;
using Citas.Application;
using Citas.Application.Commands;
using Citas.Application.DTOs;
using Citas.Application.Queries;
using Citas.Domain.Interfaces;
using Citas.Infrastructure.Data;
using MediatR;
using System;
using System.Linq;
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
            container.RegisterType<IRabbitMQPublisher, IRabbitMQPublisher>(new HierarchicalLifetimeManager());

            // Registrar IMediator
            container.RegisterType<IMediator, Mediator>(new HierarchicalLifetimeManager());

            // Registrar ServiceFactory (para versiones < 12 de MediatR)
            //container.RegisterFactory<ServiceFactory>(c =>
            //    type => (object)c.Resolve(type));

            // Registrar handlers
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            var allHandlers = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.GetInterfaces()
                             .Any(i => i.IsGenericType &&
                                       (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                                        i.GetGenericTypeDefinition() == typeof(INotificationHandler<>))))
                .ToList();

            foreach (var handler in allHandlers)
            {
                var implementedInterfaces = handler.GetInterfaces()
                                                    .Where(i => i.IsGenericType &&
                                                                (i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                                                                 i.GetGenericTypeDefinition() == typeof(INotificationHandler<>)))
                                                    .ToArray();

                foreach (var implementedInterface in implementedInterfaces)
                {
                    container.RegisterType(implementedInterface, handler, new HierarchicalLifetimeManager());
                }
            }

            // Configurar AutoMapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            container.RegisterInstance(mapperConfig.CreateMapper());

            // Establecer Unity como DependencyResolver
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
    }