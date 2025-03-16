using System.Windows;

namespace 入れ子_ネスト_にしたデータクラスによる参照値渡し
{
    /// <summary>
    /// DisplauWindowB.xaml の相互作用ロジック
    /// </summary>
    public partial class DisplayWindowB : Window
    {
        public DisplayWindowB(SuperDataClas_alpha _alpha)
        {
            InitializeComponent();
            if (_alpha != null)
                alpha = _alpha;

            else
            {
                throw new ArgumentNullException(nameof(_alpha));
            }
        }

        //public DataClassB DataClassB { get; set; }
        public SuperDataClas_alpha alpha { get; set; }

        private void btnChangeTitle_Click(object sender, RoutedEventArgs e)
        {
            // 新しいタイトルをテキストボックスから取得
            string newTitle = txtNewTitle.Text;

            // 新しいタイトルをウィンドウのタイトルとして設定
            if (!string.IsNullOrEmpty(newTitle))
            {
                this.Title = newTitle;
                txtCurrentTitle.Text = "Current Title: " + this.Title;
                alpha.dataclassB.windowName = Title;
            }
            else
            {
                MessageBox.Show("Please enter a title.");
            }
        }
    }
}
