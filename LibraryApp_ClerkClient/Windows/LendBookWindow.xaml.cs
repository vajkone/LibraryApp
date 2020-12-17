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
    /// Interaction logic for LendBookWindow.xaml
    /// </summary>
    public partial class LendBookWindow : Window
    {

        private static IList<Member> _members;
        private static LibraryBook _currentbook;
        public LendBookWindow(LibraryBook selectedLibBook)
        {
            InitializeComponent();
            RefreshMembers();
            _currentbook = selectedLibBook;
            InventoryNumberTextBlock.Text = _currentbook.InventoryNumber;
            ReturnDatePicker.SelectedDate = DateTime.Now.AddDays(14);
        }

        private void MemberListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void RefreshMembers()
        {
            _members = MemberDataProvider.GetMembers();
            MemberListBox.ItemsSource = _members;
        }

        private void SearchMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var name = SearchMemberTextBox.Text;
            if (!string.IsNullOrWhiteSpace(name) && !("Search member").Equals(name))
            {
                _members = MemberDataProvider.GetMembersByName(name);
                MemberListBox.ItemsSource = _members;
            }
            else
            {
                RefreshMembers();
            }
        }

        private void LendBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (MemberListBox.SelectedIndex>-1)
            {
                
                if ((DateTime)ReturnDatePicker.SelectedDate<DateTime.Now)
                {
                    MessageBox.Show("Please select a proper return date");
                }
                else
                {
                    var selectedmember = MemberListBox.SelectedItem as Member;

                    LoanBook loanBook = new LoanBook();
                    loanBook.LB_InventoryNumber = _currentbook.InventoryNumber;
                    loanBook.LB_MemberId = selectedmember.MemberId;
                    loanBook.LoanDate = DateTime.Now;
                    loanBook.ReturnDate = (DateTime)ReturnDatePicker.SelectedDate;
                    LoanBookDataProvider.CreateLoanBook(loanBook);
                    LibraryBookDataProvider.LendReturnLibraryBook(_currentbook);

                    DialogResult = true;
                    Close();
                }



                

            }
        }
    }
}
