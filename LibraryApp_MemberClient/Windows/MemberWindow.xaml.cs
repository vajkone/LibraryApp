using LibraryApp_Common.Models;
using LibraryApp_MemberClient.DataProviders;
using LibraryApp_MemberClient.Models;
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
        private static IList<LoanBook> _loanedBooks;
        private static IList<Book> _libraryBooks;
        private static Member _currentMember;
        private static IList<LoanBookInfo> _loanBookInfos;




        public MemberWindow(Member member)
        {
            _currentMember = member;
            InitializeComponent();
            WelcomeLabel.Content = "Welcome " + member.FirstName +" " +member.LastName+"!";
            UpdateMemberBookList();
            UpdateLibraryBookList();
        }

        private void UpdateMemberBookList()
        {
            _loanedBooks = BookDataProvider.GetBooksOfMember(_currentMember.MemberId);
            _loanBookInfos = new List<LoanBookInfo>();
            
            foreach (var item in _loanedBooks)
            {
                LoanBookInfo lbinf = new LoanBookInfo();
                lbinf.LoanDate = item.LoanDate;
                lbinf.ReturnDate = item.ReturnDate;
                Book book = BookDataProvider.GetBookByInvNum(item.LB_InventoryNumber);
                lbinf.Title = book.Title;
                lbinf.ISBN = book.ISBN;
                lbinf.Pages = book.Pages;
                lbinf.Genre = book.Genre;
                lbinf.Publisher = book.Publisher;
                lbinf.ReleaseDate = book.ReleaseDate;
                Author author = BookDataProvider.GetBookAuthor(book.BookId);
                lbinf.Author = author;
                _loanBookInfos.Add(lbinf);
            }


            BooksLoanedList.ItemsSource = _loanBookInfos;
        }

        private void CheckInfoButton_Click(object sender, RoutedEventArgs e)
        {
            LoanBookInfo selected = BooksLoanedList.SelectedItem as LoanBookInfo;

            var window = new MemberBookInfoWindow(selected);
            window.ShowDialog();


        }

        private void BookSelected(object sender, SelectionChangedEventArgs e)
        {
            if (BooksLoanedList.SelectedIndex>-1)
            {
                CheckInfoButton.Visibility = Visibility.Visible;
            }
            
        }

        private void UpdateLibraryBookList()
        {
            _libraryBooks = BookDataProvider.GetBooks();
            LibraryBooksList.ItemsSource = _libraryBooks;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string title; string author;

            if (string.IsNullOrEmpty(SearchByTitleTextBox.Text) && string.IsNullOrEmpty(SearchByAuthorTextBox.Text))
            {
                UpdateLibraryBookList();
            }

            if (!string.IsNullOrEmpty(SearchByTitleTextBox.Text))
            {
                title = SearchByTitleTextBox.Text;
                _libraryBooks = BookDataProvider.GetBooksByTitle(title);
                LibraryBooksList.ItemsSource = _libraryBooks;
            }
        }
    }
}
