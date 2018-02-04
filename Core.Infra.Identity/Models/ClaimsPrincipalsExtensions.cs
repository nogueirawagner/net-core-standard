using System;
using System.Security.Claims;

namespace Core.Infra.Identity.Models
{
  public static class ClaimsPrincipalsExtensions
  {
    public static string GetUserId(this ClaimsPrincipal principal)
    {
      if(principal == null)
      {
        throw new ArgumentException(nameof(principal));
      }
      var claim = principal.FindFirst(ClaimTypes.NameIdentifier);
      return claim?.Value;
    }

  }
}
