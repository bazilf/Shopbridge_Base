using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BAZIL.Controllers;
using BAZIL.EF;
using System.Web.Mvc;
using BAZIL.Models;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace BAZIL.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private StudentContext studentContext;
        public StudentController()
        {
            this.studentContext = new StudentContext();
            
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Create(Student student)
        {
            this.studentContext.Students.Add(student);
            this.studentContext.SaveChanges();
            return RedirectToAction("StudentList");

        }
        public ActionResult StudentList()
        {
            return View(studentContext.Students);
        }
        public ActionResult Edit(int id)
        {
            var student= studentContext.Students.Where(x=>x.Id == id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public  ActionResult Edit(Student student)
        {
            studentContext.Entry<Student>(student).State = System.Data.Entity.EntityState.Modified;
            studentContext.SaveChanges();
            return RedirectToAction("StudentList");
        }
        public ActionResult Details()
        {
            //ViewBag.Message = "Your Student and his/her Address Detail";
            return View();  
        }
        public ActionResult Delete(int id)
        {
            var student = studentContext.Students.Where(x => x.Id ==id).FirstOrDefault();
            return View(student);
        }
        [HttpPost]
        public ActionResult Delete(Student student)
        {
            var studentToDelete = studentContext.Students.Where(x => x.Id == student.Id).FirstOrDefault();
            studentContext.Students.Remove(studentToDelete);
            studentContext.SaveChanges();
            return RedirectToAction("StudentList");
        }
    }
}