﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Repositorios.Common
{
    public class BaseRepositorio
    {
        private readonly SqlConnection _cn;
        private readonly SqlTransaction _trx;

        protected BaseRepositorio(SqlConnection connection)
        {
            _cn = connection;
        }

        protected BaseRepositorio(SqlConnection connection, SqlTransaction transaction)
        {
            _cn = connection;
            _trx = transaction;
        }

        protected SqlCommand CreateCommand()
        {
            SqlCommand cmd = _cn.CreateCommand();
            if (_trx != null) cmd.Transaction = _trx;
            return cmd;
        }
    }
}
