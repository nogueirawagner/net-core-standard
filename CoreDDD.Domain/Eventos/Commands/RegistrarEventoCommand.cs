using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Commands
{
  public class RegistrarEventoCommand : BaseEventoCommand
  {
    public RegistrarEventoCommand(string pNome, DateTime pDataInicio, DateTime pDataFim,
      bool pGratuito, decimal pValor, bool pOnline, string pNomeEmpresa)
    {
      Nome = pNome;
      DataInicio = pDataInicio;
      Valor = pValor;
      Gratuito = pGratuito;
      Online = pOnline;
      NomeEmpresa = pNomeEmpresa;
    }
  }
}
