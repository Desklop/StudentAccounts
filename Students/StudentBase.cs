using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Students
{
    class StudentBase
    {
        XmlProcessing xmlFile;
        List<Student> students;

        public StudentBase(string fileName)
        {
            xmlFile = new XmlProcessing();
            students = xmlFile.Read(fileName);
        }

        public void Add(Student currentStudent)
        {
            if (currentStudent.id == -1)
                return;
            students.Add(currentStudent);
            xmlFile.AddElement(currentStudent);
        }

        public string Get(int index)
        {
            return students[index].GetString();
        }

        public Student Get(string studentData)
        {
            int id = int.Parse(studentData.Substring(0, studentData.IndexOf('.'))) - 1;
            if (id >= students.Count)
                id = students.Count - 1;
            return students[id];
        }

        public void Edit(Student currentStudent)
        {
            students[currentStudent.id] = currentStudent;
            xmlFile.Edit(currentStudent);
        }

        public void Delete(string studentData)
        {
            int id = int.Parse(studentData.Substring(0, studentData.IndexOf('.'))) - 1;
            if (id >= students.Count)
                id = students.Count - 1;
            students.RemoveAt(id);
            for (int i = id; i < students.Count; i++)
            {
                Student currentStudent = students[i];
                currentStudent.id--;
                students[i] = currentStudent;
            }
            xmlFile.Delete(id);
        }

        public int ActualCount()
        {
            return students.Count;
        }
    }
}
