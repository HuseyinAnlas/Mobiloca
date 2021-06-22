using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Mapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class IncidentManager : IIncidentService
    {
        IIncidentDal _incidentDal;

        public IncidentManager(IIncidentDal incidentDal)
        {
            _incidentDal = incidentDal;
        }


        public IDataResult<object> GetAll()
        {
            return new SuccessDataResult<object>(_incidentDal.GetAll(), Messages.IncidentListed);
        }

        public object MapIncident(List<InputIncidentsDto> inputIncidentDto)
        {
            Mapper mapper = new Mapper();
            return mapper.Map<List<InputIncidentsDto>, List<Incident>>(inputIncidentDto);
        }

        public object MapIncident(FilterIncidentDto inputIncidentDto)
        {
            Mapper mapper = new Mapper();
            return mapper.Map<FilterIncidentDto, Incident>(inputIncidentDto);
        }

        public IDataResult<object> GetById(int incidentId)
        {
            return new SuccessDataResult<object>(_incidentDal.Get(c => c.ID == incidentId), Messages.IncidentListed);
        }

        public IDataResult<object> GetByFilter(object obj)
        {
            Incident incident = (Incident)obj;
            if (!string.IsNullOrWhiteSpace(incident.dc_Zaman) && !string.IsNullOrWhiteSpace(incident.dc_Kategori))
                return new SuccessDataResult<object>(_incidentDal.GetAll(c => c.dc_Zaman == incident.dc_Zaman && c.dc_Kategori == incident.dc_Kategori),
                    Messages.IncidentListed) ;
            else if(!string.IsNullOrWhiteSpace(incident.dc_Zaman))
                return new SuccessDataResult<object>(_incidentDal.GetAll(c => c.dc_Zaman == incident.dc_Zaman),
                    Messages.IncidentListed);
            else if (!string.IsNullOrWhiteSpace(incident.dc_Kategori))
                return new SuccessDataResult<object>(_incidentDal.GetAll(c => c.dc_Kategori == incident.dc_Kategori),
                    Messages.IncidentListed);
            return new SuccessDataResult<object>(_incidentDal.GetAll(), Messages.IncidentListed);

        }



        [ValidationAspect(typeof(IncidentValidator))]
        public IResult AddRange(object incident)
        {           
            _incidentDal.AddRange((List<Incident>)incident);
            return new SuccessResult(Messages.IncidentAdded);
        }



    }
}
