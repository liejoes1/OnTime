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
            var intakeListActivity = new IntakeListActivity();

            // Set Autocomplete
            tb_intake_code.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_intake_code.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(intakeListActivity.GetIntakeCode().ToArray());
            tb_intake_code.AutoCompleteCustomSource = autoComplete;
            // Set Week
            lbl_week_value.Text = intakeListActivity.GetWeek();

            lbl_message.Visible = false;

            link_lbl_go.LinkBehavior = LinkBehavior.NeverUnderline;
        }



        private void link_lbl_go_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var intakeListActivity = new IntakeListActivity();
            var intakeCheckActivity = new IntakeCheckActivity();
            var result = tb_intake_code.Text;
            var errorCode = 0;

            for (var i = 0; i < intakeListActivity.GetIntakeCode().Count; i++)
                if (result == intakeListActivity.GetIntakeCode()[i])
                {
                    lbl_message.Visible = false;
                    errorCode = 3;
                }


            if (!intakeCheckActivity.GetIntakeCheck(result) && errorCode == 3)
            {
                errorCode = 1;
            }


            if (errorCode == 0)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "Invalid Intake Code";
            }

            if (errorCode == 1)
            {
                lbl_message.Visible = true;
                lbl_message.Text = "You have no class on this week.";
            }
        }
    }
}
