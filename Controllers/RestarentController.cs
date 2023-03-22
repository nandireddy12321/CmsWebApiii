using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using CmsDAO;
using System.Web.Http.Description;
using CmsProject.entities;

using System.Web.Http;

namespace CmsWebApi.Controllers
{
    public class RestarentController : ApiController
    {
        public IQueryable<Restaurent> GetRestaurants()
        {
            CmsDAOO dao = new CmsDAOO();

            List<Restaurent> restaurentList = dao.Showrestaurentdao();
            IQueryable<Restaurent> res = restaurentList.AsQueryable();
            return res;
        }
        // GET: api/Restaurants/5
        [ResponseType(typeof(Restaurent))]
        public IHttpActionResult GetRestaurant(int id)
        {
            CmsDAOO dao = new CmsDAOO();
            Restaurent restaurent = dao.Searchrestarent(id);
            if (restaurent == null)
            {
                return NotFound();
            }
            return Ok(restaurent);
        }

    
    }
}
