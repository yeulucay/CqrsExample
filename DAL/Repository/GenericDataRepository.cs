using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Repository
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {            
            try
            {
                List<T> list;
                using (var context = new Entities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    //Eager Loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .ToList<T>();
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                List<T> list;
                using (var context = new Entities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    //Eager Loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .Where(where)
                        .ToList<T>();
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                T item = null;
                using (var context = new Entities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    //Eager Loading
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    item = dbQuery
                        .AsNoTracking()
                        .FirstOrDefault(where);
                }

                return item;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async virtual Task<int> Add(params T[] items)
        {
            try
            {
                using (var context = new Entities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Added;
                    }
                    return await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async virtual Task<int> Update(params T[] items)
        {
            try
            {
                using (var context = new Entities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }
                    return await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async virtual Task<int> Remove(params T[] items)
        {
            try
            {
                using (var context = new Entities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }
                    return await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
