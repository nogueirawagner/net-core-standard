using Core.Domain.Core.Models;
using System;

namespace Core.Domain.Models
{
  public class Tag : XEntity<Tag>
  {
    public Tag(Guid pId)
    {
      Id = pId;
    }
    public override bool EhValido()
    {
      throw new System.NotImplementedException();
    }
  }
}