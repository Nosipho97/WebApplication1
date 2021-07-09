using Stock.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StockMasterController : Controller
    {
        // GET: StockMaster
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddStock()
        {
            return View();
        }

        // POST: StockMaster/Create
        [HttpPost]
        public ActionResult AddStock(StockModel model)
        {
            // TODO: Add insert logic here
            try
            {
                //Here we are opening connection to the database
                using (var dbContext = new ERP_SolutionDbEntities())
                {
                    //To add data to the DebtorsMaster table
                    StockMaster stock = new StockMaster();
                    stock.StockCode = model.StockCode;
                    stock.StockDescription = model.StockDescription;
                    stock.Cost = model.Cost;
                    stock.Selling_Price = model.SellingPrice;
                    stock.TotalPurchase_excl_Vat = model.TotalPurchase_ExlVat;
                    stock.TotalSales_excl_Vat = model.TotalSale_ExlVat;
                    stock.QTY_Purchased = model.QtyPurchase;
                    stock.QTY_Sold = model.QtySold;
                    stock.StockOnHand = model.StockOnHand;
                    dbContext.StockMasters.Add(stock);
                    //save changes
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e);
            }
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string StockCode)
        {

            using (var dbContext = new ERP_SolutionDbEntities())
            {
                StockMaster stock = dbContext.StockMasters.Where(x => x.StockCode == StockCode).SingleOrDefault();

                StockModel model = new StockModel
                {
                    StockCode = stock.StockCode,
                    StockDescription = stock.StockDescription,
                    Cost = (decimal)stock.Cost.Value,
                    SellingPrice= (decimal)stock.Selling_Price.Value,
                    TotalPurchase_ExlVat = (decimal)stock.TotalPurchase_excl_Vat,
                    TotalSale_ExlVat = (decimal)stock.TotalSales_excl_Vat.Value,
                    QtyPurchase = stock.QTY_Purchased.Value,
                    QtySold=(int)stock.QTY_Sold.Value,
                    StockOnHand = (int)stock.StockOnHand.Value
                };

                return View("Index", model);
            }
        }
        // GET: DebtorsMaster/Edit/5
        public ActionResult EditStock(string StockCode)
        {
            //To fill the form with data from database with the particular code
            return View();


        }

        // POST: DebtorsMaster/Edit/5
        [HttpPost]
        public ActionResult EditStock(StockModel model)
        {
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                var stock = dbContext.StockMasters.Where(x => x.StockCode == model.StockCode).SingleOrDefault();

                if (stock != null)
                {
                    stock.StockCode = model.StockCode;
                    stock.StockDescription = model.StockDescription;
                    stock.Cost = model.Cost;
                    stock.Selling_Price = model.SellingPrice;
                    stock.TotalPurchase_excl_Vat = model.TotalPurchase_ExlVat;
                    stock.TotalSales_excl_Vat = model.TotalSale_ExlVat;
                    stock.QTY_Purchased = model.QtyPurchase;
                    stock.QTY_Sold = model.QtySold;
                    stock.StockOnHand = model.StockOnHand;
                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View();
            }
        }

    }
}
