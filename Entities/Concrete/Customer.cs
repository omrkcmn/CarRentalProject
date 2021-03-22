using Core.Entites;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Customer : IEntityCar
    {
        public int id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
