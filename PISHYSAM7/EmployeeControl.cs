using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISHYSAM7
{
    public partial class EmployeeControl : UserControl
    {

        public int EmployeeID;
        public event EventHandler EmployeeFired;
        public event EventHandler ControlClicked;
        public EmployeeControl()
        {
            InitializeComponent();
        }


        public void SetEmployeeData(int EmployeeId, string FIO, string department, string office, string post, string email, string phone)
        {
            EmployeeID = EmployeeId;
            labelFIO.Text = FIO;
            labelDep.Text = department;
            labelOffice.Text = office;
            labelPost.Text = post;
            labelEmail.Text = email;
            labelPhone.Text = phone;
        }

        private void button_fire_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены что хотите уволить данного сотрудника?", "Подтверждение", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {

                this.BackColor = Color.Gray;
                EmployeeFired.Invoke(this, EventArgs.Empty);
            }
            
        }

        private void EmployeeControl_Click(object sender, EventArgs e)
        {
            ControlClicked.Invoke(this, EventArgs.Empty);
        }
    }
}
