using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Teacherid { get; private set; }
        public Course(int id, string name , int teacherid)
        {
            Id = id;
            Name = name;
            Teacherid = teacherid;
        }
    }
}
