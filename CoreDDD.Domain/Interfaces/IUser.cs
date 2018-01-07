using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Domain.Interfaces
{
  public interface IUser
  {
    string Nome { get; }
    Guid GetUserId();
    bool IsAuthenticated();
    IEnumerable<Claim> GetClaimsIdentity();

  }
}
