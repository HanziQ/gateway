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
        private Dictionary<int, TaskInfo> Tasks = new Dictionary<int, TaskInfo>();

        public TaskList()
        {
            InitializeComponent();
        }

        private void InitializeTasks()
        {
            Dictionary<int, string> descriptions = new Dictionary<int, string>();
            foreach (string s in File.ReadAllLines("exercises.txt", Encoding.Default))
            {
                descriptions.Add(int.Parse(s.Split(' ')[0]),s.Substring(s.IndexOf(" ") + 1));
            }
            List<Type> types = (from t in Assembly.GetExecutingAssembly().GetTypes() where t.IsClass && Regex.IsMatch(t.Name, "Task(\\d)+") select t).ToList();
            types.Sort((a, b) => { return int.Parse(a.Name.Substring(4)).CompareTo(int.Parse(b.Name.Substring(4))); });
            foreach (Type t in types)
            {
                int num = int.Parse(t.Name.Substring(4));
                Tasks.Add(num, new TaskInfo(num, descriptions[num], t));
                taskSelector.Items.Add(num.ToString());
            }
            taskSelector.SelectedIndex = taskSelector.Items.Count - 1;
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (taskSelector.SelectedItem == null)
                return;
            int num = int.Parse((string)taskSelector.SelectedItem);
            Form f = (Form)Activator.CreateInstance(Tasks[num].Type);
            f.Show();
        }

        private void TaskList_Load(object sender, EventArgs e)
        {
            InitializeTasks();
        }

        private void taskSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num = int.Parse((string)taskSelector.SelectedItem);
            textUlohy.Text = Tasks[num].Description;
        }

        private void taskSelector_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                start_Click(null, null);
            }
        }

    }
}
