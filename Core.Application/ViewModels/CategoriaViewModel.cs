using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Application.ViewModels
{
  public class CategoriaViewModel
  {
    [Key]
    public Guid Id { get; set; }
    public string Nome { get; set; }

    public SelectList Categorias()
    {
      return new SelectList(ListarCategorias(), "Id", "Nome");
    }

    public List<CategoriaViewModel> ListarCategorias()
    {
      var categorias = new List<CategoriaViewModel>()
      {
        new CategoriaViewModel(){Id = new Guid("874A1920-FE31-41C6-9B6E-2A3509E008A5"), Nome="Congresso"},
        new CategoriaViewModel(){Id = new Guid("D816D8BD-1249-4030-B080-EA3DD2017491"), Nome="Meetup"},
        new CategoriaViewModel(){Id = new Guid("8CC49990-E868-4A81-B7D9-3B3744973E6D"), Nome="Workshop"},
        new CategoriaViewModel(){Id = new Guid("F442A5A0-7565-4B38-9AC8-6FB2209D7B2E"), Nome="Vídeo Aula"}
      };
      return categorias;
    }
  }
}