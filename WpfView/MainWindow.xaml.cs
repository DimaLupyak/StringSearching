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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += (e, o) =>
                {
                    var viewModel = new MainWindowViewModel();
                    viewModel.ResultItemUpated += OnResultItemUpated;
                    this.DataContext = viewModel;
                };
        }



        private void OnResultItemUpated(object sender, ResultItemEventArgs e)
        {
            InputDataTextBox.Select(e.Index, e.Value.Length);
            DependencyObject focusScope = FocusManager.GetFocusScope(InputDataTextBox);
            FocusManager.SetFocusedElement(focusScope, InputDataTextBox);
        }

    }
}
