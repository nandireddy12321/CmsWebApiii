using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CmsDAO;
using CmsProject.entities;

namespace CmsWebApi.Controllers
{
    public class menurestaraurentidController : ApiController
    {
        public IHttpActionResult Getmenurestarentid(int id)
        {

            CmsDAOO dao = new CmsDAOO();
            Menu menu = dao.Menurestarent(id);
            if (menu == null)
            {
               return NotFound();
            }
            return Ok(menu);

        }
    }
}
