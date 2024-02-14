using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class AirlineCoordinator
    {
            // Properties
            private FlightManager fm;
            private BookingManager bm;
            private CustomerManager cm;

           




        // Constructor
        public AirlineCoordinator(FlightManager fm, BookingManager bm, CustomerManager cm)
            {
                this.fm = fm;
                this.bm = bm;
                this.cm = cm;
            }

            // Method to add a flight
            public bool AddFlight(int flightID, string origin, string destination, int maxSeats, int numPassengers)
            {
                return fm.AddFlight(flightID, origin, destination, maxSeats, numPassengers);
            }

            // Method to view a flight
            public Flight ViewFlight(int flightID)
            {
                return fm.ViewFlight(flightID);
            }
           public string ViewAllFlights()
           {
              return fm.ViewAllFlights();
           }


        // Method to delete a flight
        public Flight DeleteFlight(int flightID)
            {
                return fm.DeleteFlight(flightID);
            }

            // Method to add a booking
            public bool AddBooking(int bookingID, string date, Flight flight, Customer customer)
            {
                return bm.AddBooking(bookingID, date, flight, customer);
            }

            // Method to view a booking
            public Booking ViewBooking(int bookingID)
            {
                return bm.ViewBooking(bookingID);
            }

            public string ViewAllBookings()
           {
               return bm.ViewAllBookings();
           }

        // Method to cancel a booking
        public bool CancelBooking(int bookingID)
            {
                return bm.CancelBooking(bookingID);
            }

            // Method to add a customer
            public bool AddCustomer(int customerID, string fName, string lName, string ph, int numBookings)
            {
                return cm.AddCustomer(customerID, fName, lName, ph, numBookings);
            }

        // Method to view a customer
        public Customer ViewCustomers(int customerID)
        {
            return cm.ViewCustomers(customerID);
        }

        // Method to remove a customer
        public Customer RemoveCustomer(int customerID)
            {
                return cm.RemoveCustomer(customerID);
            }

            // Method to add a passenger
            public bool AddPassenger(int customerID, string fName, string lName, string ph, int numBookings, int seatNum, bool bookingStatus)
            {
                return cm.AddPassenger(customerID, fName, lName, ph, numBookings, seatNum, bookingStatus);
            }

            // Method to view a passenger
            public Passenger ViewPassenger(int customerID, int seatNumber)
            {
                return cm.ViewPassenger(customerID, seatNumber);
            }

            // Method to remove a passenger
            public Passenger RemovePassenger(int customerID, int seatNumber)
            {
                return cm.RemovePassenger(customerID, seatNumber);
            }

        public void LoadDataFromFiles(string customerFilePath, string flightFilePath, string bookingFilePath)
        {
            cm.LoadCustomersFromFile(customerFilePath);
            fm.LoadFlightsFromFile(flightFilePath);
            bm.LoadBookingsFromFile(bookingFilePath, fm, cm);
        }

        public void SaveDataToFiles(string customerFilePath, string flightFilePath, string bookingFilePath)
        {
            cm.SaveCustomersToFile(customerFilePath);
            fm.SaveFlightsToFile(flightFilePath);
            bm.SaveBookingsToFile(bookingFilePath);
        }


    }




}

