using FluentValidation;
using FluentValidation.Results;
using System;

namespace Core.Domain.Core.Models
{
  // Como AbstractValidator precisa de alguma classe.
  // Então Entity implementa um generico e esse generico é passado para o AbstractValidator onde esse generico fosse alguma classe que herdasse de Entity.
  public abstract class XEntity<T> : AbstractValidator<T> where T : XEntity<T>
  {
    public XEntity()
    {
      ValidationResult = new ValidationResult();
    }

    public Guid Id { get; protected set; }
    public abstract bool EhValido();
    public ValidationResult ValidationResult { get; protected set; }

    public override bool Equals(object obj)
    {
      var compareTo = obj as XEntity<T>;
      if (ReferenceEquals(this, compareTo)) return true;
      if (ReferenceEquals(null, compareTo)) return false;

      return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(XEntity<T> a, XEntity<T> b)
    {
      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return true;

      if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        return false;

      return a.Equals(b);
    }

    public static bool operator !=(XEntity<T> a, XEntity<T> b)
    {
      return !(a == b);
    }

    public override int GetHashCode()
    {
      return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
      return GetType().Name + " [Id = " + Id + "]";
    }
  }
}
