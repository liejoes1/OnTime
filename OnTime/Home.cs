using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

            var intakeListActivity = new IntakeListActivity();

            // Set Autocomplete
            tb_intake_code.AutoCompleteMode = AutoCompleteMode.Suggest;
            tb_intake_code.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(intakeListActivity.GetIntakeCode().ToArray());
            tb_intake_code.AutoCompleteCustomSource = autoComplete;
            // Set Week
            lbl_week_value.Text = intakeListActivity.GetWeek();

            pnl_home.Visible = true;
            lbl_message.Visible = false;

            link_lbl_go.LinkBehavior = LinkBehavior.NeverUnderline;
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }



        private async void link_lbl_go_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var intakeListActivity = new IntakeListActivity();
            var intakeCheckActivity = new IntakeCheckActivity();
            var intakeTimetableActivity = new IntakeTimetableActivity();
            
            var result = tb_intake_code.Text.ToUpper();
            var errorCode = 0;

            for (var i = 0; i < intakeListActivity.GetIntakeCode().Count; i++)
                if (result == intakeListActivity.GetIntakeCode()[i])
                {
                    errorCode = 3;
                }

            if (!intakeCheckActivity.GetIntakeCheck(result) && errorCode == 3)
            {
                errorCode = 1;
            }

            switch (errorCode)
            {
                case 0:
                    lbl_message.Visible = true;
                    lbl_message.Text = "Invalid Intake Code";
                    break;
                case 1:
                    lbl_message.Visible = true;
                    lbl_message.Text = "You have no class on this week.";
                    break;
                case 3:

                    pnl_home.Visible = false;
                    pnl_timetable.Visible = true;
                    lbl_message.Visible = false;
                    label1.Text = "Downloading";
                    //Download the data if no error
                    await Task.Run(() => intakeTimetableActivity.GetIntakeTimetable());
                    
                    label1.Text = "Success";
                    break;
            }
        }


    }
}


/*
 *  References
 *
 *  ErrorCode
 *  0 -> Invalid Intake
 *  1 -> No Class
 *  3 -> OK No Problem
 */
