using SampleApp.Core.Services;
using SQLitePCL;
using System;
using System.IO;
namespace SampleApp.Droid
{
    internal class AndroidSqliteDataService : SqliteDataService
    {
        public override void DeleteDatabaseFromPlatform(string filePath)
        {
            File.Delete(filePath);
        }

        public override string GetPlatformDatabasePath(string databaseName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, databaseName);
        }

        public override void InitPlatform()
        {
            raw.SetProvider(new SQLite3Provider_sqlcipher());
            raw.FreezeProvider();
        }
    }
}