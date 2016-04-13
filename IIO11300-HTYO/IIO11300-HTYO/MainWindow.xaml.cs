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

namespace IIO11300_HTYO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bttLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get account from BL.
                bool isAccountExist = BLAccount.IsAccountExist(txtLEmail.Text, txtLPword.Password);

                if (isAccountExist)
                {
                    MessageBox.Show("Login Accepted");

                    // Get accountId form BL.
                    int accountId = BLAccount.GetAccountId(txtLEmail.Text, txtLPword.Password);

                    // AccountWindow initialization.
                    AccountWindow accountWindow = new AccountWindow(accountId);

                    accountWindow.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed");
                }

                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void bttRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get account from BL.
                bool isAccountExist = BLAccount.IsAccountExist(txtREmail.Text, txtRPword.Password);

                if (!isAccountExist)
                {
                    MessageBox.Show("Register Accepted");

                    // Get accountId form BL.
                    int accountId = BLAccount.SetAccount(txtREmail.Text, txtRPword.Password, txtFname.Text, txtLname.Text);

                    // AccountWindow initialization.
                    AccountWindow accountWindow = new AccountWindow(accountId);

                    accountWindow.Show();
                }
                else
                {
                    MessageBox.Show("Register Failed");
                }

                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
