using System;
using System.Collections.Generic;
using System.Text;
using CarService.Shared.Interfaces;

namespace CarService.Shared.Models
{
    public class UserDetailDto : IModelDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
