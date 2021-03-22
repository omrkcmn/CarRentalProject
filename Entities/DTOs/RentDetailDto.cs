using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentDetailDto : IDTo
    {
        public string userName { get; set; }
        public string userLastName { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime returnDate { get; set; }
        public string carDescription { get; set; }
        public string email { get; set; }
    }
}
