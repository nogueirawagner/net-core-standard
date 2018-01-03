using AutoMapper;
using Core.Application.ViewModels;
using Core.Domain.Models.Eventos;
using Core.Domain.Models.Organizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.AutoMapper
{
  public class DomainToViewModelMappingProfile : Profile
  {
    public DomainToViewModelMappingProfile()
    {
      CreateMap<Evento, EventoViewModel>();
      CreateMap<Endereco, EnderecoViewModel>();
      CreateMap<Categoria, CategoriaViewModel>();
      CreateMap<Organizador, OrganizadorViewModel>();
    }
  }
}
