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

            tb_intake_code.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb_intake_code.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var autoComplete = new AutoCompleteStringCollection();
            autoComplete.AddRange(intakeListActivity.GetIntakeCode().ToArray());
            tb_intake_code.AutoCompleteCustomSource = autoComplete;
        }

        private void button1_Click(object sender, EventArgs e)
        {



 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
