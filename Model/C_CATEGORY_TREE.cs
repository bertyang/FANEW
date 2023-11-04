using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchor.FA.Model
{
    /// <summary>
    /// 物品类别树实体类
    /// </summary>
    public class C_CATEGORY_TREE
    {
        public List<C_CATEGORY_TREE> children { get; set; }
        public string id { get; set; }
        public string text { get; set; }
        public string iconCls { get; set; }
        public string ParentID { get; set; }
    }
}
