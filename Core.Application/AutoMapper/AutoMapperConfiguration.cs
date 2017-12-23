using AutoMapper;
using Core.Application.ViewModels;
using Core.Domain.Eventos.Commands;
using Core.Domain.Models.Eventos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.AutoMapper
{
  public class AutoMapperConfiguration
  {
    public static MapperConfiguration RegisterMappings()
    {
      return new MapperConfiguration(ps => 
      {
        ps.AddProfile(new DomainToViewModelMappingProfile());
        ps.AddProfile(new ViewModelToDomainMappingProfile());
      });
    }
  }
}
