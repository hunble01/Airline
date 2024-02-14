using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Customer
    {
    
            // Properties
            private int customerID;
            private string firstName;
            private string lastName;
            private string phone;
            private int numBookings;
            private List<Passenger> passengers;

        // Constructor
        public Customer(int customerID, string fName, string lName, string ph, int numBookings)
            {
                this.customerID = customerID;
                this.firstName = fName;
                this.lastName = lName;
                this.phone = ph;
                this.numBookings = numBookings;
                passengers = new List<Passenger>();
        }

            // Getter methods
            public int GetCustomerID()
            {
                return customerID;
            }

            public string GetFirstName()
            {
                return firstName;
            }

            public string GetLastName()
            {
                return lastName;
            }

            public string GetPhone()
            {
                return phone;
            }

            public int GetNumBookings()
            {
                return numBookings;
            }

        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        // Inside the Customer class
        public string GetFullName()
        {
            return $"{firstName} {lastName}";
        }

        // Inside the Customer class
        public bool IsBookedOnFlight(int flightID)
        {
            // Check if any of the passengers are booked on the specified flight
            return passengers.Any(passenger => passenger.IsBookedOnFlight(flightID));
        }




        public Passenger RemovePassenger(int seatNumber)
        {
            Passenger removedPassenger = passengers.FirstOrDefault(p => p.GetSeatNum() == seatNumber);

            if (removedPassenger != null)
            {
                passengers.Remove(removedPassenger);
            }

            return removedPassenger;
        }

        public string ToFileString()
        {
            // Convert customer data to a string format (customize as needed)
            return $"{customerID},{firstName},{lastName},{phone},{numBookings}";
        }

        public static Customer FromFileString(string fileString)
        {
            // Create a Customer object from a string read from a text file
            string[] data = fileString.Split(',');
            // Parse data and create a new Customer object
            return new Customer(int.Parse(data[0]), data[1], data[2], data[3], int.Parse(data[4]));
        }

        public List<Passenger> GetPassengers()
        {
            return passengers;
        }

        // ToString method
            public override string ToString()
            {
                string customerInfo = $"Customer ID: {customerID}\n";
                customerInfo += $"Name: {firstName} {lastName}\n";
                customerInfo += $"Phone: {phone}\n";
                customerInfo += $"Number of Bookings: {numBookings}";

                return customerInfo;
            }
        


    }
}
