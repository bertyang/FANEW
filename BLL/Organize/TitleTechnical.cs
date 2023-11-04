using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anchor.FA.Model;

namespace Anchor.FA.BLL.Organize
{
    public class TitleTechnical : IBLL.ITitle
    {
        public object LoadAllByPage(int page, int rows, string order, string sort)
        {
            return DAL.Organize.TitleTechnical.LoadAllByPage(page,rows,order,sort);
        }

        public object Edit(int? id)
        {
            return DAL.Organize.TitleTechnical.Edit(id);
        }

        public bool Save(B_TITLE_TECHNICAL entity) 
        {
            return DAL.Organize.TitleTechnical.Save(entity);
        }

        public bool Delete(IList<int> idList) 
        {
            return DAL.Organize.TitleTechnical.Delete(idList);
        }
    }
}
