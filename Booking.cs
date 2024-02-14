using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Booking
    {
            // Properties
            private int bookingID;
            private string date;
            private Flight[] flights;
            private Customer[] customers;

            // Constructor
            public Booking(int bookingID, string date, Flight[] flights, Customer[] customers)
            {
                this.bookingID = bookingID;
                this.date = date;
                this.flights = flights;
                this.customers = customers;
                
        }

            // Getter methods
            public int GetBookingID()
            {
                return bookingID;
            }

            public string GetDate()
            {
                return date;
            }

        
        public Flight[] GetFlights()
        {
            return flights;
        }

        public Customer[] GetCustomers()
        {
            return customers;
        }

        public string ToFileString()
        {
            // Convert booking data to a string format (customize as needed)
            string flightsString = string.Join(",", flights.Select(flight => flight.GetFlightID().ToString()));
            string customersString = string.Join(",", customers.Select(customer => customer.GetCustomerID().ToString()));

            return $"{bookingID},{date},{flightsString},{customersString}";
        }

        public static Booking FromFileString(string fileString, FlightManager flightManager, CustomerManager customerManager)
        {
            // Create a Booking object from a string read from a text file
            string[] data = fileString.Split(',');
            int bookingID = int.Parse(data[0]);
            string date = data[1];

            // Parse flight IDs and get corresponding Flight objects
            int[] flightIDs = data[2].Split(',').Select(int.Parse).ToArray();
            Flight[] flights = flightIDs.Select(id => flightManager.ViewFlight(id)).ToArray();

            // Parse customer IDs and get corresponding Customer objects
            int[] customerIDs = data[3].Split(',').Select(int.Parse).ToArray();
            Customer[] customers = customerIDs.Select(id => customerManager.ViewCustomers(id)).ToArray();

            return new Booking(bookingID, date, flights, customers);
        }


        // ToString method
        public override string ToString()
            {
                StringBuilder bookingInfo = new StringBuilder();
                bookingInfo.AppendLine($"Booking ID: {bookingID}");
                bookingInfo.AppendLine($"Date: {date}");

                // Display information about each flight in the booking
                bookingInfo.AppendLine("Flights:");
                foreach (Flight flight in flights)
                {
                    bookingInfo.AppendLine(flight.ToString());
                }

                // Display information about each customer in the booking
                bookingInfo.AppendLine("Customers:");
                foreach (Customer customer in customers)
                {
                    bookingInfo.AppendLine(customer.ToString());
                }

                return bookingInfo.ToString();
            }

       
    }
}
