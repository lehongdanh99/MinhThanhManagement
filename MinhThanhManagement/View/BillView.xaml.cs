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

namespace MinhThanhManagement.View
{
    /// <summary>
    /// Interaction logic for BillView.xaml
    /// </summary>
    public partial class BillView : Window
    {
        private static BillView _instance;
        public static BillView GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BillView();
            }
            return _instance;
        }

        public BillView()
        {
            InitializeComponent();
            
        }

        private void close_page(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SelectionChange_AutoComplete(object sender, SelectionChangedEventArgs e)
        {

        }

        private void print(object sender, RoutedEventArgs e)
        {
            try
            {
                AddGroupStackpanel.Visibility = Visibility.Collapsed;
                CancelButton.Visibility = Visibility.Collapsed;
                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(billPage, "Invoice");
                    MessageBox.Show("ok");
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
