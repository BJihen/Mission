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
    public class TrainingService : Service<Trainingonline>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public TrainingService() : base(ut)
        {
                        
        }

        //
      

        public IEnumerable<Course> GetCoursesByTrainingId(int id)
        {
            return ut.getRepository<Course>().GetMany(x => x.trainingonlineId == id);
        }


        public List<Trainingonline> GetTopTraining()
        {
            IEnumerable<Trainingonline> TopTrain = new List<Trainingonline>();
            TopTrain = ut.getRepository<Trainingonline>().GetAll().OrderBy(x=>x.nbReservation);
            List<Trainingonline> tr = TopTrain.ToList();
            List<Trainingonline> TopTrain2 = new List<Trainingonline>();
            for (int i = tr.Count-1; i >tr.Count-4; i--)
            {
                TopTrain2.Add(tr[i]);
            }
            return TopTrain2;
        }

    }
}
