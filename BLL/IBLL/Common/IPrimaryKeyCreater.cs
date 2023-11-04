using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchor.FA.BLL.IBLL
{
    public interface IPrimaryKeyCreater
    {
        int getIntPrimaryKey(string name);
        string getStringPrimaryKey(string name);
        //string getShortStringPrimaryKey(string name);
        long getLongPrimaryKey(string name);
    }
}
