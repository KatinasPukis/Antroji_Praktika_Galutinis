using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
   public class LessonDB
    {
        private SqlConnection conn;

        public LessonDB()
        {
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
        }

    }
}
