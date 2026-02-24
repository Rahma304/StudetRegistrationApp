using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StudentRegistrationApp
{
    public partial class Form1 : Form
    {
        private SchoolDbContext _dbContext;
        private byte[]? _currentImageData = null;

        public Form1()
        {
            InitializeComponent();
            _dbContext = new SchoolDbContext();
            RefreshGrid();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImageData = File.ReadAllBytes(ofd.FileName);
                    DisplayImage(_currentImageData);
                }
            }
        }

        private void DisplayImage(byte[]? imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    picStudent.Image = Image.FromStream(ms);
                    picStudent.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                picStudent.Image = null;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newStudent = new Student
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                ClassName = txtClass.Text,
                Age = int.Parse(txtAge.Text),
                ImageData = _currentImageData
            };
            _dbContext.AddStudent(newStudent);
            RefreshGrid();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var updatedStudent = new Student
            {
                Id = int.Parse(txtId.Text),
                Name = txtName.Text,
                ClassName = txtClass.Text,
                Age = int.Parse(txtAge.Text),
                ImageData = _currentImageData
            };
            _dbContext.UpdateStudent(updatedStudent);
            RefreshGrid();
            ClearFields();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            _dbContext.DeleteStudent(id);
            RefreshGrid();
            ClearFields();
        }

        private void RefreshGrid()
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = _dbContext.GetAllStudents();
            if (dgvStudents.Columns["ImageData"] != null)
                dgvStudents.Columns["ImageData"].Visible = false;
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtClass.Text = row.Cells["ClassName"].Value.ToString();
                txtAge.Text = row.Cells["Age"].Value.ToString();

                _currentImageData = row.Cells["ImageData"].Value as byte[];
                DisplayImage(_currentImageData);
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtName.Clear();
            txtClass.Clear();
            txtAge.Clear();
            picStudent.Image = null;
            _currentImageData = null;
        }
    }
}