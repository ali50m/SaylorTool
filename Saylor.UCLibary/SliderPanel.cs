using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections;

namespace Saylor.UCLibary
{
    public class SliderPanel : Panel, INotifyPropertyChanged
    {
        public event EventHandler SlideStarted;
        public event EventHandler SlideCompleted;
        public event PropertyChangedEventHandler PropertyChanged;
        protected void SendPropertyChanged(String propertyName)
        {
            if ((PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<UIElement> m_VisiableChildren = new List<UIElement>();
        public List<UIElement> VisiableChildren
        {
            get
            {
                return m_VisiableChildren;
            }
        }

        private Point MouseStart, MouseNow, MouseFirst, MouseFinal;

        int _Counter;
        public int Counter
        {
            get
            {
                return _Counter;
            }
            set
            {
                _Counter = value;
                SendPropertyChanged("Counter");
            }
        }

        private bool isSlider = true;
        public bool IsSlider
        {
            get
            {
                return isSlider;
            }
            set
            {
                isSlider = value;
                if (isSlider)
                {
                    this.MouseLeave += SliderPanel_MouseLeave;
                    this.MouseEnter += SliderPanel_MouseEnter;
                }
                else
                {
                    this.MouseLeave -= SliderPanel_MouseLeave;
                    this.MouseEnter -= SliderPanel_MouseEnter;
                }
            }
        }

        public SliderPanel()
        {
            IsSlider = true;
            Compute();
        }

        void SliderPanel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(SliderPanel_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(SliderPanel_MouseLeftButtonUp);
        }

        void SliderPanel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.MouseLeftButtonDown -= SliderPanel_MouseLeftButtonDown;
            this.MouseLeftButtonUp -= SliderPanel_MouseLeftButtonUp;
        }

        void SliderPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.CaptureMouse();

            this.MouseStart = e.GetPosition(this);
            this.MouseNow = this.MouseStart;
            this.MouseFirst = this.MouseStart;

            this.MouseMove += new System.Windows.Input.MouseEventHandler(SliderPanel_MouseMove);
        }

        void SliderPanel_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Compute();
            this.MouseNow = e.GetPosition(this);

            for (int i = 0; i < VisiableChildren.Count; i++)
            {
                TranslateTransform yu = new TranslateTransform(VisiableChildren[i].RenderTransform.Value.OffsetX + (MouseNow.X - MouseStart.X), 0);
                VisiableChildren[i].RenderTransform = yu;
            }

            MouseStart = MouseNow;
        }

        int _SelectedIndex;
        public int SelectedIndex
        {
            get
            {
                return _SelectedIndex;
            }
            set
            {
                _SelectedIndex = value;
                SendPropertyChanged("SelectedIndex");
                AnimateBySelectedIndex(value);
            }
        }

        public void SelectChild(UIElement element)
        {
            SelectedIndex = FindChildIndex(element);
        }

        private int FindChildIndex(UIElement element)
        {
            int i = 0;
            foreach (var ele in m_VisiableChildren)
            {
                if (ele == element)
                    return i;
                i++;
            }
            return 0;
        }

        private int countAnimate = 0;
        void AnimateBySelectedIndex(int index)
        {
            Compute();
            if (index < 0 || index > this.VisiableChildren.Count - 1 || index * -1 == Counter)
                return;

            index *= -1;
            double pTo, pFrom;
            pTo = index * this.DesiredSize.Width;
            pFrom = index > Counter ? (pTo - this.DesiredSize.Width) : (pTo + this.DesiredSize.Width);

            Counter = index;

            if (SlideStarted != null)
                SlideStarted(this, new EventArgs());
            for (int i = 0; i < VisiableChildren.Count; i++)
            {
                DoubleAnimation da = new DoubleAnimation(pFrom, pTo, new Duration(TimeSpan.FromSeconds(0.3)));
                da.Completed += da_Completed;
                countAnimate ++;
                TranslateTransform yu = new TranslateTransform(VisiableChildren[i].RenderTransform.Value.OffsetX, 0);
                VisiableChildren[i].RenderTransform = yu;

                TranslateTransform tran = (TranslateTransform)VisiableChildren[i].RenderTransform;

                tran.BeginAnimation(TranslateTransform.XProperty, da);
            }
        }

