using LibraryApp_ClerkClient.DataProviders;
using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryApp_ClerkClient.Windows
{
    /// <summary>
    /// Interaction logic for RegisterMemberWindow.xaml
    /// </summary>
    public partial class RegisterMemberWindow : Window
    {
        private Member _member;
        public RegisterMemberWindow()
        {
            InitializeComponent();
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMember())
            {
                _member = new Member();
                _member.FirstName = FirstNameTextBox.Text;
                _member.LastName = LastNameTextBox.Text;
                _member.DateOfBirth = DobPicker.SelectedDate.Value;
                _member.RegistratioNDate = DateTime.Now;
                _member.Email = EmailTextBox.Text;
                _member.Address = AddressTextBox.Text;

                MemberDataProvider.CreateMember(_member);

               

                DialogResult = true;
                Close();

            }
        }

        private bool ValidateMember()
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name should not be empty");
                return false;
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                MessageBox.Show("Last name should not be empty");
                return false;
            }

            if (string.IsNullOrEmpty(EmailTextBox.Text))
            {
                MessageBox.Show("Please provide an email address");
                return false;
            }

            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                MessageBox.Show("Please provide an address");
                return false;
            }

            if (!DobPicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a valid date");
                return false;
            }



            return true;
        }
    }
}
