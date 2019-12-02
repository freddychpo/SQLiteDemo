using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLiteDemo.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }   
}
