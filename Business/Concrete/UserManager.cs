using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _iUserDal;
        public UserManager(IUserDal iUserDal)
        {
            this._iUserDal = iUserDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _iUserDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _iUserDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll());
            
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_iUserDal.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            _iUserDal.Update(user);
            return new SuccessResult();
        }
    }
}
