namespace LauncherX
{
    partial class ServerSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSelector));
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tbpStudentInfo = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.tbpStudentOutput = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.GridBox1 = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Players = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxPlayers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TabControl1.SuspendLayout();
            this.tbpStudentInfo.SuspendLayout();
            this.tbpStudentOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.tbpStudentInfo);
            this.TabControl1.Controls.Add(this.tbpStudentOutput);
            this.TabControl1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControl1.Location = new System.Drawing.Point(-4, -29);
            this.TabControl1.Multiline = true;
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(451, 471);
            this.TabControl1.TabIndex = 8;
            // 
            // tbpStudentInfo
            // 
            this.tbpStudentInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tbpStudentInfo.Controls.Add(this.pictureBox1);
            this.tbpStudentInfo.Controls.Add(this.button3);
            this.tbpStudentInfo.Controls.Add(this.linkLabel3);
            this.tbpStudentInfo.Controls.Add(this.linkLabel2);
            this.tbpStudentInfo.Controls.Add(this.linkLabel1);
            this.tbpStudentInfo.Controls.Add(this.progressBar1);
            this.tbpStudentInfo.Controls.Add(this.Button2);
            this.tbpStudentInfo.Controls.Add(this.textBox3);
            this.tbpStudentInfo.Controls.Add(this.Label5);
            this.tbpStudentInfo.Controls.Add(this.textBox2);
            this.tbpStudentInfo.Controls.Add(this.Label1);
            this.tbpStudentInfo.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpStudentInfo.Location = new System.Drawing.Point(4, 30);
            this.tbpStudentInfo.Name = "tbpStudentInfo";
            this.tbpStudentInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStudentInfo.Size = new System.Drawing.Size(443, 437);
            this.tbpStudentInfo.TabIndex = 0;
            this.tbpStudentInfo.Text = "Student Information";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(168, 204);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 42);
            this.button3.TabIndex = 16;
            this.button3.Text = "Resume";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.SystemColors.InfoText;
            this.linkLabel3.Location = new System.Drawing.Point(12, 335);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(116, 21);
            this.linkLabel3.TabIndex = 15;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Charged Miners";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.SystemColors.InfoText;
            this.linkLabel2.Location = new System.Drawing.Point(12, 363);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(108, 21);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "800Craft Client";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.InfoText;
            this.linkLabel1.Location = new System.Drawing.Point(304, 365);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 21);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Report a problem";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.progressBar1.Location = new System.Drawing.Point(130, 272);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(197, 40);
            this.progressBar1.TabIndex = 11;
            // 
            // Button2
            // 
            this.Button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Button2.FlatAppearance.BorderSize = 0;
            this.Button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.Button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.Button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button2.Font = new System.Drawing.Font("Segoe UI Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ForeColor = System.Drawing.Color.White;
            this.Button2.Location = new System.Drawing.Point(274, 204);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(100, 42);
            this.Button2.TabIndex = 10;
            this.Button2.Text = "Connect";
            this.Button2.UseVisualStyleBackColor = false;
            this.Button2.Click += new System.EventHandler(this.Button2_Click_3);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(168, 165);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(206, 33);
            this.textBox3.TabIndex = 1;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(60, 168);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(90, 25);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "Password:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(168, 126);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(206, 33);
            this.textBox2.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(54, 129);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(96, 25);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Username:";
            // 
            // tbpStudentOutput
            // 
            this.tbpStudentOutput.BackColor = System.Drawing.SystemColors.Control;
            this.tbpStudentOutput.Controls.Add(this.button1);
            this.tbpStudentOutput.Controls.Add(this.GridBox1);
            this.tbpStudentOutput.Controls.Add(this.SearchBox);
            this.tbpStudentOutput.Controls.Add(this.Label3);
            this.tbpStudentOutput.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbpStudentOutput.Location = new System.Drawing.Point(4, 30);
            this.tbpStudentOutput.Name = "tbpStudentOutput";
            this.tbpStudentOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tbpStudentOutput.Size = new System.Drawing.Size(443, 437);
            this.tbpStudentOutput.TabIndex = 1;
            this.tbpStudentOutput.Text = "Student Output";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.CheckedBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(80, 348);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(287, 38);
            this.button1.TabIndex = 17;
            this.button1.Text = "Launch WoM";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // GridBox1
            // 
            this.GridBox1.AllowUserToAddRows = false;
            this.GridBox1.AllowUserToDeleteRows = false;
            this.GridBox1.AllowUserToResizeRows = false;
            this.GridBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridBox1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.GridBox1.ColumnHeadersHeight = 30;
            this.GridBox1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.GridBox1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Players,
            this.MaxPlayers,
            this.Url});
            this.GridBox1.Location = new System.Drawing.Point(4, 46);
            this.GridBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GridBox1.MultiSelect = false;
            this.GridBox1.Name = "GridBox1";
            this.GridBox1.ReadOnly = true;
            this.GridBox1.RowHeadersVisible = false;
            this.GridBox1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.GridBox1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GridBox1.RowTemplate.Height = 26;
            this.GridBox1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridBox1.Size = new System.Drawing.Size(435, 295);
            this.GridBox1.TabIndex = 15;
            this.GridBox1.SelectionChanged += new System.EventHandler(this.GridBox1_SelectionChanged);
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.FillWeight = 60F;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Players
            // 
            this.Players.HeaderText = "Players";
            this.Players.Name = "Players";
            this.Players.ReadOnly = true;
            this.Players.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Players.Width = 81;
            // 
            // MaxPlayers
            // 
            this.MaxPlayers.HeaderText = "Max Players";
            this.MaxPlayers.Name = "MaxPlayers";
            this.MaxPlayers.ReadOnly = true;
            this.MaxPlayers.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MaxPlayers.Width = 113;
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Url.Visible = false;
            this.Url.Width = 45;
            // 
            // SearchBox
            // 
            this.SearchBox.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBox.Location = new System.Drawing.Point(80, 6);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(288, 33);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.TextChanged += new System.EventHandler(this.SearchBox_TextChanged_2);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Segoe UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(6, 9);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(68, 25);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "Search:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(130, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 101);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // ServerSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 392);
            this.Controls.Add(this.TabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Text = "LauncherX";
            this.Load += new System.EventHandler(this.ServerSelector_Load);
            this.TabControl1.ResumeLayout(false);
            this.tbpStudentInfo.ResumeLayout(false);
            this.tbpStudentInfo.PerformLayout();
            this.tbpStudentOutput.ResumeLayout(false);
            this.tbpStudentOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage tbpStudentInfo;
        internal System.Windows.Forms.Button Button2;
        internal System.Windows.Forms.TextBox textBox3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TabPage tbpStudentOutput;
        internal System.Windows.Forms.TextBox SearchBox;
        internal System.Windows.Forms.Label Label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridView GridBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Players;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxPlayers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
        internal System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;



    }
}