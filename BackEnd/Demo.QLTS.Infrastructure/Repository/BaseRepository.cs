﻿using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Demo.QLTS.Core.Entities;
using Demo.QLTS.Core.Interfaces.Repository;
using MongoDB.Driver;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    {
        #region Field
        protected readonly string _connectionString;
        #endregion

        #region Contructor
        public BaseRepository(IOptions<DemoQLTSDatabaseSettings> demoQLTSDatabaseSettings)
        {
            _connectionString = demoQLTSDatabaseSettings.Value.ConnectionString;
        }
        #endregion

        #region Method

        public virtual async Task<List<T>> QueryUsingStoredProcedure<T>(string storeName, object param)
        {
            Console.WriteLine($"ConnectionString: {_connectionString}");

            using (var connection = new MySqlConnection(_connectionString))
            {
                //Execute stored procedure and map the returned result to a Customer object  
                var res = await connection.QueryAsync<T>(storeName, param, commandType: CommandType.StoredProcedure);

                return res.ToList();
            }
        }

        public virtual async Task<int> ExecuteUsingStoredProcedure(string storeName, object param)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                //Execute stored procedure and map the returned result to a Customer object  
                var res = await connection.ExecuteAsync(storeName, param, commandType: CommandType.StoredProcedure);

                return res;
            }
        }
        #endregion
    }
}
