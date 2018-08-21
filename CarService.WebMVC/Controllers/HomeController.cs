using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.BusinessLayer.Services;
using CarService.Shared.Models;
using CarService.WebMVC.Models;
using CarService.WebMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarService.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<OrderDetailDto> _orderDetailService;
        private readonly IService<CarTypeDto> _carTypeService;

        public HomeController(IMapper mapper, 
            IService<OrderDetailDto> orderDetailService, 
            IService<CarTypeDto> carTypeService)
        {
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _carTypeService = carTypeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(OrderDetailViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // todo fix dropdown
                model.SelectedCarType = 1;

                var orderDetailDto = _mapper.Map<OrderDetailViewModel, OrderDetailDto>(model);
                await _orderDetailService.AddEntityAsync(orderDetailDto);
            }


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ClearForm()
        {
            throw new System.NotImplementedException();
        }

        public IActionResult SendOrder()
        {
            throw new System.NotImplementedException();
        }
    }
}
