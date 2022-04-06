namespace BITCollegeWindows
{
    partial class Grading
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
            System.Windows.Forms.Label courseNumberLabel;
            System.Windows.Forms.Label courseTypeLabel;
            System.Windows.Forms.Label gradeLabel;
            System.Windows.Forms.Label descriptionLabel2;
            this.gbStudent = new System.Windows.Forms.GroupBox();
            this.descriptionLabel3 = new System.Windows.Forms.Label();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fullNameLabel1 = new System.Windows.Forms.Label();
            this.studentNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.academicProgramBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gbGrading = new System.Windows.Forms.GroupBox();
            this.lblExisting = new System.Windows.Forms.Label();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.registrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.courseTypeLabel1 = new System.Windows.Forms.Label();
            this.courseNumberMaskedLabel = new EWSoftware.MaskedLabelControl.MaskedLabel();
            this.titleLabel1 = new System.Windows.Forms.Label();
            this.lnkReturn = new System.Windows.Forms.LinkLabel();
            this.lnkUpdate = new System.Windows.Forms.LinkLabel();
            studentNumberLabel = new System.Windows.Forms.Label();
            courseNumberLabel = new System.Windows.Forms.Label();
            courseTypeLabel = new System.Windows.Forms.Label();
            gradeLabel = new System.Windows.Forms.Label();
            descriptionLabel2 = new System.Windows.Forms.Label();
            this.gbStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).BeginInit();
            this.gbGrading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // studentNumberLabel
            // 
            studentNumberLabel.AutoSize = true;
            studentNumberLabel.Location = new System.Drawing.Point(52, 25);
            studentNumberLabel.Name = "studentNumberLabel";
            studentNumberLabel.Size = new System.Drawing.Size(87, 13);
            studentNumberLabel.TabIndex = 0;
            studentNumberLabel.Text = "Student Number:";
            // 
            // courseNumberLabel
            // 
            courseNumberLabel.AutoSize = true;
            courseNumberLabel.Location = new System.Drawing.Point(37, 37);
            courseNumberLabel.Name = "courseNumberLabel";
            courseNumberLabel.Size = new System.Drawing.Size(83, 13);
            courseNumberLabel.TabIndex = 5;
            courseNumberLabel.Text = "Course Number:";
            // 
            // courseTypeLabel
            // 
            courseTypeLabel.AutoSize = true;
            courseTypeLabel.Location = new System.Drawing.Point(37, 89);
            courseTypeLabel.Name = "courseTypeLabel";
            courseTypeLabel.Size = new System.Drawing.Size(70, 13);
            courseTypeLabel.TabIndex = 6;
            courseTypeLabel.Text = "Course Type:";
            // 
            // gradeLabel
            // 
            gradeLabel.AutoSize = true;
            gradeLabel.Location = new System.Drawing.Point(37, 135);
            gradeLabel.Name = "gradeLabel";
            gradeLabel.Size = new System.Drawing.Size(39, 13);
            gradeLabel.TabIndex = 7;
            gradeLabel.Text = "Grade:";
            // 
            // descriptionLabel2
            // 
            descriptionLabel2.AutoSize = true;
            descriptionLabel2.Location = new System.Drawing.Point(52, 58);
            descriptionLabel2.Name = "descriptionLabel2";
            descriptionLabel2.Size = new System.Drawing.Size(63, 13);
            descriptionLabel2.TabIndex = 5;
            descriptionLabel2.Text = "Description:";
            // 
            // gbStudent
            // 
            this.gbStudent.Controls.Add(descriptionLabel2);
            this.gbStudent.Controls.Add(this.descriptionLabel3);
            this.gbStudent.Controls.Add(this.fullNameLabel1);
            this.gbStudent.Controls.Add(studentNumberLabel);
            this.gbStudent.Controls.Add(this.studentNumberMaskedLabel);
            this.gbStudent.Location = new System.Drawing.Point(11, 11);
            this.gbStudent.Margin = new System.Windows.Forms.Padding(2);
            this.gbStudent.Name = "gbStudent";
            this.gbStudent.Padding = new System.Windows.Forms.Padding(2);
            this.gbStudent.Size = new System.Drawing.Size(599, 104);
            this.gbStudent.TabIndex = 0;
            this.gbStudent.TabStop = false;
            this.gbStudent.Text = "Student Data";
            // 
            // descriptionLabel3
            // 
            this.descriptionLabel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionLabel3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "AcademicProgram.Description", true));
            this.descriptionLabel3.Location = new System.Drawing.Point(145, 58);
            this.descriptionLabel3.Name = "descriptionLabel3";
            this.descriptionLabel3.Size = new System.Drawing.Size(446, 23);
            this.descriptionLabel3.TabIndex = 6;
            this.descriptionLabel3.Text = "label1";
            this.descriptionLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(BITCollege_EU.Models.Student);
            // 
            // fullNameLabel1
            // 
            this.fullNameLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fullNameLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "FullName", true));
            this.fullNameLabel1.Location = new System.Drawing.Point(262, 25);
            this.fullNameLabel1.Name = "fullNameLabel1";
            this.fullNameLabel1.Size = new System.Drawing.Size(329, 23);
            this.fullNameLabel1.TabIndex = 3;
            this.fullNameLabel1.Text = "label1";
            this.fullNameLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // studentNumberMaskedLabel
            // 
            this.studentNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.studentBindingSource, "StudentNumber", true));
            this.studentNumberMaskedLabel.Location = new System.Drawing.Point(145, 25);
            this.studentNumberMaskedLabel.Name = "studentNumberMaskedLabel";
            this.studentNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.studentNumberMaskedLabel.TabIndex = 1;
            this.studentNumberMaskedLabel.Text = "maskedLabel1";
            this.studentNumberMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // academicProgramBindingSource
            // 
            this.academicProgramBindingSource.DataSource = typeof(BITCollege_EU.Models.AcademicProgram);
            // 
            // gbGrading
            // 
            this.gbGrading.Controls.Add(this.lblExisting);
            this.gbGrading.Controls.Add(gradeLabel);
            this.gbGrading.Controls.Add(this.gradeTextBox);
            this.gbGrading.Controls.Add(courseTypeLabel);
            this.gbGrading.Controls.Add(this.courseTypeLabel1);
            this.gbGrading.Controls.Add(courseNumberLabel);
            this.gbGrading.Controls.Add(this.courseNumberMaskedLabel);
            this.gbGrading.Controls.Add(this.titleLabel1);
            this.gbGrading.Controls.Add(this.lnkReturn);
            this.gbGrading.Controls.Add(this.lnkUpdate);
            this.gbGrading.Location = new System.Drawing.Point(57, 119);
            this.gbGrading.Margin = new System.Windows.Forms.Padding(2);
            this.gbGrading.Name = "gbGrading";
            this.gbGrading.Padding = new System.Windows.Forms.Padding(2);
            this.gbGrading.Size = new System.Drawing.Size(501, 225);
            this.gbGrading.TabIndex = 1;
            this.gbGrading.TabStop = false;
            this.gbGrading.Text = "Grading Information";
            // 
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(265, 135);
            this.lblExisting.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Size = new System.Drawing.Size(185, 13);
            this.lblExisting.TabIndex = 2;
            this.lblExisting.Text = "Existing grades cannot be overridden.";
            this.lblExisting.Visible = false;
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Grade", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "P2"));
            this.gradeTextBox.Enabled = false;
            this.gradeTextBox.Location = new System.Drawing.Point(126, 132);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(100, 20);
            this.gradeTextBox.TabIndex = 8;
            // 
            // registrationBindingSource
            // 
            this.registrationBindingSource.DataSource = typeof(BITCollege_EU.Models.Registration);
            // 
            // courseTypeLabel1
            // 
            this.courseTypeLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseTypeLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseType", true));
            this.courseTypeLabel1.Location = new System.Drawing.Point(126, 89);
            this.courseTypeLabel1.Name = "courseTypeLabel1";
            this.courseTypeLabel1.Size = new System.Drawing.Size(100, 23);
            this.courseTypeLabel1.TabIndex = 7;
            this.courseTypeLabel1.Text = "label1";
            this.courseTypeLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // courseNumberMaskedLabel
            // 
            this.courseNumberMaskedLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.courseNumberMaskedLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.CourseNumber", true));
            this.courseNumberMaskedLabel.Location = new System.Drawing.Point(126, 37);
            this.courseNumberMaskedLabel.Name = "courseNumberMaskedLabel";
            this.courseNumberMaskedLabel.Size = new System.Drawing.Size(100, 23);
            this.courseNumberMaskedLabel.TabIndex = 6;
            this.courseNumberMaskedLabel.Text = "maskedLabel1";
            this.courseNumberMaskedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // titleLabel1
            // 
            this.titleLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titleLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.registrationBindingSource, "Course.Title", true));
            this.titleLabel1.Location = new System.Drawing.Point(253, 37);
            this.titleLabel1.Name = "titleLabel1";
            this.titleLabel1.Size = new System.Drawing.Size(238, 23);
            this.titleLabel1.TabIndex = 5;
            this.titleLabel1.Text = "label1";
            this.titleLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkReturn
            // 
            this.lnkReturn.AutoSize = true;
            this.lnkReturn.Location = new System.Drawing.Point(250, 187);
            this.lnkReturn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkReturn.Name = "lnkReturn";
            this.lnkReturn.Size = new System.Drawing.Size(117, 13);
            this.lnkReturn.TabIndex = 1;
            this.lnkReturn.TabStop = true;
            this.lnkReturn.Text = "Return to Student Data";
            this.lnkReturn.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReturn_LinkClicked);
            // 
            // lnkUpdate
            // 
            this.lnkUpdate.AutoSize = true;
            this.lnkUpdate.Enabled = false;
            this.lnkUpdate.Location = new System.Drawing.Point(152, 187);
            this.lnkUpdate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lnkUpdate.Name = "lnkUpdate";
            this.lnkUpdate.Size = new System.Drawing.Size(74, 13);
            this.lnkUpdate.TabIndex = 0;
            this.lnkUpdate.TabStop = true;
            this.lnkUpdate.Text = "Update Grade";
            this.lnkUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkUpdate_LinkClicked);
            // 
            // Grading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 352);
            this.Controls.Add(this.gbGrading);
            this.Controls.Add(this.gbStudent);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Grading";
            this.Text = "Grading";
            this.Load += new System.EventHandler(this.Grading_Load);
            this.gbStudent.ResumeLayout(false);
            this.gbStudent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.academicProgramBindingSource)).EndInit();
            this.gbGrading.ResumeLayout(false);
            this.gbGrading.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.registrationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbStudent;
        private System.Windows.Forms.GroupBox gbGrading;
        private System.Windows.Forms.Label lblExisting;
        private System.Windows.Forms.LinkLabel lnkReturn;
        private System.Windows.Forms.LinkLabel lnkUpdate;
        private System.Windows.Forms.BindingSource academicProgramBindingSource;
        private System.Windows.Forms.Label fullNameLabel1;
        private System.Windows.Forms.BindingSource studentBindingSource;
        private EWSoftware.MaskedLabelControl.MaskedLabel studentNumberMaskedLabel;
        private System.Windows.Forms.TextBox gradeTextBox;
        private System.Windows.Forms.BindingSource registrationBindingSource;
        private System.Windows.Forms.Label courseTypeLabel1;
        private EWSoftware.MaskedLabelControl.MaskedLabel courseNumberMaskedLabel;
        private System.Windows.Forms.Label titleLabel1;
        private System.Windows.Forms.Label descriptionLabel3;
    }
}