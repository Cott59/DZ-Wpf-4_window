using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace DZ_Wpf_4_window
{
    /// <summary>
    /// Логика взаимодействия для WindowAddToDo.xaml
    /// </summary>
    public partial class WindowAddToDo : Window
    {
        MainWindow main;
        public WindowAddToDo()
        {
            InitializeComponent();
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);
            MainWindow main = (this.Owner as MainWindow);
            this.main = main;


        }

        private void AddJob(object sender, RoutedEventArgs e)
        {

            (this.Owner as MainWindow).toDoList.Add(new ToDo(titleToDo.Text, dateToDo.SelectedDate.Value,
                descriptionToDo.Text));

            titleToDo.Text = "";
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 01, 10);

            (this.Owner as MainWindow).ListToDo.Items.Refresh();
            (this.Owner as MainWindow).OnPropertyChange();
            this.Close();
        }



    }
}
