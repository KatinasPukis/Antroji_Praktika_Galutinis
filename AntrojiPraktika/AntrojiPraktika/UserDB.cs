using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using AntrojiPraktika.Backend.Models;

namespace AntrojiPraktika
{
    public class UserDB
    {
        private static List<User> usersList;
        private SqlConnection conn;
        public List<User> GetUserList()
        {
            return usersList;
        }
        public UserDB()
        {
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            if (usersList == null)
            {
                usersList = new List<User>();

            }

        }
        public void Register(User user)
        {

            try
            {
                string sql = " insert into Users(name,surname,birthdate,username,password,type,groupname)" + "values(@name, @surname,@birthdate,@username, @password,@type,@groupname)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", user.GetName());
                cmd.Parameters.AddWithValue("@surname", user.GetSurname());
                cmd.Parameters.AddWithValue("@birthdate", user.GetBirthDate());
                cmd.Parameters.AddWithValue("@username", user.GetUsername());
                cmd.Parameters.AddWithValue("@password", user.GetPassword());
                cmd.Parameters.AddWithValue("@type", user.GetUserType());
                cmd.Parameters.AddWithValue("@groupname", user.GetGroupName());
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public User Login(string username, string password)
        {

            try
            {
                string sql = "select userid, name, surname, birthdate, username, password, type, groupname from Users " +
                    "where username=@username and password=@password";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int userid = int.Parse(reader["userID"].ToString());
                        string name = reader["name"].ToString();
                        string surname = reader["surname"].ToString();
                        DateTime date = DateTime.Parse(reader["birthdate"].ToString());
                        string usrname = reader["username"].ToString();
                        string type = reader["type"].ToString();
                        string group = reader["groupname"].ToString();

                        return new User(userid, name, surname, date, usrname, password, type, group);
                    }
                }
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            throw new Exception("Blogi duomenys");

        }
        public void RemoveUser(int id)
        {

            string sql = "delete from Users where userid=@userid";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userid", id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }
        public void InsertUserImage(string imagepath, int userID)
        {
            string sql = " UPDATE Users SET Picture=@Picture WHERE userID=@userID";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userID", userID);
            cmd.Parameters.AddWithValue("@Picture", imagepath);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public string GetUserNameByID(int userid)
        {
            string username = null;
            string sql = "select username from Users where userid=@userid";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@userID", userid);
            conn.Open();
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    username = dataReader["username"].ToString();
                }
            }
            conn.Close();
            return username;
        }
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            try
            {
                string sql = "select userid, name, surname, birthdate, username, password, type, groupname from users";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int userid = int.Parse(reader["userID"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    DateTime date = DateTime.Parse(reader["birthdate"].ToString());
                    string usrname = reader["username"].ToString();
                    string password = reader["password"].ToString();
                    string type = reader["type"].ToString();
                    string group = reader["groupname"].ToString();
                    userList.Add(new User(userid, name, surname, date, usrname, password, type, group));
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }


            return usersList;
        }
        public List<Teacher> GetTeacher()
        {
            List<Teacher> teacherlist = new List<Teacher>();
            try
            {
                string sql = "select id, name, surname from teacher";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    teacherlist.Add(new Teacher(id, name, surname));
                    
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return teacherlist;
        }
        public List<Student> GetStudent()
        {
            List<Student> studentlist = new List<Student>();
            try
            {
                string sql = "select id, name, surname, groupname from student";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    string surname = reader["surname"].ToString();
                    string group = reader["groupname"].ToString();
                    studentlist.Add(new Student(id, name, surname,group));

                    
                    
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return studentlist;
        }
        public void AddNewStudent( string name, string surname, string group)
        {
            try
            {
                string sql = " insert into student(name,surname,groupname)" + "values(@name, @surname, @groupname)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@groupname", group);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public void AddNewTeacher(string name, string surname)
        {
            try
            {
                string sql = " insert into teacher(name,surname)" + "values(@name, @surname)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public List<Group> GetGroup()
        {
            List<Group> grouplist = new List<Group>();
            try
            {
                string sql = "select id, name from groupname";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int groupid = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    
                    
                        grouplist.Add(new Group(groupid, name));

                   
                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return grouplist;
        }
        public void AddNewCourse(string name, int teacherid)
        {
            try
            {
                string sql = " insert into course(name, teacherid)" + "values(@name, @teacherid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@teacherid", teacherid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public void AddNewLesson(int teacherid, int groupid, int courseid)
        {
            try
            {
                string sql = " insert into lesson(teacherid,groupid,courseid)" + "values(@teacherid, @groupid, @courseid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@teacherid", teacherid);
                cmd.Parameters.AddWithValue("@groupid", groupid);
                cmd.Parameters.AddWithValue("@courseid", courseid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
           


        }
        public void ChangeGrade(int grade, int studentid, int teacherid, int lessonid)
        {
            try
            {
                string sql = " UPDATE grade SET grade=@grade WHERE studentid=@studentid AND lessonid=@lessonid AND teacherid=@teacherid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@studentid", studentid);
                cmd.Parameters.AddWithValue("@lessonid", lessonid);
                cmd.Parameters.AddWithValue("@teacherid", teacherid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            


        }
        public void AddNewGrade(int grade, int studentid, int teacherid, int lessonid)
        {
            try
            {
                string sql = " insert into grade(grade,studentid,teacherid,lessonid)" + "values(@grade, @studentid, @teacherid, @lessonid)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@grade", grade);
                cmd.Parameters.AddWithValue("@studentid", studentid);
                cmd.Parameters.AddWithValue("@teacherid", teacherid);
                cmd.Parameters.AddWithValue("@lessonid", lessonid);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public void AddNewGroup(string name)
        {
            try
            {
                string sql = " insert into groupname(name)" + "values(@name)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
        public List<Lesson> Getlesson()
         {
             List<Lesson> lessonlist = new List<Lesson>();
             try
             {
                 string sql = "select id, teacherid, groupid, courseid from lesson";
                 SqlCommand cmd = new SqlCommand(sql, conn);
                 conn.Open();
                 SqlDataReader reader = cmd.ExecuteReader();

                 while (reader.Read())
                 {
                     int lessonid = int.Parse(reader["id"].ToString());
                     int teacherid = int.Parse(reader["teacherid"].ToString());
                     int groupid = int.Parse(reader["groupid"].ToString());
                     int courseid = int.Parse(reader["courseid"].ToString());

                     lessonlist.Add(new Lesson(lessonid,teacherid,groupid, courseid));


                 }

                 conn.Close();
             }
             catch (Exception exc)
             {
                 Debug.WriteLine(exc.Message);
             }

             return lessonlist;
         }
        
        public List<Grade> GetGrade()
        {
            List<Grade> gradelist = new List<Grade>();
            try
            {
                string sql = "select id, grade, studentid, teacherid, lessonid from grade";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    int grade = int.Parse(reader["grade"].ToString());
                    int studentid = int.Parse(reader["studentid"].ToString());
                    int teacherid = int.Parse(reader["teacherid"].ToString());
                    int lessonid = int.Parse(reader["lessonid"].ToString());

                    gradelist.Add(new Grade(id,grade,studentid,teacherid,lessonid));


                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return gradelist;
        }
        public List<Course> GetCourse()
        {
            List<Course> courselist = new List<Course>();
            try
            {
                string sql = "select id, name, teacherid from course";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = int.Parse(reader["id"].ToString());
                    string name = reader["name"].ToString();
                    int teacherid = int.Parse(reader["teacherid"].ToString());

                    courselist.Add(new Course(id, name, teacherid));


                }

                conn.Close();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc.Message);
            }

            return courselist;
        }
        public void RemoveStudent(int Id , string name , string surname)
        {
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql3 = "delete from grade  WHERE studentid=@studentid";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            cmd3.Parameters.AddWithValue("@studentid", Id);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql = "delete from student where id=@id ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql2 = "delete from users where name=@name AND surname=@surname ";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@surname", surname);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

            
        }
        public void RemoveGroup(int Id, string groupname)
        {
            try
            {
                string sql2 = " UPDATE student SET groupname=' ' WHERE groupname=@groupname";

                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@groupname", groupname);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            try
            {
                string sql2 = " UPDATE users SET groupname=' ' WHERE groupname=@groupname";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@groupname", groupname);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
         
            try
            {
                string sql2 = " delete from lesson where groupid=@groupid ";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@groupid", Id);
                conn.Open();
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql = "delete from groupname where id=@id ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
        public void RemoveLesson(int Id , int courseid )
        {
            
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql1 = "delete from lesson where id=@id ";
            SqlCommand cmd1 = new SqlCommand(sql1, conn);
            cmd1.Parameters.AddWithValue("@id", Id);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql2 = "delete from course where id=@id ";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@id", courseid);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();

        }
        public void RemoveTeacher(int Id, string name, string surname)
        {
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql3 = "delete from lesson  WHERE teacherid=@teacherid";
            SqlCommand cmd3 = new SqlCommand(sql3, conn);
            cmd3.Parameters.AddWithValue("@teacherid", Id);
            conn.Open();
            cmd3.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql4 = "delete from course  WHERE teacherid=@teacherid";
            SqlCommand cmd4 = new SqlCommand(sql4, conn);
            cmd4.Parameters.AddWithValue("@teacherid", Id);
            conn.Open();
            cmd4.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql5 = "delete from grade  WHERE teacherid=@teacherid";
            SqlCommand cmd5 = new SqlCommand(sql5, conn);
            cmd5.Parameters.AddWithValue("@teacherid", Id);
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();
            try
            {
                string sql1 = " UPDATE course SET teacherid=null WHERE teacherid=@teacherid";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@teacherid", Id);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql = "delete from teacher where id=@id ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", Id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            conn = new SqlConnection(@"Server=.;Database=AcademicDB;Trusted_Connection=true;");
            string sql2 = "delete from users where name=@name AND surname=@surname ";
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            cmd2.Parameters.AddWithValue("@name", name);
            cmd2.Parameters.AddWithValue("@surname", surname);
            conn.Open();
            cmd2.ExecuteNonQuery();
            conn.Close();


        }



    }
}
