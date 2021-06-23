using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IIncidentService
    {
        IDataResult<object> GetAll();
        IDataResult<object> GetById(int incidentId);
        IResult AddRange(object incident);
          
        object MapIncident(List<InputIncidentsDto> inputIncidentDto);
        object MapIncident(FilterIncidentDto inputIncidentDto);
        IDataResult<object> GetByFilter(object obj);

        

    }
}
