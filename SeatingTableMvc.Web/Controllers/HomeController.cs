using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeatingTabels.BAL;
using SeatingTabels.Models;

namespace SeatingTableMvc.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //    1.       Provide a way to associate each Person with a table in the [Table] table in the Database.
        //[Table].[NumberSeats] is the maximum number of people who can be seated at the table. 
        //Validate that this limit is followed.

        //2.       Add and link to a new page called "Tables" that will list out all of the tables,
        //along with the names of the people seated at each table.

        //3.       Provide a way to remove a person from a table

        //4.       Allow the user to filter the list of People to show:

        //·         All People/Only people with no tables assigned

        //·         By Gender

        //·         By Age Range

        //5.       Improve the existing code in any way that you see fit. Show off your excellent coding habits and attention to detail. Blow us away with your ingenuity.
        Models.SeatTableViewViewModel seatingTable;
        public HomeController()
        { seatingTable = new Models.SeatTableViewViewModel(); }
        public ActionResult Index()
        {
          
            return View(seatingTable);
        }
        [HttpPost]
        public ActionResult Create(SeatingTabels.Models.TableVM obj)
        {
            return View("Index");
        }
        public ActionResult AllPersonList()
        {
            return View();

        }

        public ViewResult AllTables()
        {
           // var listoftables = seatingTable.ListOfTables();
            return View(seatingTable.tableList);
        }
        [HttpGet]
        public ActionResult AssignToTable()
        {
            return View();
        }
        public ActionResult TableAssigntoPerson()
        {
            return View(seatingTable.personList);

        }
        [HttpPost]
        public ActionResult TableAssigntoPerson(TableVM id)
        {
            var ii = TempData["personId"];
            var iii = id;
            //seatingTable.TableAssignToPerson(assigntotableperson);
            return View();
        }
        public ActionResult Assign(int id)
        {
            TempData["personId"] = id;
            return View(seatingTable.tableList);
        }
        


    }
}
