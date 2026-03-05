
namespace StudentRegistrationApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.PictureBox picStudent;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnBrowse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // ----------------- Controls -----------------
            txtId = new System.Windows.Forms.TextBox();
            txtName = new System.Windows.Forms.TextBox();
            txtAge = new System.Windows.Forms.TextBox();
            txtClass = new System.Windows.Forms.TextBox();
            picStudent = new System.Windows.Forms.PictureBox();
            dgvStudents = new System.Windows.Forms.DataGridView();
            btnAdd = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnBrowse = new System.Windows.Forms.Button();

            // ----------------- Panel for Inputs -----------------
            System.Windows.Forms.Panel panelInputs = new System.Windows.Forms.Panel();
            panelInputs.Location = new System.Drawing.Point(10, 10);
            panelInputs.Size = new System.Drawing.Size(300, 400);
            panelInputs.BackColor = System.Drawing.Color.LightGray;

            // TextBoxes
            txtId.Location = new System.Drawing.Point(20, 20);
            txtId.Width = 250;
            txtId.PlaceholderText = "Student ID";

            txtName.Location = new System.Drawing.Point(20, 60);
            txtName.Width = 250;
            txtName.PlaceholderText = "Name";

            txtAge.Location = new System.Drawing.Point(20, 100);
            txtAge.Width = 250;
            txtAge.PlaceholderText = "Age";

            txtClass.Location = new System.Drawing.Point(20, 140);
            txtClass.Width = 250;
            txtClass.PlaceholderText = "Class";

            // PictureBox
            picStudent.Location = new System.Drawing.Point(50, 180);
            picStudent.Size = new System.Drawing.Size(200, 150);
            picStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            picStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // Buttons
            btnAdd.Location = new System.Drawing.Point(20, 340);
            btnAdd.Size = new System.Drawing.Size(60, 30);
            btnAdd.Text = "Add";
            btnAdd.BackColor = System.Drawing.Color.LightBlue;

            btnUpdate.Location = new System.Drawing.Point(90, 340);
            btnUpdate.Size = new System.Drawing.Size(60, 30);
            btnUpdate.Text = "Update";
            btnUpdate.BackColor = System.Drawing.Color.LightGreen;

            btnDelete.Location = new System.Drawing.Point(160, 340);
            btnDelete.Size = new System.Drawing.Size(60, 30);
            btnDelete.Text = "Delete";
            btnDelete.BackColor = System.Drawing.Color.OrangeRed;

            btnBrowse.Location = new System.Drawing.Point(230, 340);
            btnBrowse.Size = new System.Drawing.Size(60, 30);
            btnBrowse.Text = "Browse";
            btnBrowse.BackColor = System.Drawing.Color.LightYellow;

            // Add controls to panel
            panelInputs.Controls.Add(txtId);
            panelInputs.Controls.Add(txtName);
            panelInputs.Controls.Add(txtAge);
            panelInputs.Controls.Add(txtClass);
            panelInputs.Controls.Add(picStudent);
            panelInputs.Controls.Add(btnAdd);
            panelInputs.Controls.Add(btnUpdate);
            panelInputs.Controls.Add(btnDelete);
            panelInputs.Controls.Add(btnBrowse);

            // DataGridView
            dgvStudents.Location = new System.Drawing.Point(320, 10);
            dgvStudents.Size = new System.Drawing.Size(550, 380);
            dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.RowTemplate.Height = 30;
            dgvStudents.BackgroundColor = System.Drawing.Color.WhiteSmoke;

            // Form
            this.ClientSize = new System.Drawing.Size(880, 420);
            this.Controls.Add(panelInputs);
            this.Controls.Add(dgvStudents);
            this.Text = "Student Registration App";
            this.BackColor = System.Drawing.Color.White;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}