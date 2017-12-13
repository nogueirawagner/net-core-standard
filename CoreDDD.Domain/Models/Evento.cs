using Core.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Domain.Models
{
  public class Evento : XEntity<Evento>
  {
    public Evento(string pNome, string pDescricao, DateTime pDataInicio, DateTime pDataFim,
      bool pGratuito, decimal pValor, bool pOnline, string pNomeEmpresa)
    {
      Id = Guid.NewGuid();
      Nome = pNome;
      Descricao = pDescricao;
      DataInicio = pDataInicio;
      Valor = pValor;
      Gratuito = pGratuito;
      Online = pOnline;
      NomeEmpresa = pNomeEmpresa;
    }

    public string Nome { get; private set; }
    public string DescricaoCurta { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataInicio { get; private set; }
    public DateTime DataFim { get; private set; }
    public bool Gratuito { get; private set; }
    public decimal Valor { get; private set; }
    public bool Online { get; private set; }
    public string NomeEmpresa { get; private set; }
    public Categoria Categoria { get; private set; }
    public Guid? CategoriaId { get; private set; }
    public ICollection<Tag> Tags { get; private set; }
    public Endereco Endereco { get; private set; }
    public Guid? EnderecoId { get; private set; }
    public Organizador Organizador { get; private set; }
    public Guid OrganizadorId { get; private set; }

    public override bool EhValido()
    {
      Validar();
      return ValidationResult.IsValid;
    }

    private void Validar()
    {
      ValidarNome();
      ValidarValor();
      ValidarData();
      ValidarLocal();
      ValidarNomeEmpresa();
      ValidationResult = Validate(this);
    }

    private void ValidarNome()
    {
      RuleFor(c => c.Nome)
        .NotEmpty().WithMessage("O nome do evento não pode ser vazio")
        .Length(3, 150).WithMessage("O nome deve conter entre 3 e 150 caracteres");
    }

    private void ValidarValor()
    {
      if (!Gratuito)
        RuleFor(c => c.Valor)
          .ExclusiveBetween(1, 4000)
          .WithMessage("O valor deve estar entre 1.00 e 100.0000");

      if (Gratuito)
        RuleFor(c => c.Valor)
          .ExclusiveBetween(0, 0).When(e => e.Gratuito)
          .WithMessage("O valor deve ser zero para evento gratuito");
    }

    private void ValidarData()
    {
      RuleFor(c => c.DataInicio)
        .GreaterThan(c => c.DataFim)
        .WithMessage("A data início deve ser maior que a data final do evento");

      RuleFor(c => c.DataInicio)
        .LessThan(DateTime.Now)
        .WithMessage("A data início não deve ser menor que a data atual");
    }

    private void ValidarLocal()
    {
        RuleFor(c => c.Endereco)
          .Null().When(c => c.Online)
          .WithMessage("O evento não deve possuir um endereço se for online");

        RuleFor(c => c.Endereco)
          .NotNull().When(c => !c.Online)
          .WithMessage("O evento deve possuir um endereço");
    }

    private void ValidarNomeEmpresa()
    {
      RuleFor(c => c.NomeEmpresa)
        .NotEmpty().WithMessage("O nome do organizador precisa ser fornecido")
        .Length(2, 150).WithMessage("O nome do organizador precisa ter entre 2 e 150 caracteres");
    }
  }
}
