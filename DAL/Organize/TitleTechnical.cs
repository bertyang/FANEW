using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Anchor.FA.Model;
using System.Linq.Expressions;

namespace Anchor.FA.DAL.Organize
{
    public class TitleTechnical
    {
        public static object LoadAllByPage(int page, int rows, string order, string sort)
        {
            using (DbEntities dbContext = new DbEntities())
            {
                var list = (from t in dbContext.B_TITLE_TECHNICALS select t);
                long total = list.LongCount();

                list = list.OrderBy(s=>s.ID);
                list = list.Skip((page - 1) * rows).Take(rows);

                var result = new { total = total, rows = list.ToList() };

                return result;
            }    

        }
 
        public static object Edit(int? id)
        {
            using (DbEntities dbContext = new DbEntities())
            {
                B_TITLE_TECHNICAL entity = null;                
                if (id != null)
                {
                    entity = dbContext.B_TITLE_TECHNICALS.FirstOrDefault(t => t.ID == id);
                }
                entity = entity ?? new B_TITLE_TECHNICAL
                {
                    ID = 0,
                    Name = string.Empty,
                    Grade = string.Empty,
                };
                return entity;
            }   
        }

        public static bool Save(B_TITLE_TECHNICAL entity) 
        {
            using (DbEntities dbContext = new DbEntities())
            {
                if (entity.ID == 0)  //添加
                {
                    var list = from p in dbContext.B_TITLE_TECHNICALS select p.ID;
                    long total = list.LongCount();
                    if (total == 0)
                    {
                        entity.ID = 1;
                    }
                    else
                    {
                        entity.ID = dbContext.B_TITLE_TECHNICALS.Max(t => t.ID) + 1;
                    }   
                    dbContext.B_TITLE_TECHNICALS.Load();
                    dbContext.B_TITLE_TECHNICALS.Add(entity);
                    dbContext.SaveChanges();
                    return true;
                }
                else  //修改
                {
                    var model = dbContext.B_TITLE_TECHNICALS.FirstOrDefault(t => t.ID == entity.ID);
                    model.ID = entity.ID;
                    model.Name = entity.Name;
                    model.Grade = entity.Grade;
                    dbContext.SaveChanges();
                    return true;
                }               
            }      
        }
        public static bool Delete(IList<int> idList)
        {
            using (DbEntities dbContext = new DbEntities())
            {
                foreach (int g in idList)
                {
                    var model = dbContext.B_TITLE_TECHNICALS.Single(t => t.ID == g);
                    dbContext.B_TITLE_TECHNICALS.Load();
                    dbContext.B_TITLE_TECHNICALS.Remove(model);
                }
                dbContext.SaveChanges();
                return true;
            }
            
        }
    }
}
