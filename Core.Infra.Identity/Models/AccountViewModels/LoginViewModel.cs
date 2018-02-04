using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Infra.Identity.Models.AccountViewModels
{
  public class LoginViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string Password { get; set; }

    [HiddenInput(DisplayValue = false)]
    public bool RememberMe { get; set; }



    public KeyValuePair<int, int> MostPopularNumber(int[] numeros)
    {
      var max = (numeros.GroupBy(x => x)
      .Select(x => new { num = x, cnt = x.Count() })
      .OrderByDescending(g => g.cnt)
      .Select(g => g.num).First());

      return new KeyValuePair<int, int>(max.Key, max.Count());
    }




  }






}
