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
using TestTaskCrypto.ViewModels;

namespace TestTaskCrypto.Views
{
    /// <summary>
    /// Interaction logic for CryptoDetails.xaml
    /// </summary>
    public partial class CryptoDetails : UserControl
    {
        public CryptoDetails()
        {
            InitializeComponent();
        }
        public CryptoDetails(CryptoDetailsViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
