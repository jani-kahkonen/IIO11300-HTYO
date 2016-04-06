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
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("bttLogin_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("bttRegister_Click");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

// https://www.google.fi/imgres?imgurl=https://w3layouts.com/wp-content/uploads/2014/07/Login-Form.png&imgrefurl=https://w3layouts.com/golden-login-form-template/&h=540&w=850&tbnid=LoMnE9Txs19vPM:&docid=9yB0_oJOin6K7M&ei=wg0FV_KSEMajsgHx4aiQAw&tbm=isch&ved=0ahUKEwjy-8XpjfrLAhXGkSwKHfEwCjIQMwhcKDgwOA
// https://www.google.fi/imgres?imgurl=https://d13yacurqjgara.cloudfront.net/users/410406/screenshots/2162193/ui-day001-login-form.png&imgrefurl=https://dribbble.com/tags/login_form&h=600&w=800&tbnid=CIrUJCh4UaekcM:&docid=0LjCg-yQemiFwM&ei=wg0FV_KSEMajsgHx4aiQAw&tbm=isch&ved=0ahUKEwjy-8XpjfrLAhXGkSwKHfEwCjIQMwhTKC8wLw