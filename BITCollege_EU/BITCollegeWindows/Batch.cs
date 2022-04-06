using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BITCollege_EU.Data;
using BITCollege_EU.Models;

namespace BITCollegeWindows
{
    public partial class Batch : Form
    {
        private BITCollege_EUContext db = new BITCollege_EUContext();
        private BatchProcess batchProcess = new BatchProcess();

        public Batch()
        {
            InitializeComponent();
        }

        /// <summary>
        /// given:  ensures key is entered
        /// further code to be added
        /// </summary>
        private void lnkProcess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //NOTE:  This may be commented out until needed
            if (txtKey.Text == "")
            {
                MessageBox.Show("A 64-bit Key must be entered", "Error");
            }
            
            if (radSelect.Checked)
            {
                batchProcess.ProcessTransmission(descriptionComboBox.SelectedValue.ToString(),txtKey.Text);
                rtxtLog.Text = batchProcess.WriteLogData();
            }
            else if (radAll.Checked) 
            {
                string fullExecutionLog = "";
                foreach (AcademicProgram acronymItem in descriptionComboBox.Items) {
                    batchProcess.ProcessTransmission(acronymItem.ProgramAcronym, txtKey.Text);
                    fullExecutionLog += batchProcess.WriteLogData();
                }
                rtxtLog.Text = fullExecutionLog;
            }
        }

        /// <summary>
        /// given:  open in top right of frame
        /// further code required:
        /// </summary>
        private void Batch_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            loadAcademicPrograms();
        }

        /// <summary>
        /// Obtains all academic programs from the database.
        /// </summary>
        /// <returns></returns>
        private IQueryable<AcademicProgram> GetAcademicPrograms()
        {
            return db.AcademicPrograms;
        }

        /// <summary>
        /// Loads the combo box for Academic Programs
        /// </summary>
        private void loadAcademicPrograms() 
        {
            academicProgramBindingSource.DataSource = GetAcademicPrograms().ToList();
        }

        private void radSelect_CheckedChanged(object sender, EventArgs e)
        {
            descriptionComboBox.Enabled = true;
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            descriptionComboBox.Enabled = false;
        }

        private void lnkEncrypt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            batchProcess.encrypFileInput(descriptionComboBox.SelectedValue.ToString(), txtKey.Text);
            MessageBox.Show("Encryption correct", "Encryption");
        }
    }
}
