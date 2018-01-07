using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Application.ViewModels;
using Core.Site.Data;
using Core.Application.Interfaces;
using Core.Domain.Core.Notifications;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Core.Site.Controllers
{
  [Authorize]
  public class EventosController : BaseController
  {
    private readonly IEventoServices _eventoServices;

    public EventosController(IEventoServices eventoServices,
                             IDomainNotificationHandler<DomainNotification> notifications,
                             IUser user)
      :base(notifications, user)
    {
      _eventoServices = eventoServices;
    }

    // GET: Eventos
    public IActionResult Index()
    {
      var eventos = _eventoServices.ObterTodos();
      return View(eventos);
    }

    // GET: Eventos/Details/5
    public IActionResult Details(Guid? id)
    {
      if (id == null)
        return NotFound();

      var eventoViewModel = _eventoServices.ObterPorId(id.Value);
      if (eventoViewModel == null)
        return NotFound();

      return View(eventoViewModel);
    }

    // GET: Eventos/Create
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EventoViewModel eventoViewModel)
    {
      if (!ModelState.IsValid) return View(eventoViewModel);

      eventoViewModel.OrganizadorId = OrganizadorId;
      _eventoServices.Registrar(eventoViewModel);

      ViewBag.Retorno = OperacaoValida() ? "success, Evento registrado com sucesso" 
                                         : "error, Ocorreu algum problema verifique as mensagens";
      return View(eventoViewModel);
    }

    // GET: Eventos/Edit/5
    public IActionResult Edit(Guid? id)
    {
      if (id == null)
        return NotFound();

      var eventoViewModel = _eventoServices.ObterPorId(id.Value);
      if (eventoViewModel == null)
        return NotFound();
      return View(eventoViewModel);
    }

    // POST: Eventos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EventoViewModel eventoViewModel)
    {
      if (!ModelState.IsValid) return View(eventoViewModel);
      _eventoServices.Atualizar(eventoViewModel);

      ViewBag.Retorno = OperacaoValida() ? "success, Evento atualizado com sucesso"
                                         : "error, Ocorreu algum problema verifique as mensagens";

      return View(eventoViewModel);
    }

    // GET: Eventos/Delete/5
    public IActionResult Delete(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var eventoViewModel = _eventoServices.ObterPorId(id.Value);
      if (eventoViewModel == null)
      {
        return NotFound();
      }

      return View(eventoViewModel);
    }

    // POST: Eventos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(Guid id)
    {
      _eventoServices.Excluir(id);

      ViewBag.Retorno = OperacaoValida() ? "success, Evento removido com sucesso"
                                         : "error, Ocorreu algum problema verifique as mensagens";

      return RedirectToAction("Index");
    }
  }
}
