using System;
using System.ComponentModel.DataAnnotations;

namespace Jungle_Models
{
  public class TravelRecommendation
  {
    [Key]
    public int Id { get; set; }
    public string DangerLevel { get; set; }
  
    public string Description { get; set; }
    
    public string Type { get; set; }
  }
}
