using Provider.Subscription.Entities;
using System.Collections.Concurrent;
using System.Linq;
using System.Windows.Forms;

namespace UI.Win.DataPresenter
{
    public partial class FormLog : Form
    {
        public FormLog(ConcurrentBag<SubscriberOriginal> subscribers)
        {
            InitializeComponent();

            dataGridView_UnparsedSubscribers.DataSource = subscribers.Select(c =>
                new
                {
                    c.SubscriberNo,
                    c.Debt,
                    c.DueDate,
                    c.Year,
                    c.InvoiceNumber
                }).ToList();
        }
    }
}