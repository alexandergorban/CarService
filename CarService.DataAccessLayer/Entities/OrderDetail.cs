using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CarService.DataAccessLayer.Interfaces;

namespace CarService.DataAccessLayer.Entities
{
    public class OrderDetail : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime DataFirst { get; set; }
        public DateTime TimeFirst { get; set; }

        [Required]
        public DateTime DataSecond { get; set; }
        public DateTime TimeSecond { get; set; }
        public bool Transmission { get; set; }
        public bool VehicleMaintenance { get; set; }
        public bool VehicleRapair { get; set; }
        public bool Other { get; set; }
        public string YearOfCar { get; set; }
        public CarType SelectedCarType { get; set; }
        public string OrderMessage { get; set; }

        [Required]
        public UserDetail UserDetail { get; set; }
    }
}
