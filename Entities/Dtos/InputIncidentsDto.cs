using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class InputIncidentsDto
    {
        public int ID { get; set; }
        public string dc_Zaman { get; set; }
        public string dc_Kategori { get; set; }
        public string dc_Olay { get; set; }
        public string dc_Orario { get; set; }
        public string dc_Categoria { get; set; }
        public string dc_Evento { get; set; }
    }
}
