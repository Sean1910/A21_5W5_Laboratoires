using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jungle_Models
{
  public class Guide
  {
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(25)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(25)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(50)]
    public string Speciality { get; set; }

    //Propriété de navigation 1 à plusieurs
    public List<Travel> Travel { get; set; }
  }
}
