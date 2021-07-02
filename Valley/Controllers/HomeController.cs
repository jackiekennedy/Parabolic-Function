using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Valley.Models;

namespace Valley.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        public HomeController(DataContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetData(UserData udate)
        {
            if (!IsDataValid(udate))
                return Json(new { success = false });

            db.UsersData.Add(udate);
            db.SaveChanges();

            var points = CalculatePoints(udate);

            foreach (var p in points)
                db.Points.Add(p);
            db.SaveChanges();

            return Json(new { success = true, points });
        }

        private List<Point> CalculatePoints(UserData udate)
        {
            float a = udate.A;
            float b = udate.B;
            float c = udate.C;

            List<Point> points = new List<Point>();

            for (float i = udate.RangeFrom; i <= udate.RangeTo; i += udate.Step)
            {
                Point p = new Point()
                {
                    PointX = i,
                    PointY = a * i * i + b * i + c,
                    UserDateId = udate.UserDataId
                };

                points.Add(p);
            }

            return points;
        }

        private bool IsDataValid(UserData udate)
        {
            if (udate.RangeFrom >= udate.RangeTo)
                return false;
            if (udate.Step <= 0)
                return false;

            return true;
        }
    }
}
