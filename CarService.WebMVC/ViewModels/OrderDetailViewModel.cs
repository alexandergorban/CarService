using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarService.BusinessLayer.Interfaces;
using CarService.Shared.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarService.WebMVC.ViewModels
{
    public class OrderDetailViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataFirst { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeFirst { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataSecond { get; set; }

        [DataType(DataType.Time)]
        public DateTime TimeSecond { get; set; }

        [Display(Name = "Transmission")]
        public bool Transmission { get; set; }

        [Display(Name = "Vehicle Maintenance")]
        public bool VehicleMaintenance { get; set; }

        [Display(Name = "Vehicle Rapair")]
        public bool VehicleRapair { get; set; }

        [Display(Name = "Other")]
        public bool Other { get; set; }


        public string YearOfCar { get; set; }

        [Display(Name = "Selected Car Type")]
        public int SelectedCarType { get; set; }
        public IEnumerable<SelectListItem> CarTypes { get; set; }

        public string OrderMessage { get; set; }

        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [StringLength(75)]
        public string SecondName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EMail { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
