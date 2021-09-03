using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppDependencyInject_Lab.Models;
using AppDependencyInject_Lab.Models.ViewModels;

namespace AppDependencyInject_Lab.Controllers
{
  public class HomeController : Controller
  {
    public HomeVM homeVM { get; set; }
    // Ajouter la propriété du ZombieForecaster ici version 1



    // Ajouter les propriétés multi-services (Stripe, twilio et waze) Version séparés ici
    // le type: classes Utility



    public HomeController()
    {
      homeVM = new HomeVM();

    }


    public IActionResult Index()
    {
     // Version 1 injection dans le contructeur Action Index, récupérer le résultat

     
      return View();
    }

    #region Action AllConfigSetting version du constructeur muli-services
   

    #endregion

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
