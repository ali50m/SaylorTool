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

namespace Saylor.UCLibary
{
    /// <summary>
    /// ImageButton.xaml 
    /// </summary>
    public partial class PressedImageButton : Button
    {

        #region dependency property

        public static readonly DependencyProperty DefaultImageSourceProperty = DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(PressedImageButton), new PropertyMetadata(null, new PropertyChangedCallback(DefaultImageSourceChangedCallback)));
        public static readonly DependencyProperty PressedImageSourceProperty = DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(PressedImageButton), new PropertyMetadata(null, new PropertyChangedCallback(PressedImageSourceChangedCallback)));
        public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(PressedImageButton), new PropertyMetadata(Stretch.None, new PropertyChangedCallback(ImageStretchChangedCallback)));

        #endregion

        #region callback

        private static void DefaultImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is PressedImageButton)
            {
                PressedImageButton imgbtn = sender as PressedImageButton;
                imgbtn.OnDefaultImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void PressedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is PressedImageButton)
            {
                PressedImageButton imgbtn = sender as PressedImageButton;
                imgbtn.OnPressedImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void ImageStretchChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is PressedImageButton)
            {
                PressedImageButton imgbtn = sender as PressedImageButton;
                imgbtn.OnImageStretchChanged(e.OldValue, e.NewValue);
            }
        }

        #endregion

        #region public property

        /// <summary>
        /// 
        /// </summary>
        public ImageSource DefaultImageSource
        {
            get
            {
                return this.GetValue(DefaultImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(DefaultImageSourceProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageSource PressedImageSource
        {
            get
            {
                return this.GetValue(PressedImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(PressedImageSourceProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Stretch ImageStretch
        {
            get
            {
                return (Stretch)this.GetValue(ImageStretchProperty);
            }
            set
            {
                this.SetValue(ImageStretchProperty, value);
            }
        }

        #endregion

        #region protected method

        protected void OnDefaultImageSourceChanged(object oldValue, object newValue)
        {
            this.DefaultImageSource = newValue as ImageSource;
        }

        protected void OnPressedImageSourceChanged(object oldValue, object newValue)
        {
            this.PressedImageSource = newValue as ImageSource;
        }

        protected void OnImageStretchChanged(object oldValue, object newValue)
        {
            this.ImageStretch = (Stretch)newValue;
        }

        #endregion

        #region construct

        public PressedImageButton()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PressedImageButton_Loaded);
        }

        #endregion

        #region private event

        void PressedImageButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
