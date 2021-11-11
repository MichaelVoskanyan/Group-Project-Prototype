using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280_Group_Project.Main {
	class clsMainSQL {

        public static DataSet GetItems()
        {
            try
            {
                clsDataAccess db = new clsDataAccess();
                //Create a DataSet to hold the data
                DataSet ds = new DataSet();

                //Number of return values
                int iRet = 0;

                //Get all the values from the Items
                ds = db.ExecuteSQLStatement(
                   "SELECT Passenger.Passenger_ID, Passenger.First_Name, Passenger.Last_Name, Flight_Passenger_Link.Seat_Number" +
                   " FROM Passenger INNER JOIN Flight_Passenger_Link ON Passenger.Passenger_ID = Flight_Passenger_Link.Passenger_ID" +
                   " WHERE Flight_Passenger_Link.Flight_ID="
                    // "SELECT P.* FROM Passenger AS P"
                    , ref iRet);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }


    }
}
