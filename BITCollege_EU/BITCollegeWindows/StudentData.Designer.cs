namespace BITCollegeWindows
{
    partial class StudentData
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
            System.Windows.Forms.Label studentNumberLabel;
            System.Windows.Forms.Label dateCreatedLabel;
            System.Windows.Forms.Label fullNameLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label cityLabel;
            System.Windows.Forms.Label outstandingFeesLabel;
            System.Windows.Forms.Label provinceLabel;
            System.Windows.Forms.Label postalCodeLabel;
            System.Windows.Forms.Label gradePointAverageLabel;
            System.Windows.Forms.Label registrationNumberLabel;
            System.Windows.Forms.ComboBox registrationNumberComboBox;
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label creditHoursLabel;
            System.Windows.Forms.Label titleLabel;
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lnkDetails = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            this.lblReader = new System.Windows.Forms.Label();
            this.grpStudent = new System.Windows.Forms.GroupBox();
            this.descriptionLabel1 = new System.Windows.Forms.Label();
            this.gradePointStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gradePointAverageLabel1 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.postalCodeMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.provinceMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.outstandingFeesLabel1 = new System.Windows.Forms.Label();
            this.cityLabel1 = new System.Windows.Forms.Label();
            this.addressLabel1 = new System.Windows.Forms.Label();
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.dateCreatedLabel1 = new System.Windows.Forms.Label();
            this.studentNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.grpRegistration = new System.Windows.Forms.GroupBox();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.creditHoursLabel1 = new System.Windows.Forms.Label();
            this.courseNumberLabel1 = new System.Windows.Forms.Label();
            studentNumberLabel = new System.Windows.Forms.Label();
            dateCreatedLabel = new System.Windows.Forms.Label();
            fullNameLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            cityLabel = new System.Windows.Forms.Label();
            outstandingFeesLabel = new System.Windows.Forms.Label();
            provinceLabel = new System.Windows.Forms.Label();
            postalCodeLabel = new System.Windows.Forms.Label();
            gradePointAverageLabel = new System.Windows.Forms.Label();
            registrationNumberLabel = new System.Windows.Forms.Label();
            registrationNumberComboBox = new System.Windows.Forms.ComboBox();
            courseNumberLabel = new System.Windows.Forms.Label();
            creditHoursLabel = new System.Windows.Forms.Label();
            titleLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.grpStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradePointStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            this.grpRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(7, 30);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 7;
            studentNumberLabel.Text = "Student Number:";
            // 
            // dateCreatedLabel
            // 
            dateCreatedLabel.AutoSize = true;
            dateCreatedLabel.Location = new System.Drawing.Point(7, 163);
            dateCreatedLabel.Name = "dateCreatedLabel";
            dateCreatedLabel.Size = new System.Drawing.Size(73, 13);
            dateCreatedLabel.TabIndex = 13;
            dateCreatedLabel.Text = "Date Created:";
            // 
            // fullNameLabel
            // 
            fullNameLabel.AutoSize = true;
            fullNameLabel.Location = new System.Drawing.Point(7, 61);
            fullNameLabel.Name = "fullNameLabel";
            fullNameLabel.Size = new System.Drawing.Size(57, 13);
            fullNameLabel.TabIndex = 14;
            fullNameLabel.Text = "Full Name:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(7, 93);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 15;
            addressLabel.Text = "Address:";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new System.Drawing.Point(7, 128);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new System.Drawing.Size(27, 13);
            cityLabel.TabIndex = 16;
            cityLabel.Text = "City:";
            // 
            // outstandingFeesLabel
            // 
            outstandingFeesLabel.AutoSize = true;
            outstandingFeesLabel.Location = new System.Drawing.Point(248, 163);
            outstandingFeesLabel.Name = "outstandingFeesLabel";
            outstandingFeesLabel.Size = new System.Drawing.Size(93, 13);
            outstandingFeesLabel.TabIndex = 19;
            outstandingFeesLabel.Text = "Outstanding Fees:";
            // 
            // provinceLabel
            // 
            provinceLabel.AutoSize = true;
            provinceLabel.Location = new System.Drawing.Point(248, 128);
            provinceLabel.Name = "provinceLabel";
            provinceLabel.Size = new System.Drawing.Size(52, 13);
            provinceLabel.TabIndex = 20;
            provinceLabel.Text = "Province:";
            // 
            // postalCodeLabel
            // 
            postalCodeLabel.AutoSize = true;
            postalCodeLabel.Location = new System.Drawing.Point(425, 128);
            postalCodeLabel.Name = "postalCodeLabel";
            postalCodeLabel.Size = new System.Drawing.Size(67, 13);
            postalCodeLabel.TabIndex = 21;
            postalCodeLabel.Text = "Postal Code:";
            // 
            // gradePointAverageLabel
            // 
            gradePointAverageLabel.AutoSize = true;
            gradePointAverageLabel.Location = new System.Drawing.Point(7, 199);
            gradePointAverageLabel.Name = "gradePointAverageLabel";
            gradePointAverageLabel.Size = new System.Drawing.Size(109, 13);
            gradePointAverageLabel.TabIndex = 22;
            gradePointAverageLabel.Text = "Grade Point Average:";
            // 
            // registrationNumberLabel
            // 
            registrationNumberLabel.AutoSize = true;
            registrationNumberLabel.Location = new System.Drawing.Point(14, 32);
            registrationNumberLabel.Name = "registrationNumberLabel";
            registrationNumberLabel.Size = new System.Drawing.Size(106, 13);
            registrationNumberLabel.TabIndex = 0;
            registrationNumberLabel.Text = "Registration Number:";
            // 
            // registrationNumberComboBox
            // 
            registrationNumberComboBox.DataSource = this.registrationBindingSource;
            registrationNumberComboBox.DisplayMember = "RegistrationNumber";
            registrationNumberComboBox.FormattingEnabled = true;
            registrationNumberComboBox.Location = new System.Drawing.Point(124, 29);
            registrationNumberComboBox.Name = "registrationNumberComboBox";
            registrationNumberComboBox.Size = new System.Drawing.Size(125, 21);
            registrationNumberComboBox.TabIndex = 1;
            registrationNumberComboBox.ValueMember = "RegistrationNumber";
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_EU.Models.Registration);
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(14, 68);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(83, 13);
            courseNumberLabel.TabIndex = 2;
            courseNumberLabel.Text = "Course Number:";
            // 
            // creditHoursLabel
            // 
            creditHoursLabel.AutoSize = true;
            creditHoursLabel.Location = new System.Drawing.Point(14, 105);
            creditHoursLabel.Name = "creditHoursLabel";
            creditHoursLabel.Size = new System.Drawing.Size(68, 13);
            creditHoursLabel.TabIndex = 4;
            creditHoursLabel.Text = "Credit Hours:";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Location = new System.Drawing.Point(317, 68);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(30, 13);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Title:";
            // 
            // lnkDetails
            // 
            this.lnkDetails.AutoSize = true;
            this.lnkDetails.Enabled = false;
            this.lnkDetails.Location = new System.Drawing.Point(355, 427);
            this.lnkDetails.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkDetails.Name = "lnkDetails";
            this.lnkDetails.Size = new System.Drawing.Size(65, 13);
            this.lnkDetails.TabIndex = 5;
            this.lnkDetails.TabStop = true;
            this.lnkDetails.Text = "View Details";
            this.lnkDetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDetails_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(149, 427);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(74, 13);
            this.lnkUpdate.TabIndex = 4;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // lblReader
            // 
            this.lblReader.AutoSize = true;
            this.lblReader.ForeColor = System.Drawing.Color.Red;
            this.lblReader.Location = new System.Drawing.Point(415, 27);
            this.lblReader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblReader.Name = "lblReader";
            this.lblReader.Size = new System.Drawing.Size(191, 13);
            this.lblReader.TabIndex = 6;
            this.lblReader.Text = "RFID Unavailable - Enter Student Data";
            // 
            // grpStudent
            // 
            this.grpStudent.Controls.Add(this.descriptionLabel1);
            this.grpStudent.Controls.Add(gradePointAverageLabel);
            this.grpStudent.Controls.Add(this.gradePointAverageLabel1);
            this.grpStudent.Controls.Add(postalCodeLabel);
            this.grpStudent.Controls.Add(this.postalCodeMaskedLabel);
            this.grpStudent.Controls.Add(provinceLabel);
            this.grpStudent.Controls.Add(this.provinceMaskedLabel);
            this.grpStudent.Controls.Add(outstandingFeesLabel);
            this.grpStudent.Controls.Add(this.outstandingFeesLabel1);
            this.grpStudent.Controls.Add(cityLabel);
            this.grpStudent.Controls.Add(this.cityLabel1);
            this.grpStudent.Controls.Add(addressLabel);
            this.grpStudent.Controls.Add(this.addressLabel1);
            this.grpStudent.Controls.Add(fullNameLabel);
            this.grpStudent.Controls.Add(this.fullNameLabel1);
            this.grpStudent.Controls.Add(dateCreatedLabel);
            this.grpStudent.Controls.Add(this.dateCreatedLabel1);
            this.grpStudent.Controls.Add(studentNumberLabel);
            this.grpStudent.Controls.Add(this.studentNumberMaskedTextBox);
            this.grpStudent.Controls.Add(this.lblReader);
            this.grpStudent.Location = new System.Drawing.Point(11, 11);
            this.grpStudent.Margin = new System.Windows.Forms.Padding(2);
            this.grpStudent.Name = "grpStudent";
            this.grpStudent.Padding = new System.Windows.Forms.Padding(2);
            this.grpStudent.Size = new System.Drawing.Size(616, 250);
            this.grpStudent.TabIndex = 7;
            this.grpStudent.TabStop = false;
            this.grpStudent.Text = "Student Data";
            // 
            // descriptionLabel1
            // 
            this.descriptionLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gradePointStateBindingSource, "Description", true));
            this.descriptionLabel1.Location = new System.Drawing.Point(251, 199);
            this.descriptionLabel1.Name = "descriptionLabel1";
            this.descriptionLabel1.Size = new System.Drawing.Size(100, 23);
            this.descriptionLabel1.TabIndex = 24;
            this.descriptionLabel1.Text = "label1";
            this.descriptionLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gradePointStateBindingSource
            // 
            this.gradePointStateBindingSource.DataSource = typeof(BITCollege_EU.Models.GradePointState);
            // 
            // gradePointAverageLabel1
            // 
            this.gradePointAverageLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradePointAverageLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "GradePointAverage", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.gradePointAverageLabel1.Location = new System.Drawing.Point(121, 199);
            this.gradePointAverageLabel1.Name = "gradePointAverageLabel1";
            this.gradePointAverageLabel1.Size = new System.Drawing.Size(110, 23);
            this.gradePointAverageLabel1.TabIndex = 23;
            this.gradePointAverageLabel1.Text = "[gradePointAverage]";
            this.gradePointAverageLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_EU.Models.Student);
            // 
            // postalCodeMaskedLabel
            // 
            this.postalCodeMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.postalCodeMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "PostalCode", true));
            this.postalCodeMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Mask", this.studentBindingSource, "PostalCode", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "CCC#CCC"));
            this.postalCodeMaskedLabel.Location = new System.Drawing.Point(498, 128);
            this.postalCodeMaskedLabel.Name = "postalCodeMaskedLabel";
            this.postalCodeMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.postalCodeMaskedLabel.TabIndex = 22;
            this.postalCodeMaskedLabel.Text = "[postalCode]";
            this.postalCodeMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // provinceMaskedLabel
            // 
            this.provinceMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.provinceMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Province", true));
            this.provinceMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Mask", this.studentBindingSource, "Province", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "LL"));
            this.provinceMaskedLabel.Location = new System.Drawing.Point(306, 128);
            this.provinceMaskedLabel.Name = "provinceMaskedLabel";
            this.provinceMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.provinceMaskedLabel.TabIndex = 21;
            this.provinceMaskedLabel.Text = "[province]";
            this.provinceMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // outstandingFeesLabel1
            // 
            this.outstandingFeesLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outstandingFeesLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "OutstandingFees", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.outstandingFeesLabel1.Location = new System.Drawing.Point(356, 163);
            this.outstandingFeesLabel1.Name = "outstandingFeesLabel1";
            this.outstandingFeesLabel1.Size = new System.Drawing.Size(100, 23);
            this.outstandingFeesLabel1.TabIndex = 20;
            this.outstandingFeesLabel1.Text = "[outstandingFees]";
            this.outstandingFeesLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cityLabel1
            // 
            this.cityLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cityLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "City", true));
            this.cityLabel1.Location = new System.Drawing.Point(121, 128);
            this.cityLabel1.Name = "cityLabel1";
            this.cityLabel1.Size = new System.Drawing.Size(100, 23);
            this.cityLabel1.TabIndex = 17;
            this.cityLabel1.Text = "[city]";
            this.cityLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addressLabel1
            // 
            this.addressLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "Address", true));
            this.addressLabel1.Location = new System.Drawing.Point(121, 93);
            this.addressLabel1.Name = "addressLabel1";
            this.addressLabel1.Size = new System.Drawing.Size(477, 23);
            this.addressLabel1.TabIndex = 16;
            this.addressLabel1.Text = "[address]";
            this.addressLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(121, 61);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(477, 23);
            this.fullNameLabel1.TabIndex = 15;
            this.fullNameLabel1.Text = "[full name]";
            this.fullNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateCreatedLabel1
            // 
            this.dateCreatedLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dateCreatedLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "DateCreated", true));
            this.dateCreatedLabel1.Location = new System.Drawing.Point(121, 163);
            this.dateCreatedLabel1.Name = "dateCreatedLabel1";
            this.dateCreatedLabel1.Size = new System.Drawing.Size(100, 23);
            this.dateCreatedLabel1.TabIndex = 14;
            this.dateCreatedLabel1.Text = "[dateCreated]";
            this.dateCreatedLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studentNumberMaskedTextBox
            // 
            this.studentNumberMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedTextBox.Location = new System.Drawing.Point(121, 27);
            this.studentNumberMaskedTextBox.Mask = "0000-9999";
            this.studentNumberMaskedTextBox.Name = "studentNumberMaskedTextBox";
            this.studentNumberMaskedTextBox.Size = new System.Drawing.Size(103, 20);
            this.studentNumberMaskedTextBox.TabIndex = 8;
            this.studentNumberMaskedTextBox.Leave += new System.EventHandler(this.studentNumberMaskedTextBox_Leave);
            // 
            // grpRegistration
            // 
            this.grpRegistration.Controls.Add(titleLabel);
            this.grpRegistration.Controls.Add(this.titleLabel1);
            this.grpRegistration.Controls.Add(creditHoursLabel);
            this.grpRegistration.Controls.Add(this.creditHoursLabel1);
            this.grpRegistration.Controls.Add(courseNumberLabel);
            this.grpRegistration.Controls.Add(this.courseNumberLabel1);
            this.grpRegistration.Controls.Add(registrationNumberLabel);
            this.grpRegistration.Controls.Add(registrationNumberComboBox);
            this.grpRegistration.Location = new System.Drawing.Point(11, 268);
            this.grpRegistration.Margin = new System.Windows.Forms.Padding(2);
            this.grpRegistration.Name = "grpRegistration";
            this.grpRegistration.Padding = new System.Windows.Forms.Padding(2);
            this.grpRegistration.Size = new System.Drawing.Size(614, 146);
            this.grpRegistration.TabIndex = 8;
            this.grpRegistration.TabStop = false;
            this.grpRegistration.Text = "Registration Data";
            // 
            // titleLabel1
            // 
            this.titleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.titleLabel1.Location = new System.Drawing.Point(353, 68);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(253, 23);
            this.titleLabel1.TabIndex = 7;
            this.titleLabel1.Text = "[title]";
            this.titleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // creditHoursLabel1
            // 
            this.creditHoursLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditHoursLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CreditHours", true));
            this.creditHoursLabel1.Location = new System.Drawing.Point(124, 105);
            this.creditHoursLabel1.Name = "creditHoursLabel1";
            this.creditHoursLabel1.Size = new System.Drawing.Size(125, 23);
            this.creditHoursLabel1.TabIndex = 5;
            this.creditHoursLabel1.Text = "[cHours]";
            this.creditHoursLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseNumberLabel1
            // 
            this.courseNumberLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseNumberLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.courseNumberLabel1.Location = new System.Drawing.Point(124, 68);
            this.courseNumberLabel1.Name = "courseNumberLabel1";
            this.courseNumberLabel1.Size = new System.Drawing.Size(124, 23);
            this.courseNumberLabel1.TabIndex = 3;
            this.courseNumberLabel1.Text = "[courseNumber]";
            this.courseNumberLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StudentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 461);
            this.Controls.Add(this.grpRegistration);
            this.Controls.Add(this.grpStudent);
            this.Controls.Add(this.lnkDetails);
            this.Controls.Add(this.lnkUpdate);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentData";
            this.Text = "Student";
            this.Load += new System.EventHandler(this.StudentData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.grpStudent.ResumeLayout(false);
            this.grpStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradePointStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            this.grpRegistration.ResumeLayout(false);
            this.grpRegistration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkDetails;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.Label lblReader;
        private System.Windows.Forms.GroupBox grpStudent;
        private System.Windows.Forms.GroupBox grpRegistration;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.Label dateCreatedLabel1;
        private System.Windows.Forms.MaskedTextBox studentNumberMaskedTextBox;
        private System.Windows.Forms.Label gradePointAverageLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel postalCodeMaskedLabel;
        private EWSoftware.MaskedLabelControl.MaskedLabel provinceMaskedLabel;
        private System.Windows.Forms.Label outstandingFeesLabel1;
        private System.Windows.Forms.Label cityLabel1;
        private System.Windows.Forms.Label addressLabel1;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label creditHoursLabel1;
        private System.Windows.Forms.Label courseNumberLabel1;
        private System.Windows.Forms.Label descriptionLabel1;
        private System.Windows.Forms.BindingSource gradePointStateBindingSource;
    }
}