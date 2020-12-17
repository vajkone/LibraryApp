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
    /// Interaction logic for MoreBorrowedBookInfoWindow.xaml
    /// </summary>
    public partial class MoreBorrowedBookInfoWindow : Window
    {
        private static LoanBookInfo _bookinfo;
        public MoreBorrowedBookInfoWindow(LoanBookInfo lbinfo)
        {
            InitializeComponent();
            _bookinfo = lbinfo;
            FillOutFields();
        }

        private void FillOutFields()
        {
            BookTitleTB.Text = _bookinfo.Title;
            ISBNTB.Text = _bookinfo.ISBN;
            publisherTB.Text = _bookinfo.Publisher;
            PublicationDateTB.Text = _bookinfo.ReleaseDate.ToString();
            GenreTB.Text = _bookinfo.Genre;
            PagesTB.Text = _bookinfo.Pages.ToString();
            AuthorTB.Text = _bookinfo.Author.FirstName + " " + _bookinfo.Author.LastName;
            BorrowDateTB.Text = _bookinfo.LoanDate.ToString("g");
            ExpectedReturnDateTB.Text = _bookinfo.ReturnDate.ToString("g");
            if (DateTime.Now > _bookinfo.ReturnDate)
            {
                CurrentLateFeeTb.Text = (((DateTime.Now - _bookinfo.ReturnDate).Days) * 100).ToString();
            }
            else
            {
                CurrentLateFeeTb.Text = "0";
            }



        }
    }
}
