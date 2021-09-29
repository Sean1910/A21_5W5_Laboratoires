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

    public IActionResult Index()
    {
      IEnumerable<Destination> DestinationList = _unitOfWork.Destination.GetAll(includeProperties:"Country");
      
      return View(DestinationList);
    }

    public IActionResult Upsert(int? id)
    {
      IEnumerable<Country> CouList =  _unitOfWork.Country.GetAll();
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
      destinationVM.Destination = _unitOfWork.Destination.Get(id.GetValueOrDefault());
      if (destinationVM.Destination == null)
      {
        return NotFound();
      }
      return View(destinationVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(DestinationVM destinationVM)
    {
      if (ModelState.IsValid)
      {
        if (destinationVM.Destination.Id == 0)
        {
          _unitOfWork.Destination.Add(destinationVM.Destination);
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
        IEnumerable<Country> CouList = _unitOfWork.Country.GetAll();
        destinationVM.CountryList = CouList.Select(i => new SelectListItem
        {
          Text = i.Name,
          Value = i.Id.ToString()
        });

        if (destinationVM.Destination.Id != 0)
        {
          TempData["Error"] = "Error while updating destination";
          destinationVM.Destination = _unitOfWork.Destination.Get(destinationVM.Destination.Id);
        }
      }
      return View(destinationVM);
    }


   
    public IActionResult Delete(int? id)
    {
      if (id == null || id == 0)
      {
        return NotFound();
      }
      var dest = _unitOfWork.Destination.Get(id.GetValueOrDefault());
      if (dest == null)
      {
        return NotFound();
      }

      return View(dest);
    }

    //POST - DELETE
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeletePost(int? id)
    {
      var dest = _unitOfWork.Destination.Get(id.GetValueOrDefault());
      if (dest == null)
      {
        return NotFound();
      }
      TempData["Success"] = "Delete completed successfully";
      _unitOfWork.Destination.Remove(dest);
      _unitOfWork.Save();
      return RedirectToAction("Index");
    }
  }
}
