using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
    public class Lesson
    {
        public int Id { get; private set; }
        public int Teacherid { get; private set; }
        public int Groupid { get; private set; }
        public int Courseid { get; private set; }
        public Lesson(int id, int teacherid, int groupid, int courseid)
        {
            Id = id;
            Teacherid = teacherid;
            Groupid = groupid;
            Courseid = courseid;

        }
    }
}
