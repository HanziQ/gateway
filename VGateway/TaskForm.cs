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
    public partial class TaskForm : Form
    {
        int task;
        TaskList taskList;

        public TaskForm(TaskList taskList, int i)
        {
            this.taskList = taskList;
            task = i;
            InitializeComponent();
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {

        }
    }
}
