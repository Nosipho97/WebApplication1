using Debtors.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Index()
        {
            return View();
        }


        // GET: Invoice/Create
        public ActionResult AddInvoice()
        {

            InvoiceDetailsModel model = new InvoiceDetailsModel();

            //Here we are opening connection to the database
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                //Load Stock Code list for dropdown
                model.StockCodeListItem = (from p in dbContext.StockMasters
                                         select new SelectListItem()
                                         {
                                             Value = p.StockCode.ToString(),
                                             Text = p.StockDescription
                                         }).ToList();

                //Load Account Code list
                model.AccountCodeList = (from p in dbContext.DebtorsMasters
                                           select new SelectListItem()
                                           {
                                               Value = p.AccountCode.ToString(),
                                               Text = p.AccountCode
                                           }).ToList();

                //model.Stocks = new MultiSelectList(model.StockCodeListItem, "Value", "Text", null);

                //string json = JsonConvert.SerializeObject(ListOfItems);
                //List<string> CurrencyList = JsonConvert.DeserializeObject<List<string>>(json);

            }
            return View(model);

        }

        // POST: Invoice/Create
        [HttpPost]
        public ActionResult AddInvoice(InvoiceDetailsModel model)
        {
            try
            {
                             
                //Here we are opening connection to the database
                using (var dbContext = new ERP_SolutionDbEntities())
                {
                    
                    //To add data to the Invoice table
                    InvoiceDetail invoiceDetails = new InvoiceDetail();
                   
                    string stockCodeSelected = " ";
                    decimal totalUnitCost = 0;
                    decimal totalUnitSell = 0;
                    foreach (var item in model.StockCodeList)
                    {
                        totalUnitCost += (decimal)dbContext.StockMasters.Where(a => a.StockCode.Equals(item)).FirstOrDefault().Cost;
                        totalUnitSell += (decimal)dbContext.StockMasters.Where(a => a.StockCode.Equals(item)).FirstOrDefault().Selling_Price;
                        stockCodeSelected += ", "+ stockCodeSelected;

                    }

                    invoiceDetails.InvoiceDetailsId = model.InvoiceDetailsId;
                    invoiceDetails.InvoiceNo = model.InvoiceNo;                                                                                                                                                                
                    invoiceDetails.StockCode = stockCodeSelected;
                    invoiceDetails.ItemNo = model.ItemNo;
                    invoiceDetails.QtySold = model.QtySold;
                    invoiceDetails.UnitCost = model.UnitCost;
                    invoiceDetails.UnitSell = model.UnitSell;

                    //excl Total in view, and cal it here ....
                    invoiceDetails.Total = totalUnitCost;
                    dbContext.InvoiceDetails.Add(invoiceDetails);

                //    foreach (var index in model.StockCodeList)
                //    {
                //        //    //Update Stock Master (Tot purchase, Tot Sales, Qty Purchase, Qty Sold & Stock in hand )
                //        //    StockMaster stockMaster = dbContext.StockMasters.Where(x => x.StockCode == index).SingleOrDefault();
                //        //    stockMaster.TotalPurchase_excl_Vat = ;  
                //        //    stockMaster.TotalSales_excl_Vat = ;
                //        //    stockMaster.QTY_Purchased = 1 ;
                //        //    stockMaster.QTY_Sold = 1;
                //        //    stockMaster.StockOnHand -= 1 ;

                //        //    //Add Stock Transaction 
                //        Stock_Transaction stockTransaction = new Stock_Transaction();
                //        stockTransaction.StockCode = ;
                //        stockTransaction.StockDate = ;
                //        stockTransaction.TransactionType = "Current";
                //    //Auto - increment
                //        stockTransaction.DocumentNo = ;
                //        stockTransaction.Qty = 1;
                //        stockTransaction.UnitCost = ;
                //        stockTransaction.UnitSell = ;

                //}

                //save changes
                dbContext.SaveChanges();
                }
                return RedirectToAction("AddInvoice");
            }
            catch (DbEntityValidationException e)
            {
                Console.Write(e);
            }
            return View();
        }

        // GET: Invoice/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Invoice/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Invoice/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
