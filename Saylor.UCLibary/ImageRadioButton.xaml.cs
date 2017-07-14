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
    public partial class ImageRadioButton : RadioButton
    {

        #region dependency property

        public static readonly DependencyProperty UnCheckedImageSourceProperty = DependencyProperty.Register("UnCheckedImageSource", typeof(ImageSource), typeof(ImageRadioButton), new PropertyMetadata(null, new PropertyChangedCallback(UnCheckedImageSourceChangedCallback)));
        public static readonly DependencyProperty CheckedImageSourceProperty = DependencyProperty.Register("CheckedImageSource", typeof(ImageSource), typeof(ImageRadioButton), new PropertyMetadata(null, new PropertyChangedCallback(CheckedImageSourceChangedCallback)));
        public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(ImageRadioButton), new PropertyMetadata(Stretch.None, new PropertyChangedCallback(ImageStretchChangedCallback)));

        #endregion

        #region callback

        private static void UnCheckedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageRadioButton)
            {
                ImageRadioButton imgbtn = sender as ImageRadioButton;
                imgbtn.OnUnCheckedImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void CheckedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageRadioButton)
            {
                ImageRadioButton imgbtn = sender as ImageRadioButton;
                imgbtn.OnCheckedImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void ImageStretchChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is ImageRadioButton)
            {
                ImageRadioButton imgbtn = sender as ImageRadioButton;
                imgbtn.OnImageStretchChanged(e.OldValue, e.NewValue);
            }
        }

        #endregion

        #region public property

        /// <summary>
        /// 
        /// </summary>
        public ImageSource UnCheckedImageSource
        {
            get
            {
                return this.GetValue(UnCheckedImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(UnCheckedImageSourceProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageSource CheckedImageSource
        {
            get
            {
                return this.GetValue(CheckedImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(CheckedImageSourceProperty, value);
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

        protected void OnUnCheckedImageSourceChanged(object oldValue, object newValue)
        {
            this.UnCheckedImageSource = newValue as ImageSource;
        }

        protected void OnCheckedImageSourceChanged(object oldValue, object newValue)
        {
            this.CheckedImageSource = newValue as ImageSource;
        }

        protected void OnImageStretchChanged(object oldValue, object newValue)
        {
            this.ImageStretch = (Stretch)newValue;
        }

        #endregion

        #region construct

        public ImageRadioButton()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(ImageRadioButton_Loaded);
        }

        #endregion

        #region private event

        void ImageRadioButton_Loaded(object sender, RoutedEventArgs e)
        {

        }

        #endregion
    }
}
