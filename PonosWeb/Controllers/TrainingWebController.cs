using PonosDomaine.Entities;
using PonosService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PonosWeb.Controllers
{
    public class TrainingWebController : ApiController
    {
        TrainingService TS = new TrainingService();

        // GET: api/TrainingWeb
        public IEnumerable<Trainingonline> Get()
        {
            return TS.GetAll();
        }

        // GET: api/TrainingWeb/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TrainingWeb
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TrainingWeb/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TrainingWeb/5
        public void Delete(int id)
        {
        }
    }
}
