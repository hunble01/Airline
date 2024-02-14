using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class FlightManager
    {
       
            // Properties
            private int maxFlight;
            private int numFlight;
            private Flight[] flightList;

            // Constructor
            public FlightManager(int max)
            {
                maxFlight = max;
                numFlight = 0;
                flightList = new Flight[maxFlight];
            }

            // Method to add a new flight
            public bool AddFlight(int flightID, string origin, string destination, int maxSeats, int numPassengers)
            {
            if (flightList.Any(f => f != null && f.GetFlightID() == flightID))
            {
                Console.WriteLine($"Flight with ID {flightID} already exists. Cannot add duplicate flights.");
                return false;
            }

            if (numFlight < maxFlight)
                {
                    Flight newFlight = new Flight(flightID, origin, destination, maxSeats, numPassengers);
                    flightList[numFlight] = newFlight;
                    numFlight++;
                    return true; // Successfully added the flight
                }
                else
                {
                    return false; // Flight list is full
                }
            }

            // Method to view a specific flight
            public Flight ViewFlight(int flightID)
            {
                foreach (Flight flight in flightList)
                {
                    if (flight != null && flight.GetFlightID() == flightID)
                    {
                        return flight; // Found the flight
                    }
                }
                return null; // Flight not found
            }

            // Method to delete a specific flight
            public Flight DeleteFlight(int flightID)
            {
                for (int i = 0; i < numFlight; i++)
                {
                    if (flightList[i] != null && flightList[i].GetFlightID() == flightID)
                    {
                        Flight deletedFlight = flightList[i];
                        // Shift remaining flights to fill the gap
                        for (int j = i; j < numFlight - 1; j++)
                        {
                            flightList[j] = flightList[j + 1];
                        }
                        flightList[numFlight - 1] = null; // Set the last element to null
                        numFlight--;
                        return deletedFlight; // Successfully deleted the flight
                    }
                }
                return null; // Flight not found
            }

        public void SaveFlightsToFile(string filePath)
        {
            File.WriteAllLines(filePath, flightList.Where(flight => flight != null).Select(flight => flight.ToFileString()));
        }

        public void LoadFlightsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Flight newFlight = Flight.FromFileString(line);

                Flight existingFlight = flightList.FirstOrDefault(f => f != null && f.GetFlightID() == newFlight.GetFlightID());

                if (existingFlight != null)
                {
                    // Update existing flight properties
                    // Handle updates as needed
                }
                else
                {
                    // If flight with the same ID doesn't exist, add the new flight
                    flightList[numFlight] = newFlight;
                    numFlight++;
                }
            }
        }

            // Method to view all flights
            public string ViewAllFlights()
            {
                StringBuilder result = new StringBuilder();
                foreach (Flight flight in flightList)
                {
                    if (flight != null)
                    {
                        result.AppendLine($"Flight ID: {flight.GetFlightID()}, Origin: {flight.GetOrigin()}, Destination: {flight.GetDestination()}, Max Seats: {flight.GetMaxSeats()}, Num Passengers: {flight.GetNumPassengers()}");
                    }
                }
                return result.ToString();
            }
        

    }
}
