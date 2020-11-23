using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XFWithSQLiteDb.Models;

namespace XFWithSQLiteDb.Services
{
    public class DatabaseService
    {
        public static readonly string DatabasePath = Path.Combine(FileSystem.AppDataDirectory, $"{nameof(XFWithSQLiteDb)}.db3");

        private static readonly Lazy<SQLiteAsyncConnection> DatabaseConnectionHolder = new Lazy<SQLiteAsyncConnection>(() => new SQLiteAsyncConnection(DatabasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache));

        private static SQLiteAsyncConnection DatabaseConnection => DatabaseConnectionHolder.Value;

        protected static async Task<SQLiteAsyncConnection> GetDatabaseConnection<T>() where T : class, new()
        {
            if (!DatabaseConnection.TableMappings.Any(x => x.MappedType.Name == typeof(T).Name))
            {
                await DatabaseConnection.EnableWriteAheadLoggingAsync();
                await DatabaseConnection.CreateTableAsync<T>();
            }

            return DatabaseConnection;
        }

        public static async Task<IList<Note>> GetAllNotes()
        {
            var databaseConnection = await GetDatabaseConnection<Note>();
            return await databaseConnection.Table<Note>().ToListAsync();
        }

        public static async Task<int> SaveNote(Note note)
        {
            var databaseConnection = await GetDatabaseConnection<Note>();
            return await databaseConnection.InsertOrReplaceAsync(note);
        }
    }
}
