﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string GroupName { get; private set; }

        public Student(int id, string name, string surname, string groupname)
        {
            Id = id;
            Name = name;
            Surname = surname;
            GroupName = groupname;
        }
    }
}
