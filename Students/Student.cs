using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public struct Student
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }

        public Student(int id, string firstName, string lastName, int age, string gender)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.gender = gender;
        }

        public string GetString()
        {
            string ageStr = age.ToString();
            string postfix = " лет";
            if (ageStr[1] == '1')
                postfix = " год";
            else if (ageStr[1] == '2' || ageStr[1] == '3' || ageStr[1] == '4')
                postfix = " года";
            return (id + 1).ToString() + ". " + firstName + " " + lastName + ", " + ageStr + postfix + ", " + gender;
        }
    }
}
