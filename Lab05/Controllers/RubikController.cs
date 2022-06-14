using Lab05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab05.Controllers
{
    public class RubikController : Controller
    {

        DataContext dataContext = new DataContext();

        // GET: Rubik
        public ActionResult Index()
        {
            var all_Rubik = dataContext.Rubik.ToList();
            return View(all_Rubik);
        }

    }
}