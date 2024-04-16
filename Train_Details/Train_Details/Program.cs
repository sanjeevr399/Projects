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
        //static Admin ad = new Admin();
        static ADMIN_LOGIN ad = new ADMIN_LOGIN();
        static User_LogIn u_login = new User_LogIn();

        //----------------------------------------------------------------------------

        //----------------------------------------------------------------------------

        static void Main(string[] args)
        {

            Console.WriteLine("                    ============================================================");
            Console.WriteLine("                    |                                                          |");
            Console.WriteLine("                    |       Welcome TO Railway Reservation Application         |");
            Console.WriteLine("                    |                                                          |");
            Console.WriteLine("                    ============================================================");

            //-----------------------------------------------------------------------------------------------------------

            Console.WriteLine("\nPress 1 for  login as Admin");
            Console.WriteLine("Press 2 for  login as User");
            Console.WriteLine("Enter your Choice");
            string Choice = Console.ReadLine();
            switch (Choice)
            {
                case "1":
                    Console.WriteLine("             ----------------First Login to get the Access of Admin Panel----------------------");
                    Admin_control();
                    break;
                case "2":
                    Console.WriteLine("                       ----------------you are in user panel-----------------------");
                    UserControl();
                    break;
                default:
                    Console.WriteLine("Enter valid");
                    break;
            }
            Console.Read();
        }

        static void Admin_control()
        {
            Console.WriteLine("Enter Admin ID:");
            int AdminId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Password:");
            string Password = Console.ReadLine();
            var admin = db.ADMIN_LOGIN.FirstOrDefault(a => a.Admin_Id == AdminId && a.Admin_Password == Password);

            if (admin != null)
            {
                Console.WriteLine("\n                              -------------- Admin login successful !!  -------------------\n");
                Console.WriteLine("Now you can access all admin authorization ");

                //Console.WriteLine("Hii!! Welcome to Railway Reservation System--");
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
            else
            {
                Console.WriteLine("Invalid Admin_id or Password ! Please try again.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            //------------------------------------------------------------------------------------------------------------

        }

        public static void AdminControl()
        {
            //--------------------------------------------------------------------------------------------
            Console.WriteLine("Press 1 for Add Trains");
            Console.WriteLine("Press 2 for Modify Trains");
            Console.WriteLine("Press 3 for Soft Delete Trains");
            Console.WriteLine("Press 4 for Exit");
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
                    Console.WriteLine("\t         -----------------Soft Delete the unwanted train--------------------\n");
                    DisplayTrains_details();
                    Soft_DeleteTrain();
                    DisplayTrains_details();
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
                Console.WriteLine($"\t           -----------------Your Train has been successfully modified-------------------        \n");
                DisplayTrains_details();
            }
            else
            {
                Console.WriteLine("Train with the provided number does not exist.");
            }
        }


        //-------------------------------------------------------------------------------------------------------------

        public static void Soft_DeleteTrain()
        {
            Console.WriteLine("Enter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());

            // Retrieve the train details from the database
            var trainToDelete = db.Train_details.FirstOrDefault(t => t.Tno == trainNo);
            if (trainToDelete != null)
            {
                // Soft delete by updating the status to "Inactive"
                trainToDelete.Tstatus = "N";
                db.SaveChanges();
                Console.WriteLine("Train  Soft deleted successfully.");
                Console.ReadLine();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Train with the provided number does not exist.");
                //Admincontrol();
            }
        }

        //-------------------------------------------------------------------------------------------------------------

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
                    ShowBooking();
                    break;
                case "2":
                    //Console.WriteLine("Please cancel the tickets");
                    Console.WriteLine("Please cancel the ticket from the below booking details");
                    ShowBooking();
                    Cancel_ticket();
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
                Console.WriteLine("=====================================================================================================================");
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
            Console.WriteLine("\nEnter the train number you want to book the tickets:");
            int train_no = int.Parse(Console.ReadLine());
            var traino = db.Train_details.FirstOrDefault(t => t.Tno == train_no);

            if(traino != null)
            {
                // Get user input to populate dynamic object

                //Console.WriteLine("\nEnter the booking id:");
                //book.Bid = int.Parse(Console.ReadLine());
                Random random = new Random();
                book.Bid = random.Next(1, 200);

                Console.WriteLine("\nEnter the train no.");
                book.Tno = int.Parse(Console.ReadLine());

                Console.WriteLine("\nEnter the Tclass:");
                book.@class = Console.ReadLine();


                //Console.WriteLine("Please enter the date in the format (YYYY-MM-DD):");

                DateTime today = DateTime.Today;
                book.date_of_travel = today;

                Console.WriteLine("\nEnter the no of tickets you want to book:");
               // book.no_of_ticket = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                book.no_of_ticket = n;

                // Proc
                db.UpdateAvailableSeats(book.Tno, book.no_of_ticket);


                //-------------------------------------------------------------

                Console.WriteLine("\nEnter The Total Amount:");
                book.Total_amount = int.Parse(Console.ReadLine());


                db.Booking_status.Add(book);
                db.SaveChanges();
                Console.WriteLine($"Seats has been successfully added & your booking id is {book.Bid}");
            }
            else
            {
                Console.WriteLine("Please Enter Valid Train Number");
            }

            
        }

        public static void Cancel_ticket()
        {
            Console.WriteLine("\nEnter the train number you want to cancel the tickets:");
            int tr_no = int.Parse(Console.ReadLine());
            var trno = db.Booking_status.FirstOrDefault(t => t.Tno == tr_no);

            if (trno != null)
            {
                // Get user input to populate dynamic object

                //Console.WriteLine("\nEnter the cancellation id:");
                //cancel.Cid = int.Parse(Console.ReadLine());
                Random random = new Random();
                cancel.Cid = random.Next(1, 200);

                Console.WriteLine("\nEnter Tno:");
                cancel.Tno = int.Parse(Console.ReadLine());

                //Console.WriteLine("\nEnter the Tclass:");
                //cancel.@class = Console.ReadLine();


                //Console.WriteLine("Please enter the date in the format (YYYY-MM-DD):");
                DateTime today = DateTime.Today;
                cancel.date_of_travel = today;


                Console.WriteLine("\nEnter the no of tickets you want to cancel:");
                cancel.no_of_ticket = int.Parse(Console.ReadLine());

                //Proc
                db.CancelTableAvailableSeats(cancel.Tno, cancel.no_of_ticket);

                Console.WriteLine("\nEnter The Refund Amount:");
                cancel.refund = int.Parse(Console.ReadLine());

                //Console.WriteLine("\nEnter the booking id:");
                cancel.bid = book.Bid;

                //book.Bid = random.Next(1, 200);

                db.Cancelled_ticket.Add(cancel);
                db.SaveChanges();
                Console.WriteLine($"Seats has been successfully cancelled & your booking id is {cancel.Cid}");
            }
            else
            {
                Console.WriteLine("Please Enter Valid Train Number");
            }

               
        }
        public static void ShowBooking()
        {
            var Bookingdata = db.Booking_status.ToList();
            foreach (var e in Bookingdata)
            {
                //Console.WriteLine($"Booking_ID: {e.Bid},Train_no: {e.Tno},Class: {e.@class},Date: {e.date_of_travel},No.of_tickets: {e.no_of_ticket},Total_amount: {e.Total_amount}");
                Console.WriteLine("╔═════════════════════════════════════════╗");
                Console.WriteLine("║             BOOKING DETAILS             ║");
                Console.WriteLine("╠═════════════════════════════════════════╣");
                Console.WriteLine($"║ Booking ID:        {e.Bid}             ║");
                Console.WriteLine($"║ Train_no:          {e.Tno}             ║");
                Console.WriteLine($"║ Class Name:        {e.@class}          ║");
                Console.WriteLine($"║ Date of Travel:    {e.date_of_travel}  ║");
                Console.WriteLine($"║ Number of Tickets: {e.no_of_ticket}    ║");
                Console.WriteLine($"║ Total Amount:      {e.Total_amount}    ║");
                Console.WriteLine("╚═════════════════════════════════════════╝");
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