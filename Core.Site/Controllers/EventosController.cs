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

namespace Core.Site.Controllers
{
  public class EventosController : Controller
  {
    private readonly IEventoServices _eventoServices;

    public EventosController(IEventoServices eventoServices)
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

      _eventoServices.Registrar(eventoViewModel);

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

      //TODO: Operaçao ocorreu com sucesso?

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
      return RedirectToAction("Index");
    }
  }
}
