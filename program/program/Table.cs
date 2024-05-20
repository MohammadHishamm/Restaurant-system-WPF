using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Table
    {
        public int TableID { get; private set; }
        public string Status { get; set; }
        public int MaxCapacity { get; private set; }
        public List<Reservation> Reservations { get; set; }

        public Table()
        {

        }
        public Table(int tableID, string status, int maxCapacity)
        {
            TableID = tableID;
            Status = status;
            MaxCapacity = maxCapacity;
            Reservations = new List<Reservation>();
        }

        public void AddReservation(Reservation reservation)
        {
            Reservations.Add(reservation);
            Console.WriteLine($"Reservation {reservation.ReservationID} added to table {TableID}.");
        }

        public List<Reservation> getReservation()
        {
            return Reservations;
        }

        public void ViewReservations()
        {
            Console.WriteLine("Reservations:");
            foreach (var item in getReservation())
            {
                Console.WriteLine($"{item.ReservationID}");
            }
        }

        public void RemoveReservation(Reservation reservation)
        {
            Reservations.Remove(reservation);
            Console.WriteLine($"Reservation {reservation.ReservationID} removed from table {TableID}.");
        }
        public void AddItemToDatabase(int TableID, int maxCapacity)
        {
            try
            {
                // Create an instance of the DBconfig class
                DBconfig db = DBconfig.Instance;

                // Open connection
                db.OpenConnection();

                // Insert item into the database
                string insertQuery = $"INSERT INTO [Tables] (id,maxcapacity) VALUES ({TableID},{maxCapacity})";
                db.InsertData(insertQuery);

                // Close connection
                db.CloseConnection();
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it or throw a custom exception)
                throw new Exception($"Error adding item to database: {ex.Message}");
            }
        }
    }
}
