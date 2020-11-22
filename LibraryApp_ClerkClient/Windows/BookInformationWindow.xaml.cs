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
           InventoryListBox.ItemsSource = LibraryBookDataProvider.GetCopiesOfBook(_currentbook.BookId);
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
            libraryBook.LB_BookId = _currentbook.BookId;
            libraryBook.CurrentlyLoaned = false;
            LibraryBookDataProvider.CreateLibraryBook(libraryBook);
            UpdateLibraryBooks();
            
        }

        private void CheckInfoButton_Click(object sender, RoutedEventArgs e)
        {

            if (InventoryListBox.SelectedIndex > -1)
            {
                LibraryBook selectedCopy = InventoryListBox.SelectedItem as LibraryBook;
                var window = new LibraryBookInfoWindow(selectedCopy);

                window.ShowDialog();
            }

        }

        private void LendBookButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (InventoryListBox.SelectedIndex>-1)
            {
                LibraryBook selectedCopy = InventoryListBox.SelectedItem as LibraryBook;
                if (!selectedCopy.CurrentlyLoaned)
                {
                    var window = new LendBookWindow(selectedCopy);

                    if (window.ShowDialog() ?? false)
                    {
                        UpdateLibraryBooks();
                    }
                }
                else
                {
                    var window = new ReturnBookWindow(selectedCopy);

                    if (window.ShowDialog() ?? false)
                    {
                        UpdateLibraryBooks();
                    }
                }

                
            }
            
        }

        private void InventoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCopy = InventoryListBox.SelectedItem as LibraryBook;

            if (selectedCopy != null)
            {
                if (selectedCopy.CurrentlyLoaned)
                {
                    LendBookButton.Content = "Return book";
                    CheckInfoButton.Visibility = Visibility.Visible;
                }
                else
                {
                    LendBookButton.Content = "Lend book";
                    CheckInfoButton.Visibility = Visibility.Collapsed;
                }
            }
            
        }
    }
}
