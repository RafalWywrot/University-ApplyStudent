using ApplyStudent.Database;
using ApplyStudent.Service.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplyStudent.Service.Services
{
    public interface IStudentService
    {
        void AddStudent(StudentDTO studentDTO);
        List<StudentDTO> GetStudents();
    }
    public class StudentService : IStudentService
    {
        private UniversityDBContext _context;
        public StudentService(UniversityDBContext context)
        {
            _context = context;
        }

        public void AddStudent(StudentDTO studentDTO)
        {
            Student student = new Student()
            {
                Email = studentDTO.Email,
                Name = studentDTO.Name,
                Surname = studentDTO.Surname,
                Password = studentDTO.Password
            };
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<StudentDTO> GetStudents()
        {
            var students = _context.Students.ToList();
            var studentsDTO = new List<StudentDTO>();
            foreach (var student in students)
            {
                var studentDTO = new StudentDTO()
                {
                    Email = student.Email,
                    Name = student.Name,
                    Surname = student.Surname,
                    Password = student.Password
                };
                studentsDTO.Add(studentDTO);
            }
            return studentsDTO;
        }
    }
}
