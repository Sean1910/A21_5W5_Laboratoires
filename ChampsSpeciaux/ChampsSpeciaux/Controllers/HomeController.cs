using ChampsSpeciaux.Repository.IRepository;
using ChampsSpeciaux.Data;
using ChampsSpeciaux.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChampsSpeciaux.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; 
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Travel> TravelList = await _unitOfWork.Travel.GetAllAsync();

            return View(TravelList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        public async Task<IActionResult> Create(Travel travel)
        {
            if (ModelState.IsValid)
            {
                // Ajouter à la BD
                await _unitOfWork.Travel.AddAsync(travel);

                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return this.View(travel);
        }

        //GET - EDIT
        public async Task<IActionResult> Edit(int? id)
        {
            Travel travel = new Travel();
            travel = await _unitOfWork.Travel.GetAsync(id.GetValueOrDefault());
            if (travel == null)
            {
                return NotFound();
            }
            return View(travel);
        }

        //POST - EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Travel travel)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Travel.Update(travel);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(travel);
        }


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
