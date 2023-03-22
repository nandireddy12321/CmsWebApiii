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
    public class CustomerController : ApiController
    {

        [HttpGet]
        [Route("api/Customer/login/{user}/{pwd}")]
        public IHttpActionResult Authunticate(String user, String pwd)
        {
            CmsDAOO dao = new CmsDAOO();
            int result=dao.CustomerAuthenticationDAO(user, pwd);
            String res = "";
            res += result;
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(res, Encoding.UTF8, "application/json");
            return ResponseMessage(response);

        }

        public IQueryable<Customer> Getvendors()
        {

            CmsDAOO dao = new CmsDAOO();

            List<Customer> customerList = dao.Showcustomerdao();
            IQueryable<Customer> res = customerList.AsQueryable();
            return res;

        }
        [ResponseType(typeof(Customer))]

        public IHttpActionResult GetRestaurant(int id)
        {

            CmsDAOO dao = new CmsDAOO();
            Customer customer = dao.Searchcustomer(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);


           }
        [HttpGet]
        [ResponseType(typeof(Customer))]
        [Route("api/Customer/SearchByName/{user}")]

        public IHttpActionResult Searchbycustomername(string user)
        {

            CmsDAOO dao = new CmsDAOO();
            Customer customer = dao.Searchbycustomername(user);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);


        }


    }
}
