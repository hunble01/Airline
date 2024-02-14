namespace Airline
{
    internal class Program
    {
        // MICHAEL WEST - 101395382
        // AHAD ABDUL - 101447984
        // Abdulgafar Towolawi - 101462578
        // Marten Maximous - 101377704
        static void Main(string[] args)
        {

            const string customerFilePath = "Customers.txt";
            const string flightFilePath = "Flights.txt";
            const string bookingFilePath = "Bookings.txt";

            
            // Initialize the airline system
            AirlineCoordinator coordinator = InitializeAirline();

            coordinator.LoadDataFromFiles(customerFilePath, flightFilePath, bookingFilePath);

            while (true)
            {
                Console.WriteLine("Rodgers AirLines Limited.");
                Console.WriteLine("Please select a choice from the menu below:");
                Console.WriteLine("1: Customers");
                Console.WriteLine("2: Flights");
                Console.WriteLine("3: Make Bookings");
                Console.WriteLine("4: View Bookings");
                Console.WriteLine("5: Exit");

                string mainMenuChoice = Console.ReadLine();

                switch (mainMenuChoice)
                {
                    case "1":
                        CustomerMenu(coordinator);
                        break;
                    case "2":
                        FlightMenu(coordinator);
                        break;
                    
                    case "3":
                        // Add case for "Make booking" option
                        MakeBookingMenu(coordinator);
                        break;
                    case "4":
                        // Add case for "View bookings" option
                        ViewBookingsMenu(coordinator);
                        break;
                    case "5":
                        Console.WriteLine("Exiting program. Goodbye!");
                        coordinator.SaveDataToFiles(customerFilePath, flightFilePath, bookingFilePath);
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }




            static void CustomerMenu(AirlineCoordinator coordinator)
            {
                while (true)
                {
                    Console.WriteLine("Rodgers AirLines Limited. Customer Menu");
                    Console.WriteLine("Please select a choice from the menu below:");
                    Console.WriteLine("1: Add Customer");
                    Console.WriteLine("2: View Customers");
                    Console.WriteLine("3: Delete Customer");
                    Console.WriteLine("4: Back to main menu");

                    string customerMenuChoice = Console.ReadLine();

                    switch (customerMenuChoice)
                    {
                        // Inside CustomerMenu method

                        case "1":
                            // Add Customer logic
                            Console.WriteLine("Adding a new customer...");
                            Console.Write("Enter Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());

                            Console.Write("Enter First Name: ");
                            string firstName = Console.ReadLine();

                            Console.Write("Enter Last Name: ");
                            string lastName = Console.ReadLine();

                            Console.Write("Enter Phone: ");
                            string phone = Console.ReadLine();

                            Console.Write("Enter Number of Bookings: ");
                            int numBookings = int.Parse(Console.ReadLine());

                            bool addedCustomer = coordinator.AddCustomer(customerId, firstName, lastName, phone, numBookings);

                            if (addedCustomer)
                            {
                                Console.WriteLine("Customer added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add customer. Customer list might be full.");
                            }
                            break;

                        case "2":
                            // View Customer logic
                            Console.WriteLine("Enter customer ID: ");
                            if (int.TryParse(Console.ReadLine(), out int specificCustomerID))
                            {
                                Console.WriteLine(coordinator.ViewCustomers(specificCustomerID));
                            }
                            else
                            {
                                Console.WriteLine("Invalid customer ID.");
                            }
                            break;


                        case "3":
                            // Delete Customer logic
                            Console.WriteLine("Deleting a customer...");
                            Console.Write("Enter Customer ID to delete: ");
                            int customerIdToDelete = int.Parse(Console.ReadLine());

                            Customer deletedCustomer = coordinator.RemoveCustomer(customerIdToDelete);

                            if (deletedCustomer != null)
                            {
                                Console.WriteLine($"Customer ID {customerIdToDelete} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Customer ID {customerIdToDelete} not found.");
                            }
                            break;



                        case "4":
                            return; // Go back to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                            break;
                    }
                }
            }

            static void FlightMenu(AirlineCoordinator coordinator)
            {
                while (true)
                {
                    Console.WriteLine("\nFlight Menu");
                    Console.WriteLine("Please select a choice from the menu below:");
                    Console.WriteLine("1: Add Flight");
                    Console.WriteLine("2: View Flights");
                    Console.WriteLine("3: View a particular Flight");
                    Console.WriteLine("4: Delete Flight");
                    Console.WriteLine("5: Back to main menu");

                    string flightMenuChoice = Console.ReadLine();

                    switch (flightMenuChoice)
                    {
                        case "1":
                            // Add Flight logic
                            Console.WriteLine("Adding a new flight...");

                            // Gather flight details from the user
                            Console.Write("Enter Flight ID: ");
                            int flightID = int.Parse(Console.ReadLine());

                            Console.Write("Enter Origin: ");
                            string origin = Console.ReadLine();

                            Console.Write("Enter Destination: ");
                            string destination = Console.ReadLine();

                            Console.Write("Enter Max Seats: ");
                            int maxSeats = int.Parse(Console.ReadLine());

                            Console.Write("Enter Num Passengers: ");
                            int numPassengers = int.Parse(Console.ReadLine());

                            // Call the coordinator method to add the flight
                            bool flightAdded = coordinator.AddFlight(flightID, origin, destination, maxSeats, numPassengers);

                            if (flightAdded)
                            {
                                Console.WriteLine($"Flight with ID {flightID} added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add the flight. The flight list may be full.");
                            }
                            break;

                        case "2":
                            // View Flights logic
                            Console.WriteLine("Viewing all flights...");
                            string flightsList = coordinator.ViewAllFlights();
                            Console.WriteLine(flightsList);
                            break;

                        case "3":
                            // View a particular Flight logic
                            Console.WriteLine("Viewing a particular flight...");
                            Console.Write("Enter Flight ID: ");
                            int flightIdToView = int.Parse(Console.ReadLine());
                            Flight viewedFlight = coordinator.ViewFlight(flightIdToView);
                            if (viewedFlight != null)
                            {
                                Console.WriteLine(viewedFlight.ToString());
                            }
                            else
                            {
                                Console.WriteLine($"Flight with ID {flightIdToView} not found.");
                            }
                            break;

                        case "4":
                            // Delete Flight logic
                            Console.WriteLine("Deleting a flight...");
                            Console.Write("Enter Flight ID to delete: ");
                            int flightIdToDelete = int.Parse(Console.ReadLine());
                            Flight deletedFlight = coordinator.DeleteFlight(flightIdToDelete);
                            if (deletedFlight != null)
                            {
                                Console.WriteLine($"Flight with ID {flightIdToDelete} deleted successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"Flight with ID {flightIdToDelete} not found.");
                            }
                            break;
                        case "5":
                            return; // Go back to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                            break;
                    }
                }
            }

            
            static void MakeBookingMenu(AirlineCoordinator coordinator)
            {
                Console.WriteLine("Make Booking Menu");

                // Gather booking details from the user
                Console.Write("Enter Booking ID: ");
                int bookingID = int.Parse(Console.ReadLine());

                Console.Write("Enter Booking Date: ");
                string bookingDate = Console.ReadLine();

                // Assuming a flight is already added, you may want to prompt the user to select a flight
                Console.Write("Enter Flight ID for the booking: ");
                int flightIDForBooking = int.Parse(Console.ReadLine());
                Flight selectedFlight = coordinator.ViewFlight(flightIDForBooking);

                if (selectedFlight == null)
                {
                    Console.WriteLine($"Flight with ID {flightIDForBooking} not found. Booking canceled.");
                    return;
                }

                // Assuming a customer is already added, you may want to prompt the user to select a customer
                Console.Write("Enter Customer ID for the booking: ");
                int customerIDForBooking = int.Parse(Console.ReadLine());
                Customer selectedCustomer = coordinator.ViewCustomers(customerIDForBooking);

                if (selectedCustomer == null)
                {
                    Console.WriteLine($"Customer with ID {customerIDForBooking} not found. Booking canceled.");
                    return;
                }

                // Call the coordinator method to make the booking
                bool bookingMade = coordinator.AddBooking(bookingID, bookingDate, selectedFlight, selectedCustomer);

                if (bookingMade)
                {
                    Console.WriteLine($"Booking with ID {bookingID} made successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to make the booking. Please check the availability of seats.");
                }
            }


            static void ViewBookingsMenu(AirlineCoordinator coordinator)
            {
                Console.WriteLine("Viewing all bookings...");

                // Call the coordinator method to retrieve and display bookings
                string allBookings = coordinator.ViewAllBookings();

                // Display the retrieved bookings
                Console.WriteLine("All Bookings:");
                Console.WriteLine(allBookings);
            }


            static AirlineCoordinator InitializeAirline()
            {

                int maxFlights = 100; // Replace with the desired value
                int maxBookings = 100; // Replace with the desired value
                int maxCustomers = 100; // Replace with the desired value
                // Initialize the managers and other components
                FlightManager flightManager = new FlightManager(maxFlights);
                BookingManager bookingManager = new BookingManager(maxBookings);
                CustomerManager customerManager = new CustomerManager(maxCustomers);

                // Create an instance of AirlineCoordinator and pass the initialized managers
                AirlineCoordinator coordinator = new AirlineCoordinator(flightManager, bookingManager, customerManager);

                // Additional setup if needed
                // ...

                return coordinator;
            }

        }
    }
}
            
    

