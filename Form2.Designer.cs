namespace MyTimer
{
    partial class SelectTimeSpanForm
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
            this.btnDefaultTime = new CommandLink.CommandLink();
            this.btn3min = new CommandLink.CommandLink();
            this.btn10min = new CommandLink.CommandLink();
            this.inputTimeTextBox = new System.Windows.Forms.TextBox();
            this.btnCustom = new CommandLink.CommandLink();
            this.SuspendLayout();
            // 
            // btnDefaultTime
            // 
            this.btnDefaultTime.BackColor = System.Drawing.Color.White;
            this.btnDefaultTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDefaultTime.Image = null;
            this.btnDefaultTime.Location = new System.Drawing.Point(12, 8);
            this.btnDefaultTime.Margin = new System.Windows.Forms.Padding(8);
            this.btnDefaultTime.Name = "btnDefaultTime";
            this.btnDefaultTime.Size = new System.Drawing.Size(320, 60);
            this.btnDefaultTime.SupplementalExplanation = "";
            this.btnDefaultTime.TabIndex = 0;
            this.btnDefaultTime.Text = "默认时间";
            this.btnDefaultTime.UseVisualStyleBackColor = false;
            this.btnDefaultTime.Click += new System.EventHandler(this.btnDefaultTime_Click);
            // 
            // btn3min
            // 
            this.btn3min.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn3min.Image = null;
            this.btn3min.Location = new System.Drawing.Point(12, 84);
            this.btn3min.Margin = new System.Windows.Forms.Padding(8);
            this.btn3min.Name = "btn3min";
            this.btn3min.Size = new System.Drawing.Size(320, 60);
            this.btn3min.SupplementalExplanation = "";
            this.btn3min.TabIndex = 1;
            this.btn3min.Text = "3分钟";
            this.btn3min.UseVisualStyleBackColor = true;
            this.btn3min.Click += new System.EventHandler(this.btn3min_Click);
            // 
            // btn10min
            // 
            this.btn10min.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn10min.Image = null;
            this.btn10min.Location = new System.Drawing.Point(12, 160);
            this.btn10min.Margin = new System.Windows.Forms.Padding(8);
            this.btn10min.Name = "btn10min";
            this.btn10min.Size = new System.Drawing.Size(320, 60);
            this.btn10min.SupplementalExplanation = "";
            this.btn10min.TabIndex = 2;
            this.btn10min.Text = "10分钟";
            this.btn10min.UseVisualStyleBackColor = true;
            this.btn10min.Click += new System.EventHandler(this.btn10min_Click);
            // 
            // inputTimeTextBox
            // 
            this.inputTimeTextBox.Font = new System.Drawing.Font("微软雅黑", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputTimeTextBox.Location = new System.Drawing.Point(12, 231);
            this.inputTimeTextBox.Name = "inputTimeTextBox";
            this.inputTimeTextBox.Size = new System.Drawing.Size(320, 46);
            this.inputTimeTextBox.TabIndex = 3;
            this.inputTimeTextBox.Text = "10";
            this.inputTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputTimeTextBox.TextChanged += new System.EventHandler(this.inputTimeTextBox_TextChanged);
            // 
            // btnCustom
            // 
            this.btnCustom.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCustom.Image = null;
            this.btnCustom.Location = new System.Drawing.Point(12, 288);
            this.btnCustom.Margin = new System.Windows.Forms.Padding(8);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(320, 60);
            this.btnCustom.SupplementalExplanation = "";
            this.btnCustom.TabIndex = 4;
            this.btnCustom.Text = "自定义";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // SelectTimeSpanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(344, 361);
            this.ControlBox = false;
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.inputTimeTextBox);
            this.Controls.Add(this.btn10min);
            this.Controls.Add(this.btn3min);
            this.Controls.Add(this.btnDefaultTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "SelectTimeSpanForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择时间";
            this.Load += new System.EventHandler(this.SelectTimeSpanForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommandLink.CommandLink btnDefaultTime;
        private CommandLink.CommandLink btn3min;
        private CommandLink.CommandLink btn10min;
        private System.Windows.Forms.TextBox inputTimeTextBox;
        private CommandLink.CommandLink btnCustom;
    }
}