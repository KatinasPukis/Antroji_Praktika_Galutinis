using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika
{
    public class User : Person
    {
        protected int userId;
        protected string username;
        protected string password;
        protected string type;
        protected string groupname;

        public User(int userid, string name, string surname, DateTime birthDate, string username, string password, string type,string groupname ) : base(name, surname, birthDate)
        {
            this.userId = userid;
            this.username = username;
            this.password = password;
            this.groupname = groupname;
            this.type = type;
        }
        public string GetUsername()
        {
            return username;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetPassword(string password)
        {
            this.password = password;
        }
        public void SetUsername(string username)
        {
            this.username = username;
        }
        public string GetUserType()
        {
            return type;
        }
        public void SetUserType(string type)
        {
            this.type = type;
        }
        public int GetUserId()
        {
            return userId;
        }
        public string GetGroupName()
        {
            return groupname;
        }
        public void SetGroupName(string groupname)
        {
            this.groupname = groupname;
        }
    }
}
