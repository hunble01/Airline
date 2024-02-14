using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Passenger : Customer
    {
       
            // Additional properties for Passenger
            private int seatNumber;
            private bool bookingStatus;

            // Constructor
            public Passenger(int seatNum, bool bookingStatus, int customerID, string fName, string lName, string ph, int numBookings)
                : base(customerID, fName, lName, ph, numBookings)
            {
                this.seatNumber = seatNum;
                this.bookingStatus = bookingStatus;
            }

            // Getter methods specific to Passenger
            public int GetSeatNum()
            {
                return seatNumber;
            }

            public bool GetBookingStatus()
            {
                return bookingStatus;
            }

         

        public string ToFileString()
        {
            // Convert passenger data to a string format (customize as needed)
            return $"{GetSeatNum()},{GetBookingStatus()},{GetCustomerID()},{GetFirstName()},{GetLastName()},{GetPhone()},{GetNumBookings()}";
        }

        public static Passenger FromFileString(string fileString)
        {
            // Create a Passenger object from a string read from a text file
            string[] data = fileString.Split(',');
            // Parse data and create a new Passenger object
            return new Passenger(
                int.Parse(data[0]),
                bool.Parse(data[1]),
                int.Parse(data[2]),
                data[3],
                data[4],
                data[5],
                int.Parse(data[6])
            );
        }

        // Override ToString method to include Passenger information
        public override string ToString()
            {
                string passengerInfo = base.ToString(); // Inherit customer information
                passengerInfo += $"\nSeat Number: {seatNumber}\nBooking Status: {bookingStatus}";

                return passengerInfo;
            }
        

    }
}
