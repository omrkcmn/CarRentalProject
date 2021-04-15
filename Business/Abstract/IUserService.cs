using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetUserById(int id);
        IDataResult<List<User>> GetCarByRentUserId(int id);
    }
}