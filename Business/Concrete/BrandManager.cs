using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        Brand _brand;
        public void Add(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetAllById()
        {
            throw new NotImplementedException();
        }

        public void Update(int BrandId)
        {
            throw new NotImplementedException();
        }
    }
}
