using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.Eventos.Events
{
  public class EventoAtualizadoEvent : BaseEventoEvent
  {
    public EventoAtualizadoEvent(Guid id, string pNome, string pDescricao, string pDescricaoCurta, DateTime pDataInicio, DateTime pDataFim,
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

      AggregateId = id;
    }
  }
}
