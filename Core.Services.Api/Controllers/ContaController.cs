using Core.Domain.Core.Bus;
using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
using Core.Domain.Organizadores.Commands;
using Core.Infra.Identity.Models;
using Core.Infra.Identity.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services.Api.Controllers
{
  public class ContaController : BaseController
  {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger _logger;
    private readonly IBus _bus;

    protected ContaController(
      UserManager<ApplicationUser> userManager,
      SignInManager<ApplicationUser> signInManager,
      ILoggerFactory loggerFactory,
      IBus bus,
      IDomainNotificationHandler<DomainNotification> notifications,
      IUser user)
      : base(notifications, user, bus)
    {

      _userManager = userManager;
      _signInManager = signInManager;
      _logger = loggerFactory.CreateLogger<ContaController>();
      _bus = bus;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("nova-conta")]
    public async Task<IActionResult> Registrar([FromBody] RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        NotificarErroModelInvalida();
        return Response(model);
      }

      var user = new ApplicationUser { UserName = model.Nome, Email = model.Email };
      var result = await _userManager.CreateAsync(user, model.Password);

      if (result.Succeeded)
      {
        var registroCommand = new RegistrarOrganizadorCommand(
          Guid.Parse(user.Id), model.Nome, model.CPF, model.Email);
        _bus.SendCommand(registroCommand);

        // Validação no domínio
        if (!OperacaoValida())
        {
          await _userManager.DeleteAsync(user);
          return Response(model);
        }

        _logger.LogInformation(1, "Usuário criado com sucesso");
        return Response(model);
      }

      AdicionaErrosIdentity(result);
      return Response(model);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("conta")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
      if (!ModelState.IsValid)
      {
        NotificarErroModelInvalida();
        return Response(model);
      }

      var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, true);

      if (result.Succeeded)
      {
        _logger.LogInformation(1, "Usuário logado com sucesso");
        return Response(model);
      }

      NotificarErro(result.ToString(), "Falha ao realizar login");
      return Response(model);
    }
  }
}
