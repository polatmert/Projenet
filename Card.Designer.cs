namespace Projenet
{
    partial class Card
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.chBoxActive = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txtpath = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(769, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cari Kod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(387, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Surname";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarih";
            // 
            // City
            // 
            this.City.AutoSize = true;
            this.City.Location = new System.Drawing.Point(23, 94);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(31, 17);
            this.City.TabIndex = 4;
            this.City.Text = "City";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(849, 24);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(302, 22);
            this.txtCode.TabIndex = 1;
            // 
            // chBoxActive
            // 
            this.chBoxActive.AutoSize = true;
            this.chBoxActive.Location = new System.Drawing.Point(866, 87);
            this.chBoxActive.Name = "chBoxActive";
            this.chBoxActive.Size = new System.Drawing.Size(68, 21);
            this.chBoxActive.TabIndex = 6;
            this.chBoxActive.Text = "Active";
            this.chBoxActive.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(458, 87);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(302, 22);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 33);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(302, 22);
            this.txtName.TabIndex = 3;
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(75, 89);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(302, 22);
            this.txtCity.TabIndex = 4;
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(458, 26);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(301, 22);
            this.txtSurname.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(979, 335);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick_1);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1035, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 40);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1035, 457);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(106, 40);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(1035, 275);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(106, 40);
            this.btnList.TabIndex = 8;
            this.btnList.Text = "List";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1035, 333);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(106, 40);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(1035, 400);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(106, 40);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(48, 160);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(118, 35);
            this.btnChoose.TabIndex = 14;
            this.btnChoose.Text = "Choose";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txtpath
            // 
            this.txtpath.Enabled = false;
            this.txtpath.Location = new System.Drawing.Point(198, 166);
            this.txtpath.Name = "txtpath";
            this.txtpath.Size = new System.Drawing.Size(561, 22);
            this.txtpath.TabIndex = 16;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(1035, 515);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 40);
            this.btnExit.TabIndex = 17;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 587);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.txtpath);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.chBoxActive);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.City);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Card";
            this.Text = "Card";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label City;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.CheckBox chBoxActive;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txtpath;
        private System.Windows.Forms.Button btnExit;
    }
}