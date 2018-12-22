using System;

namespace Provider.Subscription.Entities
{
    /// <summary>
    /// The properly parsed subscriber object
    /// </summary>
    public class Subscriber
    {
        #region Properties

        public string SubscriberNo { get; set; }
        public decimal Debt { get; set; }
        public DateTime DueDate { get; set; }
        public int Year { get; set; }
        public string InvoiceNumber { get; set; }

        #endregion

        #region Methods - Public

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(SubscriberNo) && SubscriberNo.Length == 9
                && Debt >= 0
                && DueDate > DateTime.MinValue && DueDate < DateTime.MaxValue
                && Year > 0
                && !string.IsNullOrWhiteSpace(InvoiceNumber) && InvoiceNumber.Length == 11
                ;
        }

        #endregion
    }
}