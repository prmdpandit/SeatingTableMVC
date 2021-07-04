using SeatingTabels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seating.Data;

using AutoMapper;

namespace SeatingTabels.BAL
{
   public class SeatingTableBAL:ISeatingTable,IDisposable
    {
       SeatingDBEntities db;
       public SeatingTableBAL()
       { db = new SeatingDBEntities(); }
       public void AssignTabletoperson(TableVM assignTabletoPerson)
       {
           //var mapdata = Mapper.Map<TableVM, Table>(assignTabletoPerson);
           //db.Tables.Add(mapdata);
           //db.SaveChanges();

           var tdata = db.Tables.Where(tem => tem.TableId == assignTabletoPerson.TableId).FirstOrDefault();
           if (tdata != null)
           {
               tdata.PersonId = assignTabletoPerson.PersonId;
               
              // var tview = Mapper.Map<Table, TableVM>(tdata);
              // tview = assignTabletoPerson;
              //tdata = Mapper.Map<TableVM, Table>(tview);
               db.SaveChanges();
               
           }
           

       }
       public TableVM GetbyTableId(int id) { 
           var tdata=db.Tables.Where(t=>t.TableId==id).FirstOrDefault();

           return Mapper.Map<Table, TableVM>(tdata);
       }
     public  bool validationAssignTable(TableVM tdata) {
         var persondata = db.People.Where(p => p.PersonId == tdata.PersonId).FirstOrDefault();
         if (tdata.NumberOfSeats > persondata.ReqNoOfSheat)
             return true;
         else
             return false;
     }// validate person require sheat not be grater then table sheat 
     public IEnumerable<AssignTabletoPersonVM> ListofTablewithPerson() {
         List<AssignTabletoPersonVM> query = new List<AssignTabletoPersonVM>();
         var ATList = db.AssignTableToPersons.ToList();
         foreach (var item in ATList)
         {
             var temp = Mapper.Map<AssignTableToPerson, AssignTabletoPersonVM>(item);
             query.Add(temp);
         }
         return query.AsQueryable();
     }
     
     public  IEnumerable<PersonVM> ListAllPerson() {
         List<PersonVM> query = new List<PersonVM>();
         var personList = db.People.ToList();
         foreach (var item in personList)
         {
             var temp = Mapper.Map<Person, PersonVM>(item);
             query.Add(temp);
         }
         return query.AsQueryable();
         }
     public IEnumerable<TableVM> ListOfTables(){
         List<TableVM> query = new List<TableVM>();
         var personList = db.Tables.ToList();
         foreach (var item in personList)
         {
             var temp = Mapper.Map<Table, TableVM>(item);
             query.Add(temp);
         }
         return query.AsQueryable();
     }
   
    public   IList<PersonVM> SerchByGender(string gender) { return null; }
    public   IList<PersonVM> SearchByAgeRange(int? startrange, int? endrange) { return null; }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            //dispose managed resources
            db.Dispose();
        }
        //free native resources
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    }
}
