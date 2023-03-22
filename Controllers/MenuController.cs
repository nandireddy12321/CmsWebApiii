using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CmsDAO;
using CmsProject.entities;

namespace CmsWebApi.Controllers
{
    public class MenuController : ApiController
    {

        public IHttpActionResult Getmenu(int id)
        {
            CmsDAOO dao = new CmsDAOO();
            Menu men = dao.Searchmenu(id);
            if (men == null)
            {
                return NotFound();
            }
            return Ok(men);
        }

        //[ResponseType(typeof(Menu))]

        //public IHttpActionResult Getmenurestarentid(int id)
        //{

        //    CmsDAOO dao = new CmsDAOO();
        //    Menu menu = dao.Menurestarent(id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(menu);

        //}
    }
}
