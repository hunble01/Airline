using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class CustomerManager
    {
       
            private const int MaxCustomers = 100; // Adjust the value accordingly
            private int numCustomers;
            private Customer[] customerList;

            public CustomerManager(int maxCustomer)
            {
                numCustomers = 0;
                customerList = new Customer[MaxCustomers];
            }

            public bool AddCustomer(int customerID, string fName, string lName, string ph, int numBookings)
            {
                if (numCustomers < MaxCustomers)
                {
                    customerList[numCustomers] = new Customer(customerID, fName, lName, ph, numBookings);
                    numCustomers++;
                    return true;
                }
                return false;
            }

            public bool AddPassenger(int customerID, string fName, string lName, string ph, int numBookings, int seatNum, bool bookingStatus)
            {
                if (numCustomers < MaxCustomers)
                {
                    customerList[numCustomers] = new Passenger(seatNum, bookingStatus, customerID, fName, lName, ph, numBookings);
                    numCustomers++;
                    return true;
                }
                return false;
            }
        public Passenger ViewPassenger(int customerID, int seatNumber)
        {
            foreach (Customer customer in customerList)
            {
                if (customer is Passenger passenger &&
                    passenger.GetCustomerID() == customerID &&
                    passenger.GetSeatNum() == seatNumber)
                {
                    return passenger; // Found the passenger
                }
            }
            return null; // Passenger not found
        }



        public Customer RemoveCustomer(int customerID)
        {
            for (int i = 0; i < numCustomers; i++)
            {
                if (customerList[i] != null && customerList[i].GetCustomerID() == customerID)
                {
                    Customer removedCustomer = customerList[i];
                    // Shift remaining customers to fill the gap
                    for (int j = i; j < numCustomers - 1; j++)
                    {
                        customerList[j] = customerList[j + 1];
                    }
                    customerList[numCustomers - 1] = null; // Set the last element to null
                    numCustomers--;
                    return removedCustomer; // Successfully removed the customer
                }
            }
            return null; // Customer not found
        }


        public Customer ViewCustomers(int customerID)
        {
            foreach (Customer customer in customerList)
            {
                if (customer != null && customer.GetCustomerID() == customerID)
                {
                    return customer; // Found the customer
                }
            }
            return null; // Customer not found
        }


        public Passenger RemovePassenger(int customerID, int seatNumber)
        {
            foreach (Customer customer in customerList)
            {
                if (customer != null && customer.GetCustomerID() == customerID)
                {
                    Passenger removedPassenger = customer.RemovePassenger(seatNumber);
                    return removedPassenger;
                }
            }
            return null; // Customer not found
        }

        public void SaveCustomersToFile(string filePath)
        {
            // Save customers data to a text file
            File.WriteAllLines(filePath, customerList.Where(customer => customer != null).Select(customer => customer.ToFileString()));
        }

        public void LoadCustomersFromFile(string filePath)
        {
            // Load customers data from a text file
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                Customer newCustomer = Customer.FromFileString(line);

                // Decide how to handle duplicates or updates
                Customer existingCustomer = customerList.FirstOrDefault(c => c != null && c.GetCustomerID() == newCustomer.GetCustomerID());

                if (existingCustomer != null)
                {
                    // Update existing customer properties
                    existingCustomer.SetFirstName(newCustomer.GetFirstName());
                    existingCustomer.SetLastName(newCustomer.GetLastName());
                    // Update other properties as needed
                }
                else
                {
                    // If customer with the same ID doesn't exist, add the new customer
                    customerList[numCustomers] = newCustomer;
                    numCustomers++;
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
