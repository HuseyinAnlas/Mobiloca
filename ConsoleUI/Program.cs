using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IncidentTest();


        }

        private static void IncidentTest()
        {
            IncidentManager incidentManager = new IncidentManager(new EfIncidentDal());

            

            foreach (var incident in incidentManager.GetAll())
            {
                Console.WriteLine(incident.dc_Olay);

            }
        }
    }
}
