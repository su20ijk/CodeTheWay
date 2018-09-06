using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseActivities.Models.Entity
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public List<NoteModel> NoteList { get; set; }
        public Double GetRating()
        {
            if (NoteList.Count == null)
            {
                return 0;
            }
            double Sum = NoteList.Sum(S => S.Rating);
            return Sum / NoteList.Count;
        }
    }
}