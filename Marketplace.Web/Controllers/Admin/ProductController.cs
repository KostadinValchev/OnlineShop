using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Marketplace.Data;
using Marketplace.Models;

namespace Marketplace.Web.Controllers.Admin
{
    public class ProductController : Controller
    {
        
        // GET: Product
        //
        // GET: Article
        public ActionResult Index()
        {

            return RedirectToAction("List");
        }

        //
        // GET: Article/List
        public ActionResult List(int? id)
        {
            using (var database = new MarketplaceContext())
            {
                //Get articles from database
                var products = database.Products
                    //.Include(a => a.Files)
                    .ToList();

                return View(products);
            }

        }

        //
        // GET: Article/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new MarketplaceContext())
            {
                var products = database.Products
                    .Where(a => a.Id == id)
                    //.Include(s => s.Files)
                    .SingleOrDefault(s => s.Id == id);


                if (products == null)
                {
                    return HttpNotFound();
                }

                return View(products);
            }
        }

        //
        // Get: Article/Create
        [Authorize]
        public ActionResult Create()
        {
            using (var database = new MarketplaceContext())
            {
                var model = new ProductViewModel();
                model.Categories = database.Categories
                    .OrderBy(c => c.Title)
                    .ToList();

                return View(model);
            }
        }

        //
        // POST: Article/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Create");
            //}

            using (var database = new MarketplaceContext())
            {
                
                var product = new Product(model.Make, model.Model, model.Size, model.Material, model.Price, model.Description, model.CategoryId);


                //uploading photo
                //if (upload != null && upload.ContentLength > 0)
                //{
                //    var avatar = new File
                //    {
                //        FileName = System.IO.Path.GetFileName(upload.FileName),
                //        FileType = FileType.Avatar,
                //        ContentType = upload.ContentType
                //    };
                //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                //    {
                //        avatar.Content = reader.ReadBytes(upload.ContentLength);
                //    }
                //    product.Files = new List<File> { avatar };
                //}

                database.Products.Add(product);
                database.SaveChanges();

                return RedirectToAction("Index");
            }
            
        }

        //
        // Get: Article/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new MarketplaceContext())
            {
                // Get article from database
                var product = database.Products
                    .Where(a => a.Id == id)
                    .Include(c => c.Category)
                    //.Include(c => c.Files)
                    .First();

                if (!IsUserAuthorizedToEdit(product))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                // Chek if article exists
                if (product == null)
                {
                    return HttpNotFound();
                }

                // Pass article to view
                return View(product);
            }
        }

        //
        // Post: Article/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new MarketplaceContext())
            {
                // Get article from database 
                var products = database.Products
                    .Where(a => a.Id == id)
                    .Include(c => c.Category)
                    //.Include(c => c.Files)
                    .First();

                // Check if article exists
                if (products == null)
                {
                    return HttpNotFound();
                }

                // Delete article from database
                //database.Files.Remove(products.Files.First(f => f.FileType == FileType.Avatar));
                database.Products.Remove(products);
                database.SaveChanges();

                // Redirect to index page
                return RedirectToAction("Index");
            }
        }

        //
        // Get: Article/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new MarketplaceContext())
            {
                // Get article from database 
                var product = database.Products
                    .Where(a => a.Id == id)
                    //.Include(a => a.Files)
                    .First();


                if (!IsUserAuthorizedToEdit(product))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                // Check if article exists
                if (product == null)
                {
                    return HttpNotFound();
                }

                // Create the view model
                var model = new ProductViewModel();
                model.Id = product.Id;
                model.Model = product.Model;
                model.Make = product.Make;
                model.Material = product.Material;
                model.Price = product.Price;
                model.Description = product.Description;
                model.Categories = database.Categories
                    .OrderBy(c => c.Title)
                    .ToList();
                //model.Files = product.Files;
                // Pass the view model to view
                return View(model);
            }
        }

        //
        // Post: Article/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel model, HttpPostedFileBase upload)
        {
            // Check if model state is valid
            if (ModelState.IsValid)
            {
                using (var database = new MarketplaceContext())
                {
                    // Get article from database 
                    var product = database.Products
                        .FirstOrDefault(a => a.Id == model.Id);

                    // Set article properties
                    model.Id = product.Id;
                    model.Model = product.Model;
                    model.Make = product.Make;
                    model.Material = product.Material;
                    model.Price = product.Price;
                    model.Description = product.Description;
                    model.Categories = database.Categories
                        .OrderBy(c => c.Title)
                        .ToList();
                    //model.Files = product.Files;

                    //if (upload != null && upload.ContentLength > 0)
                    //{
                    //    if (product.Files.Any(f => f.FileType == FileType.Avatar))
                    //    {
                    //        database.Files.Remove(product.Files.First(f => f.FileType == FileType.Avatar));
                    //    }
                    //    var avatar = new File
                    //    {
                    //        FileName = System.IO.Path.GetFileName(upload.FileName),
                    //        FileType = FileType.Avatar,
                    //        ContentType = upload.ContentType
                    //    };
                    //    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    //    {
                    //        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    //    }
                    //    product.Files = new List<File> { avatar };
                    //}

                    // Save article state in database
                    database.Entry(product).State = EntityState.Modified;
                    database.SaveChanges();
                }
            }

            // Redirect to the index page 
            return RedirectToAction("Index");
        }
        

        private bool IsUserAuthorizedToEdit(Product product)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            return isAdmin;
        }
    }
}