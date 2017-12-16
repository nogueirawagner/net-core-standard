using Core.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Commands
{
  public class AtualizarEventoCommand : BaseEventoCommand
  {
    public AtualizarEventoCommand(Guid id, string pNome, string pDescricao, string pDescricaoCurta, DateTime pDataInicio, DateTime pDataFim,
      bool pGratuito, decimal pValor, bool pOnline, string pNomeEmpresa)
    {
      Id = id;
      Nome = pNome;
      Descricao = pDescricao;
      DescricaoCurta = pDescricaoCurta;
      DataInicio = pDataInicio;
      Valor = pValor;
      Gratuito = pGratuito;
      Online = pOnline;
      NomeEmpresa = pNomeEmpresa;
    }
  }
}
