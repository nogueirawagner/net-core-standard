using Core.Application.ViewModels;
using Core.Domain.Models.Organizadores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.Interfaces
{
  public interface IOrganizadorServices : IDisposable
  {
    void Registrar(OrganizadorViewModel organizadorViewModel);
  }
}
