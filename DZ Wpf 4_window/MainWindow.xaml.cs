using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.ComponentModel;

namespace DZ_Wpf_4_window
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<ToDo> toDoList;
        public List<ToDo> ToDoList
        {
            get { return toDoList; }
            set { toDoList = value;
                OnPropertyChange();
            }
        }
        public int CountDone { get; set; }






        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            toDoList = new List<ToDo>();

            toDoList.Add(new ToDo("Родиться", new DateTime(2024, 01, 10), "Важно!"));
            toDoList.Add(new ToDo("Посадить сына", new DateTime(2024, 01, 11), "Важно!!"));
            toDoList.Add(new ToDo("Построить дерево", new DateTime(2024, 01, 13), "Важно!!!"));
            toDoList.Add(new ToDo("Вырастить дом", new DateTime(2024, 01, 13), "Важно!!!!"));
            toDoList.Add(new ToDo("Умереть", new DateTime(2024, 01, 15), "Важно!!!!!"));
            
            ListToDo.ItemsSource = toDoList;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange()
        {
            CountDone = ToDoList.Where(e=>e.Doing==true).ToList().Count;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TodoList"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CountDone"));
        }





        public void DeleteJob(object sender, RoutedEventArgs e)
        {
            toDoList.Remove(ListToDo.SelectedItem as ToDo);
            ListToDo.ItemsSource = null;
            ListToDo.ItemsSource = toDoList;
            OnPropertyChange();
        }

        
        private void OpenWindow(object sender, RoutedEventArgs e)
        {
            WindowAddToDo windowAddToDo = new WindowAddToDo();
            windowAddToDo.Owner = this;
            windowAddToDo.Show();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(ListToDo.SelectedItem != null) 
            {
                (ListToDo.SelectedItem as ToDo).Doing = true;
                OnPropertyChange();
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ListToDo.SelectedItem != null)
            {
                (ListToDo.SelectedItem as ToDo).Doing = false;
                OnPropertyChange();
            }
        }




    }
}