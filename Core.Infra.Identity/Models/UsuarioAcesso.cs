using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Infra.Identity.Models
{
  public class UsuarioAcesso : IUser
  {
    private IHttpContextAccessor _accessor;

    public UsuarioAcesso(IHttpContextAccessor accessor)
    {
      _accessor = accessor;
    }

    public string Nome => _accessor.HttpContext.User.Identity.Name;

    public IEnumerable<Claim> GetClaimsIdentity()
    {
      return _accessor.HttpContext.User.Claims;
    }

    public Guid GetUserId()
    {
      return IsAuthenticated() ? Guid.Parse(_accessor.HttpContext.User.GetUserId()) : Guid.NewGuid();
    }

    public bool IsAuthenticated()
    {
      return _accessor.HttpContext.User.Identity.IsAuthenticated;

    }
  }
}
