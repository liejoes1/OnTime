using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnTime_lib.Activity;

namespace OnTime
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            IntakeListActivity intakeListActivity = new IntakeListActivity();
            //label1.Text = intakeListActivity.GetWeek();

            tb_intake_code.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_intake_code.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(intakeListActivity.GetIntakeCode().ToArray());
            tb_intake_code.AutoCompleteCustomSource = autoComplete;

            link_lbl_go.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void button1_Click(object sender, EventArgs e)
        {



 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void link_lbl_go_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IntakeListActivity intakeListActivity = new IntakeListActivity();
            string result = tb_intake_code.Text;
            bool status = false;

            for (int i = 0; i < intakeListActivity.GetIntakeCode().Count; i++)
            {
                if (result == intakeListActivity.GetIntakeCode()[i])
                {
                    status = true;
                    lbl_message.Text = "Success";
                }
            }

            if (!status)
            {
                lbl_message.Text = "Invalid Intake Code";
            }

        }

        private void lbl_message_Click(object sender, EventArgs e)
        {

        }
    }
}
