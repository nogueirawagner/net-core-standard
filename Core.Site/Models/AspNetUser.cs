using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Site.Models
{
  public class AspNetUser : IUser
  {
    private IHttpContextAccessor _accessor;

    public AspNetUser(IHttpContextAccessor accessor)
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
