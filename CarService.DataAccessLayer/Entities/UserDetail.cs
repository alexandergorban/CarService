using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CarService.DataAccessLayer.Interfaces;

namespace CarService.DataAccessLayer.Entities
{
    public class UserDetail : IEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [Required]
        [MaxLength(30)]
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
