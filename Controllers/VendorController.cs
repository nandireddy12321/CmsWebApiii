using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using CmsDAO;
using System.Web.Http.Description;
using CmsProject.entities;

namespace CmsWebApi.Controllers
{
    public class VendorController : ApiController
    {
        [System.Web.Http.HttpGet]
        [Route("api/Vendor/{user}/{pwd}")]
        public IHttpActionResult Authunticate(String user, String pwd)
        {
            CmsDAOO dao = new CmsDAOO();
            int result = dao.vendorAuthenticationDAO(user, pwd);
            String res = "";
            res += result;
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(res, Encoding.UTF8, "application/json");
            return ResponseMessage(response);

        }
        public IQueryable<Vendor> Getvendors()
        {

            CmsDAOO dao = new CmsDAOO();

            List<Vendor> restaurentList = dao.Showvendordao();
            IQueryable<Vendor> res = restaurentList.AsQueryable();
            return res;
          
        }
        [ResponseType(typeof(Vendor))]

        public IHttpActionResult GetRestaurant(int id)
        {

            CmsDAOO dao = new CmsDAOO();
            Vendor ven = dao.Searchvendorid(id);
            if (ven == null)
            {
                return NotFound();
            }
            return Ok(ven);

        }
    }

}
 