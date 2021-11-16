using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using Jungle_Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jungle.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class DestinationController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public DestinationController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
      IEnumerable<Destination> DestinationList = await _unitOfWork.Destination.GetAllAsync(includeProperties:"Country");
      
      return View(DestinationList);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
      IEnumerable<Country> CouList = await _unitOfWork.Country.GetAllAsync();
      DestinationVM destinationVM = new DestinationVM()
      {
        Destination = new Destination(),
        CountryList = CouList.Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        })
      };
      if (id == null)
      {
        //this is for create
        return View(destinationVM);
      }
      //this is for edit
      destinationVM.Destination = await _unitOfWork.Destination.GetAsync(id.GetValueOrDefault());
      if (destinationVM.Destination == null)
      {
        return NotFound();
      }
      return View(destinationVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(DestinationVM destinationVM)
    {
      if (ModelState.IsValid)
      {
        if (destinationVM.Destination.Id == 0)
        {
          await _unitOfWork.Destination.AddAsync(destinationVM.Destination);
          TempData["Success"] = "The destination added successfully";
        }
        else
        {
          _unitOfWork.Destination.Update(destinationVM.Destination);
          TempData["Success"] = "The destination updated successfully";
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      else
      {
        TempData["Error"] = "Error while creating destination";
        IEnumerable<Country> CouList = await _unitOfWork.Country.GetAllAsync();
        destinationVM.CountryList = CouList.Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        });

        if (destinationVM.Destination.Id != 0)
        {
          TempData["Error"] = "Error while updating destination";
          destinationVM.Destination = await _unitOfWork.Destination.GetAsync(destinationVM.Destination.Id);
        }
      }
      return View(destinationVM);
    }



    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var dest = await _unitOfWork.Destination.GetAsync(id.GetValueOrDefault());
      if (dest == null)
      {
        return NotFound();
      }

      return View(dest);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
      var dest = await _unitOfWork.Destination.GetAsync(id.GetValueOrDefault());
      if (dest == null)
      {
        return NotFound();
      }
      TempData["Success"] = "Delete completed successfully";
      await _unitOfWork.Destination.RemoveAsync(dest);
      _unitOfWork.Save();
      return RedirectToAction("Index");
    }
  }
}
