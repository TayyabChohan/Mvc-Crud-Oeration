using MvcCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCrud.Controllers
{
    public class DefaultController : Controller
    {

        ContractManagementEntities db = new ContractManagementEntities();
        // GET: Default
        public ActionResult Index()
        {

            var list = db.Contracts.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [Httpost]
        public ActionResult Create( Contract cnt)

        {
            db.Contracts.Add(cnt);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Contract edt = db.Contracts.Find(id);
            return View(edt);
        }
        [HttpPost]
        public ActionResult Edit(Contract edt , int id)
        {
            Contract contract = db.Contracts.SingleOrDefault(m => m.ContractID == id);
            contract.ContractID = edt.ContractID;
            contract.Name = edt.Name;
            contract.Email = edt.Email;
            contract.Phone = edt.Phone;
            contract.Gender = edt.Gender;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Contract del = db.Contracts.Find(id);
            if (del == null)
            {
                return HttpNotFound();
            }
            return View(del);
        }
        public ActionResult Delete(int id)
        {
            Contract detail = db.Contracts.Find(id);
            db.Contracts.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}