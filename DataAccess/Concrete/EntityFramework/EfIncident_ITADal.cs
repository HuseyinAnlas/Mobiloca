using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIncident_ITADal:EfEntityRepositoryBase<Incident_ITA, MobirollerDBContext>, IIncident_ITADal
    {


    }
}
