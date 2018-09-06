using DatabaseActivities.Models.Entity;
using DatabaseActivities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Service
{
    public class StudentService
    {
        private StudentRepository repository;
        public StudentService()
        {
            repository = new StudentRepository();
        }
        public List<StudentModel> GetAllStudents()
        {
            return repository.GetAllStudents();
        }
        public StudentModel GetStudentById(int Id)
        {
            return repository.GetStudentById(Id);
        }
        public void AddStudent(StudentModel toAdd)
        {
            repository.AddStudent(toAdd);
        }
        public void EditStuent(StudentModel toSave)
        {
            repository.EditStudent(toSave);
        }
    }
}