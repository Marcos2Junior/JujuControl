using JujuControl.Data.Models.dbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace JujuControl.Data
{
    public interface IJujuControl
    {
        ExceptionFull Add<T>(T entity);
        ExceptionFull Update<T>(T entity);
        ExceptionFull Delete<T>(T entity);
        Task<ExceptionFull> SaveChangesAsync();
        Task<List<T>> GetAllAsync<T>() where T : class;
        Task<List<T>> SearchAsync<T>(Expression<Func<T, bool>> where) where T : class;
        void Erro(ExceptionFull exception);
    }
}
