using LibraryApp_Common.Models;
using LibraryApp_MemberClient.DataProviders;
using LibraryApp_MemberClient.Windows;
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

namespace LibraryApp_MemberClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static Member _member;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                var window = new MemberWindow(_member);
                MemberNameTextBox.Text = string.Empty;
                window.ShowDialog();
                

            }
        }

        private bool Validate()
        {
            if (!string.IsNullOrEmpty(MemberNameTextBox.Text))
            {
                _member = MemberClientDataProvider.GetMemberByFullName(MemberNameTextBox.Text);
                if (_member == null)
                {
                    MessageBox.Show("There is no registered member with that name. Please check the spelling" +
                        " or register first.");
                    return false;
                }
                else return true; ;
            }
            else
            {
                MessageBox.Show("Please provide your full name to sign in");
                return false;
            }
        }
    }
}
