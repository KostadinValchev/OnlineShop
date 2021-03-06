﻿using System;
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
            MarketplaceContext db = new MarketplaceContext();
            List<object> myModel = new List<object>();
            myModel.Add(db.Categories.ToList());
            myModel.Add(db.Products.ToList());

            return View(myModel);
        }

        public ActionResult Search(string searchString)
        {
            using (var database = new MarketplaceContext())
            {

                var products = database.Products
                    .ToList();

                //search bar
                if (!String.IsNullOrEmpty(searchString))
                {
                    products = products.Where(s => s.Make.ToLower().Contains(searchString.ToLower())).ToList();

                    List<object> myModel = new List<object>();
                    myModel.Add(database.Categories.ToList());
                    myModel.Add(products);
                    myModel.Add(products.Count);

                    return View(myModel);
                }

            }

            return RedirectToAction("Index");
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