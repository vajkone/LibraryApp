using LibraryApp_ClerkClient.DataProviders;
using LibraryApp_ClerkClient.Windows;
using LibraryApp_Common.Models;
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

namespace LibraryApp_ClerkClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IList<Book> _books;
        private IList<Member> _members;
        public MainWindow()
        {
            InitializeComponent();
            UpdateBooks();
            UpdateMembers();
            SeeBookInformationButton.Visibility = Visibility.Collapsed;

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddBookWindow();

            if (window.ShowDialog() ?? false)
            {
                UpdateBooks();
                libraryBookList.UnselectAll();
                SeeBookInformationButton.Visibility = Visibility.Collapsed;
                CheckBorroweBooksButton.Visibility = Visibility.Collapsed;
            }
        }


        private void UpdateBooks()
        {
            _books = BookDataProvider.GetBooks();
            libraryBookList.ItemsSource = _books;
        }

        private void UpdateMembers()
        {
            _members = MemberDataProvider.GetMembers();
            libraryMemberList.ItemsSource = _members;
        }

        private void RegisterMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterMemberWindow(null);

            if (window.ShowDialog() ?? false)
            {
                UpdateBooks();
                UpdateMembers();
                libraryBookList.UnselectAll();
                CheckBorroweBooksButton.Visibility = Visibility.Collapsed;
                SeeBookInformationButton.Visibility = Visibility.Collapsed;

            }
        }

        private void SeeBookInformationButton_Click(object sender, RoutedEventArgs e)
        {

            var selectedbook = libraryBookList.SelectedItem as Book;
            var window = new BookInformationWindow(selectedbook);

            if (window.ShowDialog() ?? false)
            {
                UpdateBooks();
                libraryBookList.UnselectAll();

            }

        }

        private void libraryBookList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (libraryBookList.SelectedIndex > -1)
            {
                SeeBookInformationButton.Visibility = Visibility.Visible;
            }
        }

        
        
        private void BookList_LostFocus(object sender, RoutedEventArgs e)
        {
           // SeeBookInformationButton.Visibility = Visibility.Collapsed;
        }
        

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string title; string author; string isbn;

            if (string.IsNullOrEmpty(SearchByTitleTextBox.Text))
            {
                UpdateBooks();
            }

            if (!string.IsNullOrEmpty(SearchByTitleTextBox.Text))
            {
                title = SearchByTitleTextBox.Text;
                _books=BookDataProvider.GetBooksByTitle(title);
                libraryBookList.ItemsSource = _books;
            }

            

        }

        private void MemberSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchMemberTextBox.Text))
            {
                UpdateMembers();
            }
            else
            {
                string searchsting= SearchMemberTextBox.Text;
                _members = MemberDataProvider.GetMembersByName(searchsting);
                libraryMemberList.ItemsSource = _members;
            }

        }

        private void CheckBorroweBooksButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMember = libraryMemberList.SelectedItem as Member;
            var window = new MemberBorrowedBooksWindow(selectedMember);

            window.ShowDialog();
        }

        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (libraryMemberList.SelectedIndex > -1)
            {
                CheckBorroweBooksButton.Visibility = Visibility.Visible;

            }
        }
    }
}
