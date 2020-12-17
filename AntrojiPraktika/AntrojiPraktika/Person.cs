using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntrojiPraktika
{
    public class Person // Sukuriama nauja klase 
    {
        protected string Name; //Vardas
        protected string Surname; // Pavarde
        protected DateTime BirthDate;

        public Person(string name, string surname, DateTime birthDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new Exception("Vardas tuscias");
            if (string.IsNullOrWhiteSpace(surname))
                throw new Exception("pavarde tuscia");
            if (birthDate > DateTime.Now)
                throw new Exception("Neteisingi metai");
            Name = name;
            Surname = surname;
            BirthDate = birthDate;

        }
        public string GetFullName()
        {
            return Name + " " + Surname;
        }
        public string GetFullInfo()
        {
            return $"{GetFullName()}: Amzius = {GetAge()}";
        }
        public int GetAge()
        {
            return (int)((DateTime.Now - BirthDate).TotalDays / 365);
        }
        public DateTime GetBirthDate()
        {
            return BirthDate;
        }
        public int GetBirthday()
        {
            DateTime today = DateTime.Today;
            DateTime next = new DateTime(today.Year, BirthDate.Month, BirthDate.Day);

            if (next < today)
                next = next.AddYears(1);

            int numDays = (next - today).Days;
            return (int)(numDays);

        }

        public string GetName()
        {
            return Name;

        }
        public string GetSurname()
        {
            return Surname;
        }


    }
}
