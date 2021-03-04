using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDTo
    {
        public int CarId { get; set; }
        public string carName { get; set; }
        public string colorName { get; set; }
        public string brandName { get; set; }
    }
}