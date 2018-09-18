using DatabaseActivities.Models;
using DatabaseActivities.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DatabaseActivities.Repository
{
    public class NoteRepository
    {
        private ApplicationDbContext context;
        public NoteRepository()
        {
            context = new ApplicationDbContext();
        }
        public List<NoteModel> GetAllNotes()
        {
            return context.Notes.Include(n => n.StudentName).ToList();
        }
        public NoteModel GetNoteById(int id)
        {
            return context.Notes.Include(n => n.StudentName).SingleOrDefault(n => n.Id == id);
        }
        public void Add(NoteModel toAdd)
        {
            context.Notes.Add(toAdd);
        }
        public void Edit(NoteModel toEdit)
        {
            context.Entry(toEdit).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}