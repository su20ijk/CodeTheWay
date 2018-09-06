using DatabaseActivities.Models;
using DatabaseActivities.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Repository
{
    public class StudentRepository
    {
        private ApplicationDbContext context;
        public StudentRepository()
        {
            context = new ApplicationDbContext();
        }
        public List<StudentModel> GetAllStudents()
        {
            return context.Students.ToList();
        }
        public StudentModel GetStudentById(int Id)
        {
            return context.Students.Find(Id);
        }
        public void EditStudent(StudentModel toSave)
        {
            context.Entry(toSave).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public void AddStudent(StudentModel toAdd)
        {
            context.Students.Add(toAdd);
            context.SaveChanges();
        }
    }
}