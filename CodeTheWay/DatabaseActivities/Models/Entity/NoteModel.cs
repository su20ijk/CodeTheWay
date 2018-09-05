using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Models.Entity
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public String Note { get; set; }
        public StudentModel StudentName { get; set; }
    }
}