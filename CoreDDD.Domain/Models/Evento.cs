using Core.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Models
{
  public class Evento : Entity
  {
    public string Nome { get; set; }
    public string DescricaoCurta { get; set; }
    public string Descricao { get; set; }
  }
}
