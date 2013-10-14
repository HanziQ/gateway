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
    public partial class Task30 : Form
    {
        public Task30()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (DateTime.TryParse(textBox1.Text, out dt))
            {
                string text = ""; ;
                int cmp = DateTime.Compare(dt, DateTime.Today);
                TimeSpan ts = DateTime.Today - dt;
                if (cmp < 0)
                {
                    text = "Počet uplynulých dní - " + ts.TotalDays.ToString();
                }
                else if (cmp == 0)
                {
                    text = "Neuplynul žádný den.";
                }
                else
                {
                    text = "Počet zbývajících dní - " + (-ts.TotalDays).ToString();
                }
                MessageBox.Show(text);
            }

            else
            {
                MessageBox.Show("Datum je ve špatném formátu.");
            }
        }
    }
}
