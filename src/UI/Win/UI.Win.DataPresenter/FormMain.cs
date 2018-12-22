using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Provider.Subscription.Contracts;
using Provider.Subscription.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using UI.Win.DataPresenter.IoC;

namespace UI.Win.DataPresenter
{
    public partial class FormMain : Form
    {
        #region Fields

        private readonly WindsorContainer _container = new WindsorContainer();
        private readonly IFileParser _fileParser;

        #endregion

        #region Constructors

        public FormMain()
        {
            InitializeComponent();

            #region Installing Dependencies

            foreach (var containerInstaller in new List<IWindsorInstaller>
            {
                new CoreInstaller(),
                new ProviderInstaller()
            })
            {
                _container.Install(containerInstaller);
            }

            #endregion

            #region Resolving Dependencies

            _fileParser = _container.Resolve<IFileParser>();

            #endregion

            #region Setting Form Items as InitialState

            groupBox_Search.Enabled = false;
            button_Log.Visible = false;
            openFileDialog_Subscriber.Filter = "txt files (*.txt)|*.txt";

            #endregion
        }

        #endregion

        #region Buttons

        private async void button_LoadFile_Click(object sender, System.EventArgs e)
        {
            if (openFileDialog_Subscriber.ShowDialog() == DialogResult.OK)
            {
                #region Parsing Processor

                ToggleItems_Load(true);

                try
                {
                    await _fileParser.Parse(openFileDialog_Subscriber.FileName, (int)numericUpDown_ThreadCount.Value);

                    label_SuccessCount.Text = _fileParser.ParsedSubscribers.Count.ToString();
                    label_FailCount.Text = _fileParser.UnparsedSubscribers.Count.ToString();

                    ListInGrid(_fileParser.ParsedSubscribers.ToList());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                ToggleItems_Load(false);

                #endregion
            }
        }

        private void button_Search_Click(object sender, System.EventArgs e)
        {
            #region Searching Process

            ToggleItems_Search(true);

            if (string.IsNullOrWhiteSpace(textBox_Search.Text))
            {
                MessageBox.Show("Lütfen bir değer girin!");
            }
            else
            {
                var subscribers = _fileParser.ParsedSubscribers.Where(c =>
                        c.SubscriberNo.ToLower(CultureInfo.InvariantCulture).Contains(
                            textBox_Search.Text.ToLower(CultureInfo.InvariantCulture)))
                    .ToList();

                label_SearchResult.Text = !subscribers.Any()
                    ? "Kayıt bulunamadı!"
                    : subscribers.Sum(c => c.Debt).ToString();

                ListInGrid(subscribers);
            }

            #endregion

            ToggleItems_Search(false);
        }

        private void button_Log_Click(object sender, EventArgs e)
        {
            FormLog form = new FormLog(_fileParser.UnparsedSubscribers);
            form.ShowDialog(this);
        }

        #endregion

        #region Methods - Private

        private void ListInGrid(List<Subscriber> subscribers)
        {
            dataGridView_Subscribers.DataSource = subscribers.Select(c =>
                new
                {
                    c.SubscriberNo,
                    c.Debt,
                    c.DueDate,
                    c.Year,
                    c.InvoiceNumber
                }).ToList();
        }
        private void ToggleItems_Search(bool isOnProgress)
        {
            if (isOnProgress)
            {
                #region Form Item Enable/Disable

                button_Search.Enabled = false;
                button_Search.Text = "Arıyor..";
                button_Search.Refresh();

                #endregion
            }
            else
            {
                #region Form Item Enable/Disable

                button_Search.Enabled = true;
                button_Search.Text = "Ara";
                button_Search.Refresh();

                #endregion
            }
        }
        private void ToggleItems_Load(bool isOnProgress)
        {
            if (isOnProgress)
            {
                #region Form Item Enable/Disable

                button_LoadFile.Enabled = false;
                button_LoadFile.Text = "Yüklüyor...";
                button_LoadFile.Refresh();
                groupBox_Search.Enabled = false;
                button_Log.Visible = false;

                #endregion
            }
            else
            {
                #region Form Item Enable/Disable

                button_LoadFile.Enabled = true;
                button_LoadFile.Text = "Dosya Yükle";
                button_LoadFile.Refresh();
                groupBox_Search.Enabled = true;
                if (_fileParser.UnparsedSubscribers.Count > 0)
                {
                    button_Log.Visible = true;
                }

                #endregion
            }
        }

        #endregion
    }
}