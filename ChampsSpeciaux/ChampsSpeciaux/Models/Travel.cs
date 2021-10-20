using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChampsSpeciaux.Models
{
    public class Travel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string TravelImage { get; set; }
    }
}
