using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jungle_Models
{
  public class Country

  {
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }

    //Propriété de navigation 1 à plusieurs
    public List<Destination> Destination { get; set; }
  }
}
