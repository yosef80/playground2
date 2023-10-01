using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace playground2
{
    public partial class ScheduleEmailRibbon
    {
        private void ScheduleEmailRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            ScheduleEmailForm scheduleForm = new ScheduleEmailForm();
            scheduleForm.ShowDialog();
        }
    }
}
