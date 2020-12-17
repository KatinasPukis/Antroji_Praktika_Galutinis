﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
    public class Teacher 
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public Teacher(int id , string name, string surname) 
        {
            Id = id;
            Name = name;
            Surname = surname;
           
        }

    }
}
