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

namespace FF.Vegas.Deploy.UI.Controls
{
    /// <summary>
    /// Interaction logic for ImageButton.xaml
    /// </summary>
    public partial class ImageButton : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty ButtonHeaderProperty = DependencyProperty.Register("ButtonHeader",
                                                                                             typeof(string),
                                                                                             typeof(ImageButton),
                                                                                             new FrameworkPropertyMetadata(null,
                                                                                             FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty ButtonDescriptionProperty = DependencyProperty.Register("ButtonDescription",
                                                                                             typeof(string),
                                                                                             typeof(ImageButton),
                                                                                             new FrameworkPropertyMetadata(null,
                                                                                             FrameworkPropertyMetadataOptions.AffectsRender));


        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",
                                                                                     typeof(ImageSource),
                                                                                     typeof(ImageButton),
                                                                                     new FrameworkPropertyMetadata(null,
                                                                                     FrameworkPropertyMetadataOptions.AffectsRender));






        public string ButtonHeader
        {
            get { return (string)GetValue(ButtonHeaderProperty); }
            set { SetValue(ButtonHeaderProperty, value); }
        }

        public string ButtonDescription
        {
            get { return (string)GetValue(ButtonDescriptionProperty); }
            set { SetValue(ButtonDescriptionProperty, value); }
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        public event RoutedEventHandler? Click;

        public ImageButton()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Click?.Invoke(this, e);
        }
    }
}
