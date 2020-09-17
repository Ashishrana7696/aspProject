using Shopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Products()
        {
        ProductModel db = new ProductModel();
            
            var list = db.Products;
            
            return View(list);
        }
        
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product products,HttpPostedFileBase Imgfile)
        {
            string Imagename = Imgfile.FileName;
            Imgfile.SaveAs(Server.MapPath("~/Images/"+Imagename));
            ProductModel db = new ProductModel();
            products.ProductImage ="~/Images/"+Imagename;
           // products.ProductImage = Imagename;
            db.Products.Add(products);
            db.SaveChanges();
            return RedirectToAction("Products","Product");
        }

        public ActionResult GetPrice(Product p)
        {
            return View(p);
        }

        [HttpPost]
        public ActionResult GetByPrice(int price)
        {
            ProductModel db = new ProductModel();

            var list = db.Products.Where(x => x.Price < price);

            return RedirectToAction("GetPrice", list);
        }

    }
}