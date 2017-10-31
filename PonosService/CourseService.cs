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
   public class CourseService : Service<Course>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CourseService() : base(ut)
        {

        }



        //Trier course by date
        public IEnumerable<Course> GetCourseTrier()
        {
            return ut.getRepository<Course>().GetMany().OrderByDescending(c => c.dateAjout);

        }

    }
}
