
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
        public bool IsObverse { get; set; }
    }
}
