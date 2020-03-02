using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleMVC.Models;
using VehicleService;

namespace VehicleMVC.Controllers
{
    public class ModelController : Controller
    {
        private readonly IVehicleModelService ModelService;
        private readonly IMapper Mapper;
        public static int NumberOfElements = 5;
        public static int ElementsGot = 0;
        public static int CurrentPage = 1;
        public static string CurrentOrder;
        public static string CurrentSort;

        public ModelController(IVehicleModelService modelService, IMapper mapper)
        {
            ModelService = modelService;
            Mapper = mapper;
        }
        public IActionResult Index([Bind("SearchName")] Filtering makeFiltering, Sorting sorting, Paging paging)
        {
            if (paging.PageNumber == 1)
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

            paging.TotalPages = ModelService.CountModels();

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
                if (!ModelService.HasNameInDatabase(makeFiltering.SearchName))
                {
                    return NotFound(makeFiltering.SearchName + " not Found");
                }
                string countQuery = String.Format("SELECT * FROM dbo.VehicleModels Where Name = '{0}'", makeFiltering.SearchName);
                paging.TotalPages = ModelService.GetVehicleModels(countQuery).Count();
                ElementsGot = 0;
                string searchQuery = String.Format("SELECT * FROM dbo.VehicleModels Where Name = '{0}' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", makeFiltering.SearchName, sorting.SortBy, sorting.OrderBy, ElementsGot, NumberOfElements);
                var searchMake = ModelService.GetVehicleModels(searchQuery).Select(Mapper.Map<VehicleModelDTO>);
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
            string query = String.Format("SELECT * FROM dbo.VehicleModels ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", sorting.SortBy, sorting.OrderBy, ElementsGot, NumberOfElements);
            var make = ModelService.GetVehicleModels(query).Select(Mapper.Map<VehicleModel, VehicleModelDTO>);
            return View(make);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Makers = ModelService.GetMakes();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(VehicleModelDTO vehicleModelDTO)
        {
            if (ModelState.IsValid)
            {
                var vehicleModel = Mapper.Map<VehicleModel>(vehicleModelDTO);
                await ModelService.AddVehicleModelAsync(vehicleModel);
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
            VehicleModelDTO modelDTO = Mapper.Map<VehicleModelDTO>(await ModelService.GetOneVehicleModelAsync(id));
            return View(modelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleModelDTO vehicleModelDTO)
        {
            VehicleModel model = Mapper.Map<VehicleModel>(vehicleModelDTO);
            await ModelService.UpdateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            await ModelService.DeleteVehicleModelAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}