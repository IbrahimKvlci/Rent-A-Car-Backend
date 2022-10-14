using Business.Abstract;
using Business.Constants;
using Castle.Core.Internal;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImage>> GetCarImages(int carId)
        {
            var results = _carImageDal.GetAll(c => c.CarId == carId);
            if (!results.IsNullOrEmpty())
            {
                return new SuccessDataResult<List<CarImage>>(results, Messages.ImagesListed);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId==0));
        }

        public IResult Save(IFormFile file,string path,CarImage carImage)
        {
            IResult result=BusinessRules.Run(CheckIfImageCount(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = path+_fileHelper.GetFileName();
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            _fileHelper.SaveWithGuid(file, path);
            return new SuccessResult(Messages.ImageSaved);
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IResult CheckIfImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
