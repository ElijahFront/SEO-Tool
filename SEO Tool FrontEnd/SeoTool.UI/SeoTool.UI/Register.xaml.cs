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
using System.Windows.Shapes;

namespace SeoTool.UI
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        UserRepository UsrRepo { get; set; }

        public Register()
        {
            InitializeComponent();
        }
        
        private void regButton_Click(object sender, RoutedEventArgs e)
        {
            var login = loginBox.Text;
            var email = emailBox.Text;
            var password = Hasher.GetHash(passwordBox.Password);

            var repo = new UserRepository();
            repo.NewMessage += ShowMessageBox;

            if (repo.AddUser(login, email, password))
            {
                var loginWindow = new Login();
                Close();
                loginWindow.ShowDialog();
            }
        }

        private void ShowMessageBox(string message, string name)
        {
            MessageBox.Show(message, name);
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new Login();
            Close();
            loginWindow.ShowDialog();
        }
    }
}
