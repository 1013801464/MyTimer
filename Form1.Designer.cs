namespace MyTimer {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.currentInfoLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.timeInputTextbox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.remain_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_stop = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_remove = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.remain_time,
            this.message,
            this.state,
            this.btn_stop,
            this.btn_remove});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(628, 301);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // currentInfoLabel
            // 
            this.currentInfoLabel.BackColor = System.Drawing.SystemColors.Control;
            this.currentInfoLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentInfoLabel.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentInfoLabel.Location = new System.Drawing.Point(0, 52);
            this.currentInfoLabel.Margin = new System.Windows.Forms.Padding(0);
            this.currentInfoLabel.Name = "currentInfoLabel";
            this.currentInfoLabel.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.currentInfoLabel.Size = new System.Drawing.Size(628, 28);
            this.currentInfoLabel.TabIndex = 4;
            this.currentInfoLabel.Text = "12分钟后响铃";
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.White;
            this.bottomPanel.Controls.Add(this.timeInputTextbox);
            this.bottomPanel.Controls.Add(this.currentInfoLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 301);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(0);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(628, 80);
            this.bottomPanel.TabIndex = 0;
            // 
            // timeInputTextbox
            // 
            this.timeInputTextbox.BackColor = System.Drawing.Color.White;
            this.timeInputTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.timeInputTextbox.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timeInputTextbox.ForeColor = System.Drawing.Color.Black;
            this.timeInputTextbox.Location = new System.Drawing.Point(0, 4);
            this.timeInputTextbox.Margin = new System.Windows.Forms.Padding(20);
            this.timeInputTextbox.MaxLength = 128;
            this.timeInputTextbox.Multiline = true;
            this.timeInputTextbox.Name = "timeInputTextbox";
            this.timeInputTextbox.ShortcutsEnabled = false;
            this.timeInputTextbox.Size = new System.Drawing.Size(628, 52);
            this.timeInputTextbox.TabIndex = 1;
            this.timeInputTextbox.Text = "输入时间和内容";
            this.timeInputTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeInputTextbox.TextChanged += new System.EventHandler(this.timeInputRichTextbox_TextChanged);
            // 
            // remain_time
            // 
            this.remain_time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.remain_time.FillWeight = 3F;
            this.remain_time.HeaderText = "到期时间";
            this.remain_time.Name = "remain_time";
            this.remain_time.ReadOnly = true;
            this.remain_time.Width = 150;
            // 
            // message
            // 
            this.message.FillWeight = 10F;
            this.message.HeaderText = "名称";
            this.message.MinimumWidth = 10;
            this.message.Name = "message";
            this.message.ReadOnly = true;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.state.FillWeight = 1F;
            this.state.HeaderText = "状态";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 75;
            // 
            // btn_stop
            // 
            this.btn_stop.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btn_stop.FillWeight = 1F;
            this.btn_stop.HeaderText = "";
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.ReadOnly = true;
            this.btn_stop.Width = 48;
            // 
            // btn_remove
            // 
            this.btn_remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btn_remove.FillWeight = 1F;
            this.btn_remove.HeaderText = "";
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.ReadOnly = true;
            this.btn_remove.Width = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 381);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bottomPanel);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "计时器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label currentInfoLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.TextBox timeInputTextbox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remain_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewButtonColumn btn_stop;
        private System.Windows.Forms.DataGridViewButtonColumn btn_remove;
    }
}

