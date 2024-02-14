using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Airline
{
    internal class BookingManager
    {
        private const int MaxBookings = 100; // Adjust the value accordingly
        private int numBookings;
        private Booking[] bookingList;

        public BookingManager(int maxBookings)
        {
            numBookings = 0;
            bookingList = new Booking[MaxBookings];
        }

        public bool AddBooking(int bookingID, string date, Flight flight, Customer customer)
        {
            if (numBookings < MaxBookings)
            {
                Booking newBooking = new Booking(bookingID, date, new[] { flight }, new[] { customer });
                bookingList[numBookings] = newBooking;
                numBookings++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Booking ViewBooking(int bookingID)
        {
            foreach (Booking booking in bookingList)
            {
                if (booking != null && booking.GetBookingID() == bookingID)
                {
                    return booking;
                }
            }
            return null;
        }

        public string ViewAllBookings()
        {
            StringBuilder result = new StringBuilder();

            foreach (Booking booking in bookingList)
            {
                if (booking != null)
                {
                    result.AppendLine($"Booking ID: {booking.GetBookingID()}, Date: {booking.GetDate()}");

                    // Display information about each flight in the booking
                    result.AppendLine("Flights:");
                    foreach (Flight flight in booking.GetFlights())
                    {
                        result.AppendLine($"  - {flight.ToString()}");
                    }

                    // Display information about each customer in the booking
                    result.AppendLine("Customers:");
                    foreach (Customer customer in booking.GetCustomers())
                    {
                        result.AppendLine($"  - {customer.ToString()}");
                    }

                    result.AppendLine(); // Add a newline for better readability
                }
            }

            return result.ToString();
        }

        public bool CancelBooking(int bookingID)
        {
            for (int i = 0; i < numBookings; i++)
            {
                if (bookingList[i] != null && bookingList[i].GetBookingID() == bookingID)
                {
                    ShiftArrayElements(bookingList, i);
                    numBookings--;
                    return true;
                }
            }
            return false;
        }

        public void SaveBookingsToFile(string filePath)
        {
            File.WriteAllLines(filePath, bookingList.Where(booking => booking != null).Select(booking => booking.ToFileString()));
        }

        public void LoadBookingsFromFile(string filePath, FlightManager flightManager, CustomerManager customerManager)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Booking newBooking = Booking.FromFileString(line, flightManager, customerManager);

                Booking existingBooking = bookingList.FirstOrDefault(b => b != null && b.GetBookingID() == newBooking.GetBookingID());

                if (existingBooking != null)
                {
                    // Update existing booking properties
                    // Handle updates as needed
                }
                else
                {
                    // If booking with the same ID doesn't exist, add the new booking
                    bookingList[numBookings] = newBooking;
                    numBookings++;
                }
            }
        }

        private static void ShiftArrayElements<T>(T[] array, int index)
        {
            for (int j = index; j < array.Length - 1; j++)
            {
                array[j] = array[j + 1];
            }
            array[array.Length - 1] = default; // Set the last element to default value (null for reference types)
        }
    }
}
