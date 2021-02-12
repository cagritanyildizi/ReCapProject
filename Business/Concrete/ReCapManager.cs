using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class ReCapManager: IReCapService
    {
        IReCapDal _rentalDal;
        public ReCapManager(IReCapDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(ReCap rental)
        {
            List<ReCap> carRentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (carRentals.Count == 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.ReCapAdded);
            }
            else
            {
                foreach (var car in carRentals)
                {
                    if (car.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.NotReCaptable);
                    }
                }
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ReCapAdded);
        }
        public IResult Update(ReCap rental)
        {
            List<ReCap> carRentals = _rentalDal.GetAll(r => r.CarId == rental.CarId);
            if (carRentals.Count == 0)
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.ReCapUpdated);
            }
            else
            {
                foreach (var car in carRentals)
                {
                    if (car.ReturnDate == null)
                    {
                        return new ErrorResult(Messages.NotReCaptable);
                    }
                }
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ReCapUpdated);
        }

        public IResult Delete(ReCap rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ReCapDeleted);
        }

        public IDataResult<List<ReCap>> GetAll()
        {
            return new SuccessDataResult<List<ReCap>>(_rentalDal.GetAll());
        }

        public IDataResult<ReCap> GetById(int id)
        {
            return new SuccessDataResult<ReCap>(_rentalDal.Get(r => r.Id == id));
        }

        IDataResult<List<ReCap>> ICrudService<ReCap>.GetAll()
        {
            throw new NotImplementedException();
        }

        IDataResult<ReCap> ICrudService<ReCap>.GetById(int id)
        {
            throw new NotImplementedException();
        }

    }
}
