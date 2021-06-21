using Core.Entities;

namespace Entities.Concrete
{
    public class Incident:IEntity
    {
        public int ID { get; set; }
        public string dc_Zaman { get; set; }
        public string dc_Kategori { get; set; }
        public string dc_Olay { get; set; }

    }
}
