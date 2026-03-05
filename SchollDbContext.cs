
using System.Collections.Generic;
using System.Linq;

namespace StudentRegistrationApp
{
    public class SchoolDbContext
    {
        private List<Student> _students;

        public SchoolDbContext()
        {
            _students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public List<Student> GetAllStudents()
        {
            return _students.ToList();
        }

        public void UpdateStudent(Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.ClassName = updatedStudent.ClassName;
                student.Age = updatedStudent.Age;
                if (updatedStudent.ImageData != null)
                    student.ImageData = updatedStudent.ImageData;
            }
        }
        public void UpdateStudentWithImageCheck(Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == updatedStudent.Id);
            if (student != null)
            {
                student.Name = updatedStudent.Name;
                student.ClassName = updatedStudent.ClassName;
                student.Age = updatedStudent.Age;
                student.ImageData = updatedStudent.ImageData ?? student.ImageData;
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
                _students.Remove(student);
        }
    }
}