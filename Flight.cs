using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Flight
    {
            // Properties
            private int flightID;
            private string origin;
            private string destination;
            private int maxSeats;
            private int numPassengers;

            // Constructor
            public Flight(int flightID, string origin, string destination, int maxSeats, int numPassengers)
            {
                this.flightID = flightID;
                this.origin = origin;
                this.destination = destination;
                this.maxSeats = maxSeats;
                this.numPassengers = numPassengers;
            }

            // Getter methods
            public int GetFlightID()
            {
                return flightID;
            }

            public string GetOrigin()
            {
                return origin;
            }

            public string GetDestination()
            {
                return destination;
            }

            public int GetMaxSeats()
            {
                return maxSeats;
            }

            public int GetNumPassengers()
            {
                return numPassengers;
            }

        public string ToFileString()
        {
            // Convert flight data to a string format (you can customize this)
            return $"{flightID},{origin},{destination},{maxSeats},{numPassengers}";
        }

        public static Flight FromFileString(string fileString)
        {
            // Create a Flight object from a string read from a text file
            string[] data = fileString.Split(',');
            // Parse data and create a new Flight object
            return new Flight(int.Parse(data[0]), data[1], data[2], int.Parse(data[3]), int.Parse(data[4]));
        }

        // ToString method
        public override string ToString()
            {
                string flightInfo = $"Flight ID: {flightID}\n";
                flightInfo += $"Origin: {origin}\n";
                flightInfo += $"Destination: {destination}\n";
                flightInfo += $"Max Seats: {maxSeats}\n";
                flightInfo += $"Num Passengers: {numPassengers}";

                return flightInfo;
            }
        


    }
}
