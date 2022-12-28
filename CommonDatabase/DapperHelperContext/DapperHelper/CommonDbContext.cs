﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.DapperHelperContext.DapperHelper
{
    public class CommonDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public CommonDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CommonDbConnection");
        }

        public IDbConnection CreateConnection()
               => new SqlConnection(_connectionString);
    }
}
