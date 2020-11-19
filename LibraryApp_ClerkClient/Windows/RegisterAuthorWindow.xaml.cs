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
    /// Interaction logic for RegisterAuthorWindow.xaml
    /// </summary>
    public partial class RegisterAuthorWindow : Window
    {
        private static Author _author;
        public RegisterAuthorWindow()
        {
            InitializeComponent();
            _author = new Author();
        }

        private void RegisterAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateAuthor())
            {
               
                _author.FirstName = FirstNameTextBox.Text;
                _author.LastName = LastNameTextBox.Text;
                _author.DateOfBirth = DobPicker.SelectedDate.Value;

                AuthorDataProvider.CreateAuthor(_author);

                DialogResult = true;
                Close();

            }
        }

        private bool ValidateAuthor()
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

            if (!DobPicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a birthdate");
                return false;
            }

            return true;
        }
    }
}
