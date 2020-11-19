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
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private IList<Author> _authors;
        private Book _book;
        private Author _author;
        private BookAuthor _bookAuthor;
    
        public AddBookWindow()
        {
            InitializeComponent();

            UpdateAuthors();

            
           
        }

        private void UpdateAuthors()
        {
            _authors = AuthorDataProvider.GetAuthors();
            

            AuthorComboBox.ItemsSource = _authors;
        }

        private void RegisterAuthorButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterAuthorWindow();

            if (window.ShowDialog() ?? false)
            {
                UpdateAuthors();
            }
        }

        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateBook())
            {
                _book = new Book();
                _book.Title = BookTitleTextBox.Text;
                _book.ISBN = BookIsbnTextBox.Text;
                _book.ReleaseDate = PublishDatePicker.SelectedDate.Value;
                _book.Publisher = PublisherTextBox.Text;
                _book.Pages = int.Parse(PagesTextBox.Text);
                _book.Genre = GenreTextBox.Text;

                BookDataProvider.CreateBook(_book);

                var newBookId = BookDataProvider.GetBookByIsbn(_book.ISBN);

                _bookAuthor = new BookAuthor();
                _bookAuthor.BA_AuthorId = _author.AuthorId;
                _bookAuthor.BA_BookId = newBookId;

                BookAuthorDataProvider.CreateBookAuthorLink(_bookAuthor);

                DialogResult = true;
                Close();

            }
        }

        private bool ValidateBook()
        {
            if (string.IsNullOrEmpty(BookTitleTextBox.Text))
            {
                MessageBox.Show("Title should not be empty");
                return false;
            }

            if (string.IsNullOrEmpty(BookIsbnTextBox.Text))
            {
                MessageBox.Show("ISBN field should not be empty");
                return false;
            }

            if (!PublishDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a publication date");
                return false;
            }

            if (string.IsNullOrEmpty(PublisherTextBox.Text))
            {
                MessageBox.Show("Publisher field should not be empty");
                return false;
            }

            if (string.IsNullOrEmpty(PagesTextBox.Text))
            {
                MessageBox.Show("Please provide the pagecount of the book");
                return false;
            }

            if (string.IsNullOrEmpty(GenreTextBox.Text))
            {
                MessageBox.Show("Genre field should not be empty");
                return false;
            }

            if (AuthorComboBox.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select the author or register him/her in the database");
                return false;
            }
            else
            {
                _author = AuthorComboBox.SelectedItem as Author;
            }

            return true;
        }
    }
}
