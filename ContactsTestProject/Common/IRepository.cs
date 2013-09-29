using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ContactsTestProject.Common
{
    /// <summary>
    /// IRepository Interface: a general repository pattern interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all T from the repository
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Find T  which applies the provided expression
        /// </summary>
        /// <param name="expression">The expression </param>
        /// <returns>IEnumerable of T</returns>
        IEnumerable<T> Find(Expression<Func<T, object>> expression);

        /// <summary>
        /// Add new T Object to the repository
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add(T t);
        
        /// <summary>
        /// Get T object by Primary key
        /// Id data type should be Int or Guid in real worl application, but here
        /// we made it String 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetById(String Id);

        /// <summary>
        /// Delete the specifed T object from the repository
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Delete(T t);

        /// <summary>
        /// Update T Object
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Update(T t);

    }
}
