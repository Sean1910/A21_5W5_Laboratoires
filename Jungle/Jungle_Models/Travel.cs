using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jungle_Models
{
  public class Travel
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    [DataType(DataType.Text)] // Mettre aussi input type Text pour des text area avec format
    public string Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    [DisplayFormat(DataFormatString = "{0:c2}")] // Monetaire (currency)
    public double Price { get; set; }
    
    [DataType(DataType.Date)] //Mettre aussi le type de input
    public DateTime DepartureDate { get; set; }

    [Range(7,21)]
    public int Duration { get; set; }

    // Relation 1 à plusieurs, obligatoire
    [ForeignKey("Destination")]
    public int Destination_Id { get; set; }
    //Propriété de navigation 1 à plusieurs, côté 1
    public Destination Destination { get; set; }

    // Relation 1 à plusieurs, obligatoire
    [ForeignKey("Guide")]
    public int Guide_Id { get; set; }
    //Propriété de navigation 1 à plusieurs, côté 1
    public Guide Guide { get; set; }

    // Relation 1 à 1 facultative
    [ForeignKey("TravelRecommendation")]
    public int? TravelRecommendation_Id { get; set; }
    //Propriété de navigation 1 à 1
    public TravelRecommendation TravelRecommendation { get; set; }
  }
}
