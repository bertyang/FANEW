using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Anchor.FA.Model;
using System.Linq.Expressions;

namespace Anchor.FA.DAL.Organize
{
    public class Position
    {
        public static object LoadAllPost()
        {
            using (MainDataContext dbContext = new MainDataContext())
            {
                var list = dbContext.B_POST.ToList();
                return list.ToList();
            }

        }

        public static object Edit(int? id)
        {
            using (MainDataContext dbContext = new MainDataContext())
            {
                B_POST entity = null;
                if (id != null)
                {
                     entity = dbContext.B_POST.FirstOrDefault(t => t.ID == id);
                }
                entity = entity ?? new B_POST
                {
                    ID = 0,
                    Level = 0,
                    Name = string.Empty,  

                };
                return entity;
            }
        }

        public static bool Save(B_POST entity)
        {
            using (MainDataContext dbContext = new MainDataContext())
            {
                if (entity.ID == 0)  //添加
                {
                    var list = from p in dbContext.B_POST select p.ID;
                    long total = list.LongCount();
                    if (total == 0)
                    {
                        entity.ID = 1;                     
                    }
                    else
                    {
                        entity.ID = dbContext.B_POST.Max(t => t.ID) + 1;    
                    }

                    dbContext.B_POST.InsertOnSubmit(entity);
                    dbContext.SubmitChanges();
                    return true;
                   
                }
                else  //修改
                {
                    var model = dbContext.B_POST.FirstOrDefault(t => t.ID == entity.ID);
                    model.ID = entity.ID;
                    model.Name = entity.Name;
                    model.Level = entity.Level;
                    dbContext.SubmitChanges();
                    return true;                  
                }
            }
        }
        public static bool Delete(IList<int> idList)
        {
            using (MainDataContext dbContext = new MainDataContext())
            {
                foreach (int g in idList)
                {
                    var model = dbContext.B_POST.Single(t => t.ID == g);
                    //dbContext.B_POST.Load();
                    dbContext.B_POST.DeleteOnSubmit(model);
                }
                dbContext.SubmitChanges();
                return true;
            }

        }

        public static object LoadPostByPage(int page, int rows, string order, string sort)
        {
            using (MainDataContext dbContext = new MainDataContext())
            {
                var list = from p in dbContext.B_POST select p;
                long total = list.LongCount();

                list = list.OrderBy(p => p.ID);
                list = list.Skip((page - 1) * rows).Take(rows);

                var result = new { total = total, rows = list.ToList() };

                return result;
            }

        }
    }
}
