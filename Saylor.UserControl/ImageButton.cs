using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Saylor.UserControl
{
    public class ImageButton : Button
    {
        static ImageButton() 
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        #region   BackgroundImage

        //public ImageSource NormalImage
        //{
        //    get { return (ImageSource)GetValue(NormalImageProperty); }
        //    set { SetValue(NormalImageProperty, value); }
        //}
        //public static readonly DependencyProperty NormalImageProperty =
        //    DependencyProperty.Register("NormalImage", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, OnNormalImageChanged));

        //private static void OnNormalImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{

        //}

        //public ImageSource PressedImage
        //{
        //    get { return (ImageSource)GetValue(PressedImageProperty); }
        //    set { SetValue(PressedImageProperty, value); }
        //}
        //public static readonly DependencyProperty PressedImageProperty =
        //    DependencyProperty.Register("PressedImage", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, OnPressedImageChanged));

        //private static void OnPressedImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{

        //}




        //public ImageSource PressedImageSource
        //{
        //    get
        //    {
        //        return this.GetValue(PressedImageSourceProperty) as ImageSource;
        //    }
        //    set
        //    {
        //        this.SetValue(PressedImageSourceProperty, value);
        //    }
        //}
        //public static readonly DependencyProperty PressedImageSourceProperty = DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton),
        //    new PropertyMetadata(null, new PropertyChangedCallback(PressedImageSourceChangedCallback)));


        //private static void PressedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        //{
        //    if (sender != null && sender is ImageButton)
        //    {
        //        ImageButton imgbtn = sender as ImageButton;
        //        imgbtn.OnPressedImageSourceChanged(e.OldValue, e.NewValue);
        //    }
        //}
        #endregion


        #region dependency property

    public static readonly DependencyProperty DefaultImageSourceProperty = DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(DefaultImageSourceChangedCallback)));
    public static readonly DependencyProperty PressedImageSourceProperty = DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null, new PropertyChangedCallback(PressedImageSourceChangedCallback)));
    public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(ImageButton), new PropertyMetadata(Stretch.None, new PropertyChangedCallback(ImageStretchChangedCallback)));

    #endregion       

    #region callback

    private static void DefaultImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender != null && sender is ImageButton)
        {
            ImageButton imgbtn = sender as ImageButton;
            imgbtn.OnDefaultImageSourceChanged(e.OldValue, e.NewValue);
        }
    }

    private static void PressedImageSourceChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender != null && sender is ImageButton)
        {
            ImageButton imgbtn = sender as ImageButton;
            imgbtn.OnPressedImageSourceChanged(e.OldValue, e.NewValue);
        }
    }

    private static void ImageStretchChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
    {
        if (sender != null && sender is ImageButton)
        {
            ImageButton imgbtn = sender as ImageButton;
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
        //viewmodel.DefaultImageSource = newValue as ImageSource;
        this.DefaultImageSource = newValue as ImageSource;
    }

    protected void OnPressedImageSourceChanged(object oldValue, object newValue)
    {
        //viewmodel.PressedImageSource = newValue as ImageSource;
        this.PressedImageSource = newValue as ImageSource;
    }

    protected void OnImageStretchChanged(object oldValue, object newValue)
    {
        //viewmodel.ImageStretch = (Stretch)newValue;
        this.ImageStretch = (Stretch)newValue;
    }

    #endregion


    }
}
