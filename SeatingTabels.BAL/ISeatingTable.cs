using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeatingTabels.Models;

namespace SeatingTabels.BAL
{
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


  public  interface ISeatingTable
    {
        //public method
        void AssignTabletoperson(TableVM assignTabletoPerson);
        
        IEnumerable<AssignTabletoPersonVM> ListofTablewithPerson();

        bool validationAssignTable(TableVM tdata);// validate person require sheat not be grater then table sheat 
        IEnumerable<PersonVM> ListAllPerson();
        IEnumerable<TableVM> ListOfTables();
        
        IList<PersonVM> SerchByGender(string gender);
        IList<PersonVM> SearchByAgeRange(int? startrange, int? endrange);
        TableVM GetbyTableId(int id);
            



    }
}
