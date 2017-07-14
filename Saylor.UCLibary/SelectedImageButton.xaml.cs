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
    public partial class SelectedImageButton : Button
    {

        #region dependency property

        public static readonly DependencyProperty DefaultImageSourceProperty = DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(SelectedImageButton), new PropertyMetadata(null, new PropertyChangedCallback(DefaultImageSourceChangedCallback)));
        public static readonly DependencyProperty SelectedImageSourceProperty = DependencyProperty.Register("SelectedImageSource", typeof(ImageSource), typeof(SelectedImageButton), new PropertyMetadata(null, new PropertyChangedCallback(SelectedImageSourceChangedCallback)));
        public static readonly DependencyProperty UnSelectedImageSourceProperty = DependencyProperty.Register("UnSelectedImageSource", typeof(ImageSource), typeof(SelectedImageButton), new PropertyMetadata(null, new PropertyChangedCallback(UnSelectedImageSourceChangedCallback)));
        public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(SelectedImageButton), new PropertyMetadata(Stretch.None, new PropertyChangedCallback(ImageStretchChangedCallback)));

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectedImageButton), new PropertyMetadata(false, new PropertyChangedCallback(IsSelectedChangedCallback)));



        #endregion

        #region callback

        private static void DefaultImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is SelectedImageButton)
            {
                SelectedImageButton imgbtn = sender as SelectedImageButton;
                imgbtn.OnDefaultImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void SelectedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is SelectedImageButton)
            {
                SelectedImageButton imgbtn = sender as SelectedImageButton;
                imgbtn.OnSelectedImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void UnSelectedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is SelectedImageButton)
            {
                SelectedImageButton imgbtn = sender as SelectedImageButton;
                imgbtn.OnUnSelectedImageSourceChanged(e.OldValue, e.NewValue);
            }
        }

        private static void ImageStretchChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is SelectedImageButton)
            {
                SelectedImageButton imgbtn = sender as SelectedImageButton;
                imgbtn.OnImageStretchChanged(e.OldValue, e.NewValue);
            }
        }

        private static void IsSelectedChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender != null && sender is SelectedImageButton)
            {
                SelectedImageButton imgbtn = sender as SelectedImageButton;
                imgbtn.OnIsSelectedChanged(e.OldValue, e.NewValue);
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
        public ImageSource SelectedImageSource
        {
            get
            {
                return this.GetValue(SelectedImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(SelectedImageSourceProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ImageSource UnSelectedImageSource
        {
            get
            {
                return this.GetValue(UnSelectedImageSourceProperty) as ImageSource;
            }
            set
            {
                this.SetValue(UnSelectedImageSourceProperty, value);
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
        
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        #endregion

        #region protected method

        protected void OnDefaultImageSourceChanged(object oldValue, object newValue)
        {
            this.DefaultImageSource = newValue as ImageSource;
        }

        protected void OnSelectedImageSourceChanged(object oldValue, object newValue)
        {
            this.SelectedImageSource = newValue as ImageSource;
        }

        protected void OnUnSelectedImageSourceChanged(object oldValue, object newValue)
        {
            this.UnSelectedImageSource = newValue as ImageSource;
        }

        protected void OnImageStretchChanged(object oldValue, object newValue)
        {
            this.ImageStretch = (Stretch)newValue;
        }
        private void OnIsSelectedChanged(object oldValue, object newValue)
        {
            this.IsSelected = (bool)newValue;
            if (this.IsSelected)
            {
                DefaultImageSource = SelectedImageSource;
            }
            else
            {
                DefaultImageSource = UnSelectedImageSource;
            }
        }
        #endregion

        #region construct

        public SelectedImageButton()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(SelectedImageButton_Loaded);
        }

        #endregion

        #region private event

        void SelectedImageButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (DefaultImageSource==null)
            {
                DefaultImageSource = UnSelectedImageSource;
            }
        }

        #endregion
    }
}
