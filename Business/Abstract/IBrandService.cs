using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<List<Brand>> GetAllById(int id);

        IResult Add(Brand brand);
        IResult Delete(Brand brandId);

        IResult Update(Brand BrandId);
    }
}
