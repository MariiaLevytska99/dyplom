using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quizz.Controllers
{
    public class ModalController : Controller
    {
        // GET: Modal
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}