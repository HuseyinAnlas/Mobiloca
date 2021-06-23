using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Mapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class Incident_ITAManager : IIncidentService
    {
        IIncident_ITADal _incident_ITADal;

        public Incident_ITAManager(IIncident_ITADal incident_ITADal)
        {
            _incident_ITADal = incident_ITADal;
        }

        [SecuredOperation("incident.addRange,admin")]
        [ValidationAspect(typeof(IncidentValidator))]
        [CacheRemoveAspect("IIncidentService.Get")]
        public IResult AddRange(object incident)
        {
            _incident_ITADal.AddRange((List<Incident_ITA>)incident);
            return new SuccessResult(Messages.IncidentAdded);
        }

        [CacheAspect]
        public IDataResult<object> GetAll()
        {
            return new SuccessDataResult<object>(_incident_ITADal.GetAll(), Messages.IncidentListed);
        }

        [CacheAspect]
        public IDataResult<object> GetById(int incidentId)
        {
            return new SuccessDataResult<object>(_incident_ITADal.Get(c => c.ID == incidentId), Messages.IncidentListed);
        }

        public IDataResult<object> GetByFilter(object obj)
        {
            Incident_ITA incident = (Incident_ITA)obj;
            if (!string.IsNullOrWhiteSpace(incident.dc_Orario) && !string.IsNullOrWhiteSpace(incident.dc_Categoria))
                return new SuccessDataResult<object>(_incident_ITADal.GetAll(c => c.dc_Orario == incident.dc_Orario && c.dc_Categoria == incident.dc_Categoria),
                    Messages.IncidentListed);
            else if (!string.IsNullOrWhiteSpace(incident.dc_Orario))
                return new SuccessDataResult<object>(_incident_ITADal.GetAll(c => c.dc_Orario == incident.dc_Orario),
                    Messages.IncidentListed);
            else if (!string.IsNullOrWhiteSpace(incident.dc_Categoria))
                return new SuccessDataResult<object>(_incident_ITADal.GetAll(c => c.dc_Categoria == incident.dc_Categoria),
                    Messages.IncidentListed);
            return new SuccessDataResult<object>(_incident_ITADal.GetAll(), Messages.IncidentListed);

        }


        public object MapIncident(List<InputIncidentsDto> inputIncidentDto)
        {
            Mapper mapper = new Mapper();
            return mapper.Map<List<InputIncidentsDto>, List<Incident_ITA>>(inputIncidentDto);
        }

        public object MapIncident(FilterIncidentDto inputIncidentDto)
        {
            Mapper mapper = new Mapper();
            return mapper.Map<FilterIncidentDto, Incident_ITA>(inputIncidentDto);
        }


    }
}
