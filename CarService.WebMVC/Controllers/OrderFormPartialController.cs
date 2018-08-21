using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.BusinessLayer.Interfaces;
using CarService.Shared.Models;
using CarService.WebMVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebMVC.Controllers
{
    

    public class OrderFormPartialController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<OrderDetailDto> _orderDetailService;
        private readonly IService<CarTypeDto> _carTypeService;

        public OrderFormPartialController(IMapper mapper, 
            IService<OrderDetailDto> orderDetailService, 
            IService<CarTypeDto> carTypeService)
        {
            _mapper = mapper;
            _orderDetailService = orderDetailService;
            _carTypeService = carTypeService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new OrderDetailViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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