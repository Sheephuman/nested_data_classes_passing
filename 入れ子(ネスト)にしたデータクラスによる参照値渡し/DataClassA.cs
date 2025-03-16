using System.Windows.Media;

namespace 入れ子_ネスト_にしたデータクラスによる参照値渡し
{
   public class DataClassA
    {
    

       public  bool StateTopMost { get; set; }
       public bool StateMaximamize { get; set; }

        public bool StateEnabled { get; set; }
        public bool StateVisiblity { get; set; }

        public Brush? WindowBackColor { get; set;}

    }
}
