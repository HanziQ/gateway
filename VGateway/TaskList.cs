using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;

namespace VGateway
{
    public partial class TaskList : Form
    {
        private List<TaskInfo> Tasks = new List<TaskInfo>();

        public TaskList()
        {
            InitializeComponent();
        }

        private void InitializeTasks()
        {
            List<string> descriptions = new List<string>();
            foreach (string s in File.ReadAllLines("exercises.txt", Encoding.Default))
            {
                descriptions.Add(s.Substring(s.IndexOf(" ") + 1));
            }
            List<Type> types = (from t in Assembly.GetExecutingAssembly().GetTypes() where t.IsClass && Regex.IsMatch(t.Name, "Task(\\d)+") select t).ToList();
            foreach (Type t in types)
            {
                int num = int.Parse(t.Name.Substring(4));
                Tasks.Add(new TaskInfo(num, descriptions[num - 1], t));
                taskSelector.Items.Add(num.ToString());
            }
            taskSelector.SelectedIndex = taskSelector.Items.Count - 1;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (taskSelector.SelectedItem == null)
                return;
            int num = int.Parse((string)taskSelector.SelectedItem);
            Form f = (Form)Activator.CreateInstance(Tasks[num - 1].Type);
            f.Show();
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            InitializeTasks();
        }

        private void taskSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = int.Parse((string)taskSelector.SelectedItem);
            textUlohy.Text = Tasks[num - 1].Description;
        }
    }
}
