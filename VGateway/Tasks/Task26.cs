using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VGateway.Tasks
{
    public partial class Task26 : Form
    {
        public Task26()
        {
            InitializeComponent();
        }

        private void Task25_Load(object sender, EventArgs e)
        {
            List<DateTime> fridays13 = new List<DateTime>();
            int month = 1;
            int year = 2004;
            while (fridays13.Count < 10)
            {
                DateTime dt = new DateTime(year, month, 13);
                if (dt.DayOfWeek == DayOfWeek.Friday)
                    fridays13.Add(dt);

                month++;
                if (month == 13)
                {
                    month = 1;
                    year++;
                }
            }
            int i = 0;
            foreach (DateTime dt in fridays13)
            {
                listBox1.Items.Add(dt.ToLongDateString());
                i++;
            }
        }
    }
}
