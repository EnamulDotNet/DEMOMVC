using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
            
    //DataTable dt = new DataTable("dt1");  
    //dt.Columns.Add("id");  
    //dt.Columns.Add("txt"); 
    //dt.Rows.Add("1","BD");  
    //dt.Rows.Add("2","IN");
    //dt.Rows.Add("2","usa");
    //        for (int i = 0; i < 10000; i++)
    //        {
    //            dt.Rows.Add(i.ToString(), "fkhfkfsfj jsjdfj hkh kfsf   fsfsfsfsfsf fff");
    //        }
    //DataSet ds1 = new DataSet();
    //        ds1.Tables.Add(dt);
    //        string sJSONResponse = JsonConvert.SerializeObject(ds1);
    //        ViewBag.country = sJSONResponse;

            return View("../Test/P3");
        }

        public JsonResult PageLoad()
        {
            DataTable dt = new DataTable("dt1");
            dt.Columns.Add("id");
            dt.Columns.Add("txt");
            dt.Rows.Add("1", "BD");
            dt.Rows.Add("2", "IN");
            dt.Rows.Add("2", "usa");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add(i.ToString(), "fkhfkfsfj jsjdfj hkh kfsf   fsfsfsfsfsf fff");
            }
            DataSet ds1 = new DataSet();
            ds1.Tables.Add(dt);

            dt=new DataTable("dt2");
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("unit");
            dt.Columns.Add("qty");
            for (int i = 0; i < 10; i++)
            {
                dt.Rows.Add("Id"+i, "Name" + i, "Unit" + i,  i.ToString());
            }
            ds1.Tables.Add(dt);

            return Json(JsonConvert.SerializeObject(ds1), JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult Save(AllData obj)
        {
            DataTable dt = ToDataTable(obj.Dt1);
            return Json("1", JsonRequestBehavior.AllowGet);
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public class AllData
        {
            public string SuppId { get; set; }
            public string TrnDat { get; set; }
            public List<Dt1Data> Dt1 { get; set; }

        }
        public class Dt1Data
        {
            public string ItemId { get; set; }
            public string Qty { get; set; }
        }
	}
}