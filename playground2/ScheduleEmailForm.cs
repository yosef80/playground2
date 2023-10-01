using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace playground2
{

    public partial class ScheduleEmailForm : Form
    {
        public ScheduleEmailForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker.Value.Date;
            int hour = int.Parse(hourTextBox.Text);
            int minute = int.Parse(minuteTextBox.Text);

            // Combine date, hour, and minute
            DateTime scheduleTime = selectedDate.AddHours(hour).AddMinutes(minute);

            // Get the currently open email item in Outlook
            Outlook.MailItem mailItem = GetOpenMailItem();

            if (mailItem != null)
            {
                try
                {
                    // Schedule the email using the Outlook Object Model
                    mailItem.DeferredDeliveryTime = scheduleTime;

                    // Save and send the email
                    mailItem.Save();
                    mailItem.Send();

                    MessageBox.Show("Email scheduled successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error scheduling email: " + ex.Message);
                }
                finally
                {
                    mailItem.Close(Outlook.OlInspectorClose.olDiscard);
                }
            }
            else
            {
                MessageBox.Show("No open email item found.");
            }

            this.Close();
        }

      
        private Outlook.MailItem GetOpenMailItem()
        {
            Outlook.Application outlookApp = new Outlook.Application();
            Outlook.Explorer explorer = outlookApp.ActiveExplorer();
            Outlook.Selection selection = explorer.Selection;

            if (selection.Count == 1 && selection[1] is Outlook.MailItem)
            {
                return (Outlook.MailItem)selection[1];
            }

            return null;
        }

    }
}

