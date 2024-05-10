using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program
{
    internal class Reservation
    {
        public int ReservationID { get; private set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsCancelled { get; private set; }
        public int TableID { get; private set; }


        public Reservation(int reservationID, DateTime reservationTime, int numberOfPeople, int tableID)
        {
            ReservationID = reservationID;
            ReservationTime = reservationTime;
            NumberOfPeople = numberOfPeople;
            IsCancelled = false;
            TableID = tableID;
        }



        public void CreateReservation()
        {

            Console.WriteLine($"Reservation {ReservationID} created for {NumberOfPeople} people at {ReservationTime} at Table {TableID}.");
        }

        public void CancelReservation(Table table)
        {
            table.Reservations.Remove(this);


            Console.WriteLine($"Reservation {ReservationID} cancelled.");


        }

        public void ChangeReservationTime(DateTime newReservationTime)
        {
            ReservationTime = newReservationTime;
            Console.WriteLine($"Reservation {ReservationID} time changed to {ReservationTime}.");
        }
    }
}
