using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Students
{
    /// <summary>
    /// Логика взаимодействия для EditingStudentDataWindow.xaml
    /// </summary>
    public partial class EditingStudentDataWindow : Window
    {
        Student currentStudent;
        int currentId;

        public EditingStudentDataWindow()
        {
            InitializeComponent();
            currentStudent = new Student(-1, "", "", -1, "");
            firstNameTextBox.Focus();
        }

        public Student Add(int id)
        {
            this.currentId = id;
            this.ShowDialog();
            return currentStudent;
        }

        public Student Edit(Student currentStudent)
        {
            currentId = currentStudent.id;
            firstNameTextBox.Text = currentStudent.firstName;
            lastNameTextBox.Text = currentStudent.lastName;
            ageTextBox.Text = currentStudent.age.ToString();
            genderTextBox.Text = currentStudent.gender;
            this.ShowDialog();
            return this.currentStudent;
        }

        //Если переключать поля мышкой и в конце нажать ОК
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string ageStr = ageTextBox.Text;
            string gender = genderTextBox.Text;
            if (firstName == "" || lastName == "" || gender == "")
            {
                MessageBox.Show("Ошибка! Не все обязательные поля заполнены.", "Ошибка", MessageBoxButton.OK);
                return;
            }
            int age = 0;
            if (ageStr != "")
            {
                try
                {
                    age = int.Parse(ageStr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка! Возраст нужно вводить числом.", "Ошибка", MessageBoxButton.OK);
                    ageTextBox.Clear();
                    return;
                }
                if (age <= 16 || age >= 100)
                {
                    MessageBox.Show("Ошибка! Возраст не может быть меньше 16 и больше 100 лет.", "Ошибка", MessageBoxButton.OK);
                    ageTextBox.Clear();
                    return;
                }
            }
            currentStudent = new Student(currentId, firstName, lastName, age, gender);
            this.Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            currentStudent = new Student(-1, "", "", -1, "");
            this.Close();
        }

        //Для удобства ввода: переход на новое поле по нажатию enter, а в конце - сохранение данных и закрытие окна
        private void firstNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (firstNameTextBox.Text == "")
                {
                    MessageBox.Show("Ошибка! Поле с именем не заполнено.", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                lastNameTextBox.Focus();
            }
        }

        private void lastNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.Enter)
            {
                if (lastNameTextBox.Text == "")
                {
                    MessageBox.Show("Ошибка! Поле с фамилией не заполнено.", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                ageTextBox.Focus();
            }
        }

        private void ageTextBox_KeyDown(object sender, KeyEventArgs e)
        {                       
            if (e.Key == Key.Enter)
            {
                int age = 0; 
                if (ageTextBox.Text != "")
                {
                    try
                    {
                        age = int.Parse(ageTextBox.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка! Возраст нужно вводить числом.", "Ошибка", MessageBoxButton.OK);
                        ageTextBox.Clear();
                        return;
                    }
                    if (age <= 16 || age >= 100)
                    {
                        MessageBox.Show("Ошибка! Возраст не может быть меньше 16 и больше 100 лет.", "Ошибка", MessageBoxButton.OK);
                        ageTextBox.Clear();
                        return;
                    }
                }
                genderTextBox.Focus();
            }
        }

        private void genderTextBox_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.Enter)
            {
                if (genderTextBox.Text == "")
                {
                    MessageBox.Show("Ошибка! Поле с полом не заполнено.", "Ошибка", MessageBoxButton.OK);
                    return;
                }
                currentStudent = new Student(currentId, firstNameTextBox.Text, lastNameTextBox.Text, int.Parse(ageTextBox.Text), genderTextBox.Text);
                this.Close();
            }
        }
    }
}
