using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReCapService
    {
        IResult Add(ReCap recap);
        IResult Update(ReCap recap);
        IResult Delete(ReCap recap);
        IDataResult<List<ReCap>> GetAll();
        IDataResult<ReCap> GetById(int recapId);
    }
}
