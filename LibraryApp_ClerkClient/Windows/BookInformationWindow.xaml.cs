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
        public BookInformationWindow(Book selectedbook)
        {
            InitializeComponent();
        }
    }
}
