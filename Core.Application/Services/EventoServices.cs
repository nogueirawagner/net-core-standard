using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Application.ViewModels;
using Core.Domain.Core.Bus;
using Core.Domain.Eventos.Commands;
using AutoMapper;
using Core.Domain.Eventos.Repository;

namespace Core.Application.Services
{
  public class EventoServices : IEventoServices
  {
    private readonly IBus _bus;
    private readonly IMapper _mapper;
    private readonly IEventoRepository _eventoRepository;

    public EventoServices(IBus bus, IMapper mapper, IEventoRepository eventoRepository)
    {
      _eventoRepository = eventoRepository;
      _mapper = mapper;
      _bus = bus;
    }
    public void Registrar(EventoViewModel eventoViewModel)
    {
      var registroCommando = Mapper.Map<RegistrarEventoCommand>(eventoViewModel);
      _bus.SendCommand(registroCommando);
    }

    public EventoViewModel ObterPorId(Guid id)
    {
      return _mapper.Map<EventoViewModel>(_eventoRepository.ObterPorId(id));
    }

    public IEnumerable<EventoViewModel> ObterTodos()
    {
      return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterTodos());
    }

    public void Atualizar(EventoViewModel eventoViewModel)
    {
      // TODO: Validar se organizador é dono do evento

      var atualizarEventoCommand = _mapper.Map<AtualizarEventoCommand>(eventoViewModel);
      _bus.SendCommand(atualizarEventoCommand);
    }

    public void Excluir(Guid id)
    {
      _bus.SendCommand(new ExcluirEventoCommand(id));
    }

    public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
    {
      return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterEventoPorOrganizador(organizadorId));
    }

    public void Dispose()
    {
      _eventoRepository.Dispose();
    }
  }
}
