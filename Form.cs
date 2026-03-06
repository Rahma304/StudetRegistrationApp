
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

            dgvStudents.CellClick += studentsGrid_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnBrowse.Click += btnBrowse_Click;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog { Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp" };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _currentImageData = File.ReadAllBytes(ofd.FileName);
                DisplayImage(_currentImageData);
            }
        }

        private void DisplayImage(byte[]? imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using MemoryStream ms = new MemoryStream(imageData);
                picStudent.Image = Image.FromStream(ms);
            }
            else picStudent.Image = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("  Invalid Id  "); return; }
            var student = new Student
            {
                Id = id,
                Name = txtName.Text,
                ClassName = txtClass.Text,
                Age = int.Parse(txtAge.Text),
                ImageData = _currentImageData
            };
            _dbContext.AddStudent(student);
            RefreshGrid();
            ClearFields();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("Select a valid student first"); return; }
            var updatedStudent = new Student
            {
                Id = id,
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
            if (!int.TryParse(txtId.Text, out int id)) { MessageBox.Show("Select a valid student to delete"); return; }
            _dbContext.DeleteStudent(id);
            RefreshGrid();
            ClearFields();
        }

        private void studentsGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStudents.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtClass.Text = row.Cells["ClassName"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            _currentImageData = row.Cells["ImageData"].Value as byte[];
            DisplayImage(_currentImageData);
        }

        private void RefreshGrid()
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = _dbContext.GetAllStudents();
            if (dgvStudents.Columns["ImageData"] != null)
                dgvStudents.Columns["ImageData"].Visible = false;
        }

        private void ClearFields()
        {
            txtId.Clear(); txtName.Clear(); txtClass.Clear(); txtAge.Clear();
            picStudent.Image = null; _currentImageData = null;
        }
    }
}