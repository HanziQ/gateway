using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace VGateway.Tasks
{
    public partial class Task47 : Form
    {
        public Task47()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form newForm = new Form();

            Label label1 = new System.Windows.Forms.Label();
            PictureBox pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            newForm.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(13, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(33, 13);
            label1.TabIndex = 0;
            label1.Text = "Popis";
            // 
            // pictureBox1
            // 
            pictureBox1.ImageLocation = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSE4gmFo2bv3hxM5RQK9RUD-ieNL" + "8GtKTdR2Jo1HMVOt_CwIpzTMw";
            pictureBox1.Location = new System.Drawing.Point(12, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(301, 169);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // test
            // 
            newForm.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            newForm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            newForm.ClientSize = new System.Drawing.Size(529, 266);
            newForm.Controls.Add(pictureBox1);
            newForm.Controls.Add(label1);
            newForm.Name = "test";
            newForm.Text = "test";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            newForm.ResumeLayout(false);
            newForm.PerformLayout();
            newForm.Show();
        }
    }
}