        void da_Completed(object sender, EventArgs e)
        {
            countAnimate--;
            if (countAnimate == 0)
            {
                if (SlideCompleted != null)
                    SlideCompleted(this, new EventArgs());
            }
        }

        void SliderPanel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.MouseMove -= new System.Windows.Input.MouseEventHandler(SliderPanel_MouseMove);

                this.MouseFinal = e.GetPosition(this);
                this.ReleaseMouseCapture();

                if ((MouseFinal.X - MouseFirst.X) > 0)
                {
                    if (Math.Abs(MouseFinal.X - MouseFirst.X) > 50)
                        Counter = Counter + 1;
                }
                else
                {
                    if (Math.Abs(MouseFinal.X - MouseFirst.X) > 50)
                        Counter = Counter - 1;
                }

                double pTo, pFrom;
                pTo = Counter * this.DesiredSize.Width;
                pFrom = (MouseFinal.X - MouseFirst.X) > 0 ? (pTo - this.DesiredSize.Width) + (MouseFinal.X - MouseFirst.X) : (pTo + this.DesiredSize.Width) + (MouseFinal.X - MouseFirst.X);

                if (Math.Abs(MouseFinal.X - MouseFirst.X) < 50)
                    pFrom = pTo + (MouseFinal.X - MouseFirst.X);

                if (Counter > 0)
                {
                    pTo = (Counter - 1) * this.DesiredSize.Width;
                    Counter = Counter - 1;
                }
                else if (Counter <= VisiableChildren.Count * -1)
                {
                    pTo = (Counter + 1) * this.DesiredSize.Width;
                    Counter = Counter + 1;
                }

                for (int i = 0; i < VisiableChildren.Count; i++)
                {
                    DoubleAnimation da = new DoubleAnimation(pFrom, pTo, new Duration(TimeSpan.FromSeconds(0.3)));

                    ((TranslateTransform)VisiableChildren[i].RenderTransform).BeginAnimation(TranslateTransform.XProperty, da);
                }

                SelectedIndex = Math.Abs(Counter);
            }
            catch { }
        }

        protected override System.Windows.Size MeasureOverride(System.Windows.Size availableSize)
        {
            Compute();
            Size resultSize = new Size(0, 0);

            foreach (UIElement child in this.VisiableChildren)
            {
                child.Measure(availableSize);
                resultSize.Width = Math.Max(resultSize.Width, this.DesiredSize.Width);
                resultSize.Height = Math.Max(resultSize.Height, child.DesiredSize.Height);
            }

            resultSize.Width =
                double.IsPositiveInfinity(availableSize.Width) ?
                resultSize.Width : availableSize.Width;

            resultSize.Height =
                double.IsPositiveInfinity(availableSize.Height) ?
                resultSize.Height : availableSize.Height;

            return resultSize;
        }

        protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
        {
            Compute();
            for (int i = 0; i < VisiableChildren.Count; i++)
            {
                VisiableChildren[i].Arrange(new Rect((i * finalSize.Width), (double)0, finalSize.Width, finalSize.Height));
            }

            this.Clip = new RectangleGeometry(new Rect(0, 0, this.DesiredSize.Width, this.DesiredSize.Height));

            return base.ArrangeOverride(finalSize);
        }

        public void Compute()
        {
            m_VisiableChildren.Clear();
            foreach (var ele in this.Children)
            {
                if ((ele as UIElement).Visibility != System.Windows.Visibility.Collapsed)
                {
                    m_VisiableChildren.Add(ele as UIElement);
                }
            }
        }
    }
}
