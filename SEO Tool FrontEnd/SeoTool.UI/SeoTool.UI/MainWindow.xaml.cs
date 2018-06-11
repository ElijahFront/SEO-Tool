using SeoTool.Data;
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

namespace SeoTool.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainRepository repo = MainRepository.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            repo.OnBackEndError += HandleBackError;
            repo.OnDataLoaded += RenewItemsSource;
        }

        private void _NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        void RenewItemsSource()
        {
            
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            string address;
            address = SearchTextbox.Text;
            repo.RunCmdCommand(address);
        }
<<<<<<< HEAD

        private void SearchTextbox_GotFocus(object sender, RoutedEventArgs e)
        {
            var searchTextbox = (TextBox)sender;
            if (searchTextbox.Text == "Введите URL-адрес")
                searchTextbox.Text = "";
        }

        private void SearchTextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            var searchTextbox = (TextBox)sender;
            if (searchTextbox.Text == "")
                searchTextbox.Text = "Введите URL-адрес";
        }
    }
}
=======
        void HandleBackError(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
>>>>>>> 12db9fef968d05cb4b5aaf4b61c33709ad89fc80
