using AutoMapper;
using Core.Application.Interfaces;
using Core.Application.ViewModels;
using Core.Domain.Core.Bus;
using Core.Domain.Organizadores.Commands;
using Core.Domain.Organizadores.Repository;

namespace Core.Application.Services
{
  public class OrganizadorServices : IOrganizadorServices
  {
    private readonly IBus _bus;
    private readonly IMapper _mapper;
    private readonly IOrganizadorRepository _organizadorRepository;

    public OrganizadorServices(IBus bus, IMapper mapper, IOrganizadorRepository organizadorRepository)
    {
      _bus = bus;
      _mapper = mapper;
      _organizadorRepository = organizadorRepository;
    }

    public void Registrar(OrganizadorViewModel organizadorViewModel)
    {
      var registroCommand = Mapper.Map<RegistrarOrganizadorCommand>(organizadorViewModel);
      _bus.SendCommand(registroCommand);
    }

    public void Dispose()
    {
      _organizadorRepository.Dispose();
    }
  }
}
