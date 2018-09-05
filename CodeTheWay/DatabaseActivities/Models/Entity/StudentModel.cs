using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Models.Entity
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public List<NoteModel> NoteList { get; set; }
        public Double GetRating()
        {
            double Sum = NoteList.Sum(S => S.Rating);
            return Sum / NoteList.Count;
        }
    }
}