using Lab05.BUS;
using Lab05.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab05.GUI
{
    public partial class frmQLSV : Form
    {
        public static frmQLSV form1;
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private string pathImage;

        public frmQLSV()
        {
            InitializeComponent();
            form1 = this;
        }

        private void BindGrid(List<Student> dssv) 
        {
            dgvStudent.Rows.Clear();
            foreach(var item in dssv)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore+"";
                if (item.MajorID != null)
                    dgvStudent.Rows[index].Cells[4].Value = item.Major.Name+"";
            }
        }

        private void ShowAvatar(string imagename)
        {
            try
            {
                if (string.IsNullOrEmpty(imagename))
                    picAvatar.Image = null;
                else
                {
                    byte[] imageBytes = Convert.FromBase64String(imagename);

                    // Tạo một MemoryStream từ mảng byte
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        // Tạo một hình ảnh từ MemoryStream
                        Image avatarImage = Image.FromStream(ms);

                        // Đặt hình ảnh cho PictureBox
                        picAvatar.Image = avatarImage;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Không tìm thấy tệp hình ảnh: " + imagename);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Không thể tải hình ảnh. Hình ảnh có thể có định dạng không được hỗ trợ hoặc bị hỏng.");
            }
        }
    

        private void FillFacultyCombobox(List<Faculty> dskhoa)
        {
            cmbKhoa.DataSource = dskhoa;
            cmbKhoa.DisplayMember = "FacultyName";
            cmbKhoa.ValueMember = "FacultyID";
        }
        public void frmQLSV_Load(object sender, EventArgs e)
        {
            try
            {
                var dssv = studentService.GetAll();
                var dskhoa = facultyService.GetAll();
                FillFacultyCombobox(dskhoa);
                BindGrid(dssv);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            List<Student> listStudents = new List<Student>();
            if (this.checkBox1.Checked)
                listStudents = studentService.GetAllHasNoMajor();
            else
                listStudents = studentService.GetAll();
            BindGrid(listStudents);

        }

        private void btnPic_Click(object sender, EventArgs e)
        {
            string imagelocation = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagelocation = openFileDialog.FileName;
                picAvatar.Image = Image.FromFile(imagelocation);
                pathImage = imagelocation;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkdata())
                {
                    Student s = new Student { StudentID = txtMaSV.Text, FullName = txtHoten.Text, AverageScore = double.Parse(txtDiem.Text), FacultyID = int.Parse(cmbKhoa.SelectedValue.ToString()), MajorID = null, Avatar = pathImage};
                    studentService.InsertUpdate(s);
                    List<Student> dssv = studentService.GetAll();
                    BindGrid(dssv);
                    MessageBox.Show("Cập nhật dữ liệu thành công!","Thông báo", MessageBoxButtons.OK);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool checkdata()
        {
            if (txtDiem.Text == "" || txtHoten.Text == "" || txtMaSV.Text == "")
            {
                MessageBox.Show("Vui long nhap day du thong tin!", "Thong bao", MessageBoxButtons.OK);
                return false;
            }
            else if (txtMaSV.Text.Length != 10)
            {
                MessageBox.Show("Ma so sinh vien phai co 10 ky tu!", "Thong bao", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Student s = studentService.FindByID(dgvStudent.SelectedRows[0].Cells[0].Value.ToString());
                if (s!= null)
                {
                    txtMaSV.Text = s.StudentID;
                    txtHoten.Text = s.FullName;
                    txtDiem.Text = s.AverageScore.ToString();
                    cmbKhoa.SelectedValue = s.FacultyID;
                    if (s.Avatar != null && s.Avatar != "")
                    {
                        pathImage = s.Avatar;
                        picAvatar.ImageLocation = pathImage;
                    }
                    else
                    {
                        picAvatar.ImageLocation = null;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                studentService.RemoveByID(txtMaSV.Text);
                List<Student> dssv = studentService.GetAll();
                BindGrid(dssv);
                MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void đăngKýChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtMaSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !(e.KeyChar == 46))
                e.Handled = true;
        }

        private void txtDiem_Enter(object sender, EventArgs e)
        {
            if (float.Parse(txtDiem.Text) < 0 || float.Parse(txtDiem.Text) > 10)
            {   
                MessageBox.Show("Điểm không hợp lệ! Vui lòng nhập lại");
                txtDiem.Text = "";
            }
        }

        private bool isTypingVietnameseWord = false;

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập chữ và có dấu
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                // Nếu người dùng đang gõ một từ tiếng Việt, cho phép nhập số
                if (isTypingVietnameseWord && char.IsDigit(e.KeyChar) && char.IsWhiteSpace(e.KeyChar))
                {
                    return;
                }

                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Khi người dùng nhấn một phím chữ, giả định rằng họ đang bắt đầu gõ một từ tiếng Việt
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                isTypingVietnameseWord = true;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            // Khi người dùng thả một phím chữ, giả định rằng họ đã hoàn thành việc gõ một từ tiếng Việt
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                isTypingVietnameseWord = false;
            }
        }
    }
}
