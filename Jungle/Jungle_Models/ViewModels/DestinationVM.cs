using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_Models.ViewModels
{
  public class DestinationVM
  {
    public Destination Destination { get; set; }
    public IEnumerable<SelectListItem> CountryList { get; set; }
  }
}
