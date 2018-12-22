namespace Provider.Subscription.Entities
{
    /// <summary>
    /// The unparsed object. The properties may contain either parsable or unparsable string. The only purpose of this object is to keep
    /// track of parsing operation. If there is something wrong with the parsing, we can see why in the UI section with this object
    /// </summary>
    public class SubscriberOriginal
    {
        #region Properties

        public string SubscriberNo { get; set; }
        public string Debt { get; set; }
        public string DueDate { get; set; }
        public string Year { get; set; }
        public string InvoiceNumber { get; set; }

        #endregion
    }
}