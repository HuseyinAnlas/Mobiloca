using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStateService
    {
        //IDataResult<List<Incident>> GetAll();
        //IDataResult<Incident> GetById(int incidentId);
        IResult AddRange(List<InputIncidentsDto> incidents);
        //IResult Update(Incident incident);
        //IResult Delete(Incident incident);
    }
}
