using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models
{
  public class Destination
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(30)]
    public string Region { get; set; }

    // Relation 1 à plusieurs, obligatoire
    [ForeignKey("Country")]
    public int Country_Id { get; set; }
    //Propriété de navigation 1 à plusieurs, côté 1
    public Country Country {get; set;}

    //Propriété de navigation 1 à plusieurs
    public List<Travel> Travel { get; set; }
  }
}
