using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
    public class Grade
    {
        public int Id { get; private set; }
        public int Gradenumber { get; private set; }
        public int StudentId { get; private set; }
        public int TeacherId { get; private set; }
        public int LessonId { get; private set; }
        public Grade(int id, int grade, int studentid , int teacherid, int lessonid)
        {
            this.Id = id;
           this.Gradenumber = grade;
           this.StudentId = studentid;
           this.TeacherId = teacherid;
            this.LessonId = lessonid;
        }
     
    }
   
}
