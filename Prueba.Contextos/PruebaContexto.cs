using Prueba.Contextos.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Contextos
{
    public class PruebaContexto: IDisposable
    {
        public readonly SqlConnection Connection;
        public readonly SqlTransaction Transaction;

        public PruebaContexto(bool withTransaction = false)
        {
            try
            {
                Connection = new SqlConnection(AppSettings.pruebaConnection);
                Connection.Open();
                if (withTransaction) Transaction = Connection.BeginTransaction();
            }
            catch (Exception)
            {
                throw new Exception("Error al abrir la conexion.");
            }
        }

        public void Dispose()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
    }
}
