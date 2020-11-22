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
    /// Interaction logic for LibraryBookInfoWindow.xaml
    /// </summary>
    public partial class LibraryBookInfoWindow : Window
    {
        private static LibraryBook _currentLibraryBook;
        private static Member _loaningMember;
        private static LoanBook _loanBook;
        public LibraryBookInfoWindow(LibraryBook selectedCopy)
        {
            InitializeComponent();
            _currentLibraryBook = selectedCopy;
            
            FillOutFields();
        }

        private void FillOutFields()
        {
            var invNum= _currentLibraryBook.InventoryNumber;
            InventoryNumberLabel.Content = invNum;
            _loanBook = LoanBookDataProvider.GetLoanBookByInvNum(invNum);
            _loaningMember = MemberDataProvider.GetLoaningMember(invNum);
            LentToLabel.Content = _loaningMember.FirstName + " " + _loaningMember.LastName;
            var loandate = _loanBook.LoanDate;
            var returndate = _loanBook.ReturnDate;
            LoanDateLabel.Content = loandate.ToString("g");
            ExpReturnDateLabel.Content = returndate.ToString("g");
            if (DateTime.Now>returndate)
            {
                ExpReturnDateLabel.Foreground = Brushes.Red;
                CurrentLateFeeLabel.Content = ((DateTime.Now - returndate).Days * 100).ToString();
            }
            else
            {
                ExpReturnDateLabel.Foreground = Brushes.Green;
                CurrentLateFeeLabel.Content = "0";
            }

        }
    }
}
