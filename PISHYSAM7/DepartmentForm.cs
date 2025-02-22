using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PISHYSAM7
{
    public partial class DepartmentForm : Form
    {
        int currentDepId;
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDepartments();
            Clean();
        }

        private void Clean()
        {
            string g = "delete from employees where DATEDIFF(DAY, date_end, GETDATE()) > 30";
            DataBaseHelper.ExecuteQuery(g);
        }

        private void LoadDepartments()
        {
            string qury = "select d.department_id, d.department_name, sd.main_department_id, sd.sub_department_id from departments d left join sub_departments sd on d.department_id = sd.sub_department_id";
            var departments = DataBaseHelper.ExecuteQuery(qury);
            var parentNode = new TreeNode("Дороги России");
            treeViewDep.Nodes.Add(parentNode);
            AddDepartmentsToTree(parentNode, departments, null, new HashSet<int>());
            treeViewDep.ExpandAll();
        }

        private void AddDepartmentsToTree(TreeNode parentNode, DataTable departments, int? ParentDepartmentId, HashSet<int>visited)
        {
            foreach(var row in departments.Select(ParentDepartmentId == null ? "main_department_id is null" : $"main_department_id = {ParentDepartmentId}"))
            {
                var departments_id = Convert.ToInt32(row["department_id"]);
                if(!visited.Add(departments_id)) { continue; }
                var department_name = new TreeNode(row["department_name"].ToString()) { Tag = departments_id};

                parentNode.Nodes.Add(department_name);
                AddDepartmentsToTree(department_name, departments, departments_id, visited);
            }
        }

        private void treeViewDep_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Tag is int selectedDepId)
            {
                LoadEmployees(selectedDepId);
            }
        }

        private void LoadEmployees(int selectedDepId)
        {
           currentDepId = selectedDepId;
            flowLayoutPanelEmp.Controls.Clear();
         
        
            string query = "select e.employee_id, e.last_name + ' ' +  e.first_name as name, e.work_phone, e.post, e.office, e.corporative_email, e.date_end, d.department_name from employees e inner join departments d on e.department_id = d.department_id where e.department_id = @department_id";
            var employees = DataBaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@department_id", currentDepId} });

            foreach(DataRow row in employees.Rows)
            {
                flowLayoutPanelEmp.Controls.Add(createEmployeeControl(row));
            }
        }

        private Control createEmployeeControl(DataRow row)
        {
            var control = new EmployeeControl();
            control.SetEmployeeData(Convert.ToInt32(row["employee_id"]),
                row["name"].ToString(),
                 row["department_name"].ToString(),
                  row["office"].ToString(),
                   row["post"].ToString(),
                    row["corporative_email"].ToString(),
                     row["work_phone"].ToString());


            if (!DBNull.Value.Equals(row["date_end"]))
            {
                control.BackColor = Color.Gray;
            }

            control.EmployeeFired += Control_EmployeeFired;
            control.ControlClicked += Control_ControlClicked;

            return control;
        }

        private void Control_ControlClicked(object sender, EventArgs e)
        {
            if (!(sender is EmployeeControl control)) return;

            if(control.BackColor == Color.Gray)
            {
              
                MessageBox.Show("Этот сотрудник уже уволен");
                return;
            }

            using (var form = new EmployeeForm(control.EmployeeID, currentDepId))
                if(form.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees(currentDepId);
                }


        }

        private void Control_EmployeeFired(object sender, EventArgs e)
        {
            if (!(sender is EmployeeControl control)) return;

            string query = "update employees set date_end = @date_end where employee_id = @employee_id";
            DataBaseHelper.ExecuteQuery(query, new Dictionary<string, object> { { "@date_end", DateTime.Now }, { "@employee_id", control.EmployeeID } });

          

            MessageBox.Show("Сотрудник уволен");
        }
    }
}
