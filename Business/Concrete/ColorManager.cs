using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class ColorManager : IColorService
    {
        IColorDal _iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
           
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _iColorDal.Add(color);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            _iColorDal?.Delete(color);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            var result = _iColorDal.GetAll();
            return new SuccessDataResult<List<Color>>(result);
        }

        public IResult Update(Color color)
        {
            _iColorDal.Update(color);
            return new SuccessResult();
        }
    }
}
