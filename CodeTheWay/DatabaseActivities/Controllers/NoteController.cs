using DatabaseActivities.Enum;
using DatabaseActivities.Models.Entity;
using DatabaseActivities.Models.Wrappers;
using DatabaseActivities.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DatabaseActivities.Controllers
{
    public class NoteController : Controller
    {
        private NoteService noteService= new NoteService();
        private StudentService studentService= new StudentService();
        public ActionResult Index(int studentId, int? noteId, string viewName)
        {
            NoteWrapper wrapper = new NoteWrapper();
            wrapper.Student = studentService.GetStudentById(studentId);
            wrapper.View = viewName ?? PartialViewNavNames.StudentNote.Simple;
            wrapper.NoteId = noteId ?? wrapper.NoteId;
            return View(wrapper);
        }
        public ActionResult Card(int noteId, int studentId)
        {
            NoteWrapper wrap = new NoteWrapper();
            wrap.Student = studentService.GetStudentById(studentId);
            for (int i=0; i < wrap.Student.NoteList.Count; i++) 
            {
                if (wrap.Student.NoteList[i].Id == noteId)
                {
                    wrap.Index = i;
                }
            }
            return View(wrap);
        }
        public ActionResult NoteSimple(int studentId)
        {
            NoteWrapper wrap = new NoteWrapper();
            wrap.Student = studentService.GetStudentById(studentId);
            return View(wrap);
        }
        public ActionResult NoteEdit(int noteId)
        {
            NoteModel note = new NoteModel();
            note = noteService.GetNoteById(noteId);
            return View(note);
        }
        [HttpPost]
        public ActionResult SaveNote(int Id, string Note, int Rating, string Subject)
        {
            NoteModel note = this.noteService.GetNoteById(Id);
            note.Subject = Subject;
            note.Rating = Rating;
            note.Note = Note;
            this.noteService.EditNote(note);
            return RedirectToAction("Index", "Note", new { noteId = Id, studentId = note.StudentId, viewName = PartialViewNavNames.StudentNote.CardDetails });
        }
        public ActionResult NoteCreate(int studentId)
        {
            return View(studentService.GetStudentById(studentId));
        }
        [HttpPost]
        public ActionResult NoteCreation(NoteModel note)
        {
            note.CreationDate = DateTime.Now;
            StudentModel student = studentService.GetStudentById(note.StudentId);
            student.NoteList.Add(note);
            studentService.EditStuent(student);
            return RedirectToAction("Index", "Note", new { studentId = note.StudentId });
        }
    }
}