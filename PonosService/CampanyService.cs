using PonosData.Infrastructure;
using PonosDomaine.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PonosService
{
   public class CampanyService : Service<Campany>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CampanyService() : base(ut)
        {

        }
    
    }
}
