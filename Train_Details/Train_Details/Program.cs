using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Train_Details
{
    class Program
    {
        static Mini_ProjectEntities db = new Mini_ProjectEntities();

        static Train_details tdetails = new Train_details();
        static Booking_status book = new Booking_status();
        static Cancelled_ticket cancel = new Cancelled_ticket();
        static Admin ad = new Admin();
        static User_LogIn u_login = new User_LogIn();

        //----------------------------------------------------------------------------

        //----------------------------------------------------------------------------

        static void Main(string[] args)
        {
            
            Console.WriteLine("Hii!! Welcome to Railway Reservation System--");
            Console.WriteLine("Press 1 for Admin");
            Console.WriteLine("Press 2 for User");
            Console.WriteLine("Press 3 for exit");
            Console.WriteLine("Enter your choice");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.WriteLine("you are in admin pannel & you have access to admin functionalities");
                    AdminControl();
                    break;
                case "2":
                    Console.WriteLine("you are in user pannel & you have access to user functionalities");
                    UserControl();
                    break;
                case "3":
                    exit();
                    break;
                default:
                    Console.WriteLine("Enter valid number");

                    break;

                    //AddTrains();
                    //AddTrains(tdetails);
                    //DisplayTrains_details();
                    Console.Read();
            }
        }

        public static void AdminControl()
        {
            //--------------------------------------------------------------------------------------------
            Console.WriteLine("Press 1 for Add Trains");
            Console.WriteLine("Press 2 for Modify Trains");
            Console.WriteLine("Press 3 for Exit");
            string res = Console.ReadLine();
            switch (res)
            {
                case "1":
                    Console.WriteLine("Please Add The Train");
                    AddTrains();
                    Console.WriteLine("Trains has been successfully added");
                    DisplayTrains_details();
                    break;
                case "2":
                    Console.WriteLine("Please modify the train\n");
                    modifytrains();
                    break;
                case "3":
                    Console.WriteLine("Please modify the train");
                    exit();
                    break;
                default:
                    Console.WriteLine("Enter valid number");

                    break;
            }

            //-----------------------------------------------------------------------------------------
            Console.Read();
        }

        public static void modifytrains()
        {
            DisplayTrains_details();
            Console.WriteLine("\nEnter Train Number:");
            int train_no = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var trainToUpdate = db.Train_details.FirstOrDefault(t => t.Tno == train_no);

            if (trainToUpdate != null)
            {
                Console.WriteLine("Enter Tclass:");
                trainToUpdate.Tclass = Console.ReadLine();
               
                Console.WriteLine("Enter Tname:");
                trainToUpdate.Tname = Console.ReadLine();

                Console.WriteLine("Enter TSource:");
                trainToUpdate.TSource = Console.ReadLine();

                Console.WriteLine("Enter TDestination:");
                trainToUpdate.TDestination = Console.ReadLine();

                Console.WriteLine("Enter TotalSeat:");
                trainToUpdate.TotalSeat = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter AvlSeat:");
                trainToUpdate.AvlSeat = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Tstatus:");
                trainToUpdate.Tstatus = Console.ReadLine();

                Console.WriteLine("Enter Fare:");
                trainToUpdate.Fare = int.Parse(Console.ReadLine());

                //db.Train_details.Add(tdetails);
                db.SaveChanges();
                DisplayTrains_details();
            }
            else
            {
                Console.WriteLine("Train with the provided number does not exist.");
            }
        }

        public static void UserControl()
        {
            //Console.WriteLine("Now you can access all user utilities ");
            Console.WriteLine("Press 1 for Book Tickets");
            Console.WriteLine("Press 2 for Cancel Tickest");
            Console.WriteLine("Press 3 for Show all Trains");
            Console.WriteLine("Press 4 for Show Booking");
            Console.WriteLine("Press 5 for Exit");

            //string ress = Console.ReadLine();
            string ress= Console.ReadLine();
            switch (ress)
            {
                case "1":
                    Console.WriteLine("\nPlease Book The Seats from the following trains\n");
                    DisplayTrains_details();
                    BookTrains();
                    Console.WriteLine("Seats has been successfully added");
                    break;
                case "2":
                    //Console.WriteLine("Please cancel the tickets");
                    Console.WriteLine("Please cancel the ticket from the below booking details");
                    ShowBooking();
                    Cancel_ticket();
                    Console.WriteLine("Seats has been successfully cancelled");
                    break;
                case "3":
                    DisplayTrains_details();
                    break;
                case "4":
                    ShowBooking();
                    break;
                case "5":
                    exit();
                    break;
                default:
                    Console.WriteLine("Enter valid number");
                    break;
            }
                    Console.Read();

        }

        public static void DisplayTrains_details()
        {
            var traindata = db.Train_details.ToList();
            foreach (var e in traindata)
            {
                Console.WriteLine($"Train No: {e.Tno},Class: {e.Tclass},Train Name: {e.Tname}, Source: {e.TSource},Destination: {e.TDestination},Total_Seat{e.TotalSeat},Avl_Seat{e.AvlSeat},Status: {e.Tstatus},Fare: {e.Fare}");
            }
        }

        public static void AddTrains()
        {
            // Get user input to populate dynamic object
            Console.WriteLine("Enter Tno:");
            tdetails.Tno = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Tclass:");
            tdetails.Tclass = Console.ReadLine();

            Console.WriteLine("Enter Tname:");
            tdetails.Tname = Console.ReadLine();

            Console.WriteLine("Enter TSource:");
            tdetails.TSource = Console.ReadLine();

            Console.WriteLine("Enter TDestination:");
            tdetails.TDestination = Console.ReadLine();

            Console.WriteLine("Enter TotalSeat:");
            tdetails.TotalSeat = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter AvlSeat:");
            tdetails.AvlSeat = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Tstatus:");
            tdetails.Tstatus = Console.ReadLine();

            Console.WriteLine("Enter Fare:");
            tdetails.Fare = int.Parse(Console.ReadLine());

            db.Train_details.Add(tdetails);
            db.SaveChanges();

            //-------------------------------------------------------------------------------------------------------------------

        }
        public static void BookTrains()
        {
            // Get user input to populate dynamic object

            Console.WriteLine("\nEnter the booking id:");
            book.Bid = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Tno:");
            book.Tno = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the Tclass:");
            book.@class = Console.ReadLine();

            
            //Console.WriteLine("Please enter the date in the format (YYYY-MM-DD):");
            Console.WriteLine("\nPlease enter a date (e.g., YYYY/MM/DD): ");
            string userInput = Console.ReadLine();

            // Attempt to parse the user input string into a DateTime object
            if (DateTime.TryParse(userInput, out DateTime date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("Failed to parse the date. Invalid format.");
            }
            book.date_of_travel = date;

            Console.WriteLine("\nEnter the no of tickets you want to book:");
            book.no_of_ticket = int.Parse(Console.ReadLine());

            // Proc
            db.UpdateAvailableSeats(book.Tno, book.no_of_ticket);


            //-------------------------------------------------------------

            Console.WriteLine("\nEnter The Total Amount:");
            book.Total_amount = int.Parse(Console.ReadLine());

            db.Booking_status.Add(book);
            db.SaveChanges();
        }

        public static void Cancel_ticket()
        {
            // Get user input to populate dynamic object

            Console.WriteLine("\nEnter the cancellation id:");
            cancel.Cid = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Tno:");
            cancel.Tno = int.Parse(Console.ReadLine());

            //Console.WriteLine("\nEnter the Tclass:");
            //cancel.@class = Console.ReadLine();


            //Console.WriteLine("Please enter the date in the format (YYYY-MM-DD):");
            Console.WriteLine("\nPlease enter a date (e.g., YYYY/MM/DD): ");
            string userInput = Console.ReadLine();

            // Attempt to parse the user input string into a DateTime object
            if (DateTime.TryParse(userInput, out DateTime date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("Failed to parse the date. Invalid format.");
            }
            cancel.date_of_travel = date;

            Console.WriteLine("\nEnter the no of tickets you want to cancel:");
            cancel.no_of_ticket = int.Parse(Console.ReadLine());

            //Proc
            db.CancelTableAvailableSeats(cancel.Tno, cancel.no_of_ticket);

            Console.WriteLine("\nEnter The Total Amount:");
            cancel.refund = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter the booking id:");
            cancel.bid = int.Parse(Console.ReadLine());

            db.Cancelled_ticket.Add(cancel);
            db.SaveChanges();
        }
        public static void ShowBooking()
        {
            var Bookingdata = db.Booking_status.ToList();
            foreach (var e in Bookingdata)
            {
                Console.WriteLine($"Booking_ID: {e.Bid},Train_no: {e.Tno},Class: {e.@class},Date: {e.date_of_travel},No.of_tickets: {e.no_of_ticket},Total_amount: {e.Total_amount}");
            }
        }

        public static void exit()
        {
            Console.WriteLine("To exit from console please write exit or press ctrl+C");
            Console.ReadLine();
        }

        //-------------------------------------------------------------------------------------------------------------

    }
}