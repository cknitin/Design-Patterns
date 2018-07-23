using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDemo.Models;
using StudentDemo.DAL;

namespace StudentDemo.Controllers
{
    public class StudentController : Controller
    {
        //private StudentDemoContext db = new StudentDemoContext();

        private IStudentRepository studentRepository;
        private GenericRepository<Student> genericRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository(new RepositoryContext());
            this.genericRepository = new GenericRepository<Student>(new RepositoryContext());

        }

        // GET: Student
        public async Task<ActionResult> Index()
        {
            //return View(await db.Students.ToListAsync());
            return View(await studentRepository.GetStudentList());
            
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = await db.Students.FindAsync(id);

            //Student student = await studentRepository.GetStudentById(id);
            Student student =  genericRepository.GetById(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Students.Add(student);
                //await db.SaveChangesAsync();

                studentRepository.InsertStudent(student);
                await studentRepository.Save();

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = await db.Students.FindAsync(id);

            Student student = await studentRepository.GetStudentById(id);

            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Year")] Student student)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(student).State = EntityState.Modified;
                //await db.SaveChangesAsync();

                studentRepository.UpdateStudent(student);
                await studentRepository.Save();

                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Student student = await db.Students.FindAsync(id);

            Student student = await studentRepository.GetStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //Student student = await db.Students.FindAsync(id);
            //db.Students.Remove(student);
            //await db.SaveChangesAsync();

            Student student = await studentRepository.GetStudentById(id);
            studentRepository.DeleteStudent(student);
            await studentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                studentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
