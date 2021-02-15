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
    public class RentalManager : IReCapService
    {
        IReCapDal _recapDal;
        public RentalManager(IReCapDal recapDal)
        {
            _recapDal = recapDal;
        }

        public IResult Add(ReCap recap)
        {
            if (recap.ReturnDate == null)
            {
                return new ErrorResult();
            }
            _recapDal.Add(recap);
            return new SuccessResult();
        }

        public IResult Delete(ReCap recap)
        {
            _recapDal.Delete(recap);
            return new SuccessResult();
        }

        public IDataResult<List<ReCap>> GetAll()
        {
            return new SuccessDataResult<List<ReCap>>(_recapDal.GetAll());
        }

        public IDataResult<ReCap> GetById(int rentalId)
        {
            return new SuccessDataResult<ReCap>(_recapDal.Get(p => p.Id == rentalId));
        }

        public IResult Update(ReCap recap)
        {
            _recapDal.Update(recap);
            return new SuccessResult();
        }

    }
}
