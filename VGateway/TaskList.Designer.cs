namespace VGateway
{
    partial class TaskList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.taskSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textUlohy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // taskSelector
            // 
            this.taskSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.taskSelector.FormattingEnabled = true;
            this.taskSelector.Location = new System.Drawing.Point(94, 10);
            this.taskSelector.Name = "taskSelector";
            this.taskSelector.Size = new System.Drawing.Size(136, 21);
            this.taskSelector.TabIndex = 0;
            this.taskSelector.SelectedIndexChanged += new System.EventHandler(this.taskSelector_SelectedIndexChanged);
            this.taskSelector.KeyUp += new System.Windows.Forms.KeyEventHandler(this.taskSelector_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vyberte úlohu:";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(236, 8);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 2;
            this.start.Text = "Spustit";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Text úlohy:";
            // 
            // textUlohy
            // 
            this.textUlohy.Location = new System.Drawing.Point(16, 56);
            this.textUlohy.Multiline = true;
            this.textUlohy.Name = "textUlohy";
            this.textUlohy.ReadOnly = true;
            this.textUlohy.Size = new System.Drawing.Size(296, 94);
            this.textUlohy.TabIndex = 4;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 166);
            this.Controls.Add(this.textUlohy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.taskSelector);
            this.Name = "TaskList";
            this.Text = "TaskList";
            this.Load += new System.EventHandler(this.TaskList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox taskSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUlohy;
    }
}