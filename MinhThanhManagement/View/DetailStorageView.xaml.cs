﻿using System;
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
    /// Interaction logic for DetailStorageView.xaml
    /// </summary>
    public partial class DetailStorageView : Window
    {
        public DetailStorageView()
        {
            InitializeComponent();
        }

        private void closeDialog(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
