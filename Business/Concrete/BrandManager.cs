using Business.Abstract;
using Business.BusinessAspect.Autofac;
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

        //[SecuredOperation("brand.add,admin")]
        public IResult Add(Brand brand)
        {
            _brand.Add(brand);
            return new SuccessResult();
        }
        //[SecuredOperation("brand.delete,admin")]
        public IResult Delete(Brand brandId)
        {
            _brand.Delete(brandId);
            return new SuccessResult();
        }
        //[SecuredOperation("brand.getall,admin")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll());
        }
        //[SecuredOperation("brand.getallbyid,admin")]
        public IDataResult<List<Brand>> GetAllById(int id)
        {
            return new DataResult<List<Brand>>(_brand.GetAll(b => b.BrandId == id), true, Messages.UserListed);
        }
        //[SecuredOperation("brand.update,admin")]
        public IResult Update(Brand BrandId)
        {
            _brand.Update(BrandId);
            return new SuccessResult();
        }
    }
}
