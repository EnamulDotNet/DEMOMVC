using System.Web.Mvc;

namespace DEMOMVC.Views.Test
{
    public class P1Controller : Controller
    {
        //
        // GET: /P1/
        public ActionResult Index()
        {
            return View("../Test/P1");
        }
	}
}