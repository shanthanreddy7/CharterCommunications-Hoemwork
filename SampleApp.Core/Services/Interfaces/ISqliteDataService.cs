using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SampleApp.Core.Services.Interfaces
{
    public interface ISqliteDataService
    {
        void CreateTables();
        List<T> ReadList<T>() where T : new();
        int Insert(object value, Type type);
        int Update(object value, Type type);
        int InsertOrUpdate(object value, Type type);
        bool Delete<T>(object value);
        bool DeleteAll<T>();
        int Count<T>() where T : new();
        T ReadFirst<T>(Expression<Func<T, bool>> predicate) where T : new();
    }
}
