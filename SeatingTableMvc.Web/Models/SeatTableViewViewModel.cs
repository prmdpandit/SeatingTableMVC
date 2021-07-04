using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeatingTabels.Models;
using SeatingTabels.BAL;

namespace SeatingTableMvc.Web.Models
{
    public class SeatTableViewViewModel
    {
        ISeatingTable seatingTable;
       public IEnumerable<PersonVM> personList { get; set; }
       public IEnumerable<TableVM> tableList { get; set; }
      public  IEnumerable<AssignTabletoPersonVM> ATList { get; set; }
        public IList<joinATlist> joinatlist { get; set; }
        public SeatTableViewViewModel()
        {
            seatingTable = new SeatingTableBAL();
            personList = seatingTable.ListAllPerson();
            tableList = seatingTable.ListOfTables();
            ATList = seatingTable.ListofTablewithPerson();
            ATJoinList();
        }
        public void TableAssignToPerson(TableVM assigntabletoperson)
        {
          if(seatingTable.validationAssignTable(assigntabletoperson))
            seatingTable.AssignTabletoperson(assigntabletoperson);
            
        }
        public void TableRemoveToPerson(TableVM assigntabletoperson)
        {

            seatingTable.AssignTabletoperson(assigntabletoperson);
        }
        private void ATJoinList()
        {
            joinatlist=new List<joinATlist>();

            foreach (var item in tableList)
            {
                joinATlist jonlist = new joinATlist();
              var per=  personList.Where(p=>p.PersonId==item.PersonId).FirstOrDefault();
              var tab = tableList.Where(p => p.TableId == item.TableId).FirstOrDefault();
              jonlist.person = per;
              jonlist.table = tab;
              joinatlist.Add(jonlist);
            }
        }
        public TableVM getbyid(int id)
        { return seatingTable.GetbyTableId(id); }

    }
    public class joinATlist
    {
        public PersonVM person{get;set;}
        public TableVM table{get;set;}
    }
    public class AssignTable
    {
        public PersonVM person { get; set; }
        public IEnumerable<TableVM> tables {
            get { return tables; }
            set { }
        }

    }
}