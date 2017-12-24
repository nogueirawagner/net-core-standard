using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.Services;
using Core.Domain.Core.Bus;
using Core.Domain.Core.Events;
using Core.Domain.Core.Notifications;
using Core.Domain.Eventos.Commands;
using Core.Domain.Eventos.Events;
using Core.Infra.Bus;
using Core.Infra.Data.Context;
using Core.Infra.Data.Repository;
using Core.Infra.Data.UoW;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Infra.IoC
{
  public class NativeInjectorBootstraper
  {
    public static void RegisterServices(IServiceCollection services)
    {
      // Application
      services.AddSingleton(Mapper.Configuration);
      services.AddScoped<IMapper>(s => new Mapper(s.GetRequiredService<IConfigurationProvider>(), s.GetServices));
      services.AddScoped<IEventoServices, EventoServices>();

      // Domain - Commands
      services.AddScoped<IHandler<RegistrarEventoCommand>, EventoCommandHandler>();
      services.AddScoped<IHandler<AtualizarEventoCommand>, EventoCommandHandler>();
      services.AddScoped<IHandler<ExcluirEventoCommand>, EventoCommandHandler>();

      // Domain - Events
      services.AddScoped<IHandler<EventoRegistradoEvent>, EventoEventHandler>();
      services.AddScoped<IHandler<EventoAtualizadoEvent>, EventoEventHandler>();
      services.AddScoped<IHandler<EventoExcluidoEvent>, EventoEventHandler>();

      // Domain - Notifications
      services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

      // Infra - Data
      services.AddScoped<IEventoRepository, EventoRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<CoreContext>();
      services.AddScoped<IBus, InMemoryBus>();

      // 
    }
  }
}
