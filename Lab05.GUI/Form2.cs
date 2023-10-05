using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab05.BUS;
using Lab05.DAL.Entities;

namespace Lab05.GUI
{
    public partial class Form2 : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private readonly MajorService majorService = new MajorService();
        public Form2()
        {
            InitializeComponent();
        }
        private void FillFacultyCombobox(List<Faculty> dskhoa)
        {
            cmbKhoa.DataSource = dskhoa;
            cmbKhoa.DisplayMember = "FacultyName";
            cmbKhoa.ValueMember = "FacultyID";
        }

        private void FillMajorCombobox(List<Major> dschuyennganh)
        {
            cmbChuyennganh.DataSource = dschuyennganh;
            cmbChuyennganh.DisplayMember = "Name";
            cmbChuyennganh.ValueMember = "MajorID";

        }
        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                List<Faculty> dskhoa = facultyService.GetAll();
                FillFacultyCombobox(dskhoa);
                cmbKhoa.SelectedItem = null;
                cmbChuyennganh.SelectedItem = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbChuyennganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Faculty faculty = cmbKhoa.SelectedItem as Faculty;
            if (faculty != null)
            {
                var listMajor = majorService.GetAllByFaculty(faculty.FacultyID);
                FillMajorCombobox(listMajor);
                var listStudents = studentService.GetAllHasNoMajor(faculty.FacultyID);
                BindGrid(listStudents);
            }
            else
            {
                BindGrid(studentService.GetAllHasNoMajor());
            }
        }

        private void BindGrid(List<Student> listStudents)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudents)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore + "";
            }
            txttongsvchuadk.Text = dgvStudent.Rows.Count - 1 + "";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (dgvStudent.SelectedRows.Count > 0)
            {
                List<Student> studentsToUpdate = new List<Student>();
                foreach (DataGridViewRow row in dgvStudent.SelectedRows)
                {
                    Student s = studentService.FindByID(row.Cells[0].Value.ToString());
                    if (s != null)
                    {
                        s.MajorID = int.Parse(cmbChuyennganh.SelectedValue.ToString());
                        studentsToUpdate.Add(s);
                    }
                }

                foreach (Student s in studentsToUpdate)
                {
                    studentService.InsertUpdate(s);
                }

                Form2_Load(sender, e);
                frmQLSV.form1.frmQLSV_Load(sender, e);
                MessageBox.Show("Đăng ký thành công!");
            }
            else
            {
                MessageBox.Show("Không có thông tin cần đăng ký!");
            }

        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
