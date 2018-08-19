using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CarService.DataAccessLayer.Interfaces;

namespace CarService.DataAccessLayer.Entities
{
    public class CarType : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Model { get; set; }
    }
}
