using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Students
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentBase studentBase;
        bool listBoxEmpty = true;

        public MainWindow()
        {
            InitializeComponent();

            studentBase = new StudentBase("Students.xml");
            UpdateListBoxItems();
            listBox.Focus();
        }

        private void UpdateListBoxItems()
        {
            listBox.Items.Clear();
            if (studentBase.ActualCount() == 0)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = "Список пуст.";
                item.HorizontalAlignment = HorizontalAlignment.Left;
                listBox.Items.Add(item);
                listBoxEmpty = true;
            }
            for (int i = 0; i < studentBase.ActualCount(); i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = studentBase.Get(i);
                item.HorizontalAlignment = HorizontalAlignment.Left;
                if (i % 2 == 1)
                {
                    item.Foreground = Brushes.DarkGray;
                    item.Background = Brushes.LightGray;
                }
                listBox.Items.Add(item);
                listBoxEmpty = false;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            EditingStudentDataWindow editingWindow = new EditingStudentDataWindow();
            if (listBoxEmpty)
                studentBase.Add(editingWindow.Add(0));
            else
                studentBase.Add(editingWindow.Add(listBox.Items.Count));
            UpdateListBoxItems();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEmpty)
                return;
            var selectedItemsList = listBox.SelectedItems;
            for (int i = 0; i < selectedItemsList.Count; i++)
            {              
                EditingStudentDataWindow editingWindow = new EditingStudentDataWindow();
                studentBase.Edit(editingWindow.Edit(studentBase.Get((string)((ListBoxItem)selectedItemsList[i]).Content)));
            }
            UpdateListBoxItems();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEmpty)
                return;
            var selectedItemsList = listBox.SelectedItems;
            if (selectedItemsList.Count == 0)
            {
                MessageBox.Show("Ошибка! Ни одна запись не выбрана.", "Ошибка", MessageBoxButton.OK);
                return;
            }
            MessageBoxResult pressButton = MessageBox.Show("Вы действительно хотите удалить выбранный(-ые) элемент(-ы)?", "Подтверждение удаления", MessageBoxButton.YesNo);
            if (pressButton == MessageBoxResult.Yes)
            {
                for (int i = 0; i < selectedItemsList.Count; i++)
                {
                    studentBase.Delete((string)((ListBoxItem)selectedItemsList[i]).Content);
                    listBox.Items.Remove((ListBoxItem)selectedItemsList[i]);
                    i--;
                }
                UpdateListBoxItems();
            }
            else
                listBox.SelectedIndex = -1;
        }
    }
}
