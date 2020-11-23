# XFWithSQLiteDb

## Implementing a Xamarin.Forms app with a SQLite database

A little demo on how to save data in a local SQLite databse with a Xamarin.Forms app. I have deployed and tested this demo on Android, iOS and Windows UWP environments. :) 

Microsoft Learn Docs: https://docs.microsoft.com/en-gb/learn/modules/store-local-data-with-sqlite/

SQLite github repo: https://github.com/praeclarum/sqlite-net

SQLite nuget: https://www.nuget.org/packages/sqlite-net-pcl

This is a simple Note taking app, where you can create, read, edit and delete notes. All the notes are saved in SQLite database, and CRUD operations executed on it.

A simple singleton service maintains the connecitity to the local SQLite database.

```csharp
public class DatabaseService
{
    public static readonly string DatabasePath 
        = Path.Combine(FileSystem.AppDataDirectory, $"{nameof(XFWithSQLiteDb)}.db3");

    private static readonly Lazy<SQLiteAsyncConnection> DatabaseConnectionHolder 
        = new Lazy<SQLiteAsyncConnection>(
            () => new SQLiteAsyncConnection(
                    DatabasePath, 
                    SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache));

    private static SQLiteAsyncConnection DatabaseConnection => DatabaseConnectionHolder.Value;

    ...
}
```

<img src="Screenshots/Notes List Page iOS.png" width="200" /> <img src="Screenshots/New Note Page iOS.png" width="200" /> 
