using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;

namespace Students
{
    class XmlProcessing
    {
        XmlDocument xDoc;
        string fileName;

        public XmlProcessing()
        {
            xDoc = new XmlDocument();
        }

        public List<Student> Read(string fileName)
        {
            this.fileName = fileName;
            try
            {
                xDoc.Load(fileName);
            }
            catch (Exception ex)
            {
                StreamWriter textFile = new StreamWriter("Students.xml");
                textFile.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                textFile.WriteLine("<Students>");
                textFile.WriteLine("</Students>");
                textFile.Close();
                xDoc.Load(fileName);
            }
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.ChildNodes;

            List<Student> students = new List<Student>();

            for (int i = 0; i < nodes.Count; i++)
            {
                Student newStudent = new Student();

                if (nodes[i].Attributes.Count > 0)
                {
                    XmlNode attribut = nodes[i].Attributes.GetNamedItem("Id");
                    if (attribut != null)
                        newStudent.id = int.Parse(attribut.Value);
                }

                XmlNodeList childNodes = nodes[i].ChildNodes;
                for (int j = 0; j < childNodes.Count; j++)
                {
                    if (childNodes[j].Name == "FirstName")
                    {
                        newStudent.firstName = childNodes[j].InnerText;
                    }
                    else if (childNodes[j].Name == "Last")
                    {
                        newStudent.lastName = childNodes[j].InnerText;
                    }
                    else if (childNodes[j].Name == "Age")
                    {
                        newStudent.age = int.Parse(childNodes[j].InnerText);
                    }
                    else if (childNodes[j].Name == "Gender")
                    {
                        newStudent.gender = childNodes[j].InnerText;
                        if (newStudent.gender == "0")
                            newStudent.gender = "мужской";
                        else if (newStudent.gender == "1")
                            newStudent.gender = "женский";
                    }
                }
                students.Add(newStudent);
            }
            return students;
        }

        public void AddElement(Student currentStudent)
        {
            XmlElement newStudent = xDoc.CreateElement("Student");
            XmlAttribute Id = xDoc.CreateAttribute("Id");

            XmlElement firstNameElement = xDoc.CreateElement("FirstName");
            XmlElement lastNameElement = xDoc.CreateElement("Last");
            XmlElement ageElement = xDoc.CreateElement("Age");
            XmlElement genderElement = xDoc.CreateElement("Gender");

            XmlText IdText = xDoc.CreateTextNode(currentStudent.id.ToString());
            XmlText firstNameText = xDoc.CreateTextNode(currentStudent.firstName);
            XmlText lastNameText = xDoc.CreateTextNode(currentStudent.lastName);
            XmlText ageText = xDoc.CreateTextNode(currentStudent.age.ToString());
            if (currentStudent.gender == "мужской")
                currentStudent.gender = "0";
            else if (currentStudent.gender == "женский")
                currentStudent.gender = "1";
            XmlText genderText = xDoc.CreateTextNode(currentStudent.gender);

            Id.AppendChild(IdText);
            firstNameElement.AppendChild(firstNameText);
            lastNameElement.AppendChild(lastNameText);
            ageElement.AppendChild(ageText);
            genderElement.AppendChild(genderText);

            newStudent.Attributes.Append(Id);
            newStudent.AppendChild(firstNameElement);
            newStudent.AppendChild(lastNameElement);
            newStudent.AppendChild(ageElement);
            newStudent.AppendChild(genderElement);

            XmlElement xRoot = xDoc.DocumentElement;
            xRoot.AppendChild(newStudent);
            xDoc.Save(fileName);
        }

        public void Edit(Student currentStudent)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childNodes = xRoot.ChildNodes[currentStudent.id].ChildNodes;
            for (int j = 0; j < childNodes.Count; j++)
            {
                if (childNodes[j].Name == "FirstName")
                {
                    childNodes[j].InnerText = currentStudent.firstName;
                }
                else if (childNodes[j].Name == "Last")
                {
                    childNodes[j].InnerText = currentStudent.lastName;
                }
                else if (childNodes[j].Name == "Age")
                {
                    childNodes[j].InnerText = currentStudent.age.ToString();
                }
                else if (childNodes[j].Name == "Gender")
                {
                    if (currentStudent.gender == "мужской")
                        childNodes[j].InnerText = "0";
                    else if (currentStudent.gender == "женский")
                        childNodes[j].InnerText = "1";
                }
            }
            xDoc.Save("Students.xml");
        }

        public void Delete(int id)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList nodes = xRoot.ChildNodes;

            for (int i = id; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes.Count > 0)
                {
                    XmlNode attribut = nodes[i].Attributes.GetNamedItem("Id");
                    int currentId = int.Parse(attribut.Value);
                    if (currentId == id)
                    {
                        xRoot.RemoveChild(nodes[i]);
                        i--;
                    }
                    else if (currentId > id)
                    {
                        currentId--;
                        attribut.Value = currentId.ToString();
                    }
                }
            }
            xDoc.Save("Students.xml");
        }
    }
}
