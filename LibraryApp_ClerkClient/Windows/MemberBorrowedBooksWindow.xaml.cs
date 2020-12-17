using LibraryApp_ClerkClient.DataProviders;
using LibraryApp_Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for MemberBorrowedBooksWindow.xaml
    /// </summary>
    public partial class MemberBorrowedBooksWindow : Window
    {
        private static Member _currentMember;
        private static IList<LoanBook> _loanedBooks;
        private static IList<Book> _libraryBooks;
        
        private static IList<LoanBookInfo> _loanBookInfos;
        public MemberBorrowedBooksWindow(Member member)
        {
            
            InitializeComponent();
            _currentMember = member;
            UpdateMemberBookList();
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
            _loanBookInfos = _loanBookInfos.OrderBy(o => o.ReturnDate).ToList();


            BooksLoanedList.ItemsSource = _loanBookInfos;
        }

        private void MoreInfButton_Click(object sender, RoutedEventArgs e)
        {

            if (BooksLoanedList.SelectedIndex>-1)
            {
                LoanBookInfo selected = BooksLoanedList.SelectedItem as LoanBookInfo;

                var window = new MoreBorrowedBookInfoWindow(selected);
                window.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select the book you want more information on");
            }
            
        }
    }
}
