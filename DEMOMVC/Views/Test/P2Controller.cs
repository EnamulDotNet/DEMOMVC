using System.Web.Mvc;

namespace DEMOMVC.Views.Test
{
    public class P2Controller : Controller
    {
        //
        // GET: /P1/
        public ActionResult Index()
        {

            return View("../Test/P3");
        }
	}
}