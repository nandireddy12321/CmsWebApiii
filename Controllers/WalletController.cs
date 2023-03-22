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
    public class WalletController : ApiController
    {

        public IQueryable<Wallet> Getvendors()
        {

            CmsDAOO dao = new CmsDAOO();

            List<Wallet> walletList = dao.Showwalletdao(); ;
            IQueryable<Wallet> res = walletList.AsQueryable();
            return res;

        }
        [ResponseType(typeof(Wallet))]

        public IHttpActionResult GetRestaurant(string id)
        {

            CmsDAOO dao = new CmsDAOO();
            Wallet wallet = dao.Walletsearch(id); ;
            if (wallet == null)
            {
                return NotFound();
            }
            return Ok(wallet);

        }
    }
}
