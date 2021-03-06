using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, MobirollerDBContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (MobirollerDBContext context = new MobirollerDBContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = userOperationClaim.OperationClaimId,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }

        }
    }
}