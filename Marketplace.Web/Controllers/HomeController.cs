using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marketplace.Data;

namespace Marketplace.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("ListCategories");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListCategories()
        {
            using (var database = new MarketplaceContext())
            {
                var categories = database.Categories
                    .Include(c => c.Products)
                    .OrderBy(c => c.Title)
                    .ToList();

                return View(categories);
            }
        }

        public ActionResult ListProducts(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var database = new MarketplaceContext())
            {
                var articles = database.Products
                    .Where(a => a.CategoryId == categoryId)
                    //.Include(a => a.Files)
                    .ToList();

                return View(articles);
            }
        }
    }
}