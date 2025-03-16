using System.Windows;

namespace 入れ子_ネスト_にしたデータクラスによる参照値渡し;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        dataClassA = new DataClassA();
        dataClassB = new DataClassB();

        alpha = new SuperDataClas_alpha(dataClassA,dataClassB);

        dispA = new DisplayWindowA(alpha);

        dispA.Show();

        dispB = new DisplayWindowB(alpha);
        dispB.Show();
    }

    SuperDataClas_alpha alpha { get; set; }


    //状態の保持のみ
    DataClassA dataClassA ;
    DataClassB dataClassB;

    //状態の保持のみ
    DisplayWindowA dispA;
    DisplayWindowB dispB;

    private void GetDataA_Button_Click(object sender, RoutedEventArgs e)
    {
        
        var data = dispA.alpha.dataclassA; //エイリアスする

        data.StateVisiblity = dispA.IsVisible;
        data.StateEnabled = dispA.IsEnabled;
        data.StateMaximamize = dispA.WindowState == WindowState.Maximized;
        data.StateTopMost = dispA.Topmost;

        //MainWIndow側のalphaデータクラスに反映
        alpha.dataclassA = dispA.alpha.dataclassA;

    }

    private void GetDataB_Button_Click(object sender, RoutedEventArgs e)
    {
        

        var data = alpha.dataclassB;

        data.windowWidth = dispA.Width;
        data.windowHeight = dispB.Height;
        data.windwoLocation = new Point(dispB.Left,dispB.Top);

        data.windowName = dispB.Title;


        //MainWIndow側のalphaデータクラスに反映
        alpha.dataclassB = dispB.alpha.dataclassB;

    }
    private void DataAlphaSendtoDispB_Button_Click(object sender, RoutedEventArgs e)
    {
        //上位データクラス DataClassによる参照値渡し
        dispB.alpha = alpha;


        //displayAに下位データクラスの内容が包括して受け渡される
        //ここではデータクラスAの内容が受け渡される

        var dataA = alpha.dataclassA;
        if(dataA.StateMaximamize)
             dispB.WindowState = WindowState.Maximized;
        
        
        

        if (dataA.StateVisiblity)
            dispB.Visibility = Visibility.Visible;
        else
            dispB.Visibility = Visibility.Collapsed;

        


            dispB.Topmost = dataA.StateTopMost;

            dispB.IsEnabled = dataA.StateEnabled;

        dispB.Background = dataA.WindowBackColor;
        
    }


    private void Data_AlphaSendtoDispA_Button_Click(object sender, RoutedEventArgs e)
    {

        //上位データクラス DataClassによる参照値渡し
        dispA.alpha = alpha;

        //displayAに下位データクラスの内容が包括して受け渡される
        //ここではデータクラスＢの内容が受け渡される

        var dataB = alpha.dataclassB;

        dispA.Left = dataB.windwoLocation.X;
        dispA.Top = dataB.windwoLocation.Y;

        dispA.Title = dataB.windowName;
        dispA.Height = dataB.windowHeight;
        dispA.Width = dataB.windowWidth;

      

    }

 
}