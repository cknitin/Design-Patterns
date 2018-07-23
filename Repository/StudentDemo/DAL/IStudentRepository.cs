using StudentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace StudentDemo.DAL
{
    public interface IStudentRepository :IDisposable
    {
        Task<List<Student>> GetStudentList();
        Task<Student> GetStudentById(int? Id);
        void InsertStudent(Student student);
        void UpdateStudent(Student student);
        void Delete(int Id);
        void DeleteStudent(Student student);
        Task<int> Save();
    }
}