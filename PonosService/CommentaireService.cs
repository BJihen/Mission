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
   public class CommentaireService : Service<Commentaire>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public CommentaireService() : base(ut)
        {

        }

    
    }
}
