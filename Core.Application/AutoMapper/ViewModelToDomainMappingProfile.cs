using AutoMapper;
using Core.Application.ViewModels;
using Core.Domain.Eventos.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Application.AutoMapper
{
  public class ViewModelToDomainMappingProfile : Profile
  {
    public ViewModelToDomainMappingProfile()
    {
      CreateMap<EventoViewModel, RegistrarEventoCommand>()
        .ConstructUsing(s =>
            new RegistrarEventoCommand(s.Nome, s.Descricao, s.DescricaoCurta, s.DataInicio, s.DataFim, s.Gratuito, s.Valor,
              s.Online, s.NomeEmpresa, s.OrganizadorId, s.CategoriaId,
            new IncluirEnderecoCommand(s.Endereco.Id, s.Endereco.Logradouro, s.Endereco.Numero,
              s.Endereco.Bairro, s.Endereco.CEP, s.Endereco.Complemento,
              s.Endereco.Cidade, s.Endereco.Estado, s.Id)));

      CreateMap<EventoViewModel, AtualizarEventoCommand>()
        .ConstructUsing(s => new AtualizarEventoCommand(s.Id, s.Nome, s.Descricao, s.DescricaoCurta, s.DataInicio, s.DataFim, s.Gratuito, s.Valor,
              s.Online, s.NomeEmpresa, s.OrganizadorId, s.CategoriaId));

      CreateMap<EventoViewModel, ExcluirEventoCommand>()
        .ConstructUsing(s => new ExcluirEventoCommand(s.Id));
    }
  }
}
