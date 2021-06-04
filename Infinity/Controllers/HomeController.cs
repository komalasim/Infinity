using Infinity.EF;
using Infinity.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Infinity.Controllers
{
    public class HomeController : Controller
    {
        CodeFirstContext dbContext;
        List<Product> products;
        List<Order> orders;

        public HomeController()
        {
            dbContext = new CodeFirstContext();
            products = new List<Product>();
            orders = new List<Order>();
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Customer"))
            {
                products = dbContext.Products.ToList();
                return View(products);
            }

            return RedirectToAction("Login", "Account", new { area = "Home" });
        }

        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(FormCollection collection, HttpPostedFileBase file)
        {
            Product prdObj = new Product();
            prdObj.Model = collection["Model"];
            prdObj.Cost = int.Parse(collection["Cost"]);
            prdObj.Brand = collection["Brand"];

            if (string.Equals(collection["Desktop"], "false"))
                prdObj.Desktop = false;
            else
                prdObj.Desktop = true;

            if (string.Equals(collection["TwoInOne"], "false"))
                prdObj.TwoInOne = false;
            else
                prdObj.TwoInOne = true;

            if (string.Equals(collection["Touch"], "false"))
                prdObj.Touch = false;
            else
                prdObj.Touch = true;

            if (string.Equals(collection["Laptop"], "false"))
                prdObj.Laptop = false;
            else
                prdObj.Laptop = true;

            if (string.Equals(collection["Gaming"], "false"))
                prdObj.Gaming = false;
            else
                prdObj.Gaming = true;

            if (string.Equals(collection["Workstation"], "false"))
                prdObj.Workstation = false;
            else
                prdObj.Workstation = true;

            prdObj.Core = int.Parse(collection["Core"]);
            prdObj.Generation = int.Parse(collection["Generation"]);
            prdObj.Processor = collection["Processor"];
            prdObj.Size = float.Parse(collection["Size"]);
            prdObj.Resolution = collection["Resolution"];
            prdObj.Length = float.Parse(collection["Length"]);
            prdObj.Width = float.Parse(collection["Width"]);
            prdObj.Height = float.Parse(collection["Height"]);
            prdObj.Weight = float.Parse(collection["Weight"]);
            prdObj.RAM = int.Parse(collection["RAM"]);
            prdObj.DriveType = bool.Parse(collection["DriveType"]);
            prdObj.DiskSpace = int.Parse(collection["DiskSpace"]);
            prdObj.USBA = int.Parse(collection["USBA"]);
            prdObj.USBC = int.Parse(collection["USBC"]);
            prdObj.Ethernet = int.Parse(collection["Ethernet"]);
            prdObj.HDMI = int.Parse(collection["HDMI"]);
            prdObj.VGA = int.Parse(collection["VGA"]);

            if (string.Equals(collection["AudioJack"], "false"))
                prdObj.AudioJack = false;
            else
                prdObj.AudioJack = true;

            if (string.Equals(collection["DVDPlayer"], "false"))
                prdObj.DVDPlayer = false;
            else
                prdObj.DVDPlayer = true;

            prdObj.Feature = collection["Feature"];
            prdObj.Software = collection["Software"];

            if (file != null)
            {
                string imageName = Path.GetFileName(file.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/Content/images/Laptops/"), imageName);
                prdObj.Image = "images/Laptops/" + imageName;
                file.SaveAs(physicalPath);
            }

            dbContext.Products.Add(prdObj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product prdObj = new Product();
            prdObj = dbContext.Products.FirstOrDefault(n => n.ID == id);

            return View(prdObj);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, HttpPostedFileBase file)
        {
            Product prdObj = new Product();
            prdObj = dbContext.Products.FirstOrDefault(n => n.ID == id);
            prdObj.Model = collection["Model"];
            prdObj.Cost = int.Parse(collection["Cost"]);
            prdObj.Brand = collection["Brand"];

            if (string.Equals(collection["Desktop"], "false"))
                prdObj.Desktop = false;
            else
                prdObj.Desktop = true;

            if (string.Equals(collection["TwoInOne"], "false"))
                prdObj.TwoInOne = false;
            else
                prdObj.TwoInOne = true;

            if (string.Equals(collection["Touch"], "false"))
                prdObj.Touch = false;
            else
                prdObj.Touch = true;

            if (string.Equals(collection["Laptop"], "false"))
                prdObj.Laptop = false;
            else
                prdObj.Laptop = true;

            if (string.Equals(collection["Gaming"], "false"))
                prdObj.Gaming = false;
            else
                prdObj.Gaming = true;

            if (string.Equals(collection["Workstation"], "false"))
                prdObj.Workstation = false;
            else
                prdObj.Workstation = true;

            prdObj.Core = int.Parse(collection["Core"]);
            prdObj.Generation = int.Parse(collection["Generation"]);
            prdObj.Processor = collection["Processor"];
            prdObj.Size = float.Parse(collection["Size"]);
            prdObj.Resolution = collection["Resolution"];
            prdObj.Length = float.Parse(collection["Length"]);
            prdObj.Width = float.Parse(collection["Width"]);
            prdObj.Height = float.Parse(collection["Height"]);
            prdObj.Weight = float.Parse(collection["Weight"]);
            prdObj.RAM = int.Parse(collection["RAM"]);
            prdObj.DriveType = bool.Parse(collection["DriveType"]);
            prdObj.DiskSpace = int.Parse(collection["DiskSpace"]);
            prdObj.USBA = int.Parse(collection["USBA"]);
            prdObj.USBC = int.Parse(collection["USBC"]);
            prdObj.Ethernet = int.Parse(collection["Ethernet"]);
            prdObj.HDMI = int.Parse(collection["HDMI"]);
            prdObj.VGA = int.Parse(collection["VGA"]);

            if (string.Equals(collection["AudioJack"], "false"))
                prdObj.AudioJack = false;
            else
                prdObj.AudioJack = true;

            if (string.Equals(collection["DVDPlayer"], "false"))
                prdObj.DVDPlayer = false;
            else
                prdObj.DVDPlayer = true;

            prdObj.Feature = collection["Feature"];
            prdObj.Software = collection["Software"];

            if (file != null)
            {
                string imageName = Path.GetFileName(file.FileName);
                string physicalPath = Path.Combine(Server.MapPath("~/Content/images/Laptops/"), imageName);
                prdObj.Image = "images/Laptops/" + imageName;
                file.SaveAs(physicalPath);
            }

            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(dbContext.Products.FirstOrDefault(n => n.ID == id));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Product prdObj = dbContext.Products.FirstOrDefault(n => n.ID == id);
            dbContext.Products.Remove(prdObj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(dbContext.Products.FirstOrDefault(n => n.ID == id));
        }

        public ActionResult Brands()
        {
            SqlConnection con = new SqlConnection(@WebConfigurationManager.ConnectionStrings["Infinity"].ToString());
            con.Open();
            string Output = "";
            SqlCommand cmd = new SqlCommand("Select DISTINCT Brand from Products", con);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + '\n';
            }

            con.Close();
            Session["BrandList"] = Output;
            return View();
        }

        public ActionResult BrandSearch(string brand)
        {
            Session["BrandSelected"] = brand;
            products = dbContext.Products.SqlQuery("Select * from Products where Brand = '" + brand + "'").ToList();
            return View(products);
        }

        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult CategorySearch(string category)
        {
            Session["CategorySelected"] = category;
            products = dbContext.Products.SqlQuery("Select * from Products where " + category + " = 1").ToList();
            return View(products);
        }

        public ActionResult Processors()
        {
            SqlConnection con = new SqlConnection(@WebConfigurationManager.ConnectionStrings["Infinity"].ToString());
            con.Open();
            string Output = "";
            SqlCommand cmd = new SqlCommand("Select DISTINCT Processor from Products", con);
            SqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + '\n';
            }

            con.Close();
            Session["ProcessorList"] = Output;
            return View();
        }

        public ActionResult ProcessorSearch(string processor)
        {
            Session["ProcessorSelected"] = processor;
            products = dbContext.Products.SqlQuery("Select * from Products where Processor = '" + processor + "'").ToList();
            return View(products);
        }

        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AutoCompleteModel(string prefix)
        {
            var products = (from product in dbContext.Products
                            where product.Model.StartsWith(prefix)
                            select new
                            {
                                product.Model,
                                product.ID
                            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutoCompleteBrand(string prefix)
        {
            var products = (from product in dbContext.Products
                            where product.Brand.StartsWith(prefix)
                            select new
                            {
                                product.Brand,
                                product.ID
                            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutoCompleteSoftware(string prefix)
        {
            var products = (from product in dbContext.Products
                            where product.Software.StartsWith(prefix)
                            select new
                            {
                                product.Software,
                                product.ID
                            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutoCompleteProcessor(string prefix)
        {
            var products = (from product in dbContext.Products
                            where product.Processor.StartsWith(prefix)
                            select new
                            {
                                product.Processor,
                                product.ID
                            });

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Search(FormCollection collection, HttpPostedFileBase file)
        {
            //Search Model
            Session["Model"] = collection["Model"];

            //Search Brand
            Session["Brand"] = collection["Brand"];

            //Search Processor
            Session["Processor"] = collection["Processor"];

            //Search Operating System
            Session["OS"] = collection["Software"];

            //Search Price
            Session["Price1"] = "";
            Session["Price2"] = "";
            Session["Price3"] = "";
            Session["Price4"] = "";
                
            if (Request.Form["Price1"] != null)
            {
                if (Request.Form["Price1"].ToString().Equals("true"))
                    Session["Price1"] = Request.Form["Price1"];
            }

            if (Request.Form["Price2"] != null)
            {
                if (Request.Form["Price2"].ToString().Equals("true"))
                    Session["Price2"] = Request.Form["Price2"];
            }
                
            if (Request.Form["Price3"] != null)
            {
                if (Request.Form["Price3"].ToString().Equals("true"))
                    Session["Price3"] = Request.Form["Price3"];
            }
                
            if (Request.Form["Price4"] != null)
            {
                if (Request.Form["Price4"].ToString().Equals("true"))
                    Session["Price4"] = Request.Form["Price4"];
            }

            //Search Category
            Session["Desktop"] = "";
            Session["Laptop"] = "";
            Session["TwoInOne"] = "";
            Session["Touch"] = "";
            Session["Gaming"] = "";
            Session["Workstation"] = "";

            if (Request.Form["Desktop"] != null)
            {
                if (Request.Form["Desktop"].ToString().Equals("true"))
                    Session["Desktop"] = Request.Form["Desktop"];
            }

            if (Request.Form["Laptop"] != null)
            {
                if (Request.Form["Laptop"].ToString().Equals("true"))
                    Session["Laptop"] = Request.Form["Laptop"];
            }
                
            if (Request.Form["TwoInOne"] != null)
            {
                if (Request.Form["TwoInOne"].ToString().Equals("true"))
                    Session["TwoInOne"] = Request.Form["TwoInOne"];
            }
                
            if (Request.Form["Touch"] != null)
            {
                if (Request.Form["Touch"].ToString().Equals("true"))
                    Session["Touch"] = Request.Form["Touch"];
            }
                
            if (Request.Form["Gaming"] != null)
            {
                if (Request.Form["Gaming"].ToString().Equals("true"))
                    Session["Gaming"] = Request.Form["Gaming"];
            }
                
            if (Request.Form["Workstation"] != null)
            {
                if (Request.Form["Workstation"].ToString().Equals("true"))
                    Session["Workstation"] = Request.Form["Workstation"];
            }

            //Search DriveType
            Session["DriveType"] = "";
            if (Request.Form["DriveType"] != null)
            {
                Session["DriveType"] = Request.Form["DriveType"];
            }

            //Search Generation
            Session["Gen1"] = "";
            Session["Gen2"] = "";
            Session["Gen3"] = "";
            Session["Gen4"] = "";
            Session["Gen5"] = "";

            if (Request.Form["Gen1"] != null)
            {
                if (Request.Form["Gen1"].ToString().Equals("true"))
                    Session["Gen1"] = Request.Form["Gen1"];
            }
                
            if (Request.Form["Gen2"] != null)
            {
                if (Request.Form["Gen2"].ToString().Equals("true"))
                    Session["Gen2"] = Request.Form["Gen2"];
            }
                
            if (Request.Form["Gen3"] != null)
            {
                if (Request.Form["Gen3"].ToString().Equals("true"))
                    Session["Gen3"] = Request.Form["Gen3"];
            }
                
            if (Request.Form["Gen4"] != null)
            {
                if (Request.Form["Gen4"].ToString().Equals("true"))
                    Session["Gen4"] = Request.Form["Gen4"];
            }
                
            if (Request.Form["Gen5"] != null)
            {
                if (Request.Form["Gen5"].ToString().Equals("true"))
                    Session["Gen5"] = Request.Form["Gen5"];
            }

            //Search RAM
            Session["RAM1"] = "";
            Session["RAM2"] = "";
            Session["RAM3"] = "";
            Session["RAM4"] = "";
            Session["RAM5"] = "";
                
            if (Request.Form["RAM1"] != null)
            {
                if (Request.Form["RAM1"].ToString().Equals("true"))
                    Session["RAM1"] = Request.Form["RAM1"];
            }
                
            if (Request.Form["RAM2"] != null)
            {
                if (Request.Form["RAM2"].ToString().Equals("true"))
                    Session["RAM2"] = Request.Form["RAM2"];
            }
                
            if (Request.Form["RAM3"] != null)
            {
                if (Request.Form["RAM3"].ToString().Equals("true"))
                    Session["RAM3"] = Request.Form["RAM3"];
            }
                
            if (Request.Form["RAM4"] != null)
            {
                if (Request.Form["RAM4"].ToString().Equals("true"))
                    Session["RAM4"] = Request.Form["RAM4"];
            }
                
            if (Request.Form["RAM5"] != null)
            {
                if (Request.Form["RAM5"].ToString().Equals("true"))
                    Session["RAM5"] = Request.Form["RAM5"];
            }

            //Search Disk Storage
            Session["Disk0"] = "";
            Session["Disk1"] = "";
            Session["Disk2"] = "";
            Session["Disk3"] = "";
            Session["Disk4"] = "";
            Session["Disk5"] = "";
                
            if (Request.Form["Disk0"] != null)
            {
                if (Request.Form["Disk0"].ToString().Equals("true"))
                    Session["Disk0"] = Request.Form["Disk0"];
            }
                
            if (Request.Form["Disk1"] != null)
            {
                if (Request.Form["Disk1"].ToString().Equals("true"))
                    Session["Disk1"] = Request.Form["Disk1"];
            }
                
            if (Request.Form["Disk2"] != null)
            {
                if (Request.Form["Disk2"].ToString().Equals("true"))
                    Session["Disk2"] = Request.Form["Disk2"];
            }
                
            if (Request.Form["Disk3"] != null)
            {
                if (Request.Form["Disk3"].ToString().Equals("true"))
                    Session["Disk3"] = Request.Form["Disk3"];
            }
                
            if (Request.Form["Disk4"] != null)
            {
                if (Request.Form["Disk4"].ToString().Equals("true"))
                    Session["Disk4"] = Request.Form["Disk4"];
            }
                
            if (Request.Form["Disk5"] != null)
            {
                if (Request.Form["Disk5"].ToString().Equals("true"))
                    Session["Disk5"] = Request.Form["Disk5"];
            }

            //Search Screen Diplay Size
            Session["Screen1"] = "";
            Session["Screen2"] = "";
            Session["Screen3"] = "";
            Session["Screen4"] = "";
            Session["Screen5"] = "";
            Session["Screen6"] = "";

            if (Request.Form["Screen1"] != null)
            {
                if (Request.Form["Screen1"].ToString().Equals("true"))
                    Session["Screen1"] = Request.Form["Screen1"];
            }
                
            if (Request.Form["Screen2"] != null)
            {
                if (Request.Form["Screen2"].ToString().Equals("true"))
                    Session["Screen2"] = Request.Form["Screen2"];
            }
                
            if (Request.Form["Screen3"] != null)
            {
                if (Request.Form["Screen3"].ToString().Equals("true"))
                    Session["Screen3"] = Request.Form["Screen3"];
            }
                
            if (Request.Form["Screen4"] != null)
            {
                if (Request.Form["Screen4"].ToString().Equals("true"))
                    Session["Screen4"] = Request.Form["Screen4"];
            }
                
            if (Request.Form["Screen5"] != null)
            {
                if (Request.Form["Screen5"].ToString().Equals("true"))
                    Session["Screen5"] = Request.Form["Screen5"];
            }
                
            if (Request.Form["Screen6"] != null)
            {
                if (Request.Form["Screen6"].ToString().Equals("true"))
                    Session["Screen6"] = Request.Form["Screen6"];
            }

            return RedirectToAction("SearchResults");
        }

        public ActionResult SearchResults()
        {
            List<Product> Append1 = new List<Product>();
            List<Product> Append2 = new List<Product>();
            List<Product> Temp1 = new List<Product>();
            List<Product> Temp2 = new List<Product>();
            List<Product> Temp3 = new List<Product>();
            List<Product> Temp4 = new List<Product>();
            List<Product> Temp5 = new List<Product>();
            List<Product> Temp6 = new List<Product>();
            products = new List<Product>();
      
            bool[] CheckNull = new bool[11];
            for (int i = 0; i < 11; i++)
                CheckNull[i] = false;
            
                //Search Brand
            if (Session["Brand"].ToString().Length > 0)
            {
                CheckNull[0] = true;
                string Brand = Session["Brand"].ToString();
                Append1 = dbContext.Products.SqlQuery("Select * from Products where Brand like '%" + Brand + "%'").ToList();
            }

            //Search Model
            if (Session["Model"].ToString().Length > 0)
            {
                CheckNull[1] = true;
                string Model = Session["Model"].ToString();
                Append2 = dbContext.Products.SqlQuery("Select * from Products where Model like '%" + Model + "%'").ToList();
                
                if (CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            //Search Price
            if (Session["Price1"].ToString().Length > 0)
            {
                CheckNull[2] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where Cost >= 50000 and Cost < 100001").ToList();
            }

            if (Session["Price2"].ToString().Length > 0)
            {
                CheckNull[2] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where Cost >= 100001 and Cost < 150001").ToList();
            }

            if (Session["Price3"].ToString().Length > 0)
            {
                CheckNull[2] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where Cost >= 150001 and Cost < 200001").ToList();
            }

            if (Session["Price4"].ToString().Length > 0)
            {
                CheckNull[2] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where Cost >= 200001").ToList();
            }

            if (CheckNull[2] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            Temp1 = new List<Product>();
            Temp2 = new List<Product>();
            Temp3 = new List<Product>();
            Temp4 = new List<Product>();

            //Search Category 
            if (Session["Desktop"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where Desktop = 1").ToList();
            }

            if (Session["Laptop"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where Laptop = 1").ToList();
            }

            if (Session["TwoInOne"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where TwoInOne = 1").ToList();
            }

            if (Session["Touch"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where Touch = 1").ToList();
            }

            if (Session["Gaming"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp5 = dbContext.Products.SqlQuery("Select * from Products where Gaming = 1").ToList();
            }

            if (Session["Workstation"].ToString().Length > 0)
            {
                CheckNull[3] = true;
                Temp6 = dbContext.Products.SqlQuery("Select * from Products where Workstation = 1").ToList();
            }

            if (CheckNull[3] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2.AddRange(Temp5);
                Append2.AddRange(Temp6);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            Temp1 = new List<Product>();
            Temp2 = new List<Product>();
            Temp3 = new List<Product>();
            Temp4 = new List<Product>();
            Temp5 = new List<Product>();
            Temp6 = new List<Product>();

            //Search Drive Type
            if (Session["DriveType"].ToString().Length > 0)
            {
                CheckNull[4] = true;
                
                if (Session["DriveType"].ToString().Equals("true"))
                {
                    Temp1 = dbContext.Products.SqlQuery("Select * from Products where DriveType = 1").ToList();
                }
                else
                {
                    Temp1 = dbContext.Products.SqlQuery("Select * from Products where DriveType = 0").ToList();
                }
            }

            if (CheckNull[4] == true)
            {
                Append2 = (Temp1);
                
                if (CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
                
                Temp1 = new List<Product>();
            }

            //Search Processor
            if (Session["Processor"].ToString().Length > 0)
            {
                CheckNull[5] = true;
                string Processor = Session["Processor"].ToString();
                Append2 = dbContext.Products.SqlQuery("Select * from Products where Processor like '%" + Processor + "%'").ToList();
                
                if (CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            //Search Generation
            if (Session["Gen1"].ToString().Length > 0)
            {
                CheckNull[6] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where Generation >= 11").ToList();
            }

            if (Session["Gen2"].ToString().Length > 0)
            {
                CheckNull[6] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where Generation = 10").ToList();
            }

            if (Session["Gen3"].ToString().Length > 0)
            {
                CheckNull[6] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where Generation = 9").ToList();
            }

            if (Session["Gen4"].ToString().Length > 0)
            {
                CheckNull[6] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where Generation = 8").ToList();
            }

            if (Session["Gen5"].ToString().Length > 0)
            {
                CheckNull[6] = true;
                Temp5 = dbContext.Products.SqlQuery("Select * from Products where Generation <= 7").ToList();
            }

            if (CheckNull[6] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2.AddRange(Temp5);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[5] == true || CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            Temp1 = new List<Product>();
            Temp2 = new List<Product>();
            Temp3 = new List<Product>();
            Temp4 = new List<Product>();
            Temp5 = new List<Product>();
            Temp6 = new List<Product>();

            //Search RAM
            if (Session["RAM1"].ToString().Length > 0)
            {
                CheckNull[7] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where RAM >= 32").ToList();
            }

            if (Session["RAM2"].ToString().Length > 0)
            {
                CheckNull[7] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where RAM > 12 and RAM <= 16").ToList();
            }

            if (Session["RAM3"].ToString().Length > 0)
            {
                CheckNull[7] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where RAM > 8 and RAM <= 12").ToList();
            }

            if (Session["RAM4"].ToString().Length > 0)
            {
                CheckNull[7] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where RAM > 4 and RAM <= 8").ToList();
            }

            if (Session["RAM5"].ToString().Length > 0)
            {
                CheckNull[7] = true;
                Temp5 = dbContext.Products.SqlQuery("Select * from Products where RAM <= 4").ToList();
            }

            if (CheckNull[7] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2.AddRange(Temp5);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[6] == true || CheckNull[5] == true || CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            Temp1 = new List<Product>();
            Temp2 = new List<Product>();
            Temp3 = new List<Product>();
            Temp4 = new List<Product>();
            Temp5 = new List<Product>();
            Temp6 = new List<Product>();

            //Search Disk Space
            if (Session["Disk0"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace < 256").ToList();
            }

            if (Session["Disk1"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace = 256").ToList();
            }

            if (Session["Disk2"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace > 256 and DiskSpace <= 512").ToList();
            }

            if (Session["Disk3"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace > 512 and DiskSpace <= 1024").ToList();
            }

            if (Session["Disk4"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp5 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace > 1024 and DiskSpace <= 2048").ToList();
            }

            if (Session["Disk5"].ToString().Length > 0)
            {
                CheckNull[8] = true;
                Temp6 = dbContext.Products.SqlQuery("Select * from Products where DiskSpace > 2048").ToList();
            }

            if (CheckNull[8] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2.AddRange(Temp5);
                Append2.AddRange(Temp6);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[7] == true || CheckNull[6] == true || CheckNull[5] == true || CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            Temp1 = new List<Product>();
            Temp2 = new List<Product>();
            Temp3 = new List<Product>();
            Temp4 = new List<Product>();
            Temp5 = new List<Product>();
            Temp6 = new List<Product>();

            //Search Screen Size
            if (Session["Screen1"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp1 = dbContext.Products.SqlQuery("Select * from Products where Size >= 18").ToList();
            }

            if (Session["Screen2"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp2 = dbContext.Products.SqlQuery("Select * from Products where Size >= 17 and Size < 18").ToList();
            }

            if (Session["Screen3"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp3 = dbContext.Products.SqlQuery("Select * from Products where Size >= 15 and Size < 17").ToList();
            }

            if (Session["Screen4"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp4 = dbContext.Products.SqlQuery("Select * from Products where Size >= 14 and Size < 15").ToList();
            }

            if (Session["Screen5"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp5 = dbContext.Products.SqlQuery("Select * from Products where Size >= 13 and Size < 14").ToList();
            }

            if (Session["Screen6"].ToString().Length > 0)
            {
                CheckNull[9] = true;
                Temp6 = dbContext.Products.SqlQuery("Select * from Products where Size < 13").ToList();
            }

            if (CheckNull[9] == true)
            {
                Append2 = (Temp1);
                Append2.AddRange(Temp2);
                Append2.AddRange(Temp3);
                Append2.AddRange(Temp4);
                Append2.AddRange(Temp5);
                Append2.AddRange(Temp6);
                Append2 = Append2.Distinct().ToList();
                
                if (CheckNull[8] == true || CheckNull[7] == true || CheckNull[6] == true || CheckNull[5] == true || CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            //Search Operating System
            if (Session["OS"].ToString().Length > 0)
            {
                CheckNull[10] = true;
                string OS = Session["OS"].ToString();
                Append2 = dbContext.Products.SqlQuery("Select * from Products where Software like '%" + OS + "%'").ToList();
                
                if (CheckNull[9] == true || CheckNull[8] == true || CheckNull[7] == true || CheckNull[6] == true || CheckNull[5] == true || CheckNull[4] == true || CheckNull[3] == true || CheckNull[2] == true || CheckNull[1] == true || CheckNull[0] == true)
                {
                    Append1 = Append1.Intersect(Append2).ToList();
                }
                else
                {
                    Append1 = Append2;
                }
            }

            products = Append1.Distinct().ToList();
            
            if (CheckNull[10] == false && CheckNull[9] == false && CheckNull[8] == false && CheckNull[7] == false && CheckNull[6] == false && CheckNull[5] == false && CheckNull[4] == false && CheckNull[3] == false && CheckNull[2] == false && CheckNull[1] == false && CheckNull[0] == false)
            {
                products = dbContext.Products.ToList();
            }

            if (products.Count() > 0)
            {
                Session["ProductCount"] = "true";
            }
            else
            {
                Session["ProductCount"] = "false";
            }

            return View(products);
        }

        [HttpPost]
        public ActionResult AddToCart(int ProductId)
        {
            if (Session["cart"] == null)
            {
                List<CartItem> cart = new List<CartItem>();
                var prod = dbContext.Products.Find(ProductId);
                cart.Add(new CartItem() { product = prod, Quantity = 1 });
                Session["cart"] = cart;
            }
            else
            {
                int flag = 0;

                foreach (CartItem item in (List<CartItem>)Session["cart"])
                {
                    if (item.product.ID == ProductId)
                    {
                        flag = 1;
                        item.Quantity = item.Quantity + 1;
                    }
                }

                if (flag == 0)
                {
                    List<CartItem> cart = (List<CartItem>)Session["cart"];
                    var prod = dbContext.Products.Find(ProductId);
                    cart.Add(new CartItem() { product = prod, Quantity = 1 });
                    Session["cart"] = cart;
                }
            }

            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult OrderDetails()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PlaceOrder()
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cart = new List<CartItem>();
                int TPrice = 0;

                foreach (CartItem item in (List<CartItem>)Session["cart"])
                {
                    TPrice = TPrice + (item.product.Cost * item.Quantity);
                }

                Session["TPrice"] = TPrice;
            }

            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(FormCollection form)
        {
            Order newOrder = new Order();
            newOrder.UserAddress = form["Address"];
            newOrder.UserID = User.Identity.Name;
            newOrder.TotalPrice = Convert.ToInt32(Session["TPrice"]);
            string order = null;
            newOrder.Date = DateTime.Now.ToString("yyyy-MM-dd");
            
            foreach (CartItem item in (List<CartItem>)Session["cart"])
            {
                order += "ID: " + item.product.ID + " Name: " + item.product.Model + " Quantity: " + item.Quantity + ",";
            }

            newOrder.OrderDetails = order;
            orders.Add(newOrder);
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
            int orderID = newOrder.OrderID;
            Session["OrderID"] = orderID;
            Session["Address"] = newOrder.UserAddress;
            Session["cart"] = null;
            return View("OrderDetails");
        }

        [HttpGet]
        public ActionResult CartDetails()
        {
            return View();
        }

        public ActionResult IncreaseQuantity(int productId)
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cart = new List<CartItem>();

                foreach (CartItem item in (List<CartItem>)Session["cart"])
                {
                    if (item.product.ID != productId)
                    {
                        cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity });
                    }
                    else
                    {
                        cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity + 1 });
                    }
                }

                Session["cart"] = null;
                Session["cart"] = cart;
            }

            return Redirect("CartDetails");
        }

        public ActionResult DecreaseQuantity(int productId)
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cart = new List<CartItem>();

                foreach (CartItem item in (List<CartItem>)Session["cart"])
                {
                    if (item.product.ID != productId)
                    {
                        cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity });
                    }
                    else
                    {
                        if (item.Quantity > 1)
                        {
                            cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity - 1 });
                        }
                        else
                        {
                            cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity });
                        }
                    }
                }

                Session["cart"] = null;
                Session["cart"] = cart;
            }

            return Redirect("CartDetails");
        }

        public ActionResult DeleteCartEntry(int productId)
        {
            if (Session["cart"] != null)
            {
                List<CartItem> cart = new List<CartItem>();

                foreach (CartItem item in (List<CartItem>)Session["cart"])
                {
                    if (item.product.ID != productId)
                    {
                        cart.Add(new CartItem() { product = item.product, Quantity = item.Quantity });
                    }
                }

                Session["cart"] = null;

                if (cart.Count > 0)
                {
                    Session["cart"] = cart;
                }
            }

            return View("CartDetails");
        }

        [HttpGet]
        public ActionResult OrderHistory()
        {
            if (User.IsInRole("Administrator") || User.IsInRole("Customer"))
            {
                orders = dbContext.Orders.SqlQuery("Select * from Orders where UserID = '" + User.Identity.Name + "'").ToList();
                
                if (orders.Count > 0)
                {
                    return View(orders);
                }
                else
                {
                    orders = null;
                }
            }

            return View();
        }

        public ActionResult FAQS()
        {
            return View();
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}