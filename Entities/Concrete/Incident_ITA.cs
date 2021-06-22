using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Incident_ITA:IEntity
    {
        public int ID { get; set; }
        public string dc_Orario { get; set; }
        public string dc_Categoria { get; set; }
        public string dc_Evento { get; set; }
    }
}
