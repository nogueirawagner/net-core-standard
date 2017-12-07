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
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public bool Gratuito { get; set; }
    public decimal Valor { get; set; }
    public bool Online { get; set; }

  }
}
