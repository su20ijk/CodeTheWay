using DatabaseActivities.Models.Entity;
using DatabaseActivities.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Service
{
    public class NoteService
    {
        private NoteRepository Repository;
        public NoteService()
        {
            Repository = new NoteRepository();
        }
        public List<NoteModel> GetAllNotes()
        {
            return Repository.GetAllNotes();
        }
        public NoteModel GetNoteById(int id)
            {
            return Repository.GetNoteById(id);
            }
        public void AddNote(NoteModel toAdd)
        {
            Repository.Add(toAdd);
        }
        public void EditNote(NoteModel toEdit)
        {
            Repository.Edit(toEdit);
        }
    }
}