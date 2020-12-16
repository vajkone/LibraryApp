using LibraryApp_Common.Models;
using LibraryApp_MemberClient.DataProviders;
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

namespace LibraryApp_MemberClient.Windows
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        private static IList<Book> _loanedBooks;
        private static Member _currentMember;
        public MemberWindow(Member member)
        {
            _currentMember = member;
            InitializeComponent();
            WelcomeLabel.Content = "Welcome " + member.FirstName +" " +member.LastName+"!";
            UpdateBookList();
        }

        private void UpdateBookList()
        {
            _loanedBooks = BookDataProvider.GetBooksOfMember(_currentMember.MemberId);
            BooksLoanedList.ItemsSource = _loanedBooks;
        }
    }
}
