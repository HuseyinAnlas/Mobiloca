using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Security.Hashing;
using Business.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        
        
        
        //[CacheAspect]
        public IDataResult<List<User>> GetAll()

        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        
        
        
        //[CacheAspect]
        public IDataResult<User> GetById(int userId)

        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.Id == userId), Messages.UserListed);
        }       

        //[ValidationAspect(typeof(UserValidator), Priority =1)]
        //[CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        
        
        
        //[CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }
    
        
        //[CacheAspect]
        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=> u.Email == email));
        }
  
    }
}
