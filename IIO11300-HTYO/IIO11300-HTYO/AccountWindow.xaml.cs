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
using System.Windows.Shapes;

namespace IIO11300_HTYO
{
    /// <summary>
    /// Interaction logic for AccountWindow.xaml
    /// </summary>
    
    public partial class AccountWindow : Window
    {
        private int accountId;

        public AccountWindow(int accountId)
        {
            InitializeComponent();
            InitializeAccountData(accountId);
        }

        public void InitializeAccountData(int accountId)
        {
            try
            {
                this.accountId = accountId;

                // 1. Get account from BL.
                spAccount.DataContext = BLAccount.GetAccount(accountId);

                // 2. Get items from BL.
                lstItem.DataContext = BLAccount.GetItems(accountId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void lstItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            spItem.DataContext = lstItem.SelectedItem;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Insert item.
                BLAccount.InsertItem(txtIname.Text);

                // Update items.
                lstItem.DataContext = BLAccount.GetItems(accountId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void DelItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get selected item.
                // Item selectedItem = (Item)spItem.DataContext;

                // Delete item.
                BLAccount.DeleteItem(Convert.ToInt32(txtId.Text));

                // Update items.
                lstItem.DataContext = BLAccount.GetItems(accountId);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
