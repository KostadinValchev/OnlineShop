using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Marketplace.Data;

namespace Blog.Controllers

{
    public class FileController : Controller
    {

        private MarketplaceContext db = new MarketplaceContext();
        // GET: File
        public ActionResult Index(int id)
        {

            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }

    }

}