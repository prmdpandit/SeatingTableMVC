using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeatingTableMvc.Web.Controllers
{
    public class AssignTableController : Controller
    {
        //
        // GET: /AssignTable/
        Models.SeatTableViewViewModel seatingTable=new Models.SeatTableViewViewModel();
        public ActionResult Index()
        {
            ViewBag.Listofperson = seatingTable.personList;
            return View(seatingTable.tableList);
        }

        public ActionResult Assign(SeatingTabels.Models.TableVM model)
        {
            return View();
        }

        //
        // GET: /AssignTable/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AssignTable/Create

        public ActionResult Create()
        {
            ViewBag.Listofperson = seatingTable.personList;
            return View();
        }

        //
        // POST: /AssignTable/Create

        [HttpPost]
        public ActionResult Create(SeatingTabels.Models.TableVM collection)
        {
            try
            {
                // TODO: Add insert logic here


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AssignTable/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.Listofperson = seatingTable.personList;

            return View(seatingTable.getbyid(id));
        }

        //
        // POST: /AssignTable/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, SeatingTabels.Models.TableVM model)
        {
            try
            {
                // TODO: Add update logic here
                seatingTable.TableAssignToPerson(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AssignTable/Delete/5

        public ActionResult Delete(int id)
        {
            ViewBag.Listofperson = seatingTable.personList;
            return View(seatingTable.getbyid(id));
        }

        //
        // POST: /AssignTable/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, SeatingTabels.Models.TableVM model)
        {
            try
            {
                // TODO: Add delete logic here
              var tdata=  seatingTable.getbyid(id);
                tdata.PersonId = null;
                seatingTable.TableRemoveToPerson(tdata);
                return RedirectToAction("Index");
               
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search()
        {
            return View(seatingTable.joinatlist);
        }
    }
}
