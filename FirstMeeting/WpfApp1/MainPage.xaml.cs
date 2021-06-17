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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedRow = Grid.SelectedItems.Cast<address>().ToList();
            if(MessageBox.Show("Выдествительно хотите удалить выделенные записи?", " ", MessageBoxButton.YesNo)== MessageBoxResult.Yes)
            {
                Entity.GetContext().address.RemoveRange(selectedRow);
                Entity.GetContext().SaveChanges();
                Grid.ItemsSource = Entity.GetContext().address.ToList();
                MessageBox.Show("Записи удалены!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new AddAddress(null));
        }

        private void Grid_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Entity.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            Grid.ItemsSource = Entity.GetContext().address.ToList();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new AddAddress((sender as Button).DataContext as address));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Manager.frame.Navigate(new ClientPage((sender as Button).DataContext as address));
        }
    }
}
