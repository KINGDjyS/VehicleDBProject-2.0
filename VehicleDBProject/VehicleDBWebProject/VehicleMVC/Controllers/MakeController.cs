using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VehicleMVC.Models;
using VehicleService;

namespace VehicleMVC.Controllers
{
    public class MakeController : Controller
    {
        private readonly IVehicleMakeService MakeService;
        private readonly IMapper Mapper;
        public static int NumberOfElements = 3;
        public static int ElementsGot = 0;
        public static int CurrentPage = 1;
        public static string CurrentOrder;
        public static string CurrentSort;


        public MakeController(IVehicleMakeService makeService, IMapper mapper)
        {
            MakeService = makeService;
            Mapper = mapper;
        }

        public IActionResult Index([Bind("SearchName")] Filtering makeFiltering, Sorting sorting, Paging paging)
        {
            if(paging.PageNumber == 1)
            {
                ViewBag.OrderBy = sorting.OrderBy == "DESC" ? "ASC" : "DESC";
                CurrentOrder = sorting.OrderBy;
                CurrentSort = sorting.SortBy;
            }

            if (String.IsNullOrEmpty(sorting.SortBy))
            {
                sorting.SortBy = "Name";
                sorting.OrderBy = "ASC";
            }

            paging.TotalPages = MakeService.CountMakers();
            
            CurrentPage = paging.PageNumber;
            ElementsGot = paging.Elements;
            #region HasNextButton
            if ((ElementsGot + NumberOfElements) < paging.TotalPages)
            {
                ViewBag.HasNext = true;
            }
            else
            {
                ViewBag.HasNext = false;
            }
            #endregion
            #region HasPrevButton
            if (paging.HasPreviousPage)
            {
                ViewBag.HasPrevious = true;
            }
            else
            {
                ViewBag.HasPrevious = false;
            }
            #endregion
            #region Search
            if (!String.IsNullOrEmpty(makeFiltering.SearchName))
            {
                if (!MakeService.HasNameInDatabase(makeFiltering.SearchName))
                {
                    return NotFound(makeFiltering.SearchName + " not Found");
                }
                string countQuery = String.Format("SELECT * FROM dbo.VehicleMakers Where Name = '{0}'", makeFiltering.SearchName);
                paging.TotalPages = MakeService.GetVehicleMakes(countQuery).Count();
                ElementsGot = 0;
                string searchQuery = String.Format("SELECT * FROM dbo.VehicleMakers Where Name = '{0}' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", makeFiltering.SearchName, sorting.SortBy, sorting.OrderBy, ElementsGot, NumberOfElements);
                var searchMake = MakeService.GetVehicleMakes(searchQuery).Select(Mapper.Map<VehicleMakeDTO>);
                #region HasNextButton
                if ((ElementsGot + NumberOfElements) < paging.TotalPages)
                {
                    ViewBag.HasNext = true;
                }
                else
                {
                    ViewBag.HasNext = false;
                }
                #endregion
                #region HasPrevButton
                if (paging.HasPreviousPage)
                {
                    ViewBag.HasPrevious = true;
                }
                else
                {
                    ViewBag.HasPrevious = false;
                }
                #endregion
                return View(searchMake);
            }
            #endregion
            string query = String.Format("SELECT * FROM dbo.VehicleMakers ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", sorting.SortBy, sorting.OrderBy, ElementsGot, NumberOfElements);
            var make = MakeService.GetVehicleMakes(query).Select(Mapper.Map<VehicleMake, VehicleMakeDTO>);
            return View(make);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleMakeDTO makeDTO)
        {
            if (ModelState.IsValid)
            {
                var vehicleMake = Mapper.Map<VehicleMake>(makeDTO);
                await MakeService.AddVehicleMakerAsync(vehicleMake);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!MakeService.MakeIdExist(id))
            {
                return NotFound();
            }
            VehicleMakeDTO makeDTO = Mapper.Map<VehicleMakeDTO>(await MakeService.GetOneVehicleMakerAsync(id));
            return View(makeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleMakeDTO vehicleMakeDTO)
        {
            VehicleMake make = Mapper.Map<VehicleMake>(vehicleMakeDTO);
            await MakeService.UpdateAsync(make);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            await MakeService.DeleteVehicleMakerAsync(id);
            
            return RedirectToAction(nameof(Index));
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
