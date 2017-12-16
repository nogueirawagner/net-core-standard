using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.CommandHandlers
{
  public abstract class CommandHandler
  {
    protected void NotificarValidacoesErro(ValidationResult validationResult)
    {
      foreach(var erro in validationResult.Errors)
      {
        var error = erro.ErrorMessage;
      }
    }
  }
}
