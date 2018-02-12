using Core.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Core.Application.Interfaces
{
  public interface IEventoServices : IDisposable
  {
    void Registrar(EventoViewModel eventoViewModel);
    IEnumerable<EventoViewModel> ObterTodos();
    IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId);
    EventoViewModel ObterPorId(Guid id);
    void Atualizar(EventoViewModel eventoViewModel);
    void Excluir(Guid id);
    void AdicionarEndereco(EnderecoViewModel enderecoViewModel);
    void AtualizarEndereco(EnderecoViewModel enderecoViewModel);
    EnderecoViewModel ObterEnderecoPorId(Guid id);
  }
}
