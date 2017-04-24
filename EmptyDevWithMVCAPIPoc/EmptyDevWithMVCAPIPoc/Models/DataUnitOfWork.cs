using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Services.Description;

namespace EmptyDevWithMVCAPIPoc.Models
{
    public class DataUnitOfWork
    {
        private readonly EFContext _context;

    }

    public interface IRepository
    { 
        // Find an entity by its primary key 
        // We assume and enforce that every Entity 
        // is identified by an "Id" property of type long
        T Find<T>(long id) where T : EntityType; 

        // Query for a specific type of Entity 
        // with Linq expressions. More on this later 
        IQueryable<T> Query<T>();
        IQueryable<T> Query<T>(Expression<Func<T, bool>> where);

        // Basic operations on an Entity 
        void Delete(object target);
        void Save(object target);
        void Insert(object target);
        T[] GetAll<T>(); }
}