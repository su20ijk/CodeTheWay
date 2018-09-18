using DatabaseActivities.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Models.Wrappers
{
    public class NoteWrapper
    {
        public int Index { get; set; }
        public StudentModel Student { get; set; }
        public string View { get; set; }
        public int NoteId { get; set; } = -1;
    }
}