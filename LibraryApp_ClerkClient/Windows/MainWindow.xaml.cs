﻿using LibraryApp_ClerkClient.DataProviders;
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
        public MainWindow()
        {
            InitializeComponent();
            UpdateBooks();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddBookWindow();

            if (window.ShowDialog() ?? false)
            {
                UpdateBooks();
            }
        }


        private void UpdateBooks()
        {
            _books = BookDataProvider.GetBooks();
            libraryBookList.ItemsSource = _books;
        }

        private void RegisterMemberButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new RegisterMemberWindow();

            if (window.ShowDialog() ?? false)
            {
                UpdateBooks();
            }
        }
    }
}
