using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetAllById();

        void Add(Brand brand);
        void Delete(int brandId);

        void Update(int BrandId);
    }
}
