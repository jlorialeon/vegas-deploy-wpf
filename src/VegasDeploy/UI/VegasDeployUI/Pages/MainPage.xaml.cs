using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace FF.Vegas.Deploy.UI.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly IPageFactory pageFactory;

        public MainPage(IPageFactory? pageFactory)
        {
            InitializeComponent();

            ArgumentNullException.ThrowIfNull(pageFactory, nameof(pageFactory));
            this.pageFactory = pageFactory;
            
        }

        public MainPage()
        {
            InitializeComponent();
            this.pageFactory = new NullPageFactory();
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btndeploy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
