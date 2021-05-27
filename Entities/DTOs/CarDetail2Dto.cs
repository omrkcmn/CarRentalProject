using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetail2Dto : IDTo
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ImagePath { get; set; }
        public string Color { get; set; }

    }
}
