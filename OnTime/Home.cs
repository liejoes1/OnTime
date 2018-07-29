using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnTime_lib.Activity;
using OnTime_lib;
using OnTime_lib.Model;

namespace OnTime
{
    public partial class Home : Form
    {
        private static bool changeIntakeCounter = false;
        public Home()
        {
            this.ShowIcon = false;
            StartupActivity startup = new StartupActivity();
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
                lnklbl_change_intake.LinkBehavior = LinkBehavior.NeverUnderline;
                lnklbl_update.LinkBehavior = LinkBehavior.NeverUnderline;
                lnl_lbl_about.LinkBehavior = LinkBehavior.NeverUnderline;
                lnk_lbl_about.LinkBehavior = LinkBehavior.NeverUnderline;

            if (startup.getDataValid() && !changeIntakeCounter)
            {
                pnl_home.Visible = false;
                pnl_pw.Visible = true;
                lbl_message.Visible = false;
                loadSavedData(startup.getCacheIntake());
            }

        }

        private async void loadSavedData(string intake)
        {
            var intakeTimetableActivity = new IntakeTimetableActivity();
            //Download the data if no error
            await Task.Run(() => intakeTimetableActivity.GetSavedTimetable());
            pnl_pw.Visible = false;
            pnl_Timetable.Visible = true;
            lbl_IntakeCode.Text = intake;
            //Show TimeTable Data
            LoadTimeTableData();
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
                    pnl_pw.Visible = true;
                    lbl_message.Visible = false;
                    //Download the data if no error
                    await Task.Run(() => intakeTimetableActivity.GetIntakeTimetable());
                    pnl_pw.Visible = false;
                    pnl_Timetable.Visible = true;
                    lbl_IntakeCode.Text = result;
                    //Show TimeTable Data
                    LoadTimeTableData();


                    break;
            }
        }

        public void LoadTimeTableData()
        {
            IntakeTimetableActivity intakeTimetableActivity = new IntakeTimetableActivity();

            List<ResultClass> resultClasses = new List<ResultClass>();


            resultClasses.Add(new ResultClass("MON", lbl_Mon_Header, lv_Mon_TimeTable));
            resultClasses.Add(new ResultClass("TUE", lbl_Tue_Header, lv_Tue_TimeTable));
            resultClasses.Add(new ResultClass("WED", lbl_Wed_Header, lv_Wed_TimeTable));
            resultClasses.Add(new ResultClass("THU", lbl_Thu_Header, lv_Thu_TimeTable));
            resultClasses.Add(new ResultClass("FRI", lbl_Fri_Header, lv_Fri_TimeTable));

            //Before Load, Clear previous one first
            foreach (var i in resultClasses)
            {
                i.LblName.Text = string.Empty;
                i.LvName.Items.Clear();
            }


            foreach (var i in resultClasses)
            {
                var intakeResultlist = intakeTimetableActivity.GetTimetableDay(i.WeekDay);
                foreach (var j in intakeResultlist)
                {
                    i.LblName.Text = j.Date;
                    i.LvName.Items.Add(new ListViewItem(new string[] { j.Time, j.Module, j.Location }));
                }

                if (intakeResultlist.Count == 0)
                {
                    //If Empty
                    i.LblName.Text = "No Class";
                }
                intakeResultlist.Clear();
            }
        }

        private void lnklbl_change_intake_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changeIntakeCounter = true;
            pnl_home.Visible = true;
            pnl_Timetable.Visible = false;
        }

        private async void lnklbl_update_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pnl_pw.Visible = true;
            pnl_Timetable.Visible = false;

            IntakeCheckActivity intakeCheckActivity = new IntakeCheckActivity();
            IntakeTimetableActivity intakeTimetableActivity = new IntakeTimetableActivity();

            intakeCheckActivity.GetIntakeCheck(lbl_IntakeCode.Text);

            await Task.Run(() => intakeTimetableActivity.GetIntakeTimetable());
            pnl_pw.Visible = false;
            pnl_Timetable.Visible = true;
            //Show TimeTable Data
            LoadTimeTableData();

        }

        private void lnl_lbl_about_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

    }

    public class ResultClass
    {
        public string WeekDay { get; set; }
        public Label LblName { get; set; }
        public ListView LvName { get; set; }

        public ResultClass(string weekDay, Label lblName, ListView lvName)
        {
            WeekDay = weekDay;
            LblName = lblName;
            LvName = lvName;
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
