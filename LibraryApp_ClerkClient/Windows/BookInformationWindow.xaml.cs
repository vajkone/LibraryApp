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
    /// Interaction logic for BookInformationWindow.xaml
    /// </summary>
    public partial class BookInformationWindow : Window
    {
        private static Book _currentbook;
        private static IList<LibraryBook> _librarybooks;
        public BookInformationWindow(Book selectedbook)
        {
            _currentbook = selectedbook;
            InitializeComponent();
            FillOutFields(selectedbook);
            UpdateLibraryBooks();
        }

        private void FillOutFields(Book selectedbook)
        {
            BookTitleTextBox.Text = selectedbook.Title;
            BookIsbnTextBox.Text = selectedbook.ISBN;
            PublisherTextBox.Text = selectedbook.Publisher;
            PublishDatePicker.SelectedDate = selectedbook.ReleaseDate;
            GenreTextBox.Text = selectedbook.Genre;
            PagesTextBox.Text = selectedbook.Pages.ToString();
            IList<Author> authors= AuthorDataProvider.GetAuthors();
            AuthorComboBox.ItemsSource = authors;
            var bookauthor = AuthorDataProvider.GetAuthorByBookId(selectedbook.BookId);
            AuthorComboBox.SelectedItem = bookauthor;
            AuthorComboBox.Text = bookauthor.ToString();

        }

        private void UpdateLibraryBooks()
        {
           // InventoryListBox.ItemsSource = LibraryBookDataProvider.GetLibraryBooks(_currentbook);
        }

        private void RegisterAuthorButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddNewCopyButton_Click(object sender, RoutedEventArgs e)
        {
            //ugliest code to generate some "random" inventory number
            var inventorynumber = _currentbook.Title.Substring(0, _currentbook.Title.Length / 2) + _currentbook.ISBN + "_" + (InventoryListBox.Items.Count + 1);
            LibraryBook libraryBook = new LibraryBook();
            libraryBook.InventoryNumber = inventorynumber;
        }
    }
}
