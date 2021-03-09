using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    /// <summary>
    /// トランプのカード
    /// </summary>
    public class Card {
        /// <summary>
        /// スート
        /// </summary>
        public int Suit { get; set; }
        /// <summary>
        /// 数字
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 裏か表か
        /// 表(数字とスートの面):true
        /// 裏:false
        /// </summary>
        public bool Obverse { get; set; }
    }
}
