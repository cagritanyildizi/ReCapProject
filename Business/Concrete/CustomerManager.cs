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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            if (customer.UserId == 0)
            {
                return new ErrorResult();
            }
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Add(Color color)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IResult Delete(Color color)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetCustomerByCompanyName(string companyName)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.CompanyName == companyName));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IResult Update(Color color)
        {
            throw new NotImplementedException();
        }

        IDataResult<List<Color>> ICustomerService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}