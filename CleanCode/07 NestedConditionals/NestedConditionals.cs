using System;

namespace CleanCode.NestedConditionals
{
    public class Customer
    {
        public int LoyaltyPoints { get; set; }
    }

    public class Reservation
    {
        public Reservation(Customer customer, DateTime dateTime)
        {
            From = dateTime;
            Customer = customer;
        }

        public DateTime From { get; set; }
        public Customer Customer { get; set; }
        public bool IsCanceled { get; set; }

        public void Cancel()
        {
            // If reservation already started throw exception
            IsReservationAlreadyStarted(From);

            // Gold customers can cancel up to 24 hours before
            if (Customer.LoyaltyPoints > 100)
            {
                IsReservationTooSoon(From, 24);
            }
            // Regular customers can cancel up to 48 hours before
            else
            {
                IsAlreadyStarted(From);
                IsReservationTooSoon(From, 48);
            }
            IsCanceled = true;
        }
        
        public void IsReservationAlreadyStarted(DateTime from){
            if (DateTime.Now > from)
            {
                throw new InvalidOperationException("It's too late to cancel.");
            }
        }
                
        public void IsReservationTooSoon(DateTime from, minimumHours){
            if ((from - DateTime.Now).TotalHours < minimumHours)
            {
                throw new InvalidOperationException("It's too late to cancel.");
            }
        }

    }
}
