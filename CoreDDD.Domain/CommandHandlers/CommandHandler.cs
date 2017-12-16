using Eventos.IO.Domain.Interfaces;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.CommandHandlers
{
  public abstract class CommandHandler
  {

    public CommandHandler(IUnitOfWork uow)
    {
      _uow = uow;
    }

    private readonly IUnitOfWork _uow;

    protected void NotificarValidacoesErro(ValidationResult validationResult)
    {
      foreach(var erro in validationResult.Errors)
      {
        var error = erro.ErrorMessage;
      }
    }

    protected bool Commit()
    {

      // Validar se há alguma validação de negócio com erro!

      var cmdResponse = _uow.Commit();
      if (cmdResponse.Success)
        return true;
      else
        return false; // Ocorreu um erro ao salvar os dados no banco;
    }
  }
}
