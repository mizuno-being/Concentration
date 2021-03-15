using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concentration {
    public class Player {

        /// <summary>
        /// プレイヤー番号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// プレイヤー名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 取得枚数
        /// </summary>
        public int OwnCards { get; set; }
    }

}
