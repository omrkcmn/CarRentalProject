using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brand;
        public BrandManager(IBrandDal brandDal)
        {
            _brand = brandDal;
        }
        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brandId)
        {
            _brand.Delete(brandId);
            return new SuccessResult();
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brand.GetAll(), true, Messages.UserListed);
        }

        public IDataResult<List<Brand>> GetAllById(int id)
        {
            return new DataResult<List<Brand>>(_brand.GetAll(b => b.BrandId == id), true, Messages.UserListed);
        }

        public IResult Update(Brand BrandId)
        {
            _brand.Update(BrandId);
            return new SuccessResult();
        }
    }
}
