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
    /// Interaction logic for ReturnBookWindow.xaml
    /// </summary>
    public partial class ReturnBookWindow : Window
    {
        private static LibraryBook _libraryBook;
        public ReturnBookWindow(LibraryBook libraryBook)
        {
            _libraryBook = libraryBook;
            InitializeComponent();
        }

        private void FillOutFields()
        {
            invNumLabel.Content = _libraryBook.InventoryNumber;

            //var loaningMemberId= LoanBookDataProvider.GetMemberIdByLoanBook(_libraryBook.InventoryNumber);
            var LoanBook = LoanBookDataProvider.GetLoanBookByInvNum(_libraryBook.InventoryNumber);

            var loaningMember = MemberDataProvider.GetMemberById(LoanBook.LB_MemberId);
            lentToLabel.Content = loaningMember.FirstName + " " + loaningMember.LastName;
            var loandate = LoanBook.LoanDate;
            loanDateLabel.Content = loandate.ToString("g");
            var returndate = LoanBook.ReturnDate;
            returnDateLabel.Content = returndate.ToString("g");
            if (DateTime.Now>returndate)
            {
                var latefine = (DateTime.Now - returndate).Days;
                lateFinetoPayLabel.Content = (latefine * 100).ToString();
            }
            else
            {
                lateFinetoPayLabel.Content = "0";
            }

        }
    }
}
