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
    /// Логика взаимодействия для AddAddress.xaml
    /// </summary>
    public partial class AddAddress : Page
    {
        public address address = new address();
        public AddAddress(address selectAddress)
        {
            InitializeComponent();
            boxFirstName.ItemsSource = Entity.GetContext().clients.ToList();
            if (selectAddress != null)
            {
                address = selectAddress;
            }
            DataContext = address;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(address.Id == 0)
            {
                Entity.GetContext().address.Add(address);
            }

            try
            {
                Entity.GetContext().SaveChanges();
                MessageBox.Show("Изменения сохранены!");
                Manager.frame.GoBack();
            }
            catch
            {
                MessageBox.Show("Изменения не сохранены!");
            }
            
            
            
        }
    }
}
