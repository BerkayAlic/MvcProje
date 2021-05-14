using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticController : Controller
    {
        Context context = new Context();
        // GET: Statistic
        public ActionResult Index()
        {
            //In the controller we made an instance for "context" object.
            //In the context object we have categories as db, so we access categories.
            //With viewbag we can access categories in the View.
            //In the end we will return View Index.
            //With count method we can count the numbers of category objects.

            //Mission1
            var categoryCount = context.Categories.Count();
            ViewBag.totalCategory = categoryCount;

            //Mission2
            var yazilim = context.Headings.Count(c => c.CategoryID == 14);
            ViewBag.yazilim = yazilim;

            //Mission3
            var yazar = context.Writers.Count(c => c.WriterName.Contains("a"));
            ViewBag.yazar = yazar;

            //Mission4
            var max = context.Categories.Where(c => c.CategoryID == (context.Headings.GroupBy(x => x.CategoryID)
            .OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault())).
            Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.max = max;

            //Mission5
            var difference = context.Categories.Count(c => c.CategoryStatus == true) -
                context.Categories.Count(c => c.CategoryStatus == false);
            ViewBag.difference = difference;

            return View();
        }
    }
}