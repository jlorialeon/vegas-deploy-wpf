using FF.Vegas.Deploy.UI.Pages;
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

namespace FF.Vegas.Deploy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWindowFactory windowFactory;
        private readonly IPageFactory pageFactory;

        public MainWindow(IWindowFactory? windowFactory, IPageFactory? pageFactory)
        {
            ArgumentNullException.ThrowIfNull(windowFactory, nameof(windowFactory));
            ArgumentNullException.ThrowIfNull(pageFactory, nameof(pageFactory));

            InitializeComponent();
            this.windowFactory = windowFactory;
            this.pageFactory = pageFactory;
        }

        private void btnCommit_Click(object sender, RoutedEventArgs e)
        {
            LoadPage<CommitPage>();
        }

        private void btndeploy_Click(object sender, RoutedEventArgs e)
        {
            LoadPage<DeployPage>();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            LoadPage<SettingsPage>();
        }

        private void LoadPage<TPage>() where TPage : Page 
        {
            this.Cursor = Cursors.Wait;
            BlockSidePanel(true);
            try
            {
                var page = pageFactory.Create<TPage>();
                frmMain.Content = page;
            }
            catch (Exception)
            {
            }
            finally 
            {
                this.Cursor = Cursors.Arrow;
                BlockSidePanel(false);
            }
        }

        private void BlockSidePanel(bool block) 
        {
            btnSettings.IsEnabled = btnDeploy.IsEnabled = btnCommit.IsEnabled = !block;
        }
    }
}
