using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (ReCapProjectContext context=new ReCapProjectContext())
            {
                var result = from operationCalim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationCalim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationCalim.Id, Name = operationCalim.Name };

                return result.ToList();
            }
            
        }
    }
}
