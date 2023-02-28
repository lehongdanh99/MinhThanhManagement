using MinhThanhManagement.ViewModel;
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
    /// Interaction logic for NoteView.xaml
    /// </summary>
    public partial class NoteView : Window
    {

        private static NoteView _instance;
        public static NoteView GetInstance()
        {
            if (_instance == null)
            {
                _instance = new NoteView();
            }
            return _instance;
        }
        private NoteView()
        {
            InitializeComponent();
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void minimizeApp(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddStorageClick(object sender, RoutedEventArgs e)
        {
            try
            {
                DetailStorageView detailStorageView = new DetailStorageView();
                detailStorageView.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MyDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var editedElement = e.EditingElement as TextBox;
            DataGridRow row = (DataGridRow)DataGridXaml.ItemContainerGenerator.ContainerFromItem(e.Row.Item);
            int rowIndex = DataGridXaml.ItemContainerGenerator.IndexFromContainer(row);
            if (editedElement != null)
            {
                string type = e.Column.SortMemberPath;
                var editedValue = editedElement.Text;
                if (type.Equals("Group"))
                    GlobalDef.ListStorageModel[rowIndex].Group = editedValue;
                if (type.Equals("Name"))
                    GlobalDef.ListStorageModel[rowIndex].Name = editedValue;
                if (type.Equals("Price"))
                    GlobalDef.ListStorageModel[rowIndex].Price = Convert.ToDouble(editedValue);
                if (type.Equals("Remain"))
                    GlobalDef.ListStorageModel[rowIndex].Remain = editedValue;
                // Handle the edited value here
            }
        }

    }
}
