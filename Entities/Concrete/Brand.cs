using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : IEntityCar
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
