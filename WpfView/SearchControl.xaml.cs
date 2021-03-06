﻿using StringSearch;
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
using ViewModel;

namespace WpfView
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
        }
    
        private void ResultItemClick(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as SearchControlViewModel;
            var btn = sender as Button;
            var result = btn.DataContext as ResultItem;
            viewModel.LastClickedResultItem = result;
        }
    }
}
