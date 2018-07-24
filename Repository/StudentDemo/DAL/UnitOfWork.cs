using StudentDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentDemo.DAL
{
    public class UnitOfWork : IDisposable
    {
        //Part 1
        private RepositoryContext context = new RepositoryContext();
        private GenericRepository<Faculity> faculityRepository;
        private GenericRepository<Student> studentRepository;

        public GenericRepository<Faculity> FaculityRepository
        {
            get
            {
                if (this.faculityRepository == null)
                {
                    this.faculityRepository = new GenericRepository<Faculity>(context);
                }
                return this.faculityRepository;
            }
        }
        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this.faculityRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return this.studentRepository;
            }
        }
        // Part 2

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}