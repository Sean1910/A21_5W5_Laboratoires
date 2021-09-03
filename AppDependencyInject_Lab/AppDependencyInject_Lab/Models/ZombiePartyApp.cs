using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDependencyInject_Lab.Models
{
  public class ZombiePartyApp
  {
    public int Id { get; set; }
    [Required]
    public string Village { get; set; }
    [DataType(DataType.Date)]
    public DateTime AdventureDate { get; set; }
  }
}
