using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StateManager : IStateService
    {
        IIncidentService incidentService = null;
        private int _culture = 0;
        
        public StateManager(int culture)
        {
            _culture = culture;
            if (culture == 0)
                incidentService = new IncidentManager(new EfIncidentDal());
            if (culture == 1)
                incidentService = new Incident_ITAManager(new EfIncident_ITADal());
        }
        public IResult AddRange(List<InputIncidentsDto> incidents)
        {
            incidentService.AddRange(incidentService.MapIncident(incidents));
            return new SuccessResult(Messages.IncidentAdded);
        }

        public IDataResult<object> GetAll()
        {
            return new SuccessDataResult<object>(incidentService.GetAll(), Messages.IncidentListed);
        }

        public IDataResult<object> GetByFilter(FilterIncidentDto filterIncidents)
        {
            return new SuccessDataResult<object>(incidentService.GetByFilter(incidentService.MapIncident(filterIncidents)), Messages.IncidentListed);
            
        }
    }
}
