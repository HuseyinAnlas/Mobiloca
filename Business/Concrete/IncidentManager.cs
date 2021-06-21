using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public IDataResult<List<Incident>> GetAll()
        {
            return new SuccessDataResult<List<Incident>>(_incidentDal.GetAll(), Messages.IncidentListed);
        }

        public IDataResult<Incident> GetById(int incidentId)
        {
            return new SuccessDataResult<Incident>(_incidentDal.Get(c => c.ID == incidentId), Messages.IncidentListed);
        }


        [ValidationAspect(typeof(IncidentValidator))]
        public IResult Add(Incident incident)
        {           
            _incidentDal.Add(incident);
            return new SuccessResult(Messages.IncidentAdded);
        }


        public IResult Update(Incident incident)
        {
            _incidentDal.Update(incident);
            return new SuccessResult(Messages.IncidentUpdated);
        }

        public IResult Delete(Incident incident)
        {
            _incidentDal.Delete(incident);
            return new SuccessResult(Messages.IncidentDeleted);
        }

    }
}
