using System.Windows;
using System.Windows.Media;

namespace 入れ子_ネスト_にしたデータクラスによる参照値渡し
{
    /// <summary>
    /// DisplauWindowA.xaml の相互作用ロジック
    /// </summary>
    public partial class DisplayWindowA : Window
    {
        public DisplayWindowA(SuperDataClas_alpha _alpha)
        {
            InitializeComponent();

            if (_alpha == null)
            {
                throw new ArgumentNullException(nameof(_alpha));
            }
            else
              alpha = _alpha;

        }


        

        public SuperDataClas_alpha alpha { get; set; } 

       //public DataClassA dataclassA { get; set; }

       

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //エイリアスする
            var dataImpl = alpha.dataclassA;

          dataImpl.StateEnabled = this.IsEnabled;
          dataImpl.StateVisiblity = this.IsVisible;
          dataImpl.StateMaximamize = WindowState == WindowState.Maximized;
          dataImpl.StateTopMost = this.Topmost;
        }

        private void btnToggleWindowState_Click(object sender, RoutedEventArgs e)
        {

           var data =  alpha.dataclassA; 
            // 最大化・通常サイズをトグル
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
            data.StateMaximamize = (this.WindowState == WindowState.Maximized);
        }

        private void btnToggleIsEnabled_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
            // IsEnabledをトグル
            this.IsEnabled = !this.IsEnabled;
            data.StateEnabled = this.IsEnabled;
        }



            
        private void btnToggleIsVisible_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
            // IsVisibleをトグル
            this.Visibility = this.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
            data.StateVisiblity = this.Visibility == Visibility.Visible;
        }

        private void btnToggleTopmost_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
            // Topmostをトグル
            this.Topmost = !this.Topmost;
            data.StateTopMost = this.Topmost;
        }

        private void RedButton_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
          this.Background = new SolidColorBrush(Colors.Red); // 背景色を赤に変更

            data.WindowBackColor = Background;
        }

        private void GreenButton_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
            this.Background = new SolidColorBrush(Colors.Green); // 背景色を緑に変更
            data.WindowBackColor = Background;
        }

        private void AliceBlueButton_Click(object sender, RoutedEventArgs e)
        {
            var data = alpha.dataclassA;
            this.Background = new SolidColorBrush(Colors.AliceBlue); // 背景色をアリスブルーに変更
            data.WindowBackColor = Background;
        }
    }
}
