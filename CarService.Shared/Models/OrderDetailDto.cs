using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Interfaces;

namespace CarService.Shared.Models
{
    public class OrderDetailDto : IModelDto
    {
        public Guid Id { get; set; }
        public DateTime DataFirst { get; set; }
        public DateTime TimeFirst { get; set; }
        public DateTime DataSecond { get; set; }
        public DateTime TimeSecond { get; set; }
        public bool Transmission { get; set; }
        public bool VehicleMaintenance { get; set; }
        public bool VehicleRapair { get; set; }
        public bool Other { get; set; }
        public string YearOfCar { get; set; }
        public CarTypeDto SelectedCarType { get; set; }
        public string OrderMessage { get; set; }
        public UserDetailDto UserDetail { get; set; }
    }
}
