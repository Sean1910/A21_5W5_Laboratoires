using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class CountryController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public CountryController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
      IEnumerable<Country> CountryList = _unitOfWork.Country.GetAll();
      
      return View(CountryList);
    }

    public IActionResult Upsert(int? id)
    {
      Country country = new Country();
      if (id == null)
      {
        // Create
        return View(country);
      }
      // Update
      country = _unitOfWork.Country.Get(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }
      return View(country);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public  IActionResult Upsert(Country country)
    {
      if (ModelState.IsValid)
      {
        if (country.Id == 0)
        {
         _unitOfWork.Country.Add(country);

        }
        else
        {
          _unitOfWork.Country.Update(country);
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      return View(country);
    }

    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var country = _unitOfWork.Country.Get(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }

      return View(country);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var country = _unitOfWork.Country.Get(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }
      TempData["Success"] = "Delete completed successfully";
      _unitOfWork.Country.Remove(country);
      _unitOfWork.Save();
      return RedirectToAction("Index");
    }

  }
}
