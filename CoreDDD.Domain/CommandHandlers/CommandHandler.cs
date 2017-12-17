using Core.Domain.Core.Bus;
using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;

namespace Core.Domain.CommandHandlers
{
  public abstract class CommandHandler
  {
    private readonly IUnitOfWork _uow;
    private readonly IBus _bus;

    public CommandHandler(IUnitOfWork uow, IBus bus)
    {
      _uow = uow;
      _bus = bus;
    }

    protected void NotificarValidacoesErro(ValidationResult validationResult)
    {
      foreach(var erro in validationResult.Errors)
      {
        var error = erro.ErrorMessage;
        _bus.RaiseEvent();
      }
    }

    protected bool Commit()
    {

      // Validar se há alguma validação de negócio com erro!

      var cmdResponse = _uow.Commit();
      if (cmdResponse.Success)
        return true;
      else
      {
        _bus.RaiseEvent();
        return false; // Ocorreu um erro ao salvar os dados no banco;
      }
        
    }
  }
}
