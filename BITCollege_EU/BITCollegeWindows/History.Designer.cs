namespace BITCollegeWindows
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label descriptionLabel;
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbStudent = new System.Windows.Forms.GroupBox();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.academicProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registrationDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            descriptionLabel = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            this.gbStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new System.Drawing.Point(19, 67);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new System.Drawing.Size(49, 13);
            descriptionLabel.TabIndex = 3;
            descriptionLabel.Text = "Program:";
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(19, 32);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 4;
            studentNumberLabel.Text = "Student Number:";
            // 
            // gbStudent
            // 
            this.gbStudent.Controls.Add(this.fullNameLabel1);
            this.gbStudent.Controls.Add(studentNumberLabel);
            this.gbStudent.Controls.Add(this.studentNumberMaskedLabel);
            this.gbStudent.Controls.Add(descriptionLabel);
            this.gbStudent.Controls.Add(this.descriptionLabel1);
            this.gbStudent.Location = new System.Drawing.Point(26, 19);
            this.gbStudent.Margin = new System.Windows.Forms.Padding(2);
            this.gbStudent.Name = "gbStudent";
            this.gbStudent.Padding = new System.Windows.Forms.Padding(2);
            this.gbStudent.Size = new System.Drawing.Size(918, 113);
            this.gbStudent.TabIndex = 1;
            this.gbStudent.TabStop = false;
            this.gbStudent.Text = "Student Data";
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(270, 32);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(272, 23);
            this.fullNameLabel1.TabIndex = 6;
            this.fullNameLabel1.Text = "label1";
            this.fullNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_EU.Models.Student);
            // 
            // studentNumberMaskedLabel
            // 
            this.studentNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedLabel.Location = new System.Drawing.Point(127, 32);
            this.studentNumberMaskedLabel.Mask = "0000-9999";
            this.studentNumberMaskedLabel.Name = "studentNumberMaskedLabel";
            this.studentNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.studentNumberMaskedLabel.TabIndex = 5;
            this.studentNumberMaskedLabel.Text = "maskedLabel1";
            this.studentNumberMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.academicProgramBindingSource, "Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(127, 67);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(415, 23);
            this.descriptionLabel1.TabIndex = 4;
            this.descriptionLabel1.Text = "label1";
            this.descriptionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // academicProgramBindingSource
            // 
            this.academicProgramBindingSource.DataSource = typeof(BITCollege_EU.Models.AcademicProgram);
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(421, 431);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(117, 13);
            this.lnkReturn.TabIndex = 2;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_EU.Models.Registration);
            // 
            // registrationDataGridView
            // 
            this.registrationDataGridView.AllowUserToAddRows = false;
            this.registrationDataGridView.AllowUserToDeleteRows = false;
            this.registrationDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.registrationDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.registrationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registrationDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.Title,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.registrationDataGridView.DataSource = this.registrationBindingSource;
            this.registrationDataGridView.Location = new System.Drawing.Point(26, 161);
            this.registrationDataGridView.Name = "registrationDataGridView";
            this.registrationDataGridView.ReadOnly = true;
            this.registrationDataGridView.Size = new System.Drawing.Size(918, 220);
            this.registrationDataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "RegistrationNumber";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn4.HeaderText = "Registration Number";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // Title
            // 
            this.Title.DataPropertyName = "courseTitle";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Title.DefaultCellStyle = dataGridViewCellStyle15;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            this.Title.Width = 250;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "RegistrationDate";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.Format = "d";
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn5.HeaderText = "Registration Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Grade";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.Format = "P2";
            dataGridViewCellStyle17.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn6.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Notes";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn7.HeaderText = "Notes";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 200;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 490);
            this.Controls.Add(this.registrationDataGridView);
            this.Controls.Add(this.lnkReturn);
            this.Controls.Add(this.gbStudent);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "History";
            this.Text = "Student Registraton History";
            this.Load += new System.EventHandler(this.History_Load);
            this.gbStudent.ResumeLayout(false);
            this.gbStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStudent;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.BindingSource academicProgramBindingSource;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel studentNumberMaskedLabel;
        private System.Windows.Forms.DataGridView registrationDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}