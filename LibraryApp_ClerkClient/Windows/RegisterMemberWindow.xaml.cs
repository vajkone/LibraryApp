﻿using LibraryApp_ClerkClient.DataProviders;
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
        public RegisterMemberWindow(Member member)
        {
            InitializeComponent();
            if (member!=null)
            {
                _member = member;
                FillOutFields();
            }
            else
            {
                RegisteredDateTextBox.Content = DateTime.Now.ToString();
            }
            
        }

        private void AddMemberButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateMember())
            {
                _member = new Member();
                _member.FirstName = FirstNameTextBox.Text.Trim();
                _member.LastName = LastNameTextBox.Text.Trim();
                _member.DateOfBirth = DobPicker.SelectedDate.Value;
                _member.RegistratioNDate = DateTime.Now;
                _member.Email = EmailTextBox.Text.Trim();
                _member.Address = AddressTextBox.Text.Trim();

                MemberDataProvider.CreateMember(_member);

               

                DialogResult = true;
                Close();

            }
        }

        private void FillOutFields()
        {
            TitleLabel.Content = "Checking information of member";
            ReigsterMemberButton.Visibility = Visibility.Collapsed;
            FirstNameTextBox.Text = _member.FirstName;
            LastNameTextBox.Text = _member.LastName;
            DobPicker.SelectedDate = _member.DateOfBirth;
            EmailTextBox.Text = _member.Email;
            AddressTextBox.Text = _member.Address;
            RegisteredDateTextBox.Content = _member.RegistratioNDate.ToString("g");


        }

        private bool ValidateMember()
        {
            if (string.IsNullOrWhiteSpace(FirstNameTextBox.Text))
            {
                MessageBox.Show("First name should not be empty");
                return false;
            }
           

            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text))
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
