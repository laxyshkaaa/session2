using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISHYSAM7
{
    public partial class EmployeeForm : Form
    {
        int employeeID;
        int DepartmentID;
        public EmployeeForm(int employeeID, int departmentID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
            DepartmentID = departmentID;
        }

       private void LoadComboBox(string query, ComboBox combo, string display, string value, object SelectedItem = null, Dictionary<string, object> Parameters = null)
        {
            var data = Parameters == null ? DataBaseHelper.ExecuteQuery(query) : DataBaseHelper.ExecuteQuery(query, Parameters);
            combo.DataSource = data;
            combo.DisplayMember = display;
            combo.ValueMember = value;
            if (SelectedItem != null) combo.SelectedItem = SelectedItem;
        }

        private void LoadComboBoxes()
        {
            LoadComboBox("select department_id, department_name from departments", comboBoxDepartm, "department_name", "department_id", null);

            string query = "select employee_id, last_name + ' ' + first_name as name from employees where employee_id != @employee_id and department_id = @department_id";
            var param = new Dictionary<string, object> { {"@employee_id", employeeID }, { "@department_id", DepartmentID} }; 
            LoadComboBox(query, comboBoxAssist, "name", "employee_id", null, param);
            LoadComboBox(query, comboBoxManager, "name", "employee_id", null, param);
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadComboBoxes  ();
            LoadEmployeeData();
            SetEditMode(false);
            loadFilteredEvents("e.date_start < @today and e.date_end > @today");
            
        }


        private void LoadEmployeeData()
        {
            string query = "select employee_id, last_name + ' ' + first_name as name, work_phone, post, office, corporative_email, date_end,department_id, birth_date, personal_phone, manager_id from employees where employee_id = @employee_id";

            var employees = DataBaseHelper.ExecuteQuery (query, new Dictionary<string, object> { { "employee_id", employeeID} });

            var data = employees.Rows[0];

            textBoxFIO.Text = data["name"].ToString();
            textBox2Office.Text = data["office"].ToString();
            textBoxEmail.Text = data["corporative_email"].ToString();
            textBoxMobilePhone.Text = data["personal_phone"].ToString();
            textBoxPost.Text = data["post"].ToString();
            textBoxWork_phone.Text = data["work_phone"].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(data["birth_date"]);
            comboBoxDepartm.SelectedValue = data["department_id"].ToString();
            
        }

        private void SetEmployeeData()
        {
            var param = new Dictionary<string, object> { { "@work_phone", textBoxWork_phone.Text }, { "@post", textBoxPost.Text }, { "@office", textBox2Office.Text }, { "@corporative_email", textBoxEmail.Text }, { "@birth_date", dateTimePicker1.Value }, { "@employee_id", employeeID}, { "@department_id", comboBoxDepartm.SelectedValue} };
            var query = "update employees set work_phone = @work_phone,  post = @post, office = @office, corporative_email = @corporative_email, birth_date = @birth_date, department_id = @department_id where employee_id = @employee_id";
            DataBaseHelper.ExecuteQuery(query, param);
        }

        private void SetEditMode(bool onlyread)
        {
            textBox2Office.ReadOnly = !onlyread;
            textBoxEmail.ReadOnly = !onlyread;
            textBoxFIO.ReadOnly = !onlyread;
            textBoxMobilePhone.ReadOnly = !onlyread;
            textBoxPost.ReadOnly = !onlyread;
            textBoxWork_phone.ReadOnly = !onlyread;
            dateTimePicker1.Enabled = onlyread;
            comboBoxAssist.Enabled = onlyread;
            comboBoxDepartm.Enabled = onlyread;
            comboBoxManager .Enabled = onlyread;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            string email = textBoxEmail.Text;
            string WorkPhone = textBoxWork_phone.Text;
            string PersonalPhone = textBoxMobilePhone.Text;
            string office = textBox2Office.Text;
            if(!Regex.IsMatch(email, @"@gmail\.com$"))
            {
                MessageBox.Show("Неверный формат ввода email", "Предупреждение", MessageBoxButtons.OK);
                return;
            }

            if(office.Length > 3)
            {
                MessageBox.Show("Такого кабинета не существует, номера кабинетов: 1 - 999");
                return;
            }

            if (WorkPhone.Length  < 6 || PersonalPhone.Length < 6)
            {
                MessageBox.Show("Неверный формат номера");
                return;
            }



            SetEmployeeData();
            Close();
            LoadEmployeeData();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void loadFilteredEvents(string condition)
        {
            string query = $"select e.event_description, e.date_start, e.date_end, et.type_event_name from events e inner join event_types et on e.type_event_id = et.type_event_id where employee_id = @employee_id and {condition} order by et.type_event_name";
            var events= DataBaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@employee_id", employeeID }, { "@today", DateTime.Now} });
            DisplayEvents(events);

        }

        private void DisplayEvents(DataTable events)
        {
            flowLayoutPanelEvents.Controls.Clear();
            foreach (DataRow row in events.Rows) {
                string name = row["type_event_name"].ToString();
                string dates =$"{ DateTime.Parse(row["date_start"].ToString()) :d} -  {DateTime.Parse(row["date_end"].ToString()):d}";
                string desc = row["event_description"].ToString();
                flowLayoutPanelEvents.Controls.Add(new EventControl(name, dates, desc));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadFilteredEvents("e.date_end < @today");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadFilteredEvents("e.date_start > @today");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadFilteredEvents("e.date_start < @today and e.date_end > @today");
        }
    }
}
