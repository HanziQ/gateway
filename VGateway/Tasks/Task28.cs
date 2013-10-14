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
    public partial class Task28 : Form
    {
        public Task28()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "";
            string[] data = textBox1.Text.Split(' ');
            if (data.Length != 3)
            {
                text = "Data nejsou ve správném formátu.";
            }
            else
            {
                DateTime dt1, dt2;
                int diff;
                if (DateTime.TryParse(data[0], out dt1) && DateTime.TryParse(data[2], out dt2) && int.TryParse(data[1], out diff))
                {
                    double dayDiff = (dt2 - dt1).TotalDays;
                    if (dayDiff <= diff)
                        text = "Zaplaceno včas.";
                    else
                        text = "Nebylo zaplaceno včas.";
                }
                else
                {
                    text = "Chyba formátu.";
                }
            }
            MessageBox.Show(text);
        }
    }
}
