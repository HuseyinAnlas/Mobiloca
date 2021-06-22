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
    public interface IIncident_ITAService
    {
        IDataResult<List<Incident_ITA>> GetAll();
        IDataResult<Incident_ITA> GetById(int incidentId);
        IResult AddRange(object incident);
        IResult Update(Incident_ITA incident);
        IResult Delete(Incident_ITA incident);
        object MapIncident(List<InputIncidentsDto> inputIncidentDto);
    }
}
