using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Anchor.FA.Model;

namespace Anchor.FA.BLL.IBLL
{
    public interface ICommon
    {
        IList<G_DATA> GetDataByType(string type);
        //object SearchLoadAll(string type);
        //object LoadAllDataByPage(int page, int rows, string order, string sort,string type);
        //object Edit(int? id);
        //bool Save(G_DATA entity);
        //bool Delete(IList<int> idList);
        //object DataType();

        //object LoadNurse();

        //G_DATA GetData(string type, string value);
    }
}
