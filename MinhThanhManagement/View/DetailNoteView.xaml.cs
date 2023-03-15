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
    /// Interaction logic for DetailNoteView.xaml
    /// </summary>
    public partial class DetailNoteView : Window
    {

        private static DetailNoteView _instance;
        public static DetailNoteView GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DetailNoteView();
            }
            return _instance;
        }

        public DetailNoteView()
        {
            InitializeComponent();
        }

        private void closeDialog(object sender, RoutedEventArgs e)
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
    }
}
