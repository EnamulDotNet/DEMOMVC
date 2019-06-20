using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace DEMOMVC.Views.Test
{
    public class P3Controller : Controller
    {
        //
        // GET: /P3/
        public ActionResult Index()
        {
            ViewBag.country = "bd";
            
    DataTable dt = new DataTable("dt1");  
    dt.Columns.Add("id");  
    dt.Columns.Add("txt"); 
    dt.Rows.Add("1","BD");  
    dt.Rows.Add("2","IN");
    dt.Rows.Add("2","usa");
            for (int i = 0; i < 10000; i++)
            {
                dt.Rows.Add(i.ToString(), "fkhfkfsfj jsjdfj hkh kfsf   fsfsfsfsfsf fff");
            }
    DataSet ds1 = new DataSet();
            ds1.Tables.Add(dt);
            string sJSONResponse = JsonConvert.SerializeObject(ds1);
            ViewBag.country = sJSONResponse;

            return View("../Test/P3");
        }
	}
}