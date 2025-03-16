using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 入れ子_ネスト_にしたデータクラスによる参照値渡し
{
    public class SuperDataClas_alpha
    {
        public SuperDataClas_alpha(DataClassA _dataClassA, DataClassB _dataClassB)
        {
            if (_dataClassA == null || _dataClassB == null)
            {
                throw new ArgumentNullException(nameof(_dataClassA));

            }
            else
            {
                dataclassA = _dataClassA;
                dataclassB = _dataClassB;
            }
        }


       public DataClassA dataclassA { get; set; }
       public DataClassB dataclassB { get; set; }
    }
}
