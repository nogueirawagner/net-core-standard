﻿using Core.Domain.Core.Commands;
using System;

namespace Core.Domain.Eventos.Commands
{
  public abstract class BaseEventoCommand : Command
  {
    public Guid Id { get; protected set; }
    public string Nome { get; protected set; }
    public string Descricao { get; protected set; }
    public string DescricaoCurta { get; protected set; }
    public DateTime DataInicio { get; protected set; }
    public DateTime DataFim { get; protected set; }
    public bool Gratuito { get; protected set; }
    public decimal Valor { get; protected set; }
    public bool Online { get; protected set; }
    public string NomeEmpresa { get; protected set; }
  }
}
