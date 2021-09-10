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
  public class DestinationController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public DestinationController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
      IEnumerable<Destination> DestinationList = _unitOfWork.Destination.GetAll();
      
      return View(DestinationList);
    }

    public IActionResult Upsert(int? id)
    {
      Destination destination = new Destination();
      if (id == null)
      {
        // Create
        return View(destination);
      }
      // Update
      destination = _unitOfWork.Destination.Get(id.GetValueOrDefault());
      if (destination == null)
      {
        return NotFound();
      }
      return View(destination);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public  IActionResult Upsert(Destination destination)
    {
      if (ModelState.IsValid)
      {
        if (destination.Id == 0)
        {
         _unitOfWork.Destination.Add(destination);

        }
        else
        {
          _unitOfWork.Destination.Update(destination);
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }
      return View(destination);
    }

  }
}
