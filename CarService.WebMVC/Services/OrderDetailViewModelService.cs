using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.BusinessLayer.Interfaces;
using CarService.Shared.Models;
using CarService.WebMVC.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarService.WebMVC.Services
{
    public class OrderDetailViewModelService
    {
        private readonly IService<CarTypeDto> _carTypeService;

        public OrderDetailViewModelService(IService<CarTypeDto> carTypeService)
        {
            _carTypeService = carTypeService;
        }

        public async Task<OrderDetailViewModel> CreateOrderDetail()
        {
            var orderDetailViewModel = new OrderDetailViewModel()
            {
                CarTypes = await GetCarTypes()
            };

            return orderDetailViewModel;
        }

        public async Task<IEnumerable<SelectListItem>> GetCarTypes()
        {
            var carTypeDtos = await _carTypeService.GetEntitiesAsync();
            List<SelectListItem> carTypeItems = new List<SelectListItem>();
            foreach (var carTypeDto in carTypeDtos)
            {
                carTypeItems.Add(new SelectListItem()
                {
                    Value = carTypeDto.ModelId.ToString(),
                    Text = carTypeDto.Model
                });
            }

            return carTypeItems;
        }
    }
}
