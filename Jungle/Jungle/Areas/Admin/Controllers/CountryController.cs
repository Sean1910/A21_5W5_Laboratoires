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

    public async Task<IActionResult> Index()
    {
      IEnumerable<Country> CountryList = await _unitOfWork.Country.GetAllAsync();
      
      return View(CountryList);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
      Country country = new Country();
      if (id == null)
      {
        // Create
        return View(country);
      }
      // Update
      country = await _unitOfWork.Country.GetAsync(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }
      return View(country);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Country country)
    {
      if (ModelState.IsValid)
      {
        if (country.Id == 0)
        {
        await _unitOfWork.Country.AddAsync(country);

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

    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var country = await _unitOfWork.Country.GetAsync(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }

      return View(country);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
      var country = await _unitOfWork.Country.GetAsync(id.GetValueOrDefault());
      if (country == null)
      {
        return NotFound();
      }
      TempData["Success"] = "Delete completed successfully";
      await _unitOfWork.Country.RemoveAsync(country);
      _unitOfWork.Save();
      return RedirectToAction("Index");
    }

  }
}
