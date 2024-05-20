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

        public Table(int tableID, string status, int maxCapacity)
        {
            TableID = tableID;
            Status = status;
            MaxCapacity = maxCapacity;
            Reservations = new List<Reservation>();
        }

        public Table() { }  
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
    }
}
