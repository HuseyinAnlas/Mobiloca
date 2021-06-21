using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIncidentService
    {
        IDataResult<List<Incident>> GetAll();
        IDataResult<Incident> GetById(int incidentId);
        IResult Add(Incident incident);
        IResult Update(Incident incident);
        IResult Delete(Incident incident);

        
    }
}
