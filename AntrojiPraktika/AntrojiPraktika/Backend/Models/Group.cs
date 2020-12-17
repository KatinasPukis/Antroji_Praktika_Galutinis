using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika.Backend.Models
{
   public class Group
    { 
        public int Id { get; private set; }
        public string GroupName { get; private set; }
        public Group(int id, string groupname)
        {
            Id = id;
            GroupName = groupname;
        }
    }
}
