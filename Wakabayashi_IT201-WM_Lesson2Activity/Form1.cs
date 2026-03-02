using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wakabayashi_IT201_WM_Lesson2Activity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Browse_click_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var stream = System.IO.File.OpenRead(openFileDialog.FileName))
                {
                    pictureBox1.Image = Image.FromStream(stream);
                }

                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void NewCancel_Click(object sender, EventArgs e)
        {
            studNM.Clear();
            stud_num.Clear();
            yr_lvl.Clear();
            dateTimePicker1.Value = DateTime.Now;
            scholar.Clear();

            txtnum.Clear();
            txtCourseCode.Clear();
            txtCourseDesc.Clear();
            txtUnitLec.Clear();
            txtUnitLab.Clear();
            txtCreditUnit.Clear();
            txtTime.Clear();
            txtDay.Clear();

            number.Items.Clear(); coursecode.Items.Clear(); course_desc.Items.Clear();
            unit_lec.Items.Clear(); unit_lab.Items.Clear(); credit_units.Items.Clear();
            time.Items.Clear(); day.Items.Clear(); txtCisco.Clear(); txtExam.Clear();
            txtMisFee.Clear(); txtNumUnit.Clear(); txtTotfee.Clear(); txtTuitionFee.Clear();
            txtLabFee.Clear(); Totfee.Clear(); MiscellaneousFee.Clear(); NumUnits.Clear();
            TotalTuitionFee.Clear(); Laboratoryfee.Clear(); CiscoFee.Clear(); ExamBooklet.Clear();


            pictureBox1.Image = null;
            progbox.SelectedIndex = -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] programs = {"BS Civil Engineering", "BS Computer Engineering", "BS Electrical Engineering", "BS Aerospace Engineering", "BS Mechanical Engineering"};
            progbox.Items.AddRange(programs);
        }

        private void submit_Click(object sender, EventArgs e)
        {   
            decimal tuition = 0; 
            decimal miscellaneous = 0; 
            decimal units = 0;
            decimal labfee = 0; 
            decimal cisco = 0; 
            decimal exam = 0;

            decimal.TryParse(txtTotfee.Text, out tuition);
            decimal.TryParse(txtMisFee.Text, out miscellaneous);
            decimal.TryParse(txtNumUnit.Text, out units);
            decimal.TryParse(txtLabFee.Text, out labfee);
            decimal.TryParse(txtCisco.Text, out cisco);
            decimal.TryParse(txtExam.Text, out exam);

            decimal Totalfee = tuition + miscellaneous + units + labfee + cisco + exam;
            txtTuitionFee.Text = Totalfee.ToString("N2");
            TuitionFee.Text = Totalfee.ToString("N2");


            int rowNum = number.Items.Count + 1;
            number.Items.Add(rowNum.ToString());
            coursecode.Items.Add(txtCourseCode.Text);
            course_desc.Items.Add(txtCourseDesc.Text);
            unit_lec.Items.Add(txtUnitLec.Text);
            unit_lab.Items.Add(txtUnitLab.Text);
            credit_units.Items.Add(txtCreditUnit.Text);
            time.Items.Add(txtTime.Text);
            day.Items.Add(txtDay.Text);

            Totfee.Text = txtTotfee.Text;
            MiscellaneousFee.Text = txtMisFee.Text;
            NumUnits.Text = txtNumUnit.Text;
            TotalTuitionFee.Text = txtTuitionFee.Text;
            Laboratoryfee.Text = txtLabFee.Text;
            CiscoFee.Text = txtCisco.Text;
            ExamBooklet.Text = txtExam.Text;

        }
    }
}
