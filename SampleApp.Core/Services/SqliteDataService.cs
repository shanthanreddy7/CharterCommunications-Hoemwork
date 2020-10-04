using SampleApp.Core.Models;
using SampleApp.Core.Services.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SampleApp.Core.Services
{
    public abstract class SqliteDataService : ISqliteDataService
    {
        private static readonly object LockObject = new object();
        private SQLiteConnection _connection;
        public abstract void InitPlatform();
        public abstract string GetPlatformDatabasePath(string databaseName);
        public abstract void DeleteDatabaseFromPlatform(string filePath);

        protected SqliteDataService()
        {
            if (_connection != null)
                return;

            Initialize();
        }

        private void Initialize()
        {
            InitPlatform();
            //Create/Open the database
            string filePath = GetPlatformDatabasePath("localRepository.db");

            //Connect and then Test Database Encryption, Ensure the key is valid!
            try
            {
                //Connect to the Database
                var connectionString = new SQLiteConnectionString(filePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, true);
                _connection = new SQLiteConnection(connectionString);

                //TODO Delete
                //This will try to query the SQLite Schema Database, if the key is correct then no error is raised
                //_connection.Query<int>("SELECT count(*) FROM sqlite_master");
            }
            catch (SQLiteException)
            {
                //If Key is invalid for some reason, close the connection, and delete the database file
                _connection?.Dispose();
                _connection = null;
                DeleteDatabaseFromPlatform(filePath);
            }
        }

        public int Count<T>() where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().Count();
                }
                catch
                {
                    return 0;
                }
            }
        }

        public bool Delete<T>(object value)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.Delete<T>(value);

                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    // ignored
                }

                return false;
            }
        }

        public bool DeleteAll<T>()
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.DeleteAll<T>();

                    if (result > 0)
                    {
                        return true;
                    }
                }
                catch
                {
                    // ignored
                }

                return false;
            }
        }

        public int Insert(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.Insert(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public int InsertOrUpdate(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.InsertOrReplace(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public List<T> ReadList<T>() where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().ToList();
                }
                catch
                {
                    return null;
                }
            }
        }

        public int Update(object value, Type type)
        {
            lock (LockObject)
            {
                try
                {
                    int result = _connection.Update(value, type);

                    return result;
                }
                catch
                {
                    return -1;
                }
            }
        }

        public void CreateTables()
        {
            _connection.BeginTransaction();
            _connection.CreateTable<UserModel>();
        }

        public T ReadFirst<T>(Expression<Func<T, bool>> predicate) where T : new()
        {
            lock (LockObject)
            {
                try
                {
                    return _connection.Table<T>().Where(predicate).FirstOrDefault();
                }
                catch
                {
                    return default;
                }
            }
        }
    }
}
