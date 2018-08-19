using System;
using System.Collections.Generic;
using System.Text;

namespace CarService.DataAccessLayer.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
