using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anchor.FA.Model;

namespace Anchor.FA.BLL.Organize
{
    internal class Position
    {
        public object LoadAllPost()
        {
            return DAL.Organize.Position.LoadAllPost();
        }
        public object Edit(int? id)
        {
            return DAL.Organize.Position.Edit(id);
        }
        public bool Save(B_POST entity)
        {
            return DAL.Organize.Position.Save(entity);
        }
        public bool Delete(IList<int> idList)
        {
            return DAL.Organize.Position.Delete(idList);
        }

        public object LoadPostByPage(int page, int rows, string order, string sort)
        {
            return DAL.Organize.Position.LoadPostByPage(page,rows,order,sort);
        }
    }
}
