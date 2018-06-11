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
        }

        private void _NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            string address;
            address = SearchTextbox.Text;
            repo.RunCmdCommand(address);
        }

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
