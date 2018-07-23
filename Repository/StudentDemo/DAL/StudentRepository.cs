using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using StudentDemo.Models;

namespace StudentDemo.DAL
{
    public class StudentRepository : IStudentRepository , IDisposable
    {
        // Part 1
        private RepositoryContext _context;

        public StudentRepository(RepositoryContext context)
        {
            _context = context;
        }

        // Part 2
        public void Delete(int Id)
        {
           Student student = _context.Students.Find(Id);
            _context.Students.Remove(student);
        }

        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public Task<Student> GetStudentById(int? Id)
        {
            return _context.Students.FindAsync(Id);
        }

        public Task<List<Student>> GetStudentList()
        {
            return _context.Students.ToListAsync();
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
        }

        public Task<int> Save()
        {
            return _context.SaveChangesAsync();
        }

        public void UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        // Part 3

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}