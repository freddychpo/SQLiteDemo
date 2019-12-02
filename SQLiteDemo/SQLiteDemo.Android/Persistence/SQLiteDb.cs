//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
using SQLite;

using Android.App;
using Android.Content;  
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using SQLiteDemo.Persistence;
using System.IO;

[assembly: Dependency(typeof(SQLiteDemo.Droid.Persistence.SQLiteDb))]

namespace SQLiteDemo.Droid.Persistence
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var dbName = "MySQLite.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);  
            var path = System.IO.Path.Combine(dbPath, dbName);  
            var conn = new SQLite.SQLiteAsyncConnection(path);  
            return conn;  
        }
    }
}