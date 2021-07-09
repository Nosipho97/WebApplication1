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
        // GET: DebtorsMaster
        public ActionResult Index()
        {
            return View();
        }

        // GET: DebtorsMaster/Create
        public ActionResult AddDebtor()
        {
            return View();
        }

        // POST: DebtorsMaster/Create
        [HttpPost]
        public ActionResult AddDebtor(DebtorsMasterModel model
            )
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
                    debtor.Balance = model.Balance.HasValue ? model.Balance.Value:0;
                    debtor.SaleYearToDate = model.SalesToYearD.HasValue ? model.SalesToYearD.Value:0;
                    debtor.CostYearToDate = model.CostToYearD.HasValue ? model.CostToYearD.Value:0;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(string AccountCode)
        {

            using (var dbContext = new ERP_SolutionDbEntities())
            {
              DebtorsMaster debtor= dbContext.DebtorsMasters.Where(x => x.AccountCode == AccountCode).SingleOrDefault();
               
                DebtorsMasterModel model = new DebtorsMasterModel
                {
                    AccountCode = debtor.AccountCode,
                    Address1 = debtor.Address1,
                    Address2 = debtor.Address2,
                    Balance = (decimal)debtor.Balance.Value,
                    SalesToYearD = (decimal)debtor.SaleYearToDate.Value,
                    CostToYearD = (decimal)debtor.CostYearToDate.Value


                };

                return View("Index", model);
            }
        }
        // GET: DebtorsMaster/Edit/5
        public ActionResult EditDebtor(string AccountCode)
        {
            //To fill the form with data from database with the particular code
            return View();
            
            
        }

        // POST: DebtorsMaster/Edit/5
        [HttpPost]
        public ActionResult EditDebtor(DebtorsMasterModel model)
        {
            using (var dbContext = new ERP_SolutionDbEntities())
            {
                var debtor = dbContext.DebtorsMasters.Where(x => x.AccountCode == model.AccountCode).SingleOrDefault();

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

        
    }
}
