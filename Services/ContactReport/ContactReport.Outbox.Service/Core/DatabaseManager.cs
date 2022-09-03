using Common.Global.Core;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Npgsql;

namespace ContactReport.Outbox.Service.Core
{
    public static class DatabaseManager
    {
        static IDbConnection _connection;

        static DatabaseManager()
        {
            _connection = new NpgsqlConnection(CoreConstants.contactDBconnectionString);
        }

        public static async Task<List<T>> GetListAsync<T>(string query)
        {
            if (_connection.State == ConnectionState.Closed) _connection.Open();
            var list = await _connection.QueryAsync<T>(query);
            return list.ToList();
        }

        public static async Task ExecuteAsync(string query)
        {
            if (_connection.State == ConnectionState.Closed) _connection.Open();
            await _connection.ExecuteAsync(query);
        }

        private static bool _readState = true;

        public static bool isReady()
        {
            return _readState;
        }

        public static  void setReadStateReady()
        {
            _readState = true;
        }

        public static void setReadStateBusy()
        {
            _readState = false;
        }

    }
}
