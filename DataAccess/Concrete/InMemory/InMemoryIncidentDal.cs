using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryIncidentDal : IIncidentDal
    {
        List<Incident> _incidents;
        public InMemoryIncidentDal()
        {
            _incidents = new List<Incident>
            {
                new Incident{ID=1, dc_Zaman="1 Ocak", dc_Kategori="Olay", dc_Olay="Ölmüş" },
                new Incident{ID=2, dc_Zaman="1 Ocak", dc_Kategori="Olay", dc_Olay="Doğmuş" },
                new Incident{ID=3, dc_Zaman="1 Ocak", dc_Kategori="Olay", dc_Olay="Yaşamış" }
            };
        }
        public void Add(Incident incident)
        {
            _incidents.Add(incident);
        }

        public void Delete(Incident incident)
        {
            Incident incidentToDelete = _incidents.SingleOrDefault(p => p.ID == incident.ID);
            _incidents.Remove(incidentToDelete);
        }

        public Incident Get(Expression<Func<Incident, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Incident> GetAll()
        {
            return _incidents;
        }

        public List<Incident> GetAll(Expression<Func<Incident, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Incident incident)
        {
            Incident incidentToUpdate = _incidents.SingleOrDefault(p => p.ID == incident.ID);
            incidentToUpdate.dc_Zaman = incident.dc_Zaman;
            incidentToUpdate.dc_Kategori = incident.dc_Kategori;
            incidentToUpdate.dc_Olay = incident.dc_Olay;
        }
    }
}
