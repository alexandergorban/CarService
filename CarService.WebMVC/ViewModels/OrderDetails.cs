using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarService.WebMVC.ViewModels
{
    public class OrderDetails
    {
       

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
        public string SelectedCarType { get; set; }
        public IEnumerable<SelectListItem> CarTypes { get; set; }


        public string OrderMessage { get; set; }


        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(75)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(20)]
        public string EMail { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
