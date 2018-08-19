using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Interfaces;

namespace CarService.Shared.Models
{
    public class CarTypeDto : IModelDto
    {
        public Guid Id { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
    }
}
