using PerformanceMonitor.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PerformanceMonitor.Controllers
{
    public class HomeController : Controller
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source = D:\\DOT NET\\Sqlite\\database.db; Version=3;");
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            try
            {
                List<PerformanceModel> lst = new List<PerformanceModel>();
                conn.Open();
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM PerformanceMonitor";

                SQLiteDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    PerformanceModel obj = new PerformanceModel();
                    obj.dateTime = reader[0].ToString();
                    obj.cpuUsage = Decimal.Parse(reader[1].ToString());
                    obj.memoryUsage = Decimal.Parse(reader[2].ToString());
                    lst.Add(obj);
                    
                }

                //var filteredLst = lst.OrderByDescending(x => x.dateTime);

                var latest = lst[lst.Count - 1];

                return this.Json(latest, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return HttpNotFound();
            }

        }
    }
}