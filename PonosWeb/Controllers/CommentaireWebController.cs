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
    public class CommentaireWebController : ApiController
    {
        CommentaireService CS = new CommentaireService();
        // GET: api/CommentaireWeb
        public IEnumerable<Commentaire> Get()
        {
            return CS.GetAll();
        }

        // GET: api/CommentaireWeb/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CommentaireWeb
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CommentaireWeb/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CommentaireWeb/5
        public void Delete(int id)
        {
        }
    }
}
