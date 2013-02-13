using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VGateway
{
    public partial class TaskListForm : Form
    {
        TaskList taskList;

        public TaskListForm(TaskList taskList)
        {
            this.taskList = taskList;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (int i in taskList.GetTasks())
            {
                Button b = new Button();
                b.Text = i.ToString();
                b.Click += (o, ea) => { DisplayTaskForm(i); };
                flowLayoutPanel1.Controls.Add(b);
            }
        }

        private void DisplayTaskForm(int i)
        {
            TaskForm tf = new TaskForm(taskList, i);
            tf.FormClosed += (o, e) => { WindowState = FormWindowState.Normal; };
            tf.Show();
            WindowState = FormWindowState.Minimized;
        }
    }
}
