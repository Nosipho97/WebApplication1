using Debtors.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class DebtorsController : Controller
    { 
        public ActionResult Index()
        {
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                List<DebtorsMaster> List = new List<DebtorsMaster>();
                List= dbContext.DebtorsMasters.ToList();
                DebtorsMasterModel debtorsMasterModel = new DebtorsMasterModel()
                {
                    DebtorsList = List.ToList()
                };        
                return View(debtorsMasterModel);
            }
        }

        // POST: DebtorsMaster/Create
        [HttpPost]
        public ActionResult AddDebtor(DebtorsMasterModel model)
        {
            // TODO: Add insert logic here
            try
            {
                //Here we are opening connection to the database
                using (var dbContext = new ERP_SolutionDbEntities())
                {
                    //To add data to the DebtorsMaster table
                    DebtorsMaster debtor = new DebtorsMaster();
                    debtor.AccountCode = model.AccountCode;
                    debtor.Address1 = model.Address1;
                    debtor.Address2 = model.Address2;
                    debtor.Balance = model.Balance;
                    debtor.SaleYearToDate = model.SalesToYearD;
                    debtor.CostYearToDate = model.CostToYearD;
                    dbContext.DebtorsMasters.Add(debtor);
                    //save changes
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch(DbEntityValidationException e)
            {
                Console.Write(e);
            }
                return View();
            
        }
        /// <summary>
        ///This will search AccountCode and populate fields with data found
        /// </summary>
        /// <param name="AccountCode"></param>
        /// <returns>returns AccountCode Details</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string AccountCode)
        {

            using (var dbContext = new ERP_SolutionDbEntities())
            {
              DebtorsMaster debtor= dbContext.DebtorsMasters.Where(x => x.AccountCode == AccountCode).SingleOrDefault();
              DebtorsMasterModel model = new DebtorsMasterModel();

                List<DebtorsMaster> List = new List<DebtorsMaster>();
                List = dbContext.DebtorsMasters.ToList();
                model.AccountCode = debtor.AccountCode;
                model.Address1 = debtor.Address1;
                model.Address2 = debtor.Address2;
                model.Balance = (decimal)debtor.Balance.GetValueOrDefault();
                model.SalesToYearD = (decimal)debtor.SaleYearToDate.GetValueOrDefault();
                model.CostToYearD = (decimal)debtor.CostYearToDate.GetValueOrDefault();
                model.DebtorsList = List.ToList();
                
                return View("Index", model);
            }
        }

       
        // GET: DebtorsMaster/Edit/5
        public ActionResult EditDebtor(string AccountCode)
        {
            //To fill the form with data from database with the particular code
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                DebtorsMaster debtor = dbContext.DebtorsMasters.Where(x => x.AccountCode == AccountCode).SingleOrDefault();

                List<DebtorsMaster> List = new List<DebtorsMaster>();
                List = dbContext.DebtorsMasters.ToList();

                DebtorsMasterModel model = new DebtorsMasterModel
                {
                    AccountCode = debtor.AccountCode,
                    Address1 = debtor.Address1,
                    Address2 = debtor.Address2,
                    Balance = (decimal)debtor.Balance.GetValueOrDefault(),
                    SalesToYearD = (decimal)debtor.SaleYearToDate.GetValueOrDefault(),
                    CostToYearD = (decimal)debtor.CostYearToDate.GetValueOrDefault(),
                    DebtorsList = List.ToList()
                };
                return View(model);


            }
        }

        // POST: DebtorsMaster/Edit/5
        [HttpPost]
        public ActionResult EditDebtor(DebtorsMasterModel model)
        {
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                var debtor = dbContext.DebtorsMasters.Where(x => x.AccountCode == model.AccountCode).SingleOrDefault();
                List<StockMaster> List = new List<StockMaster>();
                if (debtor != null)
                {
                    debtor.AccountCode = model.AccountCode;
                    debtor.Address1 = model.Address1;
                    debtor.Address2 = model.Address2;
                    debtor.Balance = model.Balance;
                    debtor.SaleYearToDate = model.SalesToYearD;
                    debtor.CostYearToDate = model.CostToYearD;
                    dbContext.SaveChanges();

                    return RedirectToAction("Index");
                }
                return View();
            }
        }


        //
        // POST: DebtorsTransaction/Create
        [HttpPost]
        public ActionResult CreateTransaction(DebtorsMasterModel model)
        {

            //Here we are opening connection to the database
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                //To add data to the DebtorsMaster table
                Debtors_Transaction debtor = new Debtors_Transaction();
                DebtorsMaster debtorsMaster = new DebtorsMaster();

                var _Transaction = dbContext.DebtorsMasters.Where(x => x.AccountCode == model.AccountCode).SingleOrDefault();
                _Transaction.AccountCode = model.AccountCode;
                debtor.TransactionDate = DateTime.Now;
                debtor.TransactionType = model.TransactType;
                debtor.DocumentNo = model.DocumentNo;
                debtor.Gross_Transaction_Value = model.Gross;
                debtor.Vat_Value = model.Vat;

                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
        }
    }

}
