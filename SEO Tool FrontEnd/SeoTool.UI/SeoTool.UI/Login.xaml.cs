﻿using SeoTool.Data;
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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserRepository userRepo = new UserRepository();

        public Login()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void loginBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var loginTextBox = (TextBox)sender;
            if (loginTextBox.Text == "Login")
                loginTextBox.Text = "";
        }

        private void loginBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var loginTextBox = (TextBox)sender;
            if (loginTextBox.Text == "")
                loginTextBox.Text = "Login";
        }

        private void passwordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var passwordTextBox = (PasswordBox)sender;
            if (passwordTextBox.Password == "Password")
                passwordTextBox.Password = "";
        }

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var passwordTextBox = (PasswordBox)sender;
            if (passwordTextBox.Password == "")
                passwordTextBox.Password = "Password";
        }
    }
}
